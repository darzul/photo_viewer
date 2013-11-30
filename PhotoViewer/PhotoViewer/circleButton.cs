using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer
{
    public partial class circleButton : UserControl
    {
        public string buttonText { get { return labelText.Text; } set { labelText.Text = value; } }

        public circleButton()
        {
            InitializeComponent();
        }

        //Draw the new button
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen myPen = new Pen(Color.Black);
            //Draw the button in the form of a circle
            graphics.DrawEllipse(myPen, 0, 0, 60, 60);
            myPen.Dispose();
        }
    }
}
