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
    public partial class A_first : UserControl
    {
        public A_first()
        {
            InitializeComponent();
            show_annc1.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void getMessage()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "cdb-76uuco6h.gz.tencentcdb.com";
            sb.Port = 10132;
            sb.Database = "Library";
            sb.UserID = "root";
            sb.Password = "Birdy123";
          
            MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
            try
            {

                con.Open();
                string sq = "select Count(Bno) from tb_Book";
                label4.Text = new MySqlCommand(sq, con).ExecuteScalar().ToString();
                sq = "select Count(Sno) from tb_Student";
                label2.Text = new MySqlCommand(sq, con).ExecuteScalar().ToString(); //将数据库的select count（*）的值赋给label的text
                sq = "select Count(Ano) from tb_Admin";
                label3.Text = new MySqlCommand(sq, con).ExecuteScalar().ToString();
                sq = "select Count(ano) from tb_Announce";
                label5.Text = new MySqlCommand(sq, con).ExecuteScalar().ToString();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
        public void A_first_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            show_annc1.Show();
        }

        private void show_annc1_Load(object sender, EventArgs e)
        {

        }
    }
}
