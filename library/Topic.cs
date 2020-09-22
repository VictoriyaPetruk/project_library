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
    public partial class Topic : Form
    {
        public Topic()
        {
            InitializeComponent();
        }
        public List<ClassTopic> ListclassTopic = new List<ClassTopic>();

        ClassDataBase db = new ClassDataBase();
        public void Load_Data()
        {
            string r = @"select id_t, Name_t from topic";
            db.Execute<ClassTopic>("library.db", r, ref ListclassTopic);
        }
        public void Show_Data()
        { for (int i = 0; i < ListclassTopic.Count; i++)
                listBox1.Items.Add(ListclassTopic[i].Name);
        }
        private void Topic_Load(object sender, EventArgs e)
        {
            Load_Data();
            Show_Data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClassTopic p = new ClassTopic();
            p.Name = textBox1.Text.Trim();
            p.ID = 1;
            ListclassTopic.Add(p);
            string q = @"INSERT INTO topic (Name_t) VALUES ('" + p.Name + @"');";
            db.ExecuteNonQuery("library.db", q, 0);
            listBox1.Items.Add(p.Name);
            add a=new add ();
            a.ListClassTopic.Add(p);
            MessageBox.Show("Тематика добавлена!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();
        }
    }
}
