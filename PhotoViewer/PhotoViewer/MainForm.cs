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

            /* A supprimer */
            AlbumUC tmp = new AlbumUC("C:\\Users\\Guillaume\\Pictures");
            albums.Add(tmp);
            albumsFlowLayoutPanel.Controls.Add(tmp);
            /***************/
        }

        private void createAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var album = new AlbumUC(dialog.SelectedPath.ToString());
                albums.Add(album);
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
                xmlAlbums.readAll();
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

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Key down");

            if (e.Control && e.KeyCode == Keys.A) {


            }
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
                        <a class='container' href=" + p.getPath() + " data-lightbox=" + p.getTitle() + @">
                            <img class='cadre' src=" + p.getPath() + @">
                        </a>";
                }

                htmlText += @"
                        <body>
                    <html>
                ";
                File.WriteAllText(fileTitle, htmlText);
            }
        }
	}
}
