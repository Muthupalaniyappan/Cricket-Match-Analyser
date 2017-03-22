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
    public partial class insert_odi : Form
    {
        public insert_odi()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            dbconn.Open();


            OleDbCommand update1 = new OleDbCommand("insert into players(player_name,jersey_no) values('" + textBox1.Text + "','" + textBox2.Text + "')",dbconn);
            update1.ExecuteNonQuery();


            OleDbCommand player_no = new OleDbCommand("select ID from players where player_name =?  and jersey_no = ? ", dbconn);

            player_no.Parameters.AddWithValue("player_name", textBox1.Text);
            player_no.Parameters.AddWithValue("jersey_no", textBox2.Text);

            int ID = (int)player_no.ExecuteScalar();

            OleDbCommand update = new OleDbCommand("insert into odi_records(ID,Matches,innings,Not_Out,Runs,High_score,Average,Balls_faced,strike_rate,`100's`,`200's`,`50's`,`4's`,`6's`,Stumpings,[link],[Image]) values(ID,'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','"+ textBox17.Text + "','" + textBox18.Text + "')", dbconn);
            update.Parameters.AddWithValue("ID", ID);


            string image, link;

            image = textBox18.Text;
            link = textBox17.Text;


            //update.Parameters.AddWithValue("link", link);
            //update.Parameters.AddWithValue("image", image);

            //update.ExecuteNonQuery();
            //MessageBox.Show("player is inserted", "information", MessageBoxButtons.OK);
            if (update.ExecuteNonQuery()!= null)
            {
                MessageBox.Show("player is inserted", "information", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("player is not inserted", "information", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            odi_format o = new odi_format();
            o.Show();
        }

        private void button3_Click(object sender, EventArgs e)
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
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            odi_format o = new odi_format();
            o.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection dbconn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\user_id.accdb");
            dbconn.Open();

            //OleDbCommand update1 = new OleDbCommand("insert into players(player_name,jersey_no) values('" + textBox1.Text + "','" + textBox2.Text + "')", dbconn);
            //update1.ExecuteNonQuery();

            OleDbCommand player_no = new OleDbCommand("select ID from players where player_name = ? and jersey_no = ?", dbconn);

            player_no.Parameters.AddWithValue("player_name", textBox1.Text);
            player_no.Parameters.AddWithValue("jersey_no", textBox2.Text);

            //player_no.Parameters.AddWithValue("player_name", "raja");
            //player_no.Parameters.AddWithValue("jersey_no", "9");

            int ID = (int)player_no.ExecuteScalar();

            string BBI = textBox24.Text;
            string BBM = textBox25.Text;
            string lwickets = textBox29.Text;
            string hwickets = textBox30.Text;

            OleDbCommand update = new OleDbCommand("insert into odi_bowling (ID,Matches,innings,balls,runs_con,wickets,BBI,BBM,Economy,[avg],SR,`5wickets`,`10wickets`) values(" + ID + "," + textBox19.Text + "," + textBox20.Text + "," + textBox21.Text + "," + textBox22.Text + "," + textBox23.Text + ",'" + BBI + "','" + BBM + "'," + textBox26.Text + "," + textBox27.Text + "," + textBox28.Text + ",'" + lwickets + "','" + hwickets + "')", dbconn);

            //update.Parameters.AddWithValue("@ID",ID);
            //update.Parameters.AddWithValue("@BBI", BBI);
            //update.Parameters.AddWithValue("@BBM", BBM);
            //update.Parameters.AddWithValue("@5wickets",lwickets);
            //update.Parameters.AddWithValue("@10wickets",hwickets);


            if (update.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("player is inserted", "information", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("player is not inserted", "information", MessageBoxButtons.OK);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
