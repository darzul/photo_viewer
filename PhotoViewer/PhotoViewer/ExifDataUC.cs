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
    public partial class ExifDataUC : UserControl
    {
        #region Constructor(s) and attributes
        private static MainForm mainForm;
        public string labelText { get { return propertyLabel.Text; } set { propertyLabel.Text = value; } }
        public string propertyText { get { return propertyMaskedTextBox.Text; } set { propertyMaskedTextBox.Text = value; } }

        /// <summary>
        /// Set the mainForm
        /// </summary>
        /// <param name="form">The mainForm</param>
        public static void setMainForm (MainForm form) 
        {
            mainForm = form;
        }

        /// <summary>
        /// Constructeur pour ExifDataUC à partir de deux chaines.
        /// </summary>
        /// <param name="property">Le nom de la propriété.</param>
        /// <param name="value">Valeur de la propriété.</param>
        public ExifDataUC(string property, string value)
        {
            InitializeComponent();

            this.labelText = property;
            this.propertyText = value;
        }

        /// <summary>
        /// Constructeur pour ExifDataUC à partir d'un PropertyItem.
        /// </summary>
        /// <param name="property">La propriété à afficher</param>
        public ExifDataUC(PropertyItem property)
        {
            InitializeComponent();

            if (property.Id == 256)
            {
                this.labelText = Properties.Resources.ExifWidth;
                this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 257)
            {
                this.labelText = Properties.Resources.ExifHeight;
                this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 258)
            {
                this.labelText = Properties.Resources.ExifBitsPerColor;
                this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 270 || property.Id == 800)
            {
                this.labelText = Properties.Resources.ExifTitle;
                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 271)
            {
                this.labelText = Properties.Resources.ExifCamera;
                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 272)
            {
                this.labelText = Properties.Resources.ExifModel;
                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 305)
            {
                this.labelText = Properties.Resources.ExifSoftwareUsed;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 306)
            {
                this.labelText = Properties.Resources.ExifCreated;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 315)
            {
                this.labelText = Properties.Resources.ExifAuthor;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 33432)
            {
                this.labelText = Properties.Resources.ExifCopyright;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 33434)
            {
                this.labelText = Properties.Resources.ExifExposition;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
                //this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 36864)
            {
                this.labelText = Properties.Resources.ExifVersion;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 36867)
            {
                this.labelText = Properties.Resources.ExifDateOfShooting;

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else
            {
                this.Visible = false;
            }

            Size size = TextRenderer.MeasureText(this.propertyMaskedTextBox.Text, this.propertyMaskedTextBox.Font);
            this.propertyMaskedTextBox.Width = size.Width;
        }
        #endregion

        #region Events
        private void ExifDataUCFocus(object sender, EventArgs e)
        {
            mainForm.focusDetailLayout();
        }

        private void propertyLabelFocus(object sender, EventArgs e)
        {
            this.propertyMaskedTextBox.Focus();
        }
        #endregion
    }
}
