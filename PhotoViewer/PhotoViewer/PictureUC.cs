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
        private int rate = 0;
        private string title;
        private string path;
        private PropertyItem[] pictureProperties;
        private AlbumUC album;
        
        public PictureUC(string path, AlbumUC album)
        {
            InitializeComponent();

            this.album = album;
            this.path = path;

            this.pictureBox.Image = AlbumUC.ScaleImage(Image.FromFile(path), 140, 135);

            this.title = System.IO.Path.GetFileNameWithoutExtension(path);
            this.titleLabel.Text = this.title;

            //this.pictureProperties = Image.FromFile(path).PropertyItems;
        }
        #endregion


        #region Getter/Setter
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

        public int getRate()
        {
            if (this.rate < 0 || this.rate > 5)
                return 0;

            return this.rate;
        }

        public PropertyItem[] GetPictureMetaData()
        {
            return pictureProperties;
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
                    selectPicture(this);
                }
                else
                {
                    clearSelection();
                    selectPicture(this);
                }

                AlbumUC.focusPictureLayout();

                //Permet d'afficher les données EXIF de l'image une par une
                /*foreach (PropertyItem current_prop in pictureProperties)
                {
                    ASCIIEncoding prop = new ASCIIEncoding();

                    MessageBox.Show(prop.GetString(current_prop.Value));
                }*/
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
