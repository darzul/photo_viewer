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
        Timer timer;
        AlbumUC album;


        public Diaporama(AlbumUC album)
        {
            InitializeComponent();

            this.album = album;
        }

        public void StartDiaporama()
        {
            int picture_index = 0;

            if (album.getPictures().Count > 0)
            {
                PlayPictures(picture_index);
            }
            else
                MessageBox.Show("No pictures found");
        }

        private void PlayPictures(int p)
        {
            if (timer != null)
            {
                timer.Stop();
            }


        }

        private void Diaporama_Load(object sender, EventArgs e)
        {

        }

        private void Diaporama_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
