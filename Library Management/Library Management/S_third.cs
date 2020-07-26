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
    public partial class S_third : UserControl
    {
        private int option = 1; // 1书名，2作者，3关键词，4.索书号
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
        public S_third()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        } 

        private void S_third_Load(object sender, EventArgs e)
        {
            if(textBox4.Text.ToString()=="")
            {
                label1.Show();
            }
            dataGridView1.Hide();

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ForeColor = Color.Black;

            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView2.ForeColor = Color.Black;
            string sql = string.Format("select Bname 书名,Bauthor 作者 from tb_Book order by Bcnt DESC limit 8");
            GetMessage(sql,0);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            dataGridView1.Show();
            dataGridView1.BringToFront();
            String sql;
            //按书名查找
            if (option == 1)
            {
                if(textBox4.Text == "")
                {
                    sql = string.Format("select Bno 索书号,Bname 书名,Bauthor 作者,Blocation 馆藏处,Bisthere 状态 from tb_Book");
                    GetMessage(sql,1);
                }
                else
                {
                    sql = string.Format("select Bno 索书号,Bname 书名,Bauthor 作者,Blocation 馆藏处,Bisthere 状态 from tb_Book where Bname= '{0}'", textBox4.Text);
                    GetMessage(sql,1);
                }
                    
             }
            //按作者查找
            if(option == 2)
            {
                sql = string.Format("select Bno 索书号,Bname 书名,Bauthor 作者,Blocation 馆藏处,Bisthere 状态 from tb_Book where Bauthor LIKE '%{0}'", textBox4.Text);
                GetMessage(sql,1);
            }
            //按关键词查找
            if(option == 3)
            {
                sql = string.Format("select Bno 索书号,Bname 书名,Bauthor 作者,Blocation 馆藏处,Bisthere 状态 from tb_Book where Bname LIKE '%{0}%'", textBox4.Text);
                GetMessage(sql,1);
            }

            //按索书号查找
            if(option == 4)
            {
                sql = string.Format("select Bno 索书号,Bname 书名,Bauthor 作者,Blocation 馆藏处,Bisthere 状态 from tb_Book where Bno= {0}", textBox4.Text);
                GetMessage(sql,1);
            }
        }
        private DataTable GetMessage(String str,int option)
        {
            MySqlConnection con = connection();
            con.Open();
            String sql = str;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (option == 1)
            {
                dataGridView1.DataSource = table;
            }
            else
            {
                dataGridView2.DataSource = table;
            }
            return table;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            option = 2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            option = 4;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            option = 3;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            option = 1;
        }
    }
}
