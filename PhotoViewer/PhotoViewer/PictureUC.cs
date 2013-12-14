using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class PictureUC : UserControl
    {
        private string title;
        private string path;
        public static int widthPictureUC = 150;
        public static int heightPictureUC = 180;
        public AlbumUC album;

        private static FlowLayoutPanel detailLayout = null;
        
        public PictureUC(string path, AlbumUC album)
        {
            InitializeComponent();

            this.album = album;
            this.path = path;

            this.pictureBox.Image = AlbumUC.ScaleImage(Image.FromFile(path), 100, 100);

            this.title = System.IO.Path.GetFileNameWithoutExtension(path);
            this.titleLabel.Text = this.title;
        }

        public string getTitle()
        {
            return this.title;
        }

        public string getPath () {
            return this.path;
        }

        public static void setDetailLayout(FlowLayoutPanel layout)
        {
            PictureUC.detailLayout = layout;
        }

        private void PictureUC_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;

            
        }
    }
}
