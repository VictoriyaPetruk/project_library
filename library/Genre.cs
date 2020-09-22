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
    public partial class Genre : Form
    {
        public Genre()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClassGenre a = new ClassGenre();
            a.Name= textBox1.Text.Trim();
            a.Group=comboBox1.Text;
            ListclassGenre.Add(a);
            string q = @"INSERT INTO genre (name_g, groupp) VALUES ('" + a.Name + @"','"+a.Group + @"');";
            db.ExecuteNonQuery("library.db", q, 0);
           dataGridView1.Rows.Add(a.Name,a.Group);
            add p = new add();
            p.ListClassGenre.Add(a);
            MessageBox.Show("Жанр добавлен!");
        }
        public List<ClassGenre> ListclassGenre = new List<ClassGenre>();

        ClassDataBase db = new ClassDataBase();
        public void Load_Data()
        {
            string r = @"select a.id_g,a.name_g, a.groupp from genre a";
            db.Execute<ClassGenre>("library.db", r, ref ListclassGenre);

        }
        public void Show_Data()
        {
            for (int i = 0; i < ListclassGenre.Count; i++)
            {
                dataGridView1.Rows.Add(ListclassGenre[i].Name, ListclassGenre[i].Group);
            }
            for (int i = 0; i < ListclassGenre.Count; i++)
            {
                {
                    if (!comboBox1.Items.Contains(ListclassGenre[i].Group))
                    {
                        comboBox1.Items.Add(ListclassGenre[i].Group); comboBox1.Text = ListclassGenre[i].Group;

                    }

                }

            }
            for (int i = 0; i < ListclassGenre.Count; i++)
            {
                {
                    if (!comboBox2.Items.Contains(ListclassGenre[i].Group))
                    {
                        comboBox2.Items.Add(ListclassGenre[i].Group); comboBox2.Text = ListclassGenre[i].Group;

                    }

                }

            }

        }
        private void Genre_Load(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListclassGenre.Count; i++)
            {
                if (comboBox2.Text == ListclassGenre[i].Group)

                    dataGridView1.Rows.Add(ListclassGenre[i].Name, ListclassGenre[i].Group);
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ListclassGenre.Clear();
            Load_Data();
            Show_Data();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();
        }
    }
}
