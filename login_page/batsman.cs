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
    public partial class batsman : Form
    {
        string player_name;
        string jersey_no;

        public batsman(string name,string no)
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            player_name = name;
            jersey_no = no;
        }

        private void batsman_Load(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            odi_format o = new odi_format();
            o.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData as string);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            odi_format o = new odi_format();
            o.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this feature is not set yet", "information", MessageBoxButtons.OK);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this feature is not set yet", "information", MessageBoxButtons.OK);
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            float average;
            float  total_runs;

            float score1 = float.Parse(textBox27.Text);
            float score2 = float.Parse(textBox28.Text);
            float score3 = float.Parse(textBox29.Text);
            float score4 = float.Parse(textBox30.Text);
            float score5 = float.Parse(textBox31.Text);
            //total_ball = int.Parse(textBox32.Text + textBox33.Text + textBox34.Text + textBox35.Text + textBox36.Text);

            total_runs = score1 + score2 + score3 + score4 + score5;
             
            average = (float) (total_runs / 5);
            //sr = (total_runs / total_ball) * 100;

            label38.Text = average.ToString();

        }

        private void button9_Click(object sender, EventArgs e)
        {

            float sr;

            float score1 = float.Parse(textBox27.Text);
            float score2 = float.Parse(textBox28.Text);
            float score3 = float.Parse(textBox29.Text);
            float score4 = float.Parse(textBox30.Text);
            float score5 = float.Parse(textBox31.Text);

            float balls1 = float.Parse(textBox32.Text);
            float balls2 = float.Parse(textBox33.Text);
            float balls3 = float.Parse(textBox34.Text);
            float balls4 = float.Parse(textBox35.Text);
            float balls5 = float.Parse(textBox36.Text);

            float sr1 = (score1 / balls1) * 100;

            float sr2 = (score2 / balls2) * 100;
            
            float sr3 = (score3 / balls3) * 100;

            float sr4 = (score4 / balls4) * 100;

            float sr5 = (score5 / balls5) * 100;

            sr = (sr1 + sr2 + sr3 + sr4 + sr5) / 5;

            label39.Text = sr.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            label38.Text = "";
            label39.Text = "";

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            odi_format o = new odi_format();
            o.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.chart1.Series["runs"].Points.AddXY("match1", textBox27.Text);
            this.chart1.Series["balls"].Points.AddXY("match1", textBox32.Text);

            this.chart1.Series["runs"].Points.AddXY("match2", textBox28.Text);
            this.chart1.Series["balls"].Points.AddXY("match2", textBox33.Text);

            this.chart1.Series["runs"].Points.AddXY("match3", textBox29.Text);
            this.chart1.Series["balls"].Points.AddXY("match3", textBox34.Text);

            this.chart1.Series["runs"].Points.AddXY("match4", textBox30.Text);
            this.chart1.Series["balls"].Points.AddXY("match4", textBox35.Text);

            this.chart1.Series["runs"].Points.AddXY("match5", textBox31.Text);
            this.chart1.Series["balls"].Points.AddXY("match5", textBox36.Text);

            this.chart1.Series["average"].Points.AddXY("match1",label38.Text);
            this.chart1.Series["average"].Points.AddXY("match2", label38.Text);
            this.chart1.Series["average"].Points.AddXY("match3", label38.Text);
            this.chart1.Series["average"].Points.AddXY("match4", label38.Text);
            this.chart1.Series["average"].Points.AddXY("match5", label38.Text);

            this.chart2.Series["runs"].Points.AddXY("match1", textBox27.Text);
            this.chart2.Series["runs"].Points.AddXY("match2", textBox28.Text);
            this.chart2.Series["runs"].Points.AddXY("match3", textBox29.Text);
            this.chart2.Series["runs"].Points.AddXY("match4", textBox30.Text);
            this.chart2.Series["runs"].Points.AddXY("match5", textBox31.Text);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
