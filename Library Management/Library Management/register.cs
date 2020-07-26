using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management
{
    public partial class register : Form
    {
        
        public register()
        {
            InitializeComponent();
        }
        private void register_Load(object sender, EventArgs e)
        {
            signsname.Font = new Font("Yu Gothic UI", 13);
            signsclass.Font = new Font("Yu Gothic UI", 13);
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string usr = this.signusr.Text;
            string pwd = this.signpwd.Text;
            string sno = this.textsno.Text;
            string name = this.signsname.Text;
            string sclass = this.signsclass.Text;
            string sex = this.comboBox1.Text;
            string email = this.signemail.Text;
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "cdb-76uuco6h.gz.tencentcdb.com";
            sb.Port = 10132;
            sb.Database = "Library";
            sb.UserID = "root";
            sb.Password = "Birdy123";
            MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
            
            con.Open();

            //查询新注册的用户是否存在
            string sql = string.Format("select count(*) from tb_User_student where Susr='{0}'", usr);//查询是否有该条记录，根据账户密码
            MySqlCommand command = new MySqlCommand(sql, con);//sqlcommand表示要向向数据库执行sql语句或存储过程   
            int i = Convert.ToInt32(command.ExecuteScalar());//执行后返回记录行数
            if (i > 0)
            {
                MessageBox.Show("用户名已存在！", "提示");
            }
            else
            {
                try{

                    // 指定SQL语句       
                    string sql2 = string.Format("insert into tb_Student values('{0}','{1}','{2}','{3}','{4}')", sno, name, sclass, sex, email);
                    string sql1 = string.Format("insert into tb_User_student values('{0}','{1}','{2}')",sno,usr,pwd);

                    MySqlCommand cmd = new MySqlCommand(sql2, con);
                    cmd.ExecuteNonQuery();
                    // 建立SqlDataAdapter和DataSet对象        
                    MySqlCommand cm1 = new MySqlCommand(sql1, con);
                    cm1.ExecuteNonQuery();
                   
                    MessageBox.Show("注册成功！", "提醒");
                    login obj = new login();
                    this.Hide();
                    obj.Show();

                }
                catch(Exception ee)
                {
                    MessageBox.Show(ee.Message.ToString());
                }
                finally
                {
                    con.Close();
                }
                
            }
               
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signusr_Click(object sender, EventArgs e)
        {
            signusr.Clear();
            pictureBox2.Image = Properties.Resources.account2;
            panel2.BackColor = Color.FromArgb(17, 150, 238);
        }

        private void signusr_Leave(object sender, EventArgs e)
        {
            if(signusr.Text == "")
            {
                signusr.Text = "Username";
            }
            signusr.Font = new Font("微软雅黑", 13);
            pictureBox2.Image = Properties.Resources.account;
            panel2.BackColor = Color.Black;

        }

        private void signpwd_Click(object sender, EventArgs e)
        {
            
            signpwd.Clear();
            pictureBox1.Image = Properties.Resources.padlock2;
            panel3.BackColor = Color.FromArgb(17, 150, 238);
            signpwd.PasswordChar = '•'; //让输入的密码显示为圆点
        }

        private void signpwd_Leave(object sender, EventArgs e)
        {
           
            pictureBox1.Image = Properties.Resources.padlock;
            panel3.BackColor = Color.Black;

            if (signpwd.Text=="")
            {
                signpwd.Text = "Password";
                signpwd.PasswordChar = '\0';

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            login obj = new login();
            
            this.Left -= 30;
            
            if (this.Left <= 350)
            {
                timer1.Stop();
               
                this.TopMost = false;
                obj.TopMost = true;
                timer2.Start();
                obj.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            this.Left += 10;
            if(this.Left >= 670)
            {
                timer2.Stop();

            }
            
        }

        private void textsno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textsno_Click(object sender, EventArgs e)
        {
            textsno.Clear();
            pictureBox3.Image = Properties.Resources.student_card1;
            panel4.BackColor = Color.FromArgb(28, 161, 242);
        }

        private void textsno_Leave(object sender, EventArgs e)
        {
            if(textsno.Text == "")
            {
                textsno.Text = "Student ID";
            }
            pictureBox3.Image = Properties.Resources.student_card;
            panel4.BackColor = Color.Black;
        }

        private void signsname_Click(object sender, EventArgs e)
        {
            signsname.Clear();
            pictureBox4.Image = Properties.Resources.folder__1_;
            panel5.BackColor = Color.FromArgb(28, 161, 242);
        }

        private void signsname_Leave(object sender, EventArgs e)
        {
            if(signsname.Text == "" )
            {
                signsname.Text = "Name";
                signsname.Font = new Font("Yu Gothic UI", 13);
            }
            signsname.Font = new Font("微软雅黑", 13);
            pictureBox4.Image = Properties.Resources.folder;
            panel5.BackColor = Color.Black;
        }

        private void signsclass_Click(object sender, EventArgs e)
        {
            signsclass.Clear();
            pictureBox5.Image = Properties.Resources.classroom__1_;
            panel6.BackColor = Color.FromArgb(28, 161, 242);
        }

        private void signsclass_Leave(object sender, EventArgs e)
        {
            if(signsclass.Text == "")
            {
                signsclass.Text = "Class Name";
            }
            signsclass.Font = new Font("微软雅黑", 13);
            pictureBox5.Image = Properties.Resources.classroom;
            panel6.BackColor = Color.Black;
        }

        private void signemail_Click(object sender, EventArgs e)
        {
            signemail.Clear();
            pictureBox7.Image = Properties.Resources.email2;
            panel7.BackColor = Color.FromArgb(28, 161, 242);
        }

        private void signemail_Leave(object sender, EventArgs e)
        {
            if(signemail.Text == "")
            {
                signemail.Text = "Email";
            }
            pictureBox7.Image = Properties.Resources.email;
            panel7.BackColor = Color.Black;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.male_and_female2;
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            pictureBox6.Image = Properties.Resources.male_and_female1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void signusr_TextChanged(object sender, EventArgs e)
        {

        }

        private void signpwd_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
