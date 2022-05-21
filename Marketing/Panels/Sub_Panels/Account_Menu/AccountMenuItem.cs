using Marketing.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels.Sub_Panels.Account_Menu
{
    public class AccountMenuItem : Utils.Interfaces.PanelTemplate
    {
        CustomPanel panel = new CustomPanel();
        CustomPictureBox image = new CustomPictureBox();
        Label textLabel = new Label();

        //Fields
        Color BACK_COLOR = Color.Black;
        Color FONT_COLOR = Color.White;
        Image IMAGE = null;
        string ITEM_TEXT;


        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size(size.Width, (int)(size.Height * 0.20));
            panel.Name = "accountMenuItem";
            panel.BackColor = Color.Transparent;
            panel.Click += Click_Event;
            panel.borderTopSize = 0;
            

            image.Size = new Size((int)(panel.Size.Height * 0.98), (int)(panel.Size.Height * 0.98));
            image.Location = new Point((int)(panel.Size.Width * 0.08) / 2, (int)(panel.Size.Height * 0.02) / 2);
            image.Name = "image";
            image.BackColor = BACK_COLOR;
            image.Image = IMAGE;
            image.SizeMode = PictureBoxSizeMode.StretchImage;
            image.Click += Click_Event;

            textLabel.Size = new Size(panel.Size.Width - (image.Size.Width + image.Location.X), (int)(panel.Size.Height * 0.98));
            textLabel.Location = new Point(image.Location.X + image.Size.Width, image.Location.Y);
            textLabel.Name = "textLabel";
            textLabel.BackColor = BACK_COLOR;
            textLabel.ForeColor = FONT_COLOR;
            textLabel.Text = ITEM_TEXT;
            textLabel.TextAlign = ContentAlignment.MiddleCenter;
            textLabel.Click += Click_Event;

            panel.Controls.Add(image);
            panel.Controls.Add(textLabel);

        }

        protected virtual void Click_Event(object sender, EventArgs e)
        {

        }

        public void SetPanel(Control control)
        {
            this.panel = (CustomPanel)control;
        }

        public Color backColor
        {
            get
            {
                return BACK_COLOR;
            }
            set
            {
                this.BACK_COLOR = value;
            }
        }

        public Color fontColor
        {
            get
            {
                return FONT_COLOR;
            }
            set
            {
                this.FONT_COLOR = value;
            }
        }

        public Image itemImage
        {
            get
            {
                return IMAGE;
            }
            set
            {
                this.IMAGE = value;
            }
        }

        public string itemText
        {
            get
            {
                return ITEM_TEXT;
            }
            set
            {
                this.ITEM_TEXT = value;
            }
        }
    }
}
