﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;


namespace PhotoViewer
{
    public class XmlAlbums
    {
        #region Constructor and attributes
        XmlWriterSettings writer_settings;
        XmlReaderSettings reader_settings;
        XmlSchemaSet schema;
        private List<AlbumUC> albums;
        

        public XmlAlbums()
        {
            writer_settings = new XmlWriterSettings();
            writer_settings.Indent = true;
            writer_settings.IndentChars = " ";

            reader_settings = new XmlReaderSettings();
            reader_settings.IgnoreWhitespace = true;
            reader_settings.IgnoreComments = true;

            schema = new XmlSchemaSet();
            albums = new List<AlbumUC>();
        }
        #endregion

        #region Albums reading and writing
        public void Add(AlbumUC album)
        {
            albums.Add(album);
        }

        public void WriteAll()
        {
            if (this.albums != null)
            if (this.albums.Count == 0)
                return;

            XmlWriter writer = XmlWriter.Create(Properties.Resources.AlbumXmlFile, writer_settings);

            using(writer)
            {
                try
                {
                    writer.WriteStartElement("xmlAlbums");

                    foreach (AlbumUC album in albums)
                    {
                        writer.WriteStartElement("album");
                        writer.WriteElementString("title", album.getTitle());
                        writer.WriteElementString("path", album.getPath());

                        foreach (PictureUC picture in album.getPictures())
                        {
                            writer.WriteStartElement("picture");
                            writer.WriteElementString("title", picture.getTitle());
                            writer.WriteElementString("path", picture.getPath());
                            writer.WriteElementString("rate", picture.getRate().ToString());
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return;
                }

                writer.WriteEndElement();
            }

            writer.Flush();
            writer.Close();
        }

        public List<AlbumUC> ReadAll()
        {
            List<AlbumUC> albums = new List<AlbumUC>();
            int i = -1;

            if(System.IO.File.Exists(Properties.Resources.AlbumXmlFile))
            {
                XmlReader reader = XmlReader.Create(Properties.Resources.AlbumXmlFile, reader_settings);

                try
                {
                    while (reader.Read() == true)
                    {

                        if (reader.Name.Equals("album"))
                        {
                            reader.ReadToFollowing("title");
                            string title = reader.ReadElementContentAsString();


                            reader.Read();
                            string path = reader.Value.ToString();

                            albums.Add(new AlbumUC(title));
                            i++;
                            reader.Read();
                            reader.Read();

                            int p = 0;
                            while (reader.Name.Equals("picture"))
                            {
                                reader.ReadToFollowing("path");
                                path = reader.ReadElementContentAsString();
                                int rate = int.Parse(reader.ReadElementContentAsString());
                                albums.ElementAt(i).addPicture(path);
                                albums.ElementAt(i).getPictures().ElementAt(p).setRate(rate);
                                p++;
                                reader.Read();
                            }
                        }
                    }

                    reader.Close();
                }
                catch (Exception e)
                {

                }
            }

            this.albums = albums;
            return albums;
        }
        #endregion

        #region Getters/Setters
        public List<AlbumUC> getAlbums()
        {
            return this.albums;
        }

        public void setAlbums(List<AlbumUC> albums)
        {
            this.albums = albums;
        }
        #endregion
    }
}
