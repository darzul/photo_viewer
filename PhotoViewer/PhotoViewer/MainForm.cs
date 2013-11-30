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
        public MainForm()
        {
            InitializeComponent();
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
    }
}
