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
using System.Drawing.Imaging;

namespace PhotoViewer
{
    public partial class AlbumUC : UserControl
    {
        #region Static Methods/Attributes
        private static int albumDisplayed = -1;
        private static MainForm mainForm = null;
        private static FlowLayoutPanel pictureLayout = null;
        
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
                MessageBox.Show(Properties.Resources.NoAlbumDisplayed);
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

            if (path.Contains('\\') && Directory.Exists(path))
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
                this.path = Properties.Resources.Undefined;
                this.titleLabel.ResetText();
                this.title = path;
                this.titleLabel.Text = this.title;
                this.setThumbnailsPicture();
            }
        }

        public AlbumUC(string path, string title)
        {
            InitializeComponent();

            this.path = path;
            this.titleLabel.ResetText();
            this.title = title;
            this.titleLabel.Text = this.title;
            this.setThumbnailsPicture();
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

        public int getPictureId(PictureUC picture)
        {
            return pictures.IndexOf(picture);
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
                    if (mainForm.getSelectedAlbums().Contains(this))
                    {
                        mainForm.unSelectAlbum(this);
                    }
                    else
                    {
                        mainForm.selectAlbum(this);
                    }
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

        private void webView(object sender, EventArgs e)
        {
            mainForm.displayOnWeb(sender, e);
        }
        #endregion

        #region Control pictures
        public void addPicture(String file)
        {
            if (File.Exists(file) == false)
            {
                MessageBox.Show(Properties.Resources.FileNoExist);
                return;
            }

            PictureUC picture = new PictureUC(file, this);

            // Set the four first pictures in the picturebox on the AlbumUC
            if (pictures.Count <= 4)
            {
                switch (pictures.Count)
                {
                    case 4:
                        pictureBox4.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 3:
                        pictureBox3.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 2:
                        pictureBox2.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 1:
                        pictureBox1.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 0:
                        break;
                }
            }

            pictures.Add(picture);

            if (getIdDisplayedAlbum() >= 0)
            {
                pictureLayout.Controls.Add(picture);
            }
        }

        public void changePicturePosition(int index, PictureUC p)
        {
            pictures.Remove(p);
            pictures.Insert(index, p);

            for (int i = 0; i < pictures.Count; i++)
            {
                pictureLayout.Controls.SetChildIndex(pictures.ElementAt(i), i);
            }
        }

        public void deletePictures(List<PictureUC> list)
        {
            foreach (PictureUC p in list)
            {
                this.pictures.Remove(p);
                pictureLayout.Controls.Remove(p);
            }
        }

        public void deletePicture(PictureUC p)
        {
            this.pictures.Remove(p);
            pictureLayout.Controls.Remove(p);
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

            foreach (PictureUC picture in pictures)
            {
                if (picture.isLoad() == false)
                {
                    picture.loadPicture();
                }
                pictureLayout.Controls.Add(picture);
            }

            // Set the number of the album displayed
            albumDisplayed = mainForm.albums.IndexOf(this);
            mainForm.SetListviewNotVisible();
        }

        public void setThumbnailsPicture()
        {
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
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                PropertyItem date1 = p1.getDate();
                PropertyItem date2 = p2.getDate();

                if (date1 == null && date2 == null)
                {
                    return 0;
                }
                else if (date1 == null) 
                {
                    return -1;
                }
                else if (date2 == null)
                {
                    return 1;
                }
                else
                {
                    long tick1 = convertPropertyItemToDateTime(date1).Ticks;
                    long tick2 = convertPropertyItemToDateTime(date2).Ticks;
                    return (int) (tick1 - tick2);
                }
            }
            );

            refreshPicturesDisplay();
        }

        public DateTime convertPropertyItemToDateTime(PropertyItem item)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            string text = encoding.GetString(item.Value, 0, item.Len - 1);

            // Parse the date and time. 
            System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
            return DateTime.ParseExact(text, "yyyy:MM:d H:m:s", provider);
        }
        #endregion

        #region Drag&Drop
        private void AlbumUC_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.All);
            }
        }

        private void AlbumUC_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Contains("PhotoViewer.AlbumUC"))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void AlbumUC_DragDrop(object sender, DragEventArgs e)
        {
            AlbumUC album = e.Data.GetData(typeof(AlbumUC)) as AlbumUC;
            mainForm.changeAlbumPosition(mainForm.albums.IndexOf(this), album);
        }
        #endregion
    }
}
