using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PhotoViewer
{
    public partial class PictureUC : UserControl
    {
        private string title;
        private string path;
        private PropertyItem[] pictureProperties;
        public static int widthPictureUC = 150;
        public static int heightPictureUC = 180;
        public AlbumUC album;

        private static FlowLayoutPanel detailLayout = null;
        private static List<PictureUC> picturesSelected = new List<PictureUC> ();
        
        public PictureUC(string path, AlbumUC album)
        {
            InitializeComponent();

            this.album = album;
            this.path = path;

            this.pictureBox.Image = AlbumUC.ScaleImage(Image.FromFile(path), 100, 100);

            this.title = System.IO.Path.GetFileNameWithoutExtension(path);
            this.titleLabel.Text = this.title;

            this.pictureProperties = Image.FromFile(path).PropertyItems;
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
            if (Control.ModifierKeys == Keys.Shift)
            {
                PictureUC picStart = picturesSelected.Last();
                album.multiSelectPic(picStart, this);

            }
            else if (Control.ModifierKeys == Keys.Control)
            {
                selectPicture(this);
            }
            else
            {
                clearSelection();

                picturesSelected.Clear();
                selectPicture(this);
            }

            //Permet d'afficher les données EXIF de l'image une par une
            /*foreach (PropertyItem current_prop in pictureProperties)
            {
                ASCIIEncoding prop = new ASCIIEncoding();

                MessageBox.Show(prop.GetString(current_prop.Value));
            }*/
        }

        public PropertyItem[] GetPictureMetaData()
        {
            return pictureProperties;
        }

        public static List<PictureUC> getPicturesSelected () 
        {
            return PictureUC.picturesSelected;
        }

        public static void selectPicture(PictureUC p)
        {
            picturesSelected.Add(p);
            p.BackColor = Color.FromArgb(119,181,254);
        }

        public static void clearSelection() 
        {
            foreach (PictureUC p in picturesSelected)
            {
                p.BackColor = System.Drawing.SystemColors.ControlLight;
            }
            picturesSelected.Clear();
        }
    }
}
