using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PhotoViewer
{
    public partial class AlbumUC : UserControl
    {
        private List<PictureUC> pictures = new List<PictureUC>();
        private string title;
        private string path;

        private static int albumDisplayed = -1;

        private static FlowLayoutPanel pictureLayout = null;

        public AlbumUC(string path)
        {
            InitializeComponent();

            this.path = path;
            this.titleLabel.ResetText();
            this.title = path.Split('\\').Last();
            this.titleLabel.Text = this.title;

            importPicturesFromAlbum();
        }

        public void importPicturesFromAlbum()
        {
            /* Search picture in directory and sub-directory */
            var ext = new List<string> { ".jpg", ".gif", ".png" };
            string[] files = Directory.GetFiles(this.path, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (ext.Contains(System.IO.Path.GetExtension(file).ToLower()))
                {
                    System.Diagnostics.Debug.WriteLine(file);
                    pictures.Add (new PictureUC(file, this));

                    System.Diagnostics.Debug.WriteLine("allo");
                }
            }

            /* Add the four first pictures in pictureBox for the directory */
            int nb_picture = pictures.Count;

            switch (nb_picture) 
            {
                case 3:
                    pictureBox1.Image = ScaleImage(Image.FromFile(pictures[0].getPath()), 50, 50);
                    pictureBox2.Image = ScaleImage(Image.FromFile(pictures[1].getPath()), 50, 50);
                    pictureBox3.Image = ScaleImage(Image.FromFile(pictures[2].getPath()), 50, 50);
                    break;

                case 2:
                    pictureBox1.Image = ScaleImage(Image.FromFile(pictures[0].getPath()), 50, 50);
                    pictureBox2.Image = ScaleImage(Image.FromFile(pictures[1].getPath()), 50, 50);
                    break;

                case 1:
                    pictureBox1.Image = ScaleImage(Image.FromFile(pictures[0].getPath()), 50, 50);
                    break;

                case 0:
                    break;

                default:
                    pictureBox1.Image = ScaleImage(Image.FromFile(pictures[0].getPath()), 50, 50);
                    pictureBox2.Image = ScaleImage(Image.FromFile(pictures[1].getPath()), 50, 50);
                    pictureBox3.Image = ScaleImage(Image.FromFile(pictures[2].getPath()), 50, 50);
                    pictureBox4.Image = ScaleImage(Image.FromFile(pictures[3].getPath()), 50, 50);
                    break;
            }
        }

        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }

        public string getTitle()
        {
            return this.title;
        }

        public string getPath()
        {
            return this.path;
        }

        // Display picture of the album into the layout in arg
        public void displayPictures()
        {
            if (albumDisplayed >= 0)
            {

                if (MainForm.albums.IndexOf(this) == albumDisplayed)
                {
                    return;
                }

                pictureLayout.Controls.Clear();
            }

            foreach (PictureUC img in pictures)
            {
                pictureLayout.Controls.Add(img);
            }

            // Set the number of the album displayed
            albumDisplayed = MainForm.albums.IndexOf(this);
        }

        public static void setAlbumLayout (FlowLayoutPanel layout) 
        {
            if (AlbumUC.pictureLayout == null)
            {
                AlbumUC.pictureLayout = layout;
            }
        }

        private void AlbumUC_Click(object sender, EventArgs e)
        {
            this.displayPictures();
        }
    }
}
