using System;
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
            if (this.albums.Count == 0)
                return;

            XmlWriter writer = XmlWriter.Create("albums.xml", writer_settings);

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

            if(System.IO.File.Exists("albums.xml"))
            {
                XmlReader reader = XmlReader.Create("albums.xml", reader_settings);

                while (reader.Read() == true)
                {

                    if (reader.Name.Equals("album"))
                    {
                        //MessageBox.Show(reader.Name);
                        reader.ReadToFollowing("title");
                        string title = reader.ReadElementContentAsString();


                        reader.Read();
                        //MessageBox.Show(reader.Name);
                        string path = reader.Value.ToString();
                        //MessageBox.Show("Album path shows " + path);

                        albums.Add(new AlbumUC(title));
                        i++;
                        reader.Read();
                        reader.Read();

                        while (reader.Name.Equals("picture"))
                        {
                            //MessageBox.Show(reader.Name);
                            reader.ReadToFollowing("path");
                            albums.ElementAt(i).addPicture(reader.ReadElementContentAsString());
                            reader.Read();
                        }
                    }
                }

                reader.Close();
            }

            /*foreach (AlbumUC album in albums)
            {
                MessageBox.Show(album.getTitle() + " " + album.getPath());
                foreach (PictureUC picture in album.getPictures())
                    MessageBox.Show(picture.getTitle() + " " + picture.getPath());
            }*/

            this.albums = albums;
            return albums;
        }

    }
}
