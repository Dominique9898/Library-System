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
    public partial class StudentPage : Form
    {
        private MySqlConnection Connection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder
            {
                Server = "cdb-76uuco6h.gz.tencentcdb.com",
                Port = 10132,
                Database = "Library",
                UserID = "root",
                Password = "Birdy123"
            };
            MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
            return con;
        }
        public StudentPage(string val)
        {
            InitializeComponent();
            s_first1.Hide();
            s_second1.Hide();
            s_third1.Hide();

            label11.Text = "Welcome,"+val;
            MySqlConnection con = Connection();
            con.Open();
            string sql = String.Format("select S1.Sname,S1.Sclass,S1.Ssex,S1.Sno from tb_Student S1, tb_User_student S2 where S1.Sno = S2.Sno and S2.Susr = '{0}'",val);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader myReader = cmd.ExecuteReader();
            myReader.Read();
            label5.Text = myReader[0].ToString();
            s_first1.SetLab(label5.Text);
            s_second1.setId(label5.Text);
            label6.Text = label6.Text + myReader[1];

            label9.Text = label9.Text + myReader[2];
            String sno = myReader[3].ToString();
            myReader.Close();
            sql = String.Format("select content from tb_Announce where ano=(select MAX(ano) from tb_Announce )");
            label10.Text = "欢迎使用智能图书馆\r\n"+new MySqlCommand(sql, con).ExecuteScalar().ToString();
            label8.Text = label8.Text + DateTime.Now;
            sql = String.Format("select count(Sno) from tb_Check where Sno = {0}", sno);
            label7.Text = label7.Text + new MySqlCommand(sql, con).ExecuteScalar().ToString() + "本";
        }
        public StudentPage()
        {
            InitializeComponent();
        }
            private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void RoundPanel1_MouseHover(object sender, EventArgs e)
        {
            roundPanel1.Back = Color.FromArgb(251, 186, 65);
            pictureBox2.BackColor = Color.FromArgb(251, 186, 65);
            label2.BackColor = Color.FromArgb(251, 186, 65);
        }

        private void RoundPanel1_MouseLeave(object sender, EventArgs e)
        {
            roundPanel1.Back = Color.Orange;
            pictureBox2.BackColor = Color.Orange;
            label2.BackColor = Color.Orange;
        }

      
        private void RoundPanel2_MouseHover(object sender, EventArgs e)
        {
            roundPanel2.Back = Color.FromArgb(255, 124, 197);
            pictureBox3.BackColor = Color.FromArgb(255, 124, 197);
            label3.BackColor = Color.FromArgb(255, 124, 197);
        }

       

        private void RoundPanel2_MouseLeave(object sender, EventArgs e)
        {
            roundPanel2.Back = Color.FromArgb(231, 46, 122);
            pictureBox3.BackColor = Color.FromArgb(231, 46, 122);
            label3.BackColor = Color.FromArgb(231, 46, 122);
        }

        private void RoundPanel3_MouseHover(object sender, EventArgs e)
        {
            roundPanel3.Back = Color.Purple;
            pictureBox4.BackColor = Color.Purple;
            label4.BackColor = Color.Purple;
        }

    
        private void RoundPanel3_MouseLeave(object sender, EventArgs e)
        {
            roundPanel3.Back = Color.FromArgb(159, 31, 216);
            pictureBox4.BackColor = Color.FromArgb(159, 31, 216);
            label4.BackColor = Color.FromArgb(159, 31, 216);
        }

        private void RoundPanel1_Click(object sender, EventArgs e)
        {
            s_first1.Show();
            s_first1.BringToFront();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            this.Hide();
            obj.Show();
           
        }

        private void RoundPanel3_Click(object sender, EventArgs e)
        {
            s_third1.Show();
            s_third1.BringToFront();
        }

        

        private void RoundPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RoundPanel2_Click(object sender, EventArgs e)
        {
                s_second1.Show();
                s_second1.BringToFront();
        
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            s_second1.Show();
            s_second1.BringToFront();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            s_second1.Show();
            s_second1.BringToFront();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
