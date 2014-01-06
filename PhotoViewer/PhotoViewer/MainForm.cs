using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PhotoViewer
{
    public partial class MainForm : Form
    {
        #region Constructor
        XmlAlbums xmlAlbums;
        XmlConfig xmlConfig;
        private List<AlbumUC> albumsSelected = new List<AlbumUC>();
        public List<AlbumUC> albums;
        public List<String> extensions = new List<string> { "png", "jpg", "gif" };

        // Total screen's size
        public static int maxWidth = Screen.PrimaryScreen.Bounds.Width;
        public static int maxHeight = Screen.PrimaryScreen.Bounds.Height;

        // Screen's size without task bar
        public static int workAreaWidth = Screen.PrimaryScreen.WorkingArea.Width;
        public static int workAreaHeight = Screen.PrimaryScreen.WorkingArea.Height;

        public MainForm()
        {
            InitializeComponent();

            xmlAlbums = new XmlAlbums();
            xmlConfig = new XmlConfig();

            PictureUC.setDetailLayout(this.detailFlowLayoutPanel);

            AlbumUC.setPicturesLayout(picturesFlowLayoutPanel);
            AlbumUC.setMainForm(this);
        }
        #endregion

        #region Albums management
        /// <summary>
        /// Create album from existing folder 
        /// </summary>
        public void createAlbumFromFolder()
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

        /// <summary>
        /// Create album from existing folder
        /// </summary>
        /// <param name="folder">Absolute path of the folder</param>
        public void createAlbumFromFolder(String folder)
        {
            var album = new AlbumUC(folder);
            albums.Add(album);
            albumsFlowLayoutPanel.Controls.Add(album);
        }

        /// <summary>
        /// Create album with only a title
        /// </summary>
        private void createEmptyAlbum()
        {
            createAlbumFromFolder(ShowDialog(Properties.Resources.TapeTheAlbumsTitle, ""));
        }

        /// <summary>
        /// Refresh controls album in controlflowlayout
        /// </summary>
        public void refreshAlbums()
        {
            albumsFlowLayoutPanel.Controls.Clear();

            foreach (AlbumUC album in albums)
            {
                albumsFlowLayoutPanel.Controls.Add(album);
            }
        }

        /// <summary>
        /// Change the position of an album in list albums and his id in the controlflowlayout
        /// </summary>
        /// <param name="index">Futur index of your album</param>
        /// <param name="album">Your moved album</param>
        public void changeAlbumPosition(int index, AlbumUC album)
        {
            albums.Remove(album);
            albums.Insert(index, album);

            for (int i = 0; i < albums.Count; i++)
            {
                albumsFlowLayoutPanel.Controls.SetChildIndex(albums.ElementAt(i), i);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Albums which are in the selected albums list</returns>
        public List<AlbumUC> getSelectedAlbums()
        {
            return albumsSelected;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Last album which has been selected</returns>
        public AlbumUC getLastSelectedAlbum()
        {
            if (albumsSelected.Count == 0) 
            {
                return null;
            }

            return albumsSelected.Last();
        }

        /// <summary>
        /// Select the album in the parameter
        /// </summary>
        /// <param name="album">The album you want to select</param>
        public void selectAlbum(AlbumUC album)
        {
            album.BackColor = Color.FromArgb(119, 181, 254);
            albumsSelected.Add(album);
        }

        /// <summary>
        /// Select all album between the two albums in parameter
        /// </summary>
        /// <param name="start">You first album</param>
        /// <param name="end">Your second album</param>
        public void multiSelectAlbums(AlbumUC start, AlbumUC end)
        {
            int startId = albums.IndexOf(start);
            int endId = albums.IndexOf(end);

            if (startId > endId)
            {
                int tmp = startId;
                startId = endId;
                endId = tmp;
            }

            for (; startId <= endId; startId++)
            {
                selectAlbum(albums.ElementAt(startId));
            }
        }

        /// <summary>
        /// Select all albums in the controlflowlayout
        /// </summary>
        public void selectAllAlbums()
        {
            foreach (AlbumUC album in albums)
                selectAlbum(album);
        }

        /// <summary>
        /// Check if the album is in the selected album list
        /// </summary>
        /// <param name="album">Album you want to check</param>
        /// <returns></returns>
        public bool isSelected(AlbumUC album)
        {
            if (albumsSelected.Contains(album))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Unselect an Album
        /// </summary>
        /// <param name="album">The album you want to unselect</param>
        public void unSelectAlbum(AlbumUC album)
        {
            albumsSelected.Remove(album);
            album.BackColor = System.Drawing.SystemColors.ControlLight;
        }

        /// <summary>
        /// Reset the album selection
        /// </summary>
        public void clearAlbumSelection() 
        {
            if (albumsSelected.Count == 0)
            {
                return;
            }

            foreach (AlbumUC album in albumsSelected)
            {
                album.BackColor = System.Drawing.SystemColors.ControlLight;
            }

            albumsSelected.Clear();
        }

        /// <summary>
        /// Delete all selected album
        /// </summary>
        public void removeSelectedAlbums()
        {
            if (albumsSelected.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show(Properties.Resources.NoAlbumSelected);
                return;
            }

            AlbumUC.resetDisplayedAlbum();

            foreach (AlbumUC album in albumsSelected)
            {
                albums.Remove(album);
                albumsFlowLayoutPanel.Controls.Remove(album);
            }
        }

        /// <summary>
        /// Remove selected pictures
        /// </summary>
        public void removeSelectedPictures()
        {
            if (PictureUC.getPicturesSelected().Count <= 0)
            {
                return;
            }

            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.deletePictures(PictureUC.getPicturesSelected());

            PictureUC.clearSelection();
        }

        /// <summary>
        /// Check if the file is a picture
        /// </summary>
        /// <param name="file">Path of the file</param>
        /// <returns>True is the file is a picture</returns>
        public bool isPicture(String file)
        {
            String extension = file.Split('.').Last().ToLower();

            if (extensions.Contains(extension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Set the focus on controlflowlayout
        /// </summary>
        public void focusAlbumLayout()
        {
            albumsFlowLayoutPanel.Focus();
        }
        #endregion

        #region Events
        private void createEmptyAlbum(object sender, EventArgs e)
        {
            createEmptyAlbum();
        }

        private void createAlbumFromFolder(object sender, EventArgs e)
        {
            createAlbumFromFolder();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlAlbums.setAlbums (albums);
            xmlAlbums.WriteAll();

            xmlConfig.MainForm_Height = this.Size.Height;
            xmlConfig.MainForm_Width = this.Size.Width;
            xmlConfig.MainForm_PositionX = this.Location.X;
            xmlConfig.MainForm_PositionY = this.Location.Y;
            xmlConfig.writeConfig();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(System.IO.File.Exists(Properties.Resources.AlbumXmlFile))
                xmlAlbums.ReadAll();

            List<AlbumUC> albums = xmlAlbums.getAlbums();
            
            if (albums.Count > 0)
            {
                this.albums = albums;
            }
            else
            {
                this.albums = new List<AlbumUC>();
            }

            refreshAlbums();

            xmlConfig = xmlConfig.readConfig();

            if (xmlConfig.MainForm_Height <= 0 || xmlConfig.MainForm_Width <= 0)
            {
                //MessageBox.Show("In size " + xmlConfig.MainForm_Height.ToString());

            }
            else
            {
                this.Size = new Size(workAreaWidth, workAreaHeight);
            }

            if (xmlConfig.MainForm_PositionX <= 0 && xmlConfig.MainForm_PositionY <= 0)
            {
                //MessageBox.Show("In " + xmlConfig.MainForm_PositionX.ToString());

            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
            }
        }

        private void picturesFlowLayoutPanel_Click(object sender, EventArgs e)
        {
            PictureUC.clearSelection();
        }

        private void selectAllPictures(object sender, EventArgs e)
        {
            PictureUC.clearSelection();

            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.selectAllPictures();
        }

        /// <summary>
        /// Generate a html file with the picture of your album
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void displayOnWeb(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "HTML files (*.html)|*.html";
            dialog.Title = "Select the HTML";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String fileTitle = dialog.FileName;

                String htmlText = @"
                    <!DOCTYPE HTML>
                    <html>
                        <head>
                            <title>" + album.getTitle() + @"</title>
                        <head>
                        <body>
                            <script>
                                " + Properties.Resources.jquery_1_10_2_min + @"
                                " + Properties.Resources.lightbox_2_6_min + @"
                            </script>
                            <style>
                                " + Properties.Resources.lightbox + @"
                                " + Properties.Resources.style + @"
                            </style>
                            <h1>" + album.getTitle() + @"</h1>
                ";

                foreach (PictureUC p in album.getPictures())
                {
                    htmlText += @"
                        <div class='container'>
                        <a href='" + p.getPath() + "' data-lightbox='" + p.getTitle() + @"'>
                            <img class='cadre' src='" + p.getPath() + @"'>
                        </a>
                        </div>";
                }

                htmlText += @"
                        <body>
                    <html>
                ";
                File.WriteAllText(fileTitle, htmlText);

                System.Diagnostics.Process.Start(fileTitle);
            }
        }

        private void removePicture(object sender, EventArgs e)
        {
            removeSelectedPictures();
        }

        private void addPictures(object sender, EventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in dialog.FileNames)
                {
                    AlbumUC album = AlbumUC.getDisplayedAlbum();
                    if (album == null)
                        return;

                    album.addPicture(file);
                }
            }
        }

        private void picturesFlowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            picturesFlowLayoutPanel.Focus();
        }


        private void removeAlbum(object sender, EventArgs e)
        {
            this.removeSelectedAlbums();
        }

        private void albumsFlowLayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            focusAlbumLayout();
            clearAlbumSelection();
        }

        private void sortByDate(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByDate();
        }

        private void sortByDateDesc(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByDateDesc();
        }

        private void sortByRate(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByRate();
        }

        private void sortByRateDesc(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByRateDesc();
        }

        private void sortByTitle(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByTitle();
        }

        private void sortByTitleDesc(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByTitleDesc();
        }

        private void showDiaporamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.getSelectedAlbums().Count > 0)
                    foreach (AlbumUC album in this.getSelectedAlbums())
                    {
                        Diaporama diaporama = new Diaporama(album);
                        diaporama.Show();
                        diaporama.StartDiaporama();
                    }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        #endregion

        #region Static Methods
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.Text = caption;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = caption };
            Button confirmation = new Button() { Text = "Ok", Left = 200, Width = 100, Top = 80 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            textBox.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    prompt.Close();
                }
            };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);

            prompt.ActiveControl = textBox;
            textBox.SelectAll();

            prompt.ShowDialog();

            return textBox.Text;
        }
        #endregion

        #region Drag and Drop
        private void picturesFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                AlbumUC album = AlbumUC.getDisplayedAlbum();
                if (album == null)
                    return;

                string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string file in filePaths)
                {
                    if (File.Exists(file) && isPicture (file))
                    {
                        album.addPicture(file);
                    }
                }
            }
        }

        private void flowLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void albumsFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] folderPaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                foreach (string folder in folderPaths)
                {
                    if (Directory.Exists(folder))
                    {
                        createAlbumFromFolder(folder);
                    }
                }
            }
        }
        #endregion

   }
}
