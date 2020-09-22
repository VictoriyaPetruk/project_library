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
    public partial class Publisher : Form
    {
        public Publisher()
        {
            InitializeComponent();
        }
        public List<ClassPublish> ListClassPublish= new List<ClassPublish > ();

        ClassDataBase db = new ClassDataBase();
        public void Load_Data()
        {
            string r = @"select id_p, name_p, country_p from publisher";
            db.Execute <ClassPublish > ("library.db", r, ref ListClassPublish);
        }
        public void Show_Data()
        {

            for (int i = 0; i < ListClassPublish.Count; i++)
            {
                dataGridView1.Rows.Add(ListClassPublish[i].Name, ListClassPublish[i].Country);
            }
            for (int i = 0; i < ListClassPublish.Count; i++)
            {
                {
                    if (!comboBox1.Items.Contains(ListClassPublish[i].Country))
                    {
                        comboBox1.Items.Add(ListClassPublish[i].Country);

                    }

                }

            }
            comboBox1.Text = ListClassPublish[1].Country;
            for (int i = 0; i < ListClassPublish.Count; i++)
            {
                {
                    if (!comboBox2.Items.Contains(ListClassPublish[i].Country))
                    {
                        comboBox2.Items.Add(ListClassPublish[i].Country);

                    }

                }

            }
            comboBox2.Text = ListClassPublish[1].Country;
        }
            private void Publisher_Load(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListClassPublish.Count; i++)
            {
                if (comboBox2.Text == ListClassPublish[i].Country)

                    dataGridView1.Rows.Add(ListClassPublish[i].Name, ListClassPublish[i].Country);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ListClassPublish.Clear();
            Load_Data();
            Show_Data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClassPublish a = new ClassPublish();
            a.Name = textBox1.Text.Trim();
            a.Country = comboBox1.Text;
            ListClassPublish.Add(a);
            string q = @"INSERT INTO publisher(name_p,country_p) VALUES ('" + a.Name + @"','" + a.Country + @"');";
            db.ExecuteNonQuery("library.db", q, 0);
            dataGridView1.Rows.Add(a.Name, a.Country);
            add p = new add();
            p.ListclassPublish.Add(a);
            MessageBox.Show("Издательство добавлено!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();

        }
    }
}
