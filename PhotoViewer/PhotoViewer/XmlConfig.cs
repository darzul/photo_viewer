using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace PhotoViewer
{
    class XmlConfig
    {
        XmlWriterSettings writer_settings;
        XmlReaderSettings reader_settings;
        public System.Drawing.Size Size;
        public System.Windows.Forms.FormStartPosition position;

        public XmlConfig()
        {
            writer_settings = new XmlWriterSettings();
            writer_settings.Indent = true;
            writer_settings.IndentChars = " ";

            reader_settings = new XmlReaderSettings();
            reader_settings.IgnoreWhitespace = true;
            reader_settings.IgnoreComments = true;
        }

        public void writeConfig()
        {
            XmlWriter writer = XmlWriter.Create("config.xml", writer_settings);

            using (writer)
            {
                try
                {
                    writer.WriteStartElement("configuration");

                    writer.WriteStartElement("MainForm");
                    writer.WriteAttributeString("size", this.Size.ToString());
                    writer.WriteEndAttribute();
                    writer.WriteAttributeString("position", this.position.ToString());
                    writer.WriteEndAttribute();
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return;
                }
            }

            writer.Flush();
            writer.Close();
        }

        public void readConfig()
        {
            XmlReader reader = XmlReader.Create("config.xml", reader_settings);

            while (reader.Read() == true)
            {
                if (reader.Name.Equals("MainForm"))
                {
                    reader.MoveToFirstAttribute();
                    reader.ReadAttributeValue();
                    System.Drawing.SizeConverter sizeConverter = new System.Drawing.SizeConverter();
                    this.Size = (System.Drawing.Size)(sizeConverter.ConvertFromString(reader.Value));

                    reader.MoveToNextAttribute();
                    reader.ReadAttributeValue();
                    //this.position = reader.Value;
                }
            }
        }
    }
}
