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
        XmlWriterSettings writer_settings;
        XmlReaderSettings reader_settings;
        XmlSchemaSet schema;
        public List<AlbumUC> albums;
        

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

        public void Add(AlbumUC album)
        {
            albums.Add(album);
        }

        public void WriteAlbum(AlbumUC album)
        {
            XmlWriter writer = XmlWriter.Create(album.getTitle()+".xml", writer_settings);

            using (writer) {
                writer.WriteStartElement("album");
                writer.WriteElementString("title", album.getTitle());
                writer.WriteElementString("path", album.getPath());

                foreach (PictureUC picture in album.getPictures())
                {
                    writer.WriteStartElement("picture");
                    writer.WriteElementString("title", picture.getTitle());
                    writer.WriteElementString("path", picture.getPath());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.Flush();
            writer.Close();
        }

        public void WriteAll()
        {
            foreach (AlbumUC album in albums)
            {
                XmlWriter writer = XmlWriter.Create(album.getTitle() + ".xml", writer_settings);

                using (writer)
                {
                    writer.WriteStartElement("album");
                    writer.WriteElementString("title", album.getTitle());
                    writer.WriteElementString("path", album.getPath());

                    foreach (PictureUC picture in album.getPictures())
                    {
                        writer.WriteStartElement("picture");
                        writer.WriteElementString("title", picture.getTitle());
                        writer.WriteElementString("path", picture.getPath());
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }

                writer.Flush();
                writer.Close();
            }
        }

        public List<AlbumUC> readAll()
        {
            List<AlbumUC> albums = new List<AlbumUC>();

            XmlReader reader = XmlReader.Create("albums.xml", reader_settings);

            while (reader.Read() == true)
            {
                reader.ReadToFollowing("path");

                albums.Add(new AlbumUC(reader.ReadElementContentAsString()));

                reader.ReadToFollowing("album");
            }

            this.albums = albums;
            return albums;
        }

    }
}