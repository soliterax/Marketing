using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Marketing.Framework
{
    public class CustomPanel : Panel
    {

        //Fields
        bool BORDER = false;
        int BORDER_LEFT_SIZE = 1;
        int BORDER_RIGHT_SIZE = 1;
        int BORDER_TOP_SIZE = 1;
        int BORDER_BOTTOM_SIZE = 1;
        Color BORDER_LEFT_COLOR = Color.White;
        Color BORDER_RIGHT_COLOR = Color.White;
        Color BORDER_TOP_COLOR = Color.White;
        Color BORDER_BOTTOM_COLOR = Color.White;

        //Constructor
        public CustomPanel()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                BORDER_LEFT_COLOR, BORDER_LEFT_SIZE, ButtonBorderStyle.Solid,
                BORDER_TOP_COLOR, BORDER_TOP_SIZE, ButtonBorderStyle.Solid,
                BORDER_RIGHT_COLOR, BORDER_RIGHT_SIZE, ButtonBorderStyle.Solid,
                BORDER_BOTTOM_COLOR, BORDER_BOTTOM_SIZE, ButtonBorderStyle.Solid);
        }

        public bool haveBorder
        {
            get
            {
                return this.BORDER;
            }
            set
            {
                this.BORDER = value;
            }
        }

        public int borderRightSize
        {
            get
            {
                return this.BORDER_RIGHT_SIZE;
            }
            set
            {
                this.BORDER_RIGHT_SIZE = value;
            }
        }

        public int borderLeftSize
        {
            get
            {
                return this.BORDER_LEFT_SIZE;
            }
            set
            {
                this.BORDER_LEFT_SIZE = value;
            }
        }

        public int borderTopSize
        {
            get
            {
                return this.BORDER_TOP_SIZE;
            }
            set
            {
                this.BORDER_TOP_SIZE = value;
            }
        }

        public int borderBottomSize
        {
            get
            {
                return this.BORDER_BOTTOM_SIZE;
            }
            set
            {
                this.BORDER_BOTTOM_SIZE = value;
            }
        }

        public Color borderRightColor
        {
            get
            {
                return this.BORDER_RIGHT_COLOR;
            }
            set
            {
                this.BORDER_RIGHT_COLOR = value;
            }
        }

        public Color borderLeftColor
        {
            get
            {
                return this.BORDER_LEFT_COLOR;
            }
            set
            {
                this.BORDER_LEFT_COLOR = value;
            }
        }

        public Color borderTopColor
        {
            get
            {
                return this.BORDER_TOP_COLOR;
            }
            set
            {
                this.BORDER_TOP_COLOR = value;
            }
        }

        public Color borderBottomColor
        {
            get
            {
                return this.BORDER_BOTTOM_COLOR;
            }
            set
            {
                this.BORDER_BOTTOM_COLOR = value;
            }
        }
    }
}
