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
    public partial class A_second : UserControl
    {
        public A_second()
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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void AdminofStudentPagecs_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
           // textBox5.ReadOnly = true;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            GetMessage();
        }
        public DataTable GetMessage()
        {
            MySqlConnection con = connection();
            con.Open();
            string sql = "select Sno As 学号,Sname As 姓名,Sclass As 班级,Ssex As 性别,Semail As 邮箱 from tb_Student";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            return table;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string sex = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if(sex == "男")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                string sql= string.Format("insert into tb_Student values('{0}','{1}','{2}','{3}','{4}')", textBox2.Text, textBox3.Text, textBox1.Text, comboBox1.Text, textBox4.Text);
                       
                MySqlCommand cm1 = new MySqlCommand(sql, con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("插入成功");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                GetMessage();
                con.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                string sql = string.Format("delete from tb_Student where sno = '{0}'", textBox2.Text);
                // 建立SqlDataAdapter和DataSet对象        
                MySqlCommand cm1 = new MySqlCommand(sql, con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("删除成功");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                GetMessage();
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {

                string sql = string.Format("update tb_Student set Sname = '{0}',Sclass= '{1}', Ssex = '{2}', Semail='{3}' where sno = {4}",textBox3.Text, textBox1.Text, comboBox1.Text, textBox4.Text, textBox2.Text);
                // 建立SqlDataAdapter和DataSet对象        
                MySqlCommand cm1 = new MySqlCommand(sql, con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("修改成功");


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                GetMessage();
                con.Close();
            }
        }


        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                textBox2.Text = "学号";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                textBox3.Text = "姓名";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "班级";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "邮箱";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.Text;
        }
    }
}
