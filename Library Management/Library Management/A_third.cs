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
    public partial class A_third : UserControl
    {
        public A_third()
        {
            InitializeComponent();
        }

        private MySqlConnection connection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "cdb-76uuco6h.gz.tencentcdb.com"; //
            sb.Port = 10132;
            sb.Database = "Library";
            sb.UserID = "root";
            sb.Password = "Birdy123";
            MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
            return con;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void A_third_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; //美化datagridview1
            GetMessage();
        }
        public DataTable GetMessage()
        {
            MySqlConnection con = connection();
            con.Open();
            string sql = "SELECT Bno as 条码号,Bname as 书名,Bauthor as 作者,Blocation As 馆藏地,Bisthere As 书刊状态 FROM tb_Book";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            return table;   
        }

       

        private void btn_login_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                string sql = string.Format("insert into tb_Book values('{0}','{1}','{2}','{3}','{4}')", text_tmh.Text, text_name.Text, text_auther.Text, text_location.Text,"可借");

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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {

                string sql = string.Format("update tb_Book set Bname = '{0}',Bauthor= '{1}', Blocation = '{2}' where Bno = {3}", text_name.Text, text_auther.Text, text_location.Text,text_tmh.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                string sql = string.Format("delete from tb_Book where Bno = '{0}'", text_tmh.Text);
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            text_tmh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            text_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            text_auther.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            text_location.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void A_third_Click(object sender, EventArgs e)
        {
          //  GetMessage();
        }

        private void text_tmh_Click(object sender, EventArgs e)
        {
            text_tmh.Clear();
        }

        private void text_tmh_Leave(object sender, EventArgs e)
        {
            if(text_tmh.Text == "")
            {
                text_tmh.Text = "索书号";
            }
        }

        private void text_auther_Click(object sender, EventArgs e)
        {
            text_auther.Clear();
        }

        private void text_auther_Leave(object sender, EventArgs e)
        {
            if (text_auther.Text == "")
            {
                text_auther.Text = "作者";
            }
        }

        private void text_name_Click(object sender, EventArgs e)
        {
            text_name.Clear();
        }

        private void text_name_Leave(object sender, EventArgs e)
        {
            if (text_name.Text == "")
            {
                text_name.Text = "书名";
            }
        }

        private void text_location_Click(object sender, EventArgs e)
        {
            text_location.Clear();
            
        }

        private void text_location_Leave(object sender, EventArgs e)
        {
            if (text_location.Text == "")
            {
                text_location.Text = "馆藏地";
            }
        }
    }
}
