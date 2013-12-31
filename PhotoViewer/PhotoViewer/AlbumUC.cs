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
        #region Static Methods/Attributes
        private static int albumDisplayed = -1;
        private static MainForm mainForm = null;
        private static FlowLayoutPanel pictureLayout = null;
        
        public AlbumUC(string path, string title)
        {
            InitializeComponent();

            this.path = path;
            this.titleLabel.ResetText();
            this.title = title;
            this.titleLabel.Text = this.title;
        }

        
        public static void setMainForm(MainForm mainForm)
        {
            AlbumUC.mainForm = mainForm;
        }

        public static void setPicturesLayout(FlowLayoutPanel layout)
        {
            if (AlbumUC.pictureLayout == null)
            {
                AlbumUC.pictureLayout = layout;
            }
        }

        public static int getIdDisplayedAlbum()
        {
            if (albumDisplayed < 0 || albumDisplayed > mainForm.albums.Count)
                return -1;

            return albumDisplayed;
        }

        public static AlbumUC getDisplayedAlbum()
        {
            if (albumDisplayed < 0 || albumDisplayed > mainForm.albums.Count)
            {
                MessageBox.Show("No album displayed");
                return null;
            }

            return mainForm.albums.ElementAt(albumDisplayed);
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

        public static void resetDisplayedAlbum()
        {
            albumDisplayed = -1;
        }

        public static void focusPictureLayout()
        {
            pictureLayout.Focus();
        }
        #endregion

        #region Constructor
        private List<PictureUC> pictures = new List<PictureUC>();
        private string title;
        private string path;

        public AlbumUC(string path)
        {
            InitializeComponent();

            if (Directory.Exists(path))
            {
                this.path = path;
                this.titleLabel.ResetText();
                this.title = path.Split('\\').Last();
                this.titleLabel.Text = this.title;

                importPicturesFromAlbum();
            }

            // Album fictif, le path est en fait le titre
            else
            {
                this.path = null;
                this.titleLabel.ResetText();
                this.title = path;
                this.titleLabel.Text = this.title;
            }

        }
        #endregion

        #region Getter/Setter
        private void setTitle(string newTitle)
        {
            this.title = newTitle;
            this.titleLabel.Text = this.title;
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

        public MainForm getMainForm()
        {
            return mainForm;
        }
        #endregion

        #region Events
        private void AlbumUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (mainForm.isSelected(this) == false)
                {
                    mainForm.clearAlbumSelection();
                    mainForm.selectAlbum(this);

                    this.displayPictures();
                    pictureLayout.Focus();
                }
                rightClickContextMenuStrip.Show(Cursor.Position);
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Left) 
            {
                if (Form.ModifierKeys == Keys.Control) 
                {
                    mainForm.selectAlbum(this);
                }
                else if (Form.ModifierKeys == Keys.Shift) 
                {
                    AlbumUC start = mainForm.getLastSelectedAlbum();
                    if (start == null)
                    {
                        mainForm.selectAlbum(this);
                    }

                    mainForm.multiSelectAlbums(start ,this);
                }
                else 
                {
                    mainForm.clearAlbumSelection();
                    mainForm.selectAlbum(this);

                    this.displayPictures();
                    mainForm.focusAlbumLayout();
                }
            }
        }

        private void delete(object sender, EventArgs e)
        {
            mainForm.removeSelectedAlbums();
        }

        private void rename(object sender, EventArgs e)
        {
            String newTitle = MainForm.ShowDialog("Enter the new album title", this.title);
            this.setTitle(newTitle);
        }
        #endregion

        #region Control pictures
        public void addPicture(String file)
        {
            PictureUC picture = new PictureUC(file, this);

            pictures.Add(picture);
            pictureLayout.Controls.Add(picture);
        }

        public void deletePictures(List<PictureUC> list)
        {
            foreach (PictureUC p in list)
            {
                this.pictures.Remove(p);
                pictureLayout.Controls.Remove(p);
            }
        }

        // Display picture of the album into the layout in arg
        public void displayPictures()
        {
            if (albumDisplayed >= 0)
            {

                if (mainForm.albums.IndexOf(this) == albumDisplayed)
                {
                    return;
                }

                PictureUC.clearSelection();
                pictureLayout.Controls.Clear();
            }

            foreach (PictureUC img in pictures)
            {
                pictureLayout.Controls.Add(img);
            }

            // Set the number of the album displayed
            albumDisplayed = mainForm.albums.IndexOf(this);
        }

        public void importPicturesFromAlbum()
        {
            /* Search picture in directory and sub-directory */
            string[] files = Directory.GetFiles(this.path, "*.*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (mainForm.isPicture(file))
                {
                    pictures.Add(new PictureUC(file, this));
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
        #endregion

        #region Selection methods
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

        public void selectAllPictures()
        {
            PictureUC.clearSelection();

            foreach (PictureUC p in pictures)
            {
                PictureUC.selectPicture(p);
            }
        }

        public void refreshPicturesDisplay () 
        {
            pictureLayout.Controls.Clear();
            foreach (PictureUC picture in pictures)
            {
                pictureLayout.Controls.Add(picture);
            }
        }
        #endregion

        #region Sort methods
        public void sortByTitle()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                return p1.getTitle().CompareTo(p2.getTitle());
            }
            );

            refreshPicturesDisplay();
        }

        public void sortByRate()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                return p1.getRate() - p2.getRate();
            }
            );

            refreshPicturesDisplay();
        }

        public void sortByDate()
        {
        }
        #endregion

        private void webView(object sender, EventArgs e)
        {
            mainForm.displayOnWeb(sender, e);
        }
    }
}
