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
    public partial class library : Form
    {
        public library()
        {
            InitializeComponent();
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
         
        }
        public List<ClassBook> ListclassBook = new List<ClassBook>();

        ClassDataBase db = new ClassDataBase();
        public void Load_Data()
        {
            string r = @"select a.id_b,a.name_b,b.name_a,b.lname,p.name_p,c.name_g,t.Name_t,a.place,a.data,a.lang from genre c natural join book a natural join book_author k natural join author b natural join publisher p natural join topic t ";
            db.Execute<ClassBook>("library.db", r, ref ListclassBook);
        }
        public void Show_Data()
        {

            for (int i = 0; i < ListclassBook.Count; i++)
            {
                dataGridView1.Rows.Add(ListclassBook[i].Book, ListclassBook[i].AuthorN, ListclassBook[i].Author, ListclassBook[i].Genre, ListclassBook[i].Topic, ListclassBook[i].Publish);
            }
            for (int i = 0; i < ListclassBook.Count; i++)
            {
                {
                    if (!cbbok.Items.Contains(ListclassBook[i].Book))
                    {
                        cbbok.Items.Add(ListclassBook[i].Book);

                    }
                   
                }
                
            }
           
            for (int i = 0; i < ListclassBook.Count; i++)
            {
                {
                    if (!cbauthor.Items.Contains(ListclassBook[i].AuthorN))
                    {
                        cbauthor.Items.Add(ListclassBook[i].AuthorN);

                    }

                }
              
            }
          
            for (int i = 0; i < ListclassBook.Count; i++)
            {
                {
                    if (!cbgenre.Items.Contains(ListclassBook[i].Genre))
                    {
                        cbgenre.Items.Add(ListclassBook[i].Genre);

                    }

                }
             
            }
           
            for (int i = 0; i < ListclassBook.Count; i++)
            {
                {
                    if (!cbtopic.Items.Contains(ListclassBook[i].Topic))
                    {
                        cbtopic.Items.Add(ListclassBook[i].Topic);

                    }

                }

            }
          
            for (int i = 0; i < ListclassBook.Count; i++)
            {
                {
                    if (!cbpublish.Items.Contains(ListclassBook[i].Publish))
                    {
                        cbpublish.Items.Add(ListclassBook[i].Publish);

                    }

                }

            }
           
        }

        private void library_Load(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private int GetIdBkook(string a)
        {
            for (int i = 0; i < ListclassBook.Count; i++)
                if (ListclassBook[i].Book == a  )
                    return ListclassBook[i].ID;
            return - 1;
        }
        bool f = true;
        private void button2_Click(object sender, EventArgs e)
        {
            if (f == true)
            {
                int id = dataGridView1.CurrentCell.RowIndex;
                dataGridView2.Visible = true;
                groupBox2.Visible = true;
                string s = Convert.ToString(dataGridView1.Rows[id].Cells[0].Value);
                int k = GetIdBkook(s);
                for (int i = 0; i < ListclassBook.Count; i++)
                {
                    if (k == ListclassBook[i].ID)
                    { dataGridView2.Rows.Add(ListclassBook[i].Polka, ListclassBook[i].Year, ListclassBook[i].Lang); break; };
                }
                f = false;
            }
            else
            {
                dataGridView2.Visible = false;
                groupBox2.Visible = false;
                dataGridView2.Rows.Clear();
                f = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListclassBook.Count; i++)
            {

                if (ListclassBook[i].Checkfind(cbbok.Text, cbauthor.Text, cbauthorL.Text, cbgenre.Text, cbtopic.Text, cbpublish.Text) == true)
                {

                    dataGridView1.Rows.Add(ListclassBook[i].Book, ListclassBook[i].AuthorN, ListclassBook[i].Author, ListclassBook[i].Genre, ListclassBook[i].Topic, ListclassBook[i].Publish);
                }

            }
            
        }

        private void cbauthor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbauthorL.Items.Clear();
            for (int i = 0; i < ListclassBook.Count; i++)
            {
                if (ListclassBook[i].AuthorN == cbauthor.Text)
                {
                    if (!cbauthorL.Items.Contains(ListclassBook[i].Author))
                    {
                        cbauthorL.Items.Add(ListclassBook[i].Author); cbauthorL.Text = ListclassBook[i].Author;

                    }

                }
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cbbok.Items.Clear();
            cbauthor.Items.Clear();
            cbauthorL.Items.Clear();
            cbgenre.Items.Clear();
            cbtopic.Items.Clear();
            cbpublish.Items.Clear();
            cbauthor.Text = "";
            cbauthorL.Text = "";
            cbbok.Text = "";
            Show_Data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = dataGridView1.CurrentCell.RowIndex;
            string s = Convert.ToString(dataGridView1.Rows[id].Cells[0].Value);
            int k = GetIdBkook(s);
            if (cbplace.Text != "")
            {
                string r = cbplace.Text;
                string l = @"Update book a set a.place='" + r + "' where a.id_b=" + k + ";";
                db.ExecuteNonQuery("zoo.db", l, 0);
                dataGridView1.Rows.Clear();
                ListclassBook.Clear();
                dataGridView2.Visible = false;
                groupBox2.Visible = false;
                Load_Data();
                Show_Data();
                MessageBox.Show("Место изменено!");

            }
            else MessageBox.Show("Введите новое место!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add a = new add();
            a.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {

            ClassSerialiaze.SerialiazeToXml<List<ClassBook>>(ref ListclassBook, "data1.xml");
            Reportbook a = new Reportbook();
            a.ShowDialog();
        }
    }


   
}

