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
    public partial class show_annc : UserControl
    {
        public show_annc()
        {
            InitializeComponent();
            announce1.Hide();
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

        private void show_annc_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GetMessage();
        }
        private DataTable GetMessage()
        {
            MySqlConnection con = connection();
            con.Open();
            string sql = "SELECT ano as 序号,content As 公告 FROM tb_Announce";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            announce1.Show();
            announce1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetMessage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
            
            MySqlConnection con = connection();
            con.Open();
            try
            {
            
               int str =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
               string sql = String.Format("delete from tb_Announce where ano ={0}",str);
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                GetMessage();
               
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            finally
            {
                con.Close();
            }

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
        }
    }
}
