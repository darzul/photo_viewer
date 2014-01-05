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
        #region Static Methods/Attributes
        public static int widthPictureUC = 150;
        public static int heightPictureUC = 180;

        private static FlowLayoutPanel detailLayout = null;
        private static List<PictureUC> picturesSelected = new List<PictureUC>();

        public static void setDetailLayout(FlowLayoutPanel layout)
        {
            PictureUC.detailLayout = layout;
        }

        public static List<PictureUC> getPicturesSelected()
        {
            return PictureUC.picturesSelected;
        }

        public static void unSelectPicture(PictureUC p)
        {
            picturesSelected.Remove(p);
            p.BackColor = System.Drawing.SystemColors.ControlLight;
        }

        public static void selectPicture(PictureUC p)
        {
            picturesSelected.Add(p);
            p.BackColor = Color.FromArgb(119, 181, 254);
        }

        public static void clearSelection()
        {
            foreach (PictureUC p in picturesSelected)
            {
                p.BackColor = System.Drawing.SystemColors.ControlLight;
            }
            picturesSelected.Clear();
        }
        #endregion

        #region Constructor and attributes
        private int rate = -1 ;
        private List<RatingStarsUC> rating_stars = new List<RatingStarsUC>();
        private string title;
        private string path;
        private AlbumUC album;
        
        public PictureUC(string path, AlbumUC album)
        {
            InitializeComponent();

            this.album = album;
            this.path = path;

            this.pictureBox.Image = AlbumUC.ScaleImage(Image.FromFile(path), 140, 135);

            this.title = System.IO.Path.GetFileNameWithoutExtension(path);
            this.titleLabel.Text = this.title;
        }
        #endregion


        #region Getter/Setter

        public void loadPicture()
        {
            Image img = Image.FromFile(this.path);
            this.pictureBox.Image = AlbumUC.ScaleImage(img, 140, 135);
            //this.pictureProperties = img.PropertyItems;
        }

        public bool isLoad()
        {
            if (this.pictureBox.Image == null)
                return false;

            return true;
        }

        private void setTitle(String newTitle)
        {
            this.title = newTitle;
            this.titleLabel.Text = newTitle;
        }
        public string getTitle()
        {
            return this.title;
        }

        public string getPath()
        {
            return this.path;
        }

        public PropertyItem getDate () 
        {
            try
            {
                PropertyItem item = this.pictureBox.Image.PropertyItems[36867];
                return item;
            }
            catch (Exception e) 
            {
                return null;
            }
        }

        public int getRate()
        {
            if (this.rate < 0 || this.rate > 5)
                return -1;

            return this.rate ;
        }

        public void setRate(int rate)
        {
            this.rate = rate;
        }

        public string getExifWidth()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(256).Value);
        }

        public string getExifHeight()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;

            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(257).Value);
        }

        public string getExifTitle()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(270).Value);
        }

        public string getExifCamera()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(271).Value);
        }

        public string getExifModel()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(272).Value);
        }

        public string getExifCreationDate()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(306).Value);
        }

        public string getExifAuthor()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(315).Value);
        }

        public string getExifCopyright()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(33432).Value);
        }

        public string getExifVersion()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(36864).Value);
        }

        public string getExifDateOfShooting()
        {
            PropertyItem[] pictureProperties;
            pictureProperties = Image.FromFile(path).PropertyItems;
            ASCIIEncoding prop = new ASCIIEncoding();

            return prop.GetString(pictureProperties.ElementAt(36867).Value);
        }
        #endregion

        #region Events
        private void PictureUC_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (picturesSelected.Contains(this) == false)
                {
                    clearSelection();
                    selectPicture(this);
                }
                rightClickContextMenuStrip.Show(Cursor.Position);
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    if (picturesSelected.Count == 0)
                    {
                        selectPicture(this);
                    }

                    PictureUC picStart = picturesSelected.Last();
                    album.multiSelectPic(picStart, this);

                }
                else if (Control.ModifierKeys == Keys.Control)
                {
                    if (picturesSelected.Contains(this))
                    {
                        unSelectPicture(this);
                    }
                    else
                    {
                        selectPicture(this);
                    }
                }
                else
                {
                    clearSelection();
                    selectPicture(this);
                }

                AlbumUC.focusPictureLayout();
                detailLayout.Controls.Clear();
                
                PropertyItem[] pictureProperties;
                pictureProperties = Image.FromFile(path).PropertyItems;
                foreach (PropertyItem current_prop in pictureProperties)
                {
                    ExifDataUC data = new ExifDataUC(current_prop);

                    detailLayout.Controls.Add(data);
                }

                ExifDataUC path_property = new ExifDataUC("Path", getPath());
                detailLayout.Controls.Add(path_property);

                Image current_picture = Image.FromFile(getPath());
                ExifDataUC size_property = new ExifDataUC("Size", current_picture.Width.ToString() + "x" + current_picture.Height.ToString());
                detailLayout.Controls.Add(size_property);

                if (rating_stars.Count == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        RatingStarsUC star = new RatingStarsUC(this);

                        if (i < rate)
                        {
                            star.status = RatingStarsUC.starStatus.clicked;
                        }
                        detailLayout.Controls.Add(star);
                        rating_stars.Add(star);
                    }
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < rate)
                        {
                            rating_stars.ElementAt(i).status = RatingStarsUC.starStatus.clicked;
                        }

                        detailLayout.Controls.Add(rating_stars.ElementAt(i));
                    }
                }
            }
        }

        private void rename(object sender, EventArgs e)
        {
            String newTitle = MainForm.ShowDialog("Rename your picture", this.title);
            setTitle(newTitle);
        }

        private void delete(object sender, EventArgs e)
        {
            MainForm mainForm = album.getMainForm();
            mainForm.removeSelectedPictures();
        }
        #endregion

        #region Drag&Drop
        private void PictureUC_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.DoDragDrop(this, DragDropEffects.All);
            }
        }

        private void PictureUC_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetFormats().Contains("PhotoViewer.PictureUC"))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureUC_DragDrop(object sender, DragEventArgs e)
        {
            PictureUC picture = e.Data.GetData(typeof(PictureUC)) as PictureUC;
            album.changePicturePosition(album.getPictureId(this) ,picture);
        }
        #endregion
    }
}
