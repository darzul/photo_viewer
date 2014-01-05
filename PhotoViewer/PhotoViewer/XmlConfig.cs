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
        public System.Drawing.Size MainForm_Size;
        public System.Drawing.Point MainForm_Position;


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
                    writer.WriteAttributeString("size", this.MainForm_Size.ToString());
                    writer.WriteAttributeString("position", this.MainForm_Position.ToString());
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
            if (System.IO.File.Exists("config.xml"))
            {
                XmlReader reader = XmlReader.Create("config.xml", reader_settings);

                while (reader.Read() == true)
                {
                    if (reader.Name.Equals("MainForm"))
                    {
                        reader.MoveToFirstAttribute();
                        reader.ReadAttributeValue();
                        System.Drawing.SizeConverter sizeConverter = new System.Drawing.SizeConverter();
                        this.MainForm_Size = (System.Drawing.Size)(sizeConverter.ConvertFromString(reader.Value));
                        MessageBox.Show("Size = " + MainForm_Size.ToString());

                        reader.MoveToNextAttribute();
                        reader.ReadAttributeValue();
                        System.Drawing.PointConverter positionConverter = new System.Drawing.PointConverter();
                        this.MainForm_Position = (System.Drawing.Point)(positionConverter.ConvertFromString(reader.Value));
                        break;
                    }
                }

                reader.Close();
            }
        }
    }
}
