using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }
        public List<ClassBook> ListclassBook = new List<ClassBook>();
        public List<ClassAuthor> ListClassAuthor = new List<ClassAuthor>();
        public List<ClassPublish> ListclassPublish = new List<ClassPublish>();
        public List<ClassGenre> ListClassGenre = new List<ClassGenre>();
        public List<ClassTopic> ListClassTopic = new List<ClassTopic>();

        ClassDataBase db = new ClassDataBase();
        public void Load_Data()
        {
            string r = @"select a.id_b,a.name_b,b.name_a,b.lname,p.name_p,c.name_g,t.Name_t,a.place,a.data,a.lang from genre c natural join book a natural join book_author k natural join author b natural join publisher p natural join topic t ";
            db.Execute<ClassBook>("library.db", r, ref ListclassBook);
            string k= @"select id_t, Name_t from topic";
            db.Execute<ClassTopic>("library.db", k, ref ListClassTopic);
            string l = @"select a.id_g,a.name_g, a.groupp from genre a";
            db.Execute<ClassGenre>("library.db", l, ref ListClassGenre);
            string a = @"select id_a, name_a, lname, country_a, Date_b, Date_d from author ";
            db.Execute<ClassAuthor>("library.db", a, ref ListClassAuthor);
            string p = @"select id_p, name_p, country_p from publisher";
            db.Execute<ClassPublish>("library.db", p, ref ListclassPublish);
        }
        public int GetIdGenre(string a)
        {
            for (int i = 0; i < ListClassGenre.Count; i++)
                if (ListClassGenre[i].Name == a)
                    return ListClassGenre[i].ID;
            return -1;
        }
        public int GetIdTopic(string a)
        {
            for (int i = 0; i < ListClassTopic.Count; i++)
                if (ListClassTopic[i].Name == a)
                    return ListClassTopic[i].ID;
            return -1;
        }
        public int GetIdAuthor(string a,string b)
        {

            for (int i = 0; i < ListClassAuthor.Count; i++)
                if (ListClassAuthor[i].Name == a&& ListClassAuthor[i].Lname==b)
                    return ListClassAuthor[i].ID;
            return -1;
        }
        public int GetIdPublish(string a)
        {
            for (int i = 0; i < ListclassPublish.Count; i++)
                if (ListclassPublish[i].Name == a)
                    return ListclassPublish[i].ID;
            return -1;
        }
        public void Show_Data()
        {
            
            for (int i = 0; i < ListClassGenre.Count; i++)
            {
                {
                    if (!comboBox1.Items.Contains(ListClassGenre[i].Name))
                    {
                        comboBox1.Items.Add(ListClassGenre[i].Name);

                    }

                }
            }
            comboBox1.Text = ListClassGenre[1].Name;
            for (int i = 0; i < ListClassTopic.Count; i++)
            {
                {
                    if (!comboBox2.Items.Contains (ListClassTopic[i].Name))
                    {
                        comboBox2.Items.Add(ListClassTopic[i].Name);

                    }

                }
            }
            comboBox2.Text = ListClassTopic[1].Name;
            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                {
                    if (!comboBox4.Items.Contains(ListClassAuthor[i].Name))
                    {
                        comboBox4.Items.Add(ListClassAuthor[i].Name);

                    }

                }

            }
            comboBox4.Text = ListClassAuthor[1].Name;
            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                {
                    if (!comboBox6.Items.Contains(ListClassAuthor[i].Name))
                    {
                        comboBox6.Items.Add(ListClassAuthor[i].Name);

                    }

                }

            }
            comboBox6.Text = ListClassAuthor[1].Name;

            for (int i = 0; i < ListclassPublish.Count; i++)
            {
                {
                    if (!comboBox7.Items.Contains(ListclassPublish[i].Name))
                    {
                        comboBox7.Items.Add(ListclassPublish[i].Name);

                    }

                }
            }
            comboBox7.Text = ListclassPublish[1].Name;
        }
            private void Save_to_DB()
            {
            ClassBook a = new ClassBook();
            a.Book = textBox1.Text.Trim();
            a.Genre = comboBox1.Text;
            a.Topic = comboBox2.Text;
            a.AuthorN= comboBox4.Text;
            a.Author= comboBox5.Text;
            a.Publish= comboBox7.Text;
            a.Polka= comboBox3.Text;
            a.Year =Convert.ToInt32(textBox2.Text.Trim());
            a.Lang = textBox3.Text.Trim();
            ListclassBook.Add(a);
            string q = @"INSERT INTO book (name_b, Id_g, Id_t, place, data, lang, id_p) VALUES ('" + a.Book + @"'," + GetIdGenre(a.Genre) + @"," + GetIdTopic(a.Topic) + @",'" + a.Polka+ @"'," + a.Year + @",'"+a.Lang+@"',"+GetIdPublish(a.Publish)+@");";
            db.ExecuteNonQuery("library.db", q, 0);
            string s= @"INSERT INTO book_author (Id_b, Id_a) VALUES ("+"(select Id_b from book order by 1  desc limit 1)"+ @"," + GetIdAuthor(a.AuthorN,a.Author)+@")";
            db.ExecuteNonQuery("library.db", s, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Save_to_DB();
            MessageBox.Show("Книга добавлена! Если у книги есть соавтор, добавьте его в строке ниже.");
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Genre a = new Genre();
            if (a.ShowDialog() == DialogResult.Cancel)
            {
                Load_Data();
                Show_Data();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Topic a = new Topic();

            if (a.ShowDialog() == DialogResult.Cancel)
            {
                Load_Data();
                Show_Data();
            }
     
      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Author a = new Author();
            if (a.ShowDialog() == DialogResult.Cancel)
            {
                Load_Data();
                Show_Data();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Publisher a = new Publisher();
            if (a.ShowDialog() == DialogResult.Cancel)
            {
                Load_Data();
                Show_Data();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                if (ListClassAuthor[i].Name == comboBox4.Text)
                {
                    if (!comboBox5.Items.Contains(ListClassAuthor[i].Lname))
                    {
                        comboBox5.Items.Add(ListClassAuthor[i].Lname); comboBox5.Text = ListClassAuthor[i].Lname;

                    }

                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                if (ListClassAuthor[i].Name == comboBox6.Text)
                {
                    if (!comboBox8.Items.Contains(ListClassAuthor[i].Lname))
                    {
                        comboBox8.Items.Add(ListClassAuthor[i].Lname); comboBox8.Text = ListClassAuthor[i].Lname;

                    }

                }
            }
        }

        

        private void add_Load(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = @"INSERT INTO book_author (Id_b, Id_a) VALUES (" + "(select Id_b from book order by 1  desc limit 1)" + @"," + GetIdAuthor(comboBox6.Text, comboBox8.Text) + @")";
            db.ExecuteNonQuery("library.db", s, 0);
        }
    }
}
