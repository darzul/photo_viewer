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
        public string labelText { get { return propertyLabel.Text; } set { propertyLabel.Text = value; } }
        public string propertyText { get { return propertyMaskedTextBox.Text; } set { propertyMaskedTextBox.Text = value; } }


        public ExifDataUC(PropertyItem property)
        {
            InitializeComponent();

            if (property.Id == 256)
            {
                this.labelText = "Width";
                this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 257)
            {
                this.labelText = "Height";
                this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 258)
            {
                this.labelText = "Bits per color";
                this.propertyText = property.Value.ToString();
            }
            else if (property.Id == 270 || property.Id == 800)
            {
                this.labelText = "Title";
                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 271)
            {
                this.labelText = "Camera";
                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 272)
            {
                this.labelText = "Model";
                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 305)
            {
                this.labelText = "Software used";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 306)
            {
                this.labelText = "Created";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 315)
            {
                this.labelText = "Author";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 33432)
            {
                this.labelText = "Copyright";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 33434)
            {
                this.labelText = "Exposition";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 36864)
            {
                this.labelText = "EXIF Version";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else if (property.Id == 36867)
            {
                this.labelText = "Date of shooting";

                ASCIIEncoding prop = new ASCIIEncoding();

                this.propertyText = prop.GetString(property.Value);
            }
            else
            {
                this.Visible = false;
            }

        }

        //Méthode non-utilisée
        public void getNull()
        {

        }
    }
}
