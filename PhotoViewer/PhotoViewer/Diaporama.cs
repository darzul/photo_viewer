using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class Diaporama : Form
    {
        AlbumUC album;
        int picture_index = 0;
        int timeLapse;
        bool diapoPaused = false;

        public Diaporama(AlbumUC album)
        {
            InitializeComponent();

            timeLapse = 50;
            this.album = album;
            Cursor.Hide();
        }

        public void StartDiaporama()
        {
            timer.Interval = timeLapse * 100;
           

            if (album.getPictures().Count > 0 && picture_index < album.getPictures().Count)
            {
                if (diapoPaused == false)
                {
                    PlayPicture(picture_index);
                    picture_index++;
                    timer.Start();
                }
            }
            else if(album.getPictures().Count <= 0)
                MessageBox.Show("No pictures found");
            else
            this.Close();
            
        }

        private void PlayPicture(int p)
        {
            try
            {
                Image image = Image.FromFile(album.getPictures().ElementAt(picture_index).getPath());
                diapoPictureBox.Image = AlbumUC.ScaleImage(image, MainForm.maxWidth, MainForm.maxHeight);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void Diaporama_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Press Space bar to pause"+ Environment.NewLine +@"
                ESC to quit
                "+ Environment.NewLine +@"+/- to change time between two pictures
                " + Environment.NewLine +"Left/Right arraw to go to previous/next picture");
        }

        private void Diaporama_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyData = e.KeyData;

            if(keyData == Keys.Escape)
            {
                this.Close();
                Cursor.Show();
            }

            else if (keyData == Keys.Space)
            {
                diapoPaused = !diapoPaused;

                if (diapoPaused)
                    timer.Stop();
                else
                    timer.Start();
            }
            else if (keyData == Keys.Left)
            {
                picture_index -= 2;
                if (picture_index < 0)
                {
                    picture_index = 0;
                }

                StartDiaporama();
                timer.Stop();
                timer.Start();
            }
            else if (keyData == Keys.Right)
            {
                StartDiaporama();
                timer.Stop();
                timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            StartDiaporama();
        }

        private void Diaporama_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyChar = e.KeyChar;

            if (keyChar == '+') 
            {
                timeLapse ++;
            }
            else if (keyChar == '-') 
            {
                if (timeLapse > 1)
                {
                    timeLapse --;
                }
            }
        }
    }
}
