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
    public partial class floor2 : UserControl
    {
        private int[] flag = new int[40];
        private Panel[] seat = new Panel[38];
        private FlowLayoutPanel[] flout = new FlowLayoutPanel[10];
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
        public floor2()
        {
            InitializeComponent();
           
            int y = 29;
            int x = 19;
            int i = 1;
            MySqlConnection con = connection();
            con.Open();
            String sql = String.Format("select Sstate from tb_Seat where Slocation = '考研教室' ORDER BY Seatno+0 ");
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据到dt
            foreach (DataRow row in dt.Rows)
            {
                flag[i++] = int.Parse(row["Sstate"].ToString());
               
            }
            con.Close();
            for(i=1;i<=9;i++)
            {
                flout[i] = new FlowLayoutPanel();
                flout[i].Size = new Size(100, 100);
                if(i<=5)
                {
                    flout[i].Location = new Point(144 * (i-1) + x * i, y);
                }
                else 
                {
                    flout[i].Location = new Point(144 * (i - 6) + x * (i-5), y+121);
                }
               
                this.Controls.Add(flout[i]);
            }
            int j = 1;
            for (i = 1; i <= 36; i++)//5列
            {
               
                seat[i] = new Panel();
                seat[i].Name = i.ToString();
                seat[i].Size = new Size(35, 35);
                seat[i].BackgroundImageLayout = ImageLayout.Zoom;
                seat[i].Click += new System.EventHandler(this.seat_Click);
                if (flag[i] == 0)
                {
                    seat[i].BackgroundImage = Properties.Resources.armchair__1_;
                }
                else
                {
                    seat[i].BackgroundImage = Properties.Resources.armchair;
                    flag[i] = 2;
                }
                flout[j].Controls.Add(seat[i]);
                if (i%4==0)
                {
                    j++;
                }
            }
        }
        private Boolean IsChecked()
        {
            Boolean f = false;
            for (int i = 1; i <= 36; i++)
            {
                if (flag[i] == 1)
                {
                    f = true;
                    
                }
            }
            return f;
        }
       
        private void seat_Click(object sender, EventArgs e) // flag 0 数据库未被预约，1数据库中被预约，2界面中被选中
        {
            int num = Int32.Parse(((Panel)sender).Name.ToString());
           // MessageBox.Show(num.ToString());
            if (flag[num] == 0 && IsChecked() == false)
            {
               ((Panel)sender).BackgroundImage = Properties.Resources.armchair__2_;
                flag[num] = 1;
            }
            else 
            {

                if (flag[num] != 2)
                {
                    ((Panel)sender).BackgroundImage = Properties.Resources.armchair__1_;
                    //MessageBox.Show(flag[num].ToString());
                    flag[num] = 0;
                }
                
            }
        }
        public String getSeat()
        {
            string snum="";
            for (int i = 1; i <=36;i++)
            {
                if(flag[i]==1)
                {
                    snum =i.ToString();
                    break;
                }
            }
            
            return snum;
        }
        public void reservation()
        {
            int num = int.Parse(getSeat());
            seat[num].BackgroundImage = Properties.Resources.armchair;
            flag[num] = 2;
        }
        public void disre(string val) //取消预约
        {
            string seatno = "";
            for(int i=3;i<val.Length;i++)
            {
                seatno += val[i]; 
            }
            seat[int.Parse(seatno)].BackgroundImage = Properties.Resources.armchair__1_;
            flag[int.Parse(seatno)] = 0;
        }

    }
}
