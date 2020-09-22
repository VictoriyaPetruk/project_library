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
    public partial class Author : Form
    {
        public Author()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            DateTime date = new DateTime();
            string dater = date.ToShortDateString();
        }
        public List<ClassAuthor> ListClassAuthor = new List<ClassAuthor>();

        ClassDataBase db = new ClassDataBase();
        public void Load_Data()
        {
            string r = @"select id_a, name_a, lname, country_a, Date_b, Date_d from author ";
            db.Execute<ClassAuthor>("library.db", r, ref ListClassAuthor);
        }
        public void Show_Data()
        {

            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                dataGridView1.Rows.Add(ListClassAuthor[i].Name, ListClassAuthor[i].Lname, ListClassAuthor[i].Country);
            }
            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                {
                    if (!comboBox1.Items.Contains(ListClassAuthor[i].Country))
                    {
                        comboBox1.Items.Add(ListClassAuthor[i].Country); 

                    }

                }

            }
            comboBox1.Text = ListClassAuthor[1].Country;
        }
            private void Author_Load(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();
        }
        private int GetIdAuthor(string a,string b)
        {
            for (int i = 0; i < ListClassAuthor.Count; i++)
                if (ListClassAuthor[i].Name== a && ListClassAuthor[i].Lname==b)
                    return ListClassAuthor[i].ID;
            return -1;
        }
        bool f=true;
        private void button3_Click(object sender, EventArgs e)
        {
            if (f == true)
            {
                int id = dataGridView1.CurrentCell.RowIndex;
              
                groupBox2.Visible = true;
                string a = Convert.ToString(dataGridView1.Rows[id].Cells[0].Value);
                string b = Convert.ToString(dataGridView1.Rows[id].Cells[1].Value);
                int k = GetIdAuthor(a,b);
                for (int i = 0; i < ListClassAuthor.Count; i++)
                {
                    if (k == ListClassAuthor[i].ID)
                    { dataGridView2.Rows.Add(ListClassAuthor[i].Data_b, ListClassAuthor[i].Data_d); break; };
                }
                f = false;
            }
            else
            {
              
                groupBox2.Visible = false;
                dataGridView2.Rows.Clear();
                f = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListClassAuthor.Count; i++)
            {
                if (comboBox1.Text == ListClassAuthor[i].Country)

                    dataGridView1.Rows.Add(ListClassAuthor[i].Name, ListClassAuthor[i].Lname, ListClassAuthor[i].Country);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ListClassAuthor.Clear();
            Load_Data();
            Show_Data();
        }
        private void Save_toDB()
        {
            ClassAuthor a = new ClassAuthor();
            a.Name = textBox1.Text.Trim();
            a.Lname= textBox2.Text.Trim();
            a.Country = textBox3.Text.Trim();
            a.Data_b = Convert.ToString(dateTimePicker1.Text);
            if (checkBox1.Checked)
            {
                a.Data_d = "";

            }
            else { a.Data_d = Convert.ToString(dateTimePicker2.Text); }
            ListClassAuthor.Add(a);
            if (!checkBox1.Checked)
            {
                string q = @"INSERT INTO author (name_a, lname, country_a, Date_b, Date_d) VALUES ('" + a.Name + @"','" + a.Lname + @"','" + a.Country + @"','" + a.Data_b + @"','" + a.Data_d + @"');";
                db.ExecuteNonQuery("library.db", q, 0);
            }
            else
            {
                string q = @"INSERT INTO author (name_a, lname, country_a, Date_b) VALUES ('" + a.Name + @"','" + a.Lname + @"','" + a.Country + @"','" + a.Data_b + @"');";
                db.ExecuteNonQuery("library.db", q, 0);
            }
            dataGridView1.Rows.Clear();
            Load_Data();
            Show_Data();
            add p = new add();
            p.ListClassAuthor.Add(a);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            if (dateTimePicker2.Value > DateTime.Today)
            {
                MessageBox.Show("Вы не можете ввести дату больше сегодняшней");
                dateTimePicker2.Value = DateTime.Today;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_toDB();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button4.Enabled = true;
            MessageBox.Show("Автор добавлен! Нажмите на кнопку 'добавить книги этого автора', чтобы добавить его книги.");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.ShowDialog();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value > DateTime.Today)
            {
                MessageBox.Show("Вы не можете ввести дату больше сегодняшней");
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();
        }
    }
}
