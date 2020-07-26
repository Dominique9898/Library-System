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
    public partial class A_fourth : UserControl
    {
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
        public A_fourth()
        {
            InitializeComponent();
        }

        private void A_fourth_Load(object sender, EventArgs e)
        {
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
        private DataTable GetMessage()
        {
            MySqlConnection con = connection();
            con.Open();
            string sql = "SELECT R1.Rno 序号,R1.Stuno 学生学号,S1.Sname 姓名,R1.Seatno 座位编号,S2.Slocation 地点,R1.Rdate 日期,R1.Rstart 开始时间,R1.Rtime 时长 FROM tb_Reservation R1,tb_Student S1,tb_Seat S2 where R1.Stuno = S1.Sno and R1.Seatno = S2.Seatno;";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            return table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection con = connection();
            con.Open();
            String var = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String sql = String.Format("delete from tb_Reservation where Stuno = '{0}'", var);
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功");
            GetMessage();
        }
    }
}
