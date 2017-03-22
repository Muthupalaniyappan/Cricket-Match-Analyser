using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMA_System
{
    public partial class Mainpage : Form
    {
        public Mainpage()
        {

            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username;
            string password;
            string message = "invalid username or password,please try again";

            username = textBox1.Text;
            password = textBox2.Text;

            OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            dbconn.Open();

            OleDbCommand sqlquery = new OleDbCommand("SELECT username, password FROM usernames WHERE username = ? AND password = ?", dbconn);

            sqlquery.Parameters.AddWithValue("username", username);
            sqlquery.Parameters.AddWithValue("password", password);

            if (sqlquery.ExecuteScalar() != null)
            {
                dbconn.Close();

                this.Hide();
                login l = new login();
                l.FormClosed += (o, ea) => this.Close();
                l.Show();
                
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show("welcome","information",MessageBoxButtons.OK);

                
            }
            else
            {
                dbconn.Close();
                MessageBox.Show(message, "information", MessageBoxButtons.OK);
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This software is developed on the basis,who are all want to know?cricketers details and his performance details and also match summary", "Information", MessageBoxButtons.OK);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            choosing_player c = new choosing_player();
            c.Show();
        }
    }
}
