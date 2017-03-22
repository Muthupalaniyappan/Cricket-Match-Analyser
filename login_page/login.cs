using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMA_System
{
    public partial class login : Form
    {
        public login()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odi_format o = new odi_format();
            o.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wait for next version stay tuned for updates", "information", MessageBoxButtons.OK);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Mainpage l = new Mainpage();
            l.Show();
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            
            Mainpage m = new Mainpage();
            m.Show();

            MessageBox.Show("you have signout successfully", "information", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("wait for next version stay tuned for updates", "information", MessageBoxButtons.OK);
        }
    }
}
