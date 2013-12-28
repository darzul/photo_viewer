using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class MainForm : Form
    {
        XmlAlbums xmlAlbums;
        public static List<AlbumUC> albums = new List<AlbumUC> ();

        public MainForm()
        {
            InitializeComponent();

            xmlAlbums = new XmlAlbums();

            // Set the minimal size for the detailLayout
            this.secondarySplitContainer.SplitterDistance = this.Height;

            PictureUC.setDetailLayout(this.detailFlowLayoutPanel);

            AlbumUC.setAlbumLayout(picturesFlowLayoutPanel);
        }

        private void createAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var album = new AlbumUC(dialog.SelectedPath.ToString());
                albums.Add(album);
                xmlAlbums.Add(album);
                albumsFlowLayoutPanel.Controls.Add(album);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlAlbums.WriteAll();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {   
            if (System.IO.File.Exists("albums.xml"))
            {
                xmlAlbums.ReadAll();

                if (xmlAlbums.albums.Count > 0)
                    foreach (AlbumUC album in xmlAlbums.albums)
                    {
                        albumsFlowLayoutPanel.Controls.Add(album);
                        albums.Add(album);
                    }
            }
        }

        private void picturesFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            foreach (PictureUC p in PictureUC.picturesSelected)
            {
                p.BackColor = Color.Gray;
            }
            PictureUC.picturesSelected.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureUC.picturesSelected.Clear();
            int idAlbum = AlbumUC.getAlbumSelected();
            
            if (idAlbum >= 0 && idAlbum <= albums.Count)
            {
                albums.ElementAt(idAlbum).selectAll();
            }
        }

        private void displayOnWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idAlbum = AlbumUC.getAlbumSelected();

            if (idAlbum == -1) {
                return;
            }
            AlbumUC album = albums.ElementAt(idAlbum);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML files (*.html)|*.html";
            dialog.Title = "Select the HTML";
            
            if (dialog.ShowDialog() == DialogResult.OK) 
            {
                String fileTitle = dialog.FileName;

                String htmlText = @"
                    <!DOCTYPE HTML>
                    <html>
                        <head>
                            <title>"+ album.getTitle() + @"</title>
                        <head>
                        <body>
                            <script>
                                " + Properties.Resources.jquery_1_10_2_min + @"
                                " + Properties.Resources.lightbox_2_6_min + @"
                            </script>
                            <style>
                                " + Properties.Resources.lightbox + @"
                                " + Properties.Resources.style + @"
                            </style>
                            <h1>" + album.getTitle() + @"</h1>
                ";

                foreach (PictureUC p in album.getPictures()) 
                {
                    htmlText += @"
                        <div class='container'>
                        <a href=" + p.getPath() + " data-lightbox=" + p.getTitle() + @">
                            <img class='cadre' src=" + p.getPath() + @">
                        </a>
                        </div>";
                }

                htmlText += @"
                        <body>
                    <html>
                ";
                File.WriteAllText(fileTitle, htmlText);

                System.Diagnostics.Process.Start(fileTitle);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idAlbum = AlbumUC.getAlbumSelected();

            System.Diagnostics.Debug.WriteLine(idAlbum);
            if (idAlbum < 0) 
            {
                return;
            }

            AlbumUC album = albums.ElementAt(idAlbum);
            album.deletePictures(PictureUC.picturesSelected);

            picturesFlowLayoutPanel.Refresh();

            System.Diagnostics.Debug.WriteLine("OK");
        }
	}
}
