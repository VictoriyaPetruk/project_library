using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ClassBook
    {
        private int id;
        private string name;
        private string author_n;
        private string author;
        private string publish;
        private string genre;
        private string topic;
        private string polka;
        private int year;
        private string lang;
        public int ID { set { id = value; } get { return id; } }
        public string Book { set { name = value; } get { return name; } }
        public string AuthorN { set { author_n = value; } get { return author_n; } }
        public string Author { set { author = value; } get { return author; } }
        public string Publish { set { publish = value; } get { return publish; } }
        public string Genre { set { genre = value; } get { return genre; } }
        public string Topic { set { topic = value; } get { return topic; } }
        public string Polka { set { polka = value; } get { return polka; } }
        public int Year { set { year = value; } get { return year; } }
        public string Lang { set { lang = value; } get { return lang; } }
        public ClassBook()
        {
            id = -1;name = "";author_n = "";author = "";publish = "";genre = "";topic = "";polka = "";
            year = -1;lang = "";
        }
        public ClassBook(string info)
        {
            info = info.Trim();
            if (info.Length > 2)
            {
                string[] val = info.Split('!');
                id = Convert.ToInt32(val[0]);
                name = val[1];
                author_n = val[2];
                author = val[3];
                publish = val[4];
                genre = val[5];
                topic = val[6];
                polka = val[7];
                year = Convert.ToInt32(val[8]);
                lang = val[9];
            }

        }
        public bool Checkfind(string book, string author, string authorl, string genre, string topic, string publish)
        {
            bool k = true;

            if (this.Book == book|| book == "") k = true;
            else return false;
            if (this.AuthorN== author || author == "") k = true;
            else return false;
            if (this.Author == authorl || authorl == "") k = true;
            else return false;
            if (this.Genre == genre || genre == "") k = true;
            else return false;
            if (this.Topic == topic || topic == "") k = true;
            else return false;
            if (this.Publish== publish|| publish == "") k = true;
            else return false;
          
            return k;
        }
    }
}
