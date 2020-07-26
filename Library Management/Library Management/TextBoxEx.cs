using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class TextBoxEx : TextBox
    {

        public String PlaceHolderStr { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            //
            if (!String.IsNullOrEmpty(this.PlaceHolderStr))
            {
                //坐标位置 0,0 需要根据对齐方式重新计算.
                e.Graphics.DrawString(this.PlaceHolderStr, this.Font, new SolidBrush(Color.LightGray), 0, 0);
            }
            else
            {
                base.OnPaint(e);
            }
        }
    }
}
