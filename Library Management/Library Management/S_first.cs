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
    public partial class S_first : UserControl
    {
        public S_first()
        {
            InitializeComponent();
            

        }
        public static string tipdou = null;
        public void SetLab(string _tipdou)
        {
            tipdou = _tipdou;
        }

        public static string GetLab()
        {
            return tipdou;
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
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void S_first_Load(object sender, EventArgs e)
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
            GetMessage();
        }
        private DataTable GetMessage()
        {
            MySqlConnection con = connection();
            con.Open();
            string sql = string.Format("select C1.Sno 学号,S1.Sname,B1.Bno 索书号,B1.Bname 书名,idate 借阅日期,odate 应还日期 from tb_Check C1,tb_Book B1,tb_Student S1 where B1.Bno = C1.Bno and S1.Sno = C1.Sno and S1.Sname = '{0}'", tipdou);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            return table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetMessage();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {

                string sql = string.Format("INSERT INTO tb_Check VALUES ('{0}','{1}',NOW(),DATE_ADD(CURDATE(),INTERVAL 1 MONTH))", textBox2.Text, textBox4.Text);
                MySqlCommand cm1 = new MySqlCommand(sql, con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("借书成功");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
