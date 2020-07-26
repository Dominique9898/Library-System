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

namespace Library_Management
{
    public partial class S_second : UserControl
    {
        private string sid;
        public static String sname;
        public void setId(String val)
        {
            sname = val;
            MySqlConnection con = connection();
            con.Open();
            String sql = String.Format("select sno from tb_Student where sname = '{0}'", sname);
            sid = new MySqlCommand(sql, con).ExecuteScalar().ToString();
            con.Close();
           dateTimePicker1.MinDate = Convert.ToDateTime(DateTime.Now.ToLongDateString().ToString()); //设置最小时间，预约不能选择当前时间之前的日期。 
        }
        public S_second()
        {
            InitializeComponent();
            floor21.Hide();
            floor11.Hide();
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
           
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void S_second_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "考研教室")
            {
                floor21.Show();
                floor21.BringToFront();
            }
            else
            {
                floor21.Hide();
            }
            
        }

        private void S_second_Load(object sender, EventArgs e)
        {

        }
     
        private void btn_login_Click(object sender, EventArgs e)
        {

            if(comboBox4.SelectedIndex == 1)
            {
                String sno;
                sno = "F2S" + floor21.getSeat(); // 获取座位号
                MySqlConnection con = connection();
                con.Open();


                // MessageBox.Show(sno.ToString());
                String sql1 = String.Format("insert into tb_Reservation(Stuno,Seatno,Rdate,Rstart,Rtime) values('{0}','{1}','{2}','{3}','{4}')", sid, sno, dateTimePicker1.Text, comboBox2.Text, comboBox3.Text);
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    cmd1.ExecuteNonQuery();
                    floor21.reservation();
                    MessageBox.Show("预约成功");
                }
                catch (Exception ee)
                {
                   
                        MessageBox.Show("您已预约，请取消预约重新选座。");
                   
                }
                finally
                {
                    con.Close();
                }

            }
            if(comboBox4.SelectedIndex == 2)
            {
                String sno;
                sno = "F1S" + floor11.getSeat(); // 获取座位号
                MySqlConnection con = connection();
                con.Open();
                String sql1 = String.Format("insert into tb_Reservation(Stuno,Seatno,Rdate,Rstart,Rtime) values('{0}','{1}','{2}','{3}','{4}')", sid, sno, dateTimePicker1.Text, comboBox2.Text, comboBox3.Text);
                try
                {
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    cmd1.ExecuteNonQuery();
                    floor11.reservation();
                    MessageBox.Show("预约成功");
                }
                catch (Exception ee)
                {
                    
                        MessageBox.Show("您已预约，请取消预约重新选座。");
                    
                }
                finally
                {
                    con.Close();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string val="";

           // MessageBox.Show(sid);
            MySqlConnection con = connection();
            con.Open();
            try
            {
                    if(comboBox4.SelectedIndex == 1)
                    {
                             String sql = String.Format("select Seatno from tb_Reservation where Stuno = '{0}'", sid);
                                val = new MySqlCommand(sql, con).ExecuteScalar().ToString();
                                floor21.disre(val); //传送座位号
                                //MessageBox.Show(val);
                                String sql1 = String.Format("delete from tb_Reservation where Stuno = '{0}'", sid); //删除预约
                               MySqlCommand cmd = new MySqlCommand(sql1, con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("取消预约成功");
                                //con.Close();
                    }
                    if(comboBox4.SelectedIndex == 2)
                    {
                        String sql = String.Format("select Seatno from tb_Reservation where Stuno = '{0}'", sid); // 从预约记录里获取改学生选座的位置
                        val = new MySqlCommand(sql, con).ExecuteScalar().ToString();
                        floor11.disre(val); //传送座位号
                                            //MessageBox.Show(val);
                        String sql1 = String.Format("delete from tb_Reservation where Stuno = '{0}'", sid); //删除预约
                        MySqlCommand cmd = new MySqlCommand(sql1, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("取消预约成功");
                        //con.Close();
                    }
            }
            catch(Exception ee)
            {
                  MessageBox.Show("您已预约，请取消预约");
            }
            finally
            {
                con.Close();
            }
            
            

        }

        private void comboBox4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(comboBox4.SelectedIndex == 1)
            {
                floor21.Show();
                floor21.BringToFront();
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                floor11.Show();
                floor11.BringToFront();
            }
            else
            {
                floor21.Hide();
                floor11.Hide();
            }
        }
    }
}
