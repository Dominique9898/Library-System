using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Org.BouncyCastle.Asn1.Crmf;
using MySql.Data.MySqlClient;

namespace Library_Management
{
    public partial class floor1 : UserControl
    {
        private int[] flag = new int[31]; // 1为选择，0为取消or未选择。
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
        public floor1()
        {
            InitializeComponent();
            int i = 1;
            MySqlConnection con = connection();
            con.Open();
            String sql = String.Format("select Sstate from tb_Seat where Slocation = '阅览室' ORDER BY Seatno+0 ");
            MySqlDataAdapter sda = new MySqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);//填充数据到dt
            foreach (DataRow row in dt.Rows)
            {
                flag[i++] = int.Parse(row["Sstate"].ToString());

            }
            Findres(); // 初始化后台数据里的预约情况将已经预约的位置设成2.
        }
        private void Findres()
        {
            for (int i = 1; i <= 30; i++)//5列
            {
                if (flag[i] == 1)
                {
                    string val = "F1S" + i.ToString();
                    // MessageBox.Show(val);
                    object seat = this.GetType().GetField(val, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
                    ((Panel)seat).BackgroundImage = Properties.Resources.armchair;
                    flag[i] = 2;
                }
            }
            
        }
        private Boolean IsChecked()
        {
            Boolean f = false;
            for (int i = 1; i <= 30; i++)
            {
                if (flag[i] == 1)
                {
                    f = true;

                }
            }
            return f;
        }
        public String getSeat()
        {
            string snum = "";
            for (int i = 1; i <= 30; i++)
            {
                if (flag[i] == 1)
                {
                    snum = i.ToString();
                    break;
                }
            }

            return snum;
        }
        public void reservation()
        {
            string val = "F1S" + getSeat();
            object seat = this.GetType().GetField(val, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Panel)seat).BackgroundImage = Properties.Resources.armchair;
            flag[int.Parse(getSeat())] = 2;
        }

        public void disre(string val) //取消预约
        {
            string seatno = "";
            for (int i = 3; i < val.Length; i++)
            {
                seatno += val[i];
            }
            object seat = this.GetType().GetField(val, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this);
            ((Panel)seat).BackgroundImage = Properties.Resources.armchair__1_;
            flag[int.Parse(seatno)] = 0;
        }

        private void F1S001_Click(object sender, EventArgs e)
        {
            if (flag[1] == 0 && IsChecked() == false )
            {
                F1S1.BackgroundImage = Properties.Resources.armchair__2_;
                flag[1] = 1;
            }
            else
            {
                if (flag[1] != 2)
                {
                    F1S1.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[1] = 0;
                }
            }
           
        }

        private void F1S002_Click(object sender, EventArgs e)
        {
            if (flag[2] == 0 && IsChecked() == false)
            {
                F1S2.BackgroundImage = Properties.Resources.armchair__2_;
                flag[2] = 1;
            }
            else
            {
                if (flag[2] != 2) {
                    F1S2.BackgroundImage = Properties.Resources.armchair__1_;
                flag[2] = 0;
                }
                    
            }
        }

        private void F1S003_Click(object sender, EventArgs e)
        {
            if (flag[3] == 0 && IsChecked() == false )
            {
                F1S3.BackgroundImage = Properties.Resources.armchair__2_;
                flag[3] = 1;
            }
            else
            {
                if (flag[3] != 2)
                {
                    F1S3.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[3] = 0;
                }
            }
        }

        private void F1S004_Click(object sender, EventArgs e)
        {
            if (flag[4] == 0 && IsChecked() == false)
            {
                F1S4.BackgroundImage = Properties.Resources.armchair__2_;
                flag[4] = 1;
            }
            else
            {
                if (flag[4] != 2)
                {
                    F1S4.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[4] = 0;
                }
            }
        }

        

        private void F1S006_Click(object sender, EventArgs e)
        {
            if (flag[6] == 0 && IsChecked() == false)
            {
                F1S6.BackgroundImage = Properties.Resources.armchair__2_;
                flag[6] = 1;
            }
            else
            {
                if (flag[6] != 2)
                {
                    F1S6.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[6] = 0;
                }
            }
        }

        private void F1S005_Click(object sender, EventArgs e)
        {
            if (flag[5] == 0 && IsChecked() == false)
            {
                F1S5.BackgroundImage = Properties.Resources.armchair__2_;
                flag[5] = 1;
            }
            else
            {
                if (flag[5] != 2)
                {
                    F1S5.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[5] = 0;
                }
            }
        }

        private void F1S007_Click(object sender, EventArgs e)
        {
            if (flag[7] == 0 && IsChecked() == false)
            {
                F1S7.BackgroundImage = Properties.Resources.armchair__2_;
                flag[7] = 1;
            }
            else
            {
                if (flag[7] != 2)
                {
                    F1S7.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[7] = 0;
                }
            }
        }

        private void floor1_Load(object sender, EventArgs e)
        {

        }

        private void F1S007_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F1S008_Click(object sender, EventArgs e)
        {
            if (flag[8] == 0 && IsChecked() == false)
            {
                F1S8.BackgroundImage = Properties.Resources.armchair__2_;
                flag[8] = 1;
            }
            else
            {
                if (flag[8] != 2)
                {
                    F1S8.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[8] = 0;
                }
            }
        }

        private void F1S009_Click(object sender, EventArgs e)
        {
            if (flag[9] == 0 && IsChecked() == false)
            {
                F1S9.BackgroundImage = Properties.Resources.armchair__2_;
                flag[9] = 1;
            }
            else
            {
                if (flag[9] != 2)
                {
                    F1S9.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[9] = 0;
                }
            }
        }

        private void F1S0010_Click(object sender, EventArgs e)
        {
            if (flag[10] == 0 && IsChecked() == false)
            {
                F1S10.BackgroundImage = Properties.Resources.armchair__2_;
                flag[10] = 1;
            }
            else
            {
                if (flag[10] != 2)
                {
                    F1S10.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[10] = 0;
                }
            }
        }

        private void F1S0011_Click(object sender, EventArgs e)
        {
            if (flag[11] == 0 && IsChecked() == false)
            {
                F1S11.BackgroundImage = Properties.Resources.armchair__2_;
                flag[11] = 1;
            }
            else
            {
                if (flag[11] != 2)
                {
                    F1S11.BackgroundImage = Properties.Resources.armchair__1_;
                    flag[11] = 0;
                }
            }
        }

        private void F1S0012_Click(object sender, EventArgs e)
        {
            if (flag[12] == 0 && IsChecked() == false)
            {
                F1S12.BackgroundImage = Properties.Resources.armchair__2_;
                flag[12] = 1;
            }
            else
            {
                if (flag[12] != 2)
                {F1S12.BackgroundImage = Properties.Resources.armchair__1_;
                flag[12] = 0;
                }
                    
            }
        }

        private void F1S0013_Paint(object sender, PaintEventArgs e)
        {
        }

        private void F1S0014_Click(object sender, EventArgs e)
        {
            if (flag[14] == 0 && IsChecked() == false)
            {
                F1S14.BackgroundImage = Properties.Resources.armchair__2_;
                flag[14] = 1;
            }
            else
            {
                if (flag[14] != 2) {F1S14.BackgroundImage = Properties.Resources.armchair__1_;
                flag[14] = 0;
                }
                    
            }
        }

        private void F1S0015_Click(object sender, EventArgs e)
        {
            if (flag[15] == 0 && IsChecked() == false)
            {
                F1S15.BackgroundImage = Properties.Resources.armchair__2_;
                flag[15] = 1;
            }
            else
            {
                if (flag[15] != 2) {F1S15.BackgroundImage = Properties.Resources.armchair__1_;
                flag[15] = 0;
                }
                    
            }
        }

        private void F1S0016_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F1S0013_Click(object sender, EventArgs e)
        {
            if (flag[13] == 0 && IsChecked() == false)
            {
                F1S13.BackgroundImage = Properties.Resources.armchair__2_;
                flag[13] = 1;
            }
            else
            {
                if (flag[13] != 2)
                { F1S13.BackgroundImage = Properties.Resources.armchair__1_;
                flag[13] = 0;

                }
                   
            }
        }

        private void F1S0016_Click(object sender, EventArgs e)
        {
            if (flag[16] == 0 && IsChecked() == false)
            {
                F1S16.BackgroundImage = Properties.Resources.armchair__2_;
                flag[16] = 1;
            }
            else
            {
                if (flag[16] != 2)
                {
                     F1S16.BackgroundImage = Properties.Resources.armchair__1_;
                                    flag[16] = 0;
                }
                   
            }
        }

        private void F1S0017_Click(object sender, EventArgs e)
        {
            if (flag[17] == 0 && IsChecked() == false)
            {
                F1S17.BackgroundImage = Properties.Resources.armchair__2_;
                flag[17] = 1;
            }
            else
            {
                if (flag[17] != 2) { F1S17.BackgroundImage = Properties.Resources.armchair__1_;
                flag[17] = 0;
                }
                   
            }
        }

        private void F1S0018_Click(object sender, EventArgs e)
        {
            if (flag[18] == 0 && IsChecked() == false)
            {
                F1S18.BackgroundImage = Properties.Resources.armchair__2_;
                flag[18] = 1;
            }
            else
            {
                if (flag[18] != 2) {F1S18.BackgroundImage = Properties.Resources.armchair__1_;
                flag[18] = 0;
                }
                    
            }
        }

        private void F1S0019_Click(object sender, EventArgs e)
        {
            if (flag[19] == 0 && IsChecked() == false)
            {
                F1S19.BackgroundImage = Properties.Resources.armchair__2_;
                flag[19] = 1;
            }
            else
            {
                if (flag[19] != 2)
                {
                    F1S19.BackgroundImage = Properties.Resources.armchair__1_;
                                    flag[19] = 0;
                }
                    
            }
        }

        private void F1S0020_Click(object sender, EventArgs e)
        {
            if (flag[20] == 0 && IsChecked() == false)
            {
                F1S20.BackgroundImage = Properties.Resources.armchair__2_;
                flag[20] = 1;
            }
            else
            {
                if (flag[20] != 2)
                {
                    F1S20.BackgroundImage = Properties.Resources.armchair__1_;
                                    flag[20] = 0;
                }
                    
            }
        }

        private void F1S0021_Leave(object sender, EventArgs e)
        {

        }

        private void F1S0021_Click(object sender, EventArgs e)
        {
            if (flag[21] == 0 && IsChecked() == false)
            {
                F1S21.BackgroundImage = Properties.Resources.armchair__2_;
                flag[21] = 1;
            }
            else
            {
                if (flag[21] != 2)
                {
                    F1S21.BackgroundImage = Properties.Resources.armchair__1_;
                                    flag[21] = 0;
                }
                    
            }
        }

        private void F1S0022_Click(object sender, EventArgs e)
        {
            if (flag[22] == 0 && IsChecked() == false)
            {
                F1S22.BackgroundImage = Properties.Resources.armchair__2_;
                flag[22] = 1;
            }
            else
            {
                F1S22.BackgroundImage = Properties.Resources.armchair__1_;
                flag[22] = 0;
            }
        }

        private void F1S0023_Click(object sender, EventArgs e)
        {
            if (flag[23] == 0 && IsChecked() == false)
            {
                F1S23.BackgroundImage = Properties.Resources.armchair__2_;
                flag[23] = 1;
            }
            else
            {
                if (flag[23] != 2)
                {
                        F1S23.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[23] = 0;
                }
                    
            }
        }

        private void F1S0024_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F1S0024_Click(object sender, EventArgs e)
        {
            if (flag[24] == 0 && IsChecked() == false)
            {
                F1S24.BackgroundImage = Properties.Resources.armchair__2_;
                flag[24] = 1;
            }
            else
            {
                if (flag[24] != 2)
                {
                        F1S24.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[24] = 0;
                }
                    
            }
        }

        private void F1S0025_Click(object sender, EventArgs e)
        {
            if (flag[25] == 0 && IsChecked() == false)
            {
                F1S25.BackgroundImage = Properties.Resources.armchair__2_;
                flag[25] = 1;
            }
            else
            {
                if (flag[25] != 2)
                {
                     F1S25.BackgroundImage = Properties.Resources.armchair__1_;
                                    flag[25] = 0;
                }
                   
            }
        }

        private void F1S0026_Click(object sender, EventArgs e)
        {
            if (flag[26] == 0 && IsChecked() == false)
            {
                F1S26.BackgroundImage = Properties.Resources.armchair__2_;
                flag[26] = 1;
            }
            else
            {
                if (flag[26] != 2)
                {
                         F1S26.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[26] = 0;
                }
                   
            }
        }

        private void F1S0027_Click(object sender, EventArgs e)
        {
            if (flag[27] == 0 && IsChecked() == false)
            {
                F1S27.BackgroundImage = Properties.Resources.armchair__2_;
                flag[27] = 1;
            }
            else
            {
                if (flag[27] != 2)
                {
                        F1S27.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[27] = 0;
                }
                    
            }
        }

        private void F1S0028_Click(object sender, EventArgs e)
        {
            if (flag[28] == 0 && IsChecked() == false)
            {
                F1S28.BackgroundImage = Properties.Resources.armchair__2_;
                flag[28] = 1;
            }
            else
            {
                if (flag[28] != 2)
                {
                        F1S28.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[28] = 0;
                }
                    
            }
        }

        private void F1S0029_Click(object sender, EventArgs e)
        {
            if (flag[29] == 0 && IsChecked() == false)
            {
                F1S29.BackgroundImage = Properties.Resources.armchair__2_;
                flag[29] = 1;
            }
            else
            {
                if (flag[29] != 2)
                {
                        F1S29.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[29] = 0;
                }
                    
            }
        }

        private void F1S0030_Click(object sender, EventArgs e)
        {
            if (flag[30] == 0 && IsChecked() == false)
            {
                F1S30.BackgroundImage = Properties.Resources.armchair__2_;
                flag[30] = 1;
            }
            else
            {
                if (flag[30] != 2)
                {
                         F1S30.BackgroundImage = Properties.Resources.armchair__1_;
                                        flag[30] = 0;
                }
                   
            }
        }

    }
}
