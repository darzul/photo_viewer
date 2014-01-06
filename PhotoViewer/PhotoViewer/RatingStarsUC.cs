using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoViewer
{
    //Code found on Daniweb, written by ddanbe
    public partial class RatingStarsUC : UserControl
    {
        #region Constructor and attributes
        PointF[] Star;SolidBrush FillBrush;
        public enum starStatus { unClicked, hover, clicked };
        public starStatus status;
        PictureUC picture;
        public static List<RatingStarsUC> stars_list = new List<RatingStarsUC>();

        public RatingStarsUC(PictureUC picture)
        {
            InitializeComponent();
            this.picture = picture;
            this.Paint += new PaintEventHandler(MyPainting);
            stars_list.Add(this);
        }
        #endregion

        #region Drawing methods
        private void MyPainting(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < stars_list.Count; i++)
            {
                Graphics G = e.Graphics;
                G.SmoothingMode = SmoothingMode.HighQuality;

                if (status.Equals(starStatus.unClicked))
                {
                    // init star
                    stars_list.ElementAt(i).Star = Calculate5StarPoints(new PointF(10f, 10f), 10f, 6f);
                    FillBrush = new SolidBrush(Color.Gray);
                    G.FillPolygon(FillBrush, stars_list.ElementAt(i).Star);
                }

                if (status.Equals(starStatus.hover))
                {
                    stars_list.ElementAt(i).Star = Calculate5StarPoints(new PointF(10f, 10f), 10f, 6f);
                    FillBrush = new SolidBrush(Color.Orange);
                    G.FillPolygon(FillBrush, stars_list.ElementAt(i).Star);
                }

                if (status.Equals(starStatus.clicked))
                {
                    stars_list.ElementAt(i).Star = Calculate5StarPoints(new PointF(10f, 10f), 10f, 6f);
                    FillBrush = new SolidBrush(Color.Yellow);
                    G.FillPolygon(FillBrush, stars_list.ElementAt(i).Star);
                }
            }
        }

        /// <summary>
        /// Return an array of 10 points to be used in a Draw- or FillPolygon method
        /// </summary>
        /// <param name="Orig"> The origin is the middle of the star.</param>
        /// <param name="outerradius">Radius of the surrounding circle.</param>
        /// <param name="innerradius">Radius of the circle for the "inner" points</param>
        /// <returns>Array of 10 PointF structures</returns>
        private PointF[] Calculate5StarPoints(PointF Orig, float outerradius, float innerradius)
        {
            // Define some variables to avoid as much calculations as possible
            // conversions to radians
            double Ang36 = Math.PI / 5.0;   // 36° x PI/180
            double Ang72 = 2.0 * Ang36;     // 72° x PI/180

            // some sine and cosine values we need
            float Sin36 = (float)Math.Sin(Ang36);
            float Sin72 = (float)Math.Sin(Ang72);
            float Cos36 = (float)Math.Cos(Ang36);
            float Cos72 = (float)Math.Cos(Ang72);

            // Fill array with 10 origin points
            PointF[] pnts = { Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig, Orig };
            pnts[0].Y -= outerradius;  // top off the star, or on a clock this is 12:00 or 0:00 hours
            pnts[1].X += innerradius * Sin36; pnts[1].Y -= innerradius * Cos36; // 0:06 hours
            pnts[2].X += outerradius * Sin72; pnts[2].Y -= outerradius * Cos72; // 0:12 hours
            pnts[3].X += innerradius * Sin72; pnts[3].Y += innerradius * Cos72; // 0:18
            pnts[4].X += outerradius * Sin36; pnts[4].Y += outerradius * Cos36; // 0:24 
            
            // Phew! Glad I got that trig working.
            pnts[5].Y += innerradius;
            
            // I use the symmetry of the star figure here
            pnts[6].X += pnts[6].X - pnts[4].X; pnts[6].Y = pnts[4].Y;  // mirror point
            pnts[7].X += pnts[7].X - pnts[3].X; pnts[7].Y = pnts[3].Y;  // mirror point
            pnts[8].X += pnts[8].X - pnts[2].X; pnts[8].Y = pnts[2].Y;  // mirror point
            pnts[9].X += pnts[9].X - pnts[1].X; pnts[9].Y = pnts[1].Y;  // mirror point
            return pnts;
        }
        #endregion

        #region Events
        private void RatingStarsUC_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i <= stars_list.IndexOf(this); i++)
            {
                if (stars_list.ElementAt(i).picture.Equals(this.picture))
                {
                    stars_list.ElementAt(i).status = starStatus.clicked;
                    stars_list.ElementAt(i).Refresh();
                }
            }
            this.picture.setRate((stars_list.IndexOf(this)%5)+1);
        }

        private void RatingStarsUC_MouseHover(object sender, EventArgs e)
        {
            for (int i = 0; i <= stars_list.IndexOf(this); i++)
            {
                if (stars_list.ElementAt(i).picture.Equals(picture))
                {
                    if (stars_list.ElementAt(i).status != starStatus.clicked)
                    {
                        stars_list.ElementAt(i).status = starStatus.hover;
                        stars_list.ElementAt(i).Refresh();
                    }
                }
            }
        }

        private void RatingStarsUC_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i <= stars_list.IndexOf(this); i++)
            {
                    if (stars_list.ElementAt(i).status == starStatus.hover)
                    {
                        stars_list.ElementAt(i).status = starStatus.unClicked;
                        stars_list.ElementAt(i).Refresh();
                    }
            }
        }
        #endregion
    }
}
