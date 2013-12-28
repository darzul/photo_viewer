using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                        albumsFlowLayoutPanel.Controls.Add(album);
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
            System.Diagnostics.Debug.WriteLine(idAlbum);
            
            if (idAlbum >= 0 && idAlbum <= albums.Count)
            {
                albums.ElementAt(idAlbum).selectAll();
            }
        }
	}
}
