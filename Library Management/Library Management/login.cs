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

namespace Library_Management
{

    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
          
            comboBox1.SelectedIndex = 0;

        }

        register obj = new register();
     
        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
                string usr = this.username.Text;
                string pwd = this.password.Text;
                string type = this.comboBox1.Text;
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                sb.Server = "cdb-76uuco6h.gz.tencentcdb.com";
                sb.Port = 10132;
                sb.Database = "Library";
                sb.UserID = "root";
                sb.Password = "Birdy123";
                MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
    
                con.Open();
                if (usr.Equals("") || pwd.Equals(""))
                {
                    MessageBox.Show("用户名或密码不能为空！");
                }
                else if (type == "管理员登陆")
                {
                        string sql = string.Format("select count(*) from tb_User_admin where Ausr='{0}' and Apwd='{1}'", usr, pwd);//查询是否有该条记录，根据账户密码
                        MySqlCommand command = new MySqlCommand(sql, con);//sqlcommand表示要向向数据库执行sql语句或存储过程   
                        int i = Convert.ToInt32(command.ExecuteScalar());//执行后返回记录行数
                        if (i>0)
                        {
                             this.Hide();
                             AdminPage obj = new AdminPage(usr);
                             obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("用户名或者密码错误！");

                        }
                    
                }
                else
                {
                    string sql = string.Format("select count(*) from tb_User_student where Susr='{0}' and Spwd='{1}'", usr, pwd);//查询是否有该条记录，根据账户密码
                    MySqlCommand command = new MySqlCommand(sql, con);//sqlcommand表示要向向数据库执行sql语句或存储过程   
                    int i = Convert.ToInt32(command.ExecuteScalar());//执行后返回记录行数
                    if (i > 0)
                    {
                        StudentPage obj = new StudentPage(usr);
                         obj.Show();
                         this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或者密码错误！");

                    }
                }
            
            
           
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Username_Click(object sender, EventArgs e)
        {
            username.Clear();
            if (password.Text == "")
            {
                password.PasswordChar= '\0';
                password.Text = "Password";
            }
            pictureBox2.Image = Properties.Resources.account2;
            panel2.BackColor = Color.FromArgb(28, 161, 242);
            //password恢复
            pictureBox1.Image = Properties.Resources.padlock;
            panel3.BackColor = Color.Black;
        }

        private void password_Click(object sender, EventArgs e)
        {
            password.Clear();
            //username恢复
            pictureBox2.Image = Properties.Resources.account;
            panel2.BackColor = Color.Black;
            pictureBox1.Image = Properties.Resources.padlock2;
            panel3.BackColor = Color.FromArgb(28, 161, 242); 
            if(username.Text=="")
            {
                username.Text = "Username";
                
            }
            password.PasswordChar = '•';
        }

        private void btn_register_MouseHover(object sender, EventArgs e)
        {
            btn_register.ForeColor = Color.FromArgb(28, 161, 242); 
        }

        private void btn_register_MouseLeave(object sender, EventArgs e)
        {
            btn_register.ForeColor = Color.Gray;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            obj.Show();
            obj.Left += 20;
            if(obj.Left >= 950)
            {
                timer1.Stop();
                this.TopMost = false;
                obj.TopMost = true;
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            obj.Left -= 10;
            if(obj.Left <= 680)
            {
                timer2.Stop();

            }
        }

      
    }
}
