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
    public partial class viewer : Form
    {

        string player_name;
        string jersey_no;
        public viewer(string name,string no)
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            player_name = name;
            jersey_no = no;
        }



        private void viewer_Load(object sender, EventArgs e)
        {

            OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            dbconn.Open();

            OleDbCommand sqlquery = new OleDbCommand("select Matches,innings,Not_Out,Runs,High_score,Average,Balls_faced,strike_rate,`100's`,`200's`,`50's`,`4's`,`6's`,Stumpings,link,Image from odi_records inner join players on odi_records.ID=players.ID where player_name = ? and jersey_no = ?", dbconn);

            sqlquery.Parameters.AddWithValue("player_name", player_name);
            sqlquery.Parameters.AddWithValue("jersy_no", jersey_no);

            var data = sqlquery.ExecuteReader();

            data.Read();
            label1.Text = player_name;
            textBox1.Text = "" + data.GetInt32(0);
            textBox2.Text = "" + data.GetInt32(1);
            textBox3.Text = "" + data.GetInt32(2);
            textBox4.Text = "" + data.GetInt32(3);
            textBox5.Text = "" + data.GetInt32(4);
            textBox6.Text = "" + data.GetInt32(5);
            textBox7.Text = "" + data.GetInt32(6);
            textBox8.Text = "" + data.GetInt32(7);
            textBox9.Text = "" + data.GetInt32(8);
            textBox10.Text = "" + data.GetInt32(9);
            textBox11.Text = "" + data.GetInt32(10);
            textBox12.Text = "" + data.GetInt32(11);
            textBox13.Text = "" + data.GetInt32(12);
            textBox14.Text = "" + data.GetInt32(13);

            var link = new LinkLabel.Link();
            link.LinkData = data.GetString(14);
            linkLabel1.Links.Add(link);


            var imgfilename = data.GetString(15);
            pictureBox1.Image = Image.FromFile("Assets\\" + imgfilename);

            OleDbCommand sqlquery1 = new OleDbCommand("select Matches,innings,balls,runs_con,wickets,BBI,BBM,Economy,avg,SR,`5wickets`,`10wickets` from odi_bowling inner join players on odi_bowling.ID=players.ID where player_name = ? and jersey_no = ?", dbconn);

            sqlquery1.Parameters.AddWithValue("player_name", player_name);
            sqlquery1.Parameters.AddWithValue("jersy_no", jersey_no);

            var data1 = sqlquery1.ExecuteReader();

            data1.Read();
            textBox15.Text = "" + data1.GetInt32(0);
            textBox16.Text = "" + data1.GetInt32(1);
            textBox17.Text = "" + data1.GetInt32(2);
            textBox18.Text = "" + data1.GetInt32(3);
            textBox19.Text = "" + data1.GetInt32(4);
            textBox20.Text = "" + data1.GetString(5);
            textBox21.Text = "" + data1.GetString(6);
            textBox22.Text = "" + data1.GetInt32(7);
            textBox23.Text = "" + data1.GetInt32(8);
            textBox24.Text = "" + data1.GetInt32(9);
            textBox25.Text = "" + data1.GetString(10);
            textBox26.Text = "" + data1.GetString(11);

        }





        private void tabPage1_Click(object sender, EventArgs e)
        {
           

            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

            //OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            //dbconn.Open();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            choosing_player o = new choosing_player();
            o.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            choosing_player o = new choosing_player();
            o.Show();
        }
    }
}
