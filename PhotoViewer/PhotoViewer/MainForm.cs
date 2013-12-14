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
	}
}
