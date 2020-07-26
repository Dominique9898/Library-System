using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;

namespace Library_Management
{
    public partial class A_fifth : UserControl
    {
        public A_fifth()
        {
            InitializeComponent();
        }
        private MySqlConnection connection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "cdb-76uuco6h.gz.tencentcdb.com";
            sb.Port = 10132;
            sb.Database = "Library";
            sb.UserID = "root";
            sb.Password = "Birdy123";
            MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
            return con;
        }
        private void A_fifth_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ForeColor = Color.Black;

        }
        private DataTable GetMessage()
        {
            MySqlConnection con = connection();
            con.Open();

            string sql = string.Format("select C1.Sno 学号,S1.Sname 姓名,B1.Bno 索书号,B1.Bname 书名,idate 借阅日期,odate 应还日期 ,S1.Semail 邮箱 from tb_Check C1,tb_Book B1,tb_Student S1 where B1.Bno = C1.Bno and S1.Sno = C1.Sno and C1.Sno='{0}'", textBox1.Text);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            return table;
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                string sql1 = string.Format("select Bisthere from tb_Book where Bno = '{0}'", textBox4.Text);
                string state = new MySqlCommand(sql1, con).ExecuteScalar().ToString();
                if (state == "不可借")
                {
                    MessageBox.Show("该书已借出，当前不可借阅");
                }
                else
                {
                    string sql = string.Format("INSERT INTO tb_Check VALUES ('{0}','{1}',NOW(),DATE_ADD(CURDATE(),INTERVAL 1 MONTH))", textBox2.Text, textBox4.Text);
                    MySqlCommand cm1 = new MySqlCommand(sql, con);
                    cm1.ExecuteNonQuery();
                    MessageBox.Show("借书成功");
                }
            }
            catch(Exception ee)
            {

                MessageBox.Show(ee.ToString());
            }
            finally
            {
                GetMessage();
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            GetMessage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                string sql = string.Format("DELETE from tb_Check where Sno = '{0}' and Bno = '{1}'", textBox5.Text, textBox3.Text);
                MySqlCommand cm1 = new MySqlCommand(sql, con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("还书成功");
                GetMessage();
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient("smtp.qq.com");   //设置邮件协议
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;//这一句得写前面
            client.DeliveryMethod = SmtpDeliveryMethod.Network; //通过网络发送到Smtp服务器
            client.Credentials = new NetworkCredential("826931133@qq.com", "aymzgquduypbbcje"); //qq邮箱  和 授权码
            MailMessage mmsg = new MailMessage(new MailAddress("826931133@qq.com"), new MailAddress(textBox6.Text)); //发件人和收件人的邮箱地址
            mmsg.Subject = "测试";      //邮件主题
            mmsg.SubjectEncoding = Encoding.UTF8;   //主题编码
            mmsg.Body = textBox7.Text;         //邮件正文
            mmsg.BodyEncoding = Encoding.UTF8;      //正文编码
            mmsg.IsBodyHtml = true;    //设置为HTML格式          
            mmsg.Priority = MailPriority.High;   //优先级         
            try
            {
                client.Send(mmsg);
                MessageBox.Show("邮件已发成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
