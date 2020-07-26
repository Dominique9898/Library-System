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
    public partial class announce : UserControl
    {
        public announce()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "cdb-76uuco6h.gz.tencentcdb.com";
            sb.Port = 10132;
            sb.Database = "Library";
            sb.UserID = "root";
            sb.Password = "Birdy123";
            MySqlConnection con = new MySqlConnection(sb.ConnectionString);//实例化连接
            con.Open();
            try
            {
                string sql = string.Format("insert into tb_Announce values(null,'{0}')", textBox1.Text);
                MySqlCommand cm1 = new MySqlCommand(sql, con);
                cm1.ExecuteNonQuery();
                MessageBox.Show("发布成功");
                this.Hide();
                textBox1.Clear();
                

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
       
        private void announce_Leave(object sender, EventArgs e)
        {

        }
    }
}
