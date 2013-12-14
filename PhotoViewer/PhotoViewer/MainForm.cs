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
    public partial class MainForm : Form
    {
        AlbumUC AlbumUC2;
        AlbumUC AlbumUC3;
        AlbumUC currentAlbumPrinted = null;
        XmlAlbums xmlAlbums;

        public MainForm()
        {
            InitializeComponent();

            xmlAlbums = new XmlAlbums();

            this.AlbumUC2 = new AlbumUC("C:\\Users\\Dev\\Pictures");
            albumsFlowLayoutPanel.Controls.Add(AlbumUC2);
            xmlAlbums.Add(AlbumUC2);

            this.AlbumUC3 = new AlbumUC("C:\\Users\\Dev\\Pictures");
            this.AlbumUC3.Click += displayPictures;
            albumsFlowLayoutPanel.Controls.Add(this.AlbumUC3);
            xmlAlbums.Add(AlbumUC3);

            //if(xmlAlbums.readAll().Equals(xmlAlbums.albums)) MessageBox.Show("ça marche !");
        }

        private void displayPictures(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("AlbumUC"))
            {
                if (sender.Equals(this.AlbumUC2))
                {
                    this.AlbumUC2.displayPictures(picturesFlowLayoutPanel);
                    currentAlbumPrinted = AlbumUC2;
                }
                else if (sender.Equals(this.AlbumUC3))
                {
                    this.AlbumUC3.displayPictures(picturesFlowLayoutPanel);
                    currentAlbumPrinted = AlbumUC3;
                }

                
            }
        }

        private bool needDisplayvScrollBar ()
        {
            //picturesFlowLayoutPanel.get
            return true;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath = new System.Drawing.Drawing2D.GraphicsPath();

            //Set a new rectangle to the same size as the button's
            //ClientRectangle property.
            System.Drawing.Rectangle newRectangle = button1.ClientRectangle;

            //Decrease the size of the rectangle
            newRectangle.Inflate(-1, -1);

            //Draw the button's border
            e.Graphics.DrawEllipse(System.Drawing.Pens.CadetBlue, newRectangle);

            //Increase the size of the rectangle to include the border
            newRectangle.Inflate(1, 1);

            //Create a circle within the new rectangle
            buttonPath.AddEllipse(newRectangle);

            //Set the button's region property to the newly created circle region
            button1.Region = new System.Drawing.Region(buttonPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lancer le diapo
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            xmlAlbums.WriteAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            xmlAlbums.readAll();
        }
    }
}
