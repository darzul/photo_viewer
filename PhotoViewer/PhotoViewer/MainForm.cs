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

namespace PhotoViewer
{
    public partial class MainForm : Form
    {
        #region Constrcutor
        XmlAlbums xmlAlbums;
        private List<AlbumUC> albumsSelected = new List<AlbumUC>();
        public List<AlbumUC> albums = new List<AlbumUC>();
        public List<String> extensions = new List<string> { "png", "jpg", "gif" };

        public MainForm()
        {
            InitializeComponent();

            xmlAlbums = new XmlAlbums();

            // Set the minimal size for the detailLayout
            this.secondarySplitContainer.SplitterDistance = this.Height;

            PictureUC.setDetailLayout(this.detailFlowLayoutPanel);

            AlbumUC.setPicturesLayout(picturesFlowLayoutPanel);
            AlbumUC.setMainForm(this);
        }
        #endregion

        #region Albums management
        public void createAlbumFromFolder()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                var album = new AlbumUC(dialog.SelectedPath.ToString());
                albums.Add(album);
                xmlAlbums.Add(album);
                albumsFlowLayoutPanel.Controls.Add(album);
            }
        }

        public void createAlbumFromFolder(String folder)
        {
            var album = new AlbumUC(folder);
            albums.Add(album);
            xmlAlbums.Add(album);
            albumsFlowLayoutPanel.Controls.Add(album);
        }

        private void createEmptyAlbum()
        {
            createAlbumFromFolder(ShowDialog("Tape the album's title", ""));
        }

        public void refreshAlbums()
        {
            albumsFlowLayoutPanel.Controls.Clear();

            foreach (AlbumUC album in albums)
            {
                albumsFlowLayoutPanel.Controls.Add(album);
            }
        }

        public void changeAlbumPosition(int index, AlbumUC album)
        {
            albums.Remove(album);
            albums.Insert(index, album);

            for (int i = 0; i < albums.Count; i++)
            {
                albumsFlowLayoutPanel.Controls.SetChildIndex(albums.ElementAt(i), i);
            }
        }

        public AlbumUC getLastSelectedAlbum()
        {
            if (albumsSelected.Count == 0) 
            {
                return null;
            }

            return albumsSelected.Last();
        }

        public void selectAlbum(AlbumUC album)
        {
            album.BackColor = Color.FromArgb(119, 181, 254);
            albumsSelected.Add(album);
        }

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

        public void selectAllAlbums()
        {
            foreach (AlbumUC album in albums)
                selectAlbum(album);
        }

        public bool isSelected(AlbumUC album)
        {
            if (albumsSelected.Contains(album))
            {
                return true;
            }

            return false;
        }

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

        public void removeSelectedAlbums()
        {
            if (albumsSelected.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("No album selected");
                return;
            }

            AlbumUC.resetDisplayedAlbum();

            foreach (AlbumUC album in albumsSelected)
            {
                albums.Remove(album);
                albumsFlowLayoutPanel.Controls.Remove(album);
            }
        }

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

        public void focusAlbumLayout()
        {
            albumsFlowLayoutPanel.Focus();
        }
        #endregion

        #region Event
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
            xmlAlbums.WriteAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("albums.xml"))
            {
                xmlAlbums.ReadAll();

                if (xmlAlbums.albums.Count > 0)
                    foreach (AlbumUC album in xmlAlbums.albums)
                    {
                        albumsFlowLayoutPanel.Controls.Add(album);
                        albums.Add(album);
                    }
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
                        <a href=" + p.getPath() + " data-lightbox=" + p.getTitle() + @">
                            <img class='cadre' src=" + p.getPath() + @">
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

        private void sortByTitle(object sender, EventArgs e)
        {
            AlbumUC album = AlbumUC.getDisplayedAlbum();
            if (album == null)
                return;

            album.sortByTitle();
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
