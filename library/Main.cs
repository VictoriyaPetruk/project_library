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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.label1.BackColor= System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
        }

        private void информацияОКнигахToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Author a = new Author();
            a.Show();
        }

        private void добавитьКнигуавтораToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           library a = new library();
            a.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Genre a = new Genre();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Topic a = new Topic();
            a.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Publisher a = new Publisher();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
          AboutApplication a = new AboutApplication();
            a.Show();
        }
    }
}
