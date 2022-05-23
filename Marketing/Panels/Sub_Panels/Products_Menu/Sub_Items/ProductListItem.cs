using Marketing.Utils.Base_Classes;
using SoliteraxControlLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels.Sub_Panels.Products_Menu.Sub_Items
{
    public class ProductListItem : Utils.Interfaces.PanelTemplate
    {

        CustomPanel panel = new CustomPanel();

        private Image PRODUCTIMAGE = null;
        private Product PRODUCT = null;
        private Color BACKCOLOR = Color.Transparent;
        private Color FORECOLOR = Color.White;
        

        PictureBox productImage = new PictureBox();
        Label productName = new Label();
        Label productCategory = new Label();
        Label productKdv = new Label();
        Label productPrice = new Label();

        Panel buttonPanel = new Panel();
        PictureBox remove = new PictureBox();
        PictureBox edit = new PictureBox();

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            #region Main Panel Controls
            panel.Size = new Size();
            panel.Location = new Point();
            panel.Name = "ProductListItem";
            panel.BackColor = BACKCOLOR;
            panel.MouseEnter += Panel_Enter;
            panel.MouseLeave += Panel_Leave;

            productImage.Size = new Size();
            productImage.Location = new Point();
            productImage.Name = "productImage";
            productImage.BackColor = BACKCOLOR;
            productImage.Image = PRODUCTIMAGE;
            productImage.SizeMode = PictureBoxSizeMode.StretchImage;
            productImage.MouseEnter += Panel_Enter;
            productImage.MouseLeave += Panel_Leave;

            productName.Size = new Size();
            productName.Location = new Point();
            productName.Name = "productName";
            productName.BackColor = BACKCOLOR;
            productName.ForeColor = FORECOLOR;
            productName.TextAlign = ContentAlignment.MiddleCenter;
            productName.Text = "";
            productName.MouseEnter += Panel_Enter;
            productName.MouseLeave += Panel_Leave;

            productCategory.Size = productName.Size;
            productCategory.Location = new Point();
            productCategory.Name = "productCategory";
            productCategory.BackColor = BACKCOLOR;
            productCategory.ForeColor = FORECOLOR;
            productCategory.TextAlign = ContentAlignment.MiddleCenter;
            productCategory.Text = "";
            productCategory.MouseEnter += Panel_Enter;
            productCategory.MouseLeave += Panel_Leave;

            productKdv.Size = productCategory.Size;
            productKdv.Location = new Point();
            productKdv.Name = "productKdv";
            productKdv.BackColor = BACKCOLOR;
            productKdv.ForeColor = FORECOLOR;
            productKdv.TextAlign = ContentAlignment.MiddleCenter;
            productKdv.Text = "";
            productKdv.MouseEnter += Panel_Enter;
            productKdv.MouseLeave += Panel_Leave;

            productPrice.Size = productKdv.Size;
            productPrice.Location = new Point();
            productPrice.Name = "productPrice";
            productPrice.BackColor = BACKCOLOR;
            productPrice.ForeColor = FORECOLOR;
            productPrice.TextAlign = ContentAlignment.MiddleCenter;
            productPrice.Text = "";
            productPrice.MouseEnter += Panel_Enter;
            productPrice.MouseLeave += Panel_Leave;
            #endregion

            buttonPanel.Size = panel.Size;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.BackColor = BACKCOLOR;
            buttonPanel.MouseEnter += Panel_Enter;
            buttonPanel.MouseLeave += Panel_Leave;

            edit.Size = new Size();
            edit.Location = new Point();
            edit.BackColor = BACKCOLOR;
            edit.Name = "editButton";
            edit.Image = null;
            edit.SizeMode = PictureBoxSizeMode.StretchImage;
            edit.MouseEnter += Panel_Enter;
            edit.MouseLeave += Panel_Leave;

            remove.Size = edit.Size;
            remove.Location = new Point();
            remove.BackColor = BACKCOLOR;
            remove.Name = "removeButton";
            remove.Image = null;
            remove.SizeMode = PictureBoxSizeMode.StretchImage;
            remove.MouseEnter += Panel_Enter;
            remove.MouseLeave += Panel_Leave;

            panel.Controls.Add(productImage);
            panel.Controls.Add(productName);
            panel.Controls.Add(productCategory);
            panel.Controls.Add(productKdv);
            panel.Controls.Add(productPrice);

        }

        public void SetPanel(Control control)
        {
            this.panel = (CustomPanel)control;
        }

        private void Panel_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Panel_Leave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        public Image image { get => PRODUCTIMAGE; set => PRODUCTIMAGE = value; }
        public Product Product { get => PRODUCT; set => PRODUCT = value; }
        public Color BackColor { get => BACKCOLOR; set => BACKCOLOR = value; }
        public Color ForeColor { get => FORECOLOR; set => FORECOLOR = value; }

    }
}
