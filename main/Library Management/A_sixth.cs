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
    public partial class A_sixth : UserControl
    {
        public A_sixth()
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
  
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void A_sixth_Load(object sender, EventArgs e)
        {
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ForeColor = Color.Black;
    
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
            String sql = String.Format("SELECT A1.Ano 编号,U1.Ausr 用户名,A1.Aname 姓名,A1.Asex 性别 from tb_Admin A1,tb_User_admin U1 where U1.Ano = A1.Ano ");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table;
            return table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            try
            {
                String sql = String.Format("insert into tb_User_admin values('{0}','{1}','{2}')", textBox8.Text, textBox2.Text, textBox4.Text);
                String sql1 = String.Format("insert into tb_Admin values('{0}','{1}','{2}')", textBox8.Text, textBox1.Text, comboBox1.Text);
                MySqlCommand cmd = new MySqlCommand(sql1, con);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd1 = new MySqlCommand(sql, con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("插入成功");
                GetMessage();
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void a_fourth1_Load(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            String var = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            String sql = String.Format("delete from tb_Admin where Ano = '{0}'", var);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功");
            GetMessage();

        }
    }
}
