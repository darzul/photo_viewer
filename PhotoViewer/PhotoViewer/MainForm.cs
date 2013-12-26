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
        AlbumUC AlbumUC2;
        AlbumUC AlbumUC3;
        AlbumUC currentAlbumPrinted = null;
        XmlAlbums xmlAlbums;
        public static List<AlbumUC> albums = new List<AlbumUC> ();

        public MainForm()
        {
            InitializeComponent();

            xmlAlbums = new XmlAlbums();

            this.AlbumUC2 = new AlbumUC("C:\\Users\\Dev\\Pictures");
            albumsFlowLayoutPanel.Controls.Add(AlbumUC2);
            xmlAlbums.Add(AlbumUC2);

            this.AlbumUC3 = new AlbumUC("C:\\Users\\Dev\\Pictures");
            //this.AlbumUC3.Click += displayPictures;
            albumsFlowLayoutPanel.Controls.Add(this.AlbumUC3);
            xmlAlbums.Add(AlbumUC3);

            //if(xmlAlbums.readAll().Equals(xmlAlbums.albums)) MessageBox.Show("ça marche !");

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
                albumsFlowLayoutPanel.Controls.Add(album);
            }
        }

        private bool needDisplayvScrollBar ()
        {
            //picturesFlowLayoutPanel.get
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Lancer le diapo
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlAlbums.WriteAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            xmlAlbums.readAll();
        }
	}
}
