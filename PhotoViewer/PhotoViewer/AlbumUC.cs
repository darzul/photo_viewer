﻿using System;
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

        public AlbumUC(string path, string title)
        {
            InitializeComponent();

            this.path = path;
            this.titleLabel.ResetText();
            this.title = title;
            this.titleLabel.Text = this.title;
        }

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
                    pictures.Add (new PictureUC(file, this));
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

        public List<PictureUC> getPictures()
        {
            return this.pictures;
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

                AlbumUC old = MainForm.albums.ElementAt(albumDisplayed);
                old.BackColor = System.Drawing.SystemColors.ControlLight;

                PictureUC.clearSelection();
                pictureLayout.Controls.Clear();
            }

            foreach (PictureUC img in pictures)
            {
                pictureLayout.Controls.Add(img);
            }

            // Set the number of the album displayed
            albumDisplayed = MainForm.albums.IndexOf(this);

            this.BackColor = Color.FromArgb(119, 181, 254);
        }

        public static void refreshDisplay()
        {
            pictureLayout.Controls.Clear();
            AlbumUC album = MainForm.albums.ElementAt(albumDisplayed);
            List <PictureUC> pictures = album.pictures;

            foreach (PictureUC img in pictures)
            {
                pictureLayout.Controls.Add(img);
            }
        }

        public static void setAlbumLayout (FlowLayoutPanel layout) 
        {
            if (AlbumUC.pictureLayout == null)
            {
                AlbumUC.pictureLayout = layout;
            }
        }

        public static int getAlbumSelected () 
        {
            return albumDisplayed;
        }

        private void AlbumUC_Click(object sender, EventArgs e)
        {
            this.displayPictures();
            pictureLayout.Focus();
        }

        public void multiSelectPic(PictureUC picStart, PictureUC picEnd)
        {
                
            int indexStart = this.pictures.IndexOf(picStart);
            int indexEnd = this.pictures.IndexOf(picEnd);

            if (indexStart > indexEnd)
            {
                int tmp = indexStart;
                indexStart = indexEnd;
                indexEnd = tmp;
            }
            PictureUC p;

            for (; indexStart <= indexEnd; indexStart++)
            {
                p = this.pictures.ElementAt(indexStart);
                PictureUC.selectPicture(p);
            }
        }

        public void selectAll()
        {
            PictureUC.clearSelection();

            foreach (PictureUC p in pictures)
            {
                PictureUC.selectPicture(p);
            }
        }

        public void addPicture(String file)
        {
            pictures.Add(new PictureUC (file, this));
        }

        public void deletePictures (List <PictureUC> list) 
        {
            foreach (PictureUC p in list)
            {
                this.pictures.Remove(p);
            }

            pictureLayout.Controls.Clear();

            refreshDisplay();
        }

        public static void resetSelectedAlbum()
        {
            albumDisplayed = -1;
        }
    }
}
