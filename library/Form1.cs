using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace library
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            
         
        }

        private void LogIn()
        {
            string loginuser = tblog.Text;
            string passuser = tbpas.Text;
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `entering` WHERE `Login`=@log AND `password`=@pas", db.getconn());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = loginuser;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = passuser;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                this.Hide();
                Main a = new Main();
                a.Show();

            }
            else MessageBox.Show("Некоректный ввод данных", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
