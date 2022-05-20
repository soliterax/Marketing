using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Framework
{
    public class CustomLabel : Label
    {
        int BORDER_SIZE = 5;
        Color BORDER_COLOR = Color.White;
        Color TOP_BORDER_COLOR = Color.White;

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Watermark color")]
        [DisplayName("WaterMark Color")]
        public int BorderSize
        {
            get
            {
                return BORDER_SIZE;
            }
            set
            {
                this.BORDER_SIZE = value;
            }
        }
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets Watermark color")]
        [DisplayName("WaterMark Color")]
        public Color BorderColor
        {
            get
            {
                return BORDER_COLOR;
            }
            set
            {
                this.BORDER_COLOR = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid,
                                         BORDER_COLOR, BORDER_SIZE, ButtonBorderStyle.Solid);
        }
    }
}
