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

        public int MainForm_Height = -1;
        public int MainForm_Width = -1;
        public int MainForm_PositionX = -1;
        public int MainForm_PositionY = -1;
        public int mainSplitPanel_Height = -1;
        public int mainSplitPanel_Width = -1;
        public int mainSplitPanel_SplitterDistance = -1;
        public int secondarySplitPanel_Height = -1;
        public int secondarySplitPanel_Width = -1;
        public int secondarySplitPanel_SplitterDistance = -1;

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
                    writer.WriteAttributeString("height", this.MainForm_Height.ToString());
                    writer.WriteAttributeString("width", this.MainForm_Width.ToString());
                    writer.WriteAttributeString("X", this.MainForm_PositionX.ToString());
                    writer.WriteAttributeString("Y", this.MainForm_PositionY.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("mainSplitPanel");
                    writer.WriteAttributeString("height", this.mainSplitPanel_Height.ToString());
                    writer.WriteAttributeString("width", this.mainSplitPanel_Width.ToString());
                    writer.WriteAttributeString("splitterDistance", this.mainSplitPanel_SplitterDistance.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("secondarySplitPanel");
                    writer.WriteAttributeString("height", this.secondarySplitPanel_Height.ToString());
                    writer.WriteAttributeString("width", this.secondarySplitPanel_Width.ToString());
                    writer.WriteAttributeString("splitterDistance", this.secondarySplitPanel_SplitterDistance.ToString());
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

        public XmlConfig readConfig()
        {
            if (System.IO.File.Exists("config.xml"))
            {
                try
                {
                    XmlReader reader = XmlReader.Create("config.xml", reader_settings);
                    while (reader.Read() == true)
                    {
                        if (reader.Name.Equals("MainForm"))
                        {
                            reader.MoveToFirstAttribute();
                            reader.ReadAttributeValue();
                            MainForm_Height = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            MainForm_Width = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            MainForm_PositionX = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            MainForm_PositionY = int.Parse(reader.Value);
                        }

                        if (reader.Name.Equals("mainSplitPanel"))
                        {
                            reader.MoveToFirstAttribute();
                            reader.ReadAttributeValue();
                            mainSplitPanel_Height = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            mainSplitPanel_Width = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            mainSplitPanel_SplitterDistance = int.Parse(reader.Value);
                        }

                        if (reader.Name.Equals("secondarySplitPanel"))
                        {
                            reader.MoveToFirstAttribute();
                            reader.ReadAttributeValue();
                            secondarySplitPanel_Height = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            secondarySplitPanel_Width = int.Parse(reader.Value);
                            reader.MoveToNextAttribute();
                            reader.ReadAttributeValue();
                            secondarySplitPanel_SplitterDistance = int.Parse(reader.Value);
                        }
                    }

                    reader.Close();
                }
                catch (Exception e)
                {
                    return this;
                }
            }
            return this;
        }
    }
}
