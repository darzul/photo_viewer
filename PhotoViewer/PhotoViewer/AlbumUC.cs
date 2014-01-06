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

        /// <summary>
        /// Define the flowlayoutpanel
        /// </summary>
        /// <param name="layout">Reference of flowlayoutpanel</param>
        public static void setPicturesLayout(FlowLayoutPanel layout)
        {
            if (AlbumUC.pictureLayout == null)
            {
                AlbumUC.pictureLayout = layout;
            }
        }

        /// <summary>
        /// Give the ID of the displayed album
        /// </summary>
        /// <returns>Id</returns>
        public static int getIdDisplayedAlbum()
        {
            if (albumDisplayed < 0 || albumDisplayed > mainForm.albums.Count)
                return -1;

            return albumDisplayed;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return the AlbumUC currently displayed</returns>
        public static AlbumUC getDisplayedAlbum()
        {
            if (albumDisplayed < 0 || albumDisplayed > mainForm.albums.Count)
            {
                MessageBox.Show(Properties.Resources.NoAlbumDisplayed);
                return null;
            }

            return mainForm.albums.ElementAt(albumDisplayed);
        }

        /// <summary>
        /// Resize picture to maximum dimension with the same ratio width/height
        /// </summary>
        /// <param name="image">Picture to resize</param>
        /// <param name="maxWidth">Max width picture</param>
        /// <param name="maxHeight">Max height picture</param>
        /// <returns>Picture resized</returns>
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

        /// <summary>
        /// Set album displayed to -1 (No album display)
        /// </summary>
        public static void resetDisplayedAlbum()
        {
            albumDisplayed = -1;
        }

        /// <summary>
        /// Give the focus to picture flowlayoutpanel
        /// </summary>
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

            // Fictif album, the path is the title
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

                getPictures().ElementAt(0).getDetailLayout().Controls.Clear();
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
        /// <summary>
        /// Add picture to this album
        /// </summary>
        /// <param name="file">path of the picture</param>
        public void addPicture(String file)
        {
            if (File.Exists(file) == false)
            {
                MessageBox.Show(file +" "+ Properties.Resources.FileNoExist);
                return;
            }

            PictureUC picture = new PictureUC(file, this);

            // Set the four first pictures in the picturebox on the AlbumUC
            if (pictures.Count <= 4)
            {
                switch (pictures.Count)
                {
                    case 3:
                        pictureBox4.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 2:
                        pictureBox3.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 1:
                        pictureBox2.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;

                    case 0:
                        pictureBox1.Image = ScaleImage(Image.FromFile(file), 50, 50);
                        break;
                }
            }

            pictures.Add(picture);

            if (getIdDisplayedAlbum() >= 0)
            {
                pictureLayout.Controls.Add(picture);
            }
        }

        /// <summary>
        /// Change the position of one picture
        /// </summary>
        /// <param name="index">Ne index for the picture</param>
        /// <param name="p">The PictureUC to change</param>
        public void changePicturePosition(int index, PictureUC p)
        {
            pictures.Remove(p);
            pictures.Insert(index, p);

            for (int i = 0; i < pictures.Count; i++)
            {
                pictureLayout.Controls.SetChildIndex(pictures.ElementAt(i), i);
            }
        }

        /// <summary>
        /// Delete the picture in the list
        /// </summary>
        /// <param name="list">List of pictures will be delete</param>
        public void deletePictures(List<PictureUC> list)
        {
            foreach (PictureUC p in list)
            {
                this.pictures.Remove(p);
                pictureLayout.Controls.Remove(p);
            }
        }

        /// <summary>
        /// Delete one picture
        /// </summary>
        /// <param name="p">The picture to delete</param>
        public void deletePicture(PictureUC p)
        {
            this.pictures.Remove(p);
            pictureLayout.Controls.Remove(p);
        }

        /// <summary>
        /// Display the picture of the album in picture flowlayoutpanel
        /// </summary>
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
        }

        /// <summary>
        /// Print the four first picture of the Album in the picturebox
        /// </summary>
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
        /// <summary>
        /// Search all picture in a directory and add them into this album
        /// </summary>
        public void importPicturesFromAlbum()
        {
            if (!Directory.Exists(this.path))
                return;

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

        /// <summary>
        /// Select picture between picStart and picEnd
        /// </summary>
        /// <param name="picStart">Picture one</param>
        /// <param name="picEnd">Picture two</param>
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

        /// <summary>
        /// Select all pictures in the album
        /// </summary>
        public void selectAllPictures()
        {
            PictureUC.clearSelection();

            foreach (PictureUC p in pictures)
            {
                PictureUC.selectPicture(p);
            }
        }

        /// <summary>
        /// Refresh the controls of each picture display in flowlayoutpanel picture
        /// </summary>
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
        /// <summary>
        /// Sort by title alphabetically
        /// </summary>
        public void sortByTitle()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                return p1.getTitle().CompareTo(p2.getTitle());
            }
            );

            refreshPicturesDisplay();
        }

        /// <summary>
        /// Sort by Title desc-alphabetically
        /// </summary>
        public void sortByTitleDesc()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                return p2.getTitle().CompareTo(p1.getTitle());
            }
            );

            refreshPicturesDisplay();
        }

        /// <summary>
        /// Sort by rate
        /// </summary>
        public void sortByRate()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                return p2.getRate() - p1.getRate();
            }
            );

            refreshPicturesDisplay();
        }

        /// <summary>
        /// Sort by desc-rate
        /// </summary>
        public void sortByRateDesc()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                return p1.getRate() - p2.getRate();
            }
            );

            refreshPicturesDisplay();
        }

        /// <summary>
        /// Sort by date of shooting
        /// </summary>
        public void sortByDate()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                if (p1.getTicksDate() == 0 && p2.getTicksDate() == 0)
                {
                    return 0;
                }
                else if (p1.getTicksDate() == 0)
                {
                    return 1;
                }
                else if (p2.getTicksDate() == 0)
                {
                    return -1;
                }

                return (int)(p2.getTicksDate() - p1.getTicksDate());
            }
            );

            refreshPicturesDisplay();
        }

        /// <summary>
        /// Sort by date of shooting descending
        /// </summary>
        public void sortByDateDesc()
        {
            pictures.Sort(delegate(PictureUC p1, PictureUC p2)
            {
                if (p1.getTicksDate() == 0 && p2.getTicksDate() == 0)
                {
                    return 0;
                }
                else if (p1.getTicksDate() == 0)
                {
                    return -1;
                }
                else if (p2.getTicksDate() == 0)
                {
                    return 1;
                }

                return (int) (p1.getTicksDate() - p2.getTicksDate());
            }
            );

            refreshPicturesDisplay();
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
