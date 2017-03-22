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
    public partial class odi_format : Form
    {
        public odi_format()
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.Mahendra_Singh_Dhoni_1366x768;
            InitializeComponent();
            Timer tm = new Timer();
            tm.Interval = 2500;
            tm.Tick += new EventHandler(changeimage);
            tm.Start();
        }
        private void changeimage(object sender, EventArgs e)
        {

            List<Bitmap> b1 = new List<Bitmap>();
            b1.Add(Properties.Resources.Mahendra_Singh_Dhoni_1366x768);
            b1.Add(Properties.Resources.Yuvraj_Singh_action_wallpaper);
            b1.Add(Properties.Resources._5);
            b1.Add(Properties.Resources._61);
            //b1.Add(Properties.Resources.shikhar_dhawan);
            int index = DateTime.Now.Second % b1.Count;
            this.BackgroundImage = b1[index];
        } 



        private void button1_Click(object sender, EventArgs e)
        {
            string player_name;
            string jersey_no;

            player_name = comboBox1.Text;
            jersey_no = comboBox2.Text;

            OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            dbconn.Open();

            OleDbCommand sqlquery = new OleDbCommand("select * from odi_records inner join players on odi_records.ID=players.ID where player_name = ? and jersey_no  = ?", dbconn);

            sqlquery.Parameters.AddWithValue("player_name", player_name);
            sqlquery.Parameters.AddWithValue("jersey_no", jersey_no);

            if (sqlquery.ExecuteScalar() != null)
            {
                batsman d = new batsman(player_name,jersey_no);
                d.Show();
                MessageBox.Show("player " + player_name + " is selected", "information", MessageBoxButtons.OK);
                this.Hide();

            }
            else
                MessageBox.Show("not set yet under processing", "information", MessageBoxButtons.OK);

            /* string Player_name;
             string jerssy_no;

             Player_name = comboBox1.Text;
             jerssy_no = comboBox2.Text;


             if (Player_name == "Mahendra Singh Dhoni" && jerssy_no == "7")
             {
                 dhoni d = new dhoni();
                 d.Show();
                 MessageBox.Show("dhoni is selected", "information", MessageBoxButtons.OK);
                 this.Hide();
             }
             else
                 MessageBox.Show("not set yet under processing", "information", MessageBoxButtons.OK);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login o = new login();
            o.Show();
            
        }

        private void odi_format_Load(object sender, EventArgs e)
        {

            


            OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            dbconn.Open();

            OleDbCommand sqlquery = new OleDbCommand("select Player_name, jersey_no from players", dbconn);

            var result = sqlquery.ExecuteReader();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();

            while (result.Read())
            {
                comboBox1.Items.Add(result.GetString(0));
                comboBox2.Items.Add(result.GetInt32(1));
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            insert_odi od = new insert_odi();
            od.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
