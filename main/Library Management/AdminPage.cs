using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class AdminPage : Form
    {
        public AdminPage(string val)
        {
            InitializeComponent();
            arrow.Top = btn1.Top;
            name.Text = "Welcome," + val;
            a_first1.BringToFront();
            a_first1.getMessage();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            a_first1.getMessage();
            this.arrow.Top = this.btn1.Top;
            
            a_first1.BringToFront();
           
            
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            this.arrow.Top = this.btn2.Top;
            a_second1.BringToFront();
            

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.arrow.Top = this.btn3.Top;
            a_third1.GetMessage();
            a_third1.BringToFront();
           

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.arrow.Top = this.btn4.Top;
            a_fourth1.BringToFront();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.arrow.Top = this.btn5.Top;
            a_fifth1.BringToFront();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.arrow.Top = this.btn6.Top;
            a_sixth1.BringToFront();
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void a_second1_Load(object sender, EventArgs e)
        {

        }

        private void a_third1_Load(object sender, EventArgs e)
        {

        }

        private void a_first1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            this.Hide();
            obj.Show();
        }
    }
}
