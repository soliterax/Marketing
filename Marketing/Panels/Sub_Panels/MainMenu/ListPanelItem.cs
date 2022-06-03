using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Interfaces;
using SoliteraxControlLibrary;

namespace Marketing.Panels.Sub_Panels.MainMenu
{
    public class ListPanelItem : PanelTemplate
    {

        Panel panel = new Panel();

        Product PRODUCT;
        Color BACKCOLOR;
        Color FORECOLOR;

        CustomLabel lbl_count = new CustomLabel();
        CustomLabel lbl_name = new CustomLabel();
        CustomLabel lbl_category = new CustomLabel();
        CustomLabel lbl_Price = new CustomLabel();

        Panel buttonPanel = new Panel();
        PictureBox remove = new PictureBox();

        public void InitializeComponents(Size size)
        {
            if (PRODUCT == null)
                throw new SystemException();

            panel.Size = new Size(size.Width, (int)(size.Height * 0.08));
            panel.Name = "ListPanelItem";
            panel.BackColor = BACKCOLOR;

            buttonPanel.Size = panel.Size;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.BackColor = BACKCOLOR;
            buttonPanel.Click += Button_Click;

            lbl_count.Size = new Size(panel.Size.Width / 4, panel.Size.Height);
            lbl_count.Location = new Point(0, 0);
            lbl_count.Name = "lbl_count";
            lbl_count.BackColor = BACKCOLOR;
            lbl_count.ForeColor = FORECOLOR;
            lbl_count.BorderColor = FORECOLOR;
            lbl_count.haveBorder = true;
            lbl_count.BorderSize = 1;
            lbl_count.Text = PRODUCT.product_Amount.ToString();
            lbl_count.TextAlign = ContentAlignment.MiddleCenter;
            lbl_count.Click += Button_Click;

            lbl_name.Size = lbl_count.Size;
            lbl_name.Location = new Point(lbl_count.Size.Width, 0);
            lbl_name.Name = "lbl_name";
            lbl_name.BackColor = BACKCOLOR;
            lbl_name.ForeColor = FORECOLOR;
            lbl_name.BorderColor = FORECOLOR;
            lbl_name.haveBorder = true;
            lbl_name.BorderSize = lbl_count.BorderSize;
            lbl_name.Text = PRODUCT.product_Name;
            lbl_name.TextAlign = lbl_count.TextAlign;
            lbl_name.Click += Button_Click;

            lbl_category.Size = lbl_count.Size;
            lbl_category.Location = new Point(lbl_name.Location.X + lbl_name.Size.Width, 0);
            lbl_category.Name = "lbl_category";
            lbl_category.BackColor = BACKCOLOR;
            lbl_category.ForeColor = FORECOLOR;
            lbl_category.BorderColor = FORECOLOR;
            lbl_category.haveBorder = true;
            lbl_category.BorderSize = lbl_count.BorderSize;
            lbl_category.Text = PRODUCT.product_Category.category_Name;
            lbl_category.TextAlign = lbl_count.TextAlign;
            lbl_category.Click += Button_Click;

            lbl_Price.Size = lbl_count.Size;
            lbl_Price.Location = new Point(lbl_category.Location.X + lbl_category.Size.Width, 0);
            lbl_Price.Name = "lbl_name";
            lbl_Price.BackColor = BACKCOLOR;
            lbl_Price.ForeColor = FORECOLOR;
            lbl_Price.BorderColor = FORECOLOR;
            lbl_Price.haveBorder = true;
            lbl_Price.BorderSize = lbl_count.BorderSize;
            lbl_Price.Text = PRODUCT.product_Price.ToString();
            lbl_Price.TextAlign = lbl_count.TextAlign;
            lbl_Price.Click += Button_Click;

            remove.Size = new Size((int)(panel.Size.Height * 0.88), (int)(panel.Size.Height * 0.88));
            remove.Location = new Point(((buttonPanel.Size.Width / 2) - (remove.Size.Width)), (buttonPanel.Size.Height / 2) - (remove.Size.Height / 2));
            remove.BackColor = Color.Transparent;
            remove.Name = "removeButton";
            remove.Image = Properties.Resources.RemovePictureButton;
            remove.SizeMode = PictureBoxSizeMode.StretchImage;
            remove.Click += Remove_Click;

            buttonPanel.Controls.Add(remove);

            buttonPanel.Visible = false;

            panel.Controls.Add(buttonPanel);
            panel.Controls.Add(lbl_count);
            panel.Controls.Add(lbl_name);
            panel.Controls.Add(lbl_category);
            panel.Controls.Add(lbl_Price);

        }

        private void Remove_Click(object sender, EventArgs e)
        {
            panel.Dispose();
            itemDestroyed.Invoke(this, null);
        }

        public event EventHandler itemDestroyed;

        private void Button_Click(object sender, EventArgs e)
        {
            if (buttonPanel.Visible)
                buttonPanel.Visible = false;
            else
                buttonPanel.Visible = true;
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }

        public Product product
        {
            get
            {
                return PRODUCT;
            }
            set
            {
                this.PRODUCT = value;
            }
        }

        public Color backColor
        {
            get
            {
                return BACKCOLOR;
            }
            set
            {
                this.BACKCOLOR = value;
            }
        }

        public Color foreColor
        {
            get
            {
                return FORECOLOR;
            }
            set
            {
                this.FORECOLOR = value;
            }
        }
    }
}
