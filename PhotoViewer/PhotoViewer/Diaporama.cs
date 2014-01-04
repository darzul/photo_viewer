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

            timeLapse = 5;
            this.album = album;
        }

        public void StartDiaporama()
        {
            timer.Interval = timeLapse * 1000;
           

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
                diapoPictureBox.Image = Image.FromFile(album.getPictures().ElementAt(picture_index).getPath());

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void Diaporama_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Press Space bar to pause and ESC to quit");
        }

        private void Diaporama_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Escape))
            {
                this.Close();
            }

            if (e.KeyCode.Equals(Keys.Space))
            {
                diapoPaused = !diapoPaused;

                if (diapoPaused)
                    timer.Stop();
                else
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
            
        }
    }
}
