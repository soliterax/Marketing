using Marketing.Panels.Sub_Panels.Account_Menu;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;
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

        ProductList listPanel;
        User user = UserManager.loggedUser;

        PictureBox productImage = new PictureBox();
        CustomLabel productName = new CustomLabel();
        CustomLabel productCategory = new CustomLabel();
        CustomLabel productKdv = new CustomLabel();
        CustomLabel productPrice = new CustomLabel();

        Panel buttonPanel = new Panel();
        PictureBox remove = new PictureBox();
        PictureBox edit = new PictureBox();

        public ProductListItem(ProductList panel)
        {
            this.listPanel = panel;
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            #region Main Panel Controls
            panel.Size = new Size(size.Width, (int)(size.Height * 0.08));
            panel.Name = "ProductListItem";
            panel.BackColor = BACKCOLOR;
            panel.haveBorder = true;
            panel.borderColor = Color.Blue;
            panel.borderSize = 2;
            

            productImage.Size = new Size(panel.Size.Height , panel.Size.Height);
            productImage.Location = new Point(0, 0);
            productImage.Name = "productImage";
            productImage.BackColor = BACKCOLOR;
            productImage.Image = PRODUCTIMAGE;
            productImage.SizeMode = PictureBoxSizeMode.StretchImage;
            

            productName.Size = new Size((size.Width - productImage.Size.Width) / 4, panel.Size.Height);
            productName.Location = new Point(productImage.Size.Width, 0);
            productName.Name = "productName";
            productName.BackColor = BACKCOLOR;
            productName.ForeColor = FORECOLOR;
            productName.Text = PRODUCT.product_Name;
            productName.TextAlign = ContentAlignment.MiddleCenter;
            productName.Font = new Font(productName.Font.FontFamily, 12f);
            productName.haveBorder = true;
            productName.BorderSize = 2;
            productName.BorderColor = Color.Blue;
            productName.borderTopSize = 0;
            productName.borderBottomSize = 0;
            

            productCategory.Size = productName.Size;
            productCategory.Location = new Point(productName.Location.X + productName.Size.Width, 0);
            productCategory.Name = "productCategory";
            productCategory.BackColor = BACKCOLOR;
            productCategory.ForeColor = FORECOLOR;
            productCategory.TextAlign = productName.TextAlign;
            productCategory.Font = productName.Font;
            productCategory.Text = PRODUCT.product_Category.category_Name;
            productCategory.haveBorder = true;
            productCategory.BorderColor = Color.Blue;
            productCategory.BorderSize = 0;
            productCategory.borderRightSize = 2;
            

            productKdv.Size = productCategory.Size;
            productKdv.Location = new Point(productCategory.Location.X + productCategory.Size.Width, 0);
            productKdv.Name = "productKdv";
            productKdv.BackColor = BACKCOLOR;
            productKdv.ForeColor = FORECOLOR;
            productKdv.TextAlign = productName.TextAlign;
            productKdv.Font = productName.Font;
            productKdv.Text = "% " + PRODUCT.product_Category.KDV;
            productKdv.haveBorder = true;
            productKdv.BorderColor = Color.Blue;
            productKdv.BorderSize = 0;
            productKdv.borderRightSize = 2;
            

            productPrice.Size = productKdv.Size;
            productPrice.Location = new Point(productKdv.Location.X + productKdv.Size.Width, 0);
            productPrice.Name = "productPrice";
            productPrice.BackColor = BACKCOLOR;
            productPrice.ForeColor = FORECOLOR;
            productPrice.TextAlign = productName.TextAlign;
            productPrice.Font = productName.Font;
            productPrice.Text = PRODUCT.product_Price + " TL";
            
            #endregion

            buttonPanel.Size = panel.Size;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.BackColor = BACKCOLOR;
            buttonPanel.Visible = false;
            
                

            edit.Size = new Size((int)(panel.Size.Height * 0.8), (int)(panel.Size.Height * 0.8));
            edit.Location = new Point(((panel.Size.Width / 2) - (edit.Size.Width * 2 / 2)) - edit.Size.Width, (panel.Size.Height / 2) - (edit.Size.Height / 2));
            edit.BackColor = Color.Red;
            edit.Name = "editButton";
            edit.Image = null;
            edit.SizeMode = PictureBoxSizeMode.StretchImage;
            

            remove.Size = edit.Size;
            remove.Location = new Point(((panel.Size.Width / 2) - (remove.Size.Width)) + remove.Size.Width, (panel.Size.Height / 2) - (remove.Size.Height / 2));
            remove.BackColor = Color.Red;
            remove.Name = "removeButton";
            remove.Image = null;
            remove.SizeMode = PictureBoxSizeMode.StretchImage;


            //Events
            if (user.havePermission(PermissionManager.GetPermission(4)) || user.havePermission(PermissionManager.GetPermission(5)))
            {
                panel.Click += Panel_Enter;
                productImage.Click += Panel_Enter;
                productName.Click += Panel_Enter;
                productCategory.Click += Panel_Enter;
                productKdv.Click += Panel_Enter;
                productPrice.Click += Panel_Enter;
                buttonPanel.Click += Panel_Enter;
                edit.Click += Panel_Enter;
                remove.Click += Panel_Enter;
            }

            buttonPanel.Controls.Add(edit);
            buttonPanel.Controls.Add(remove);

            panel.Controls.Add(buttonPanel);
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
            
            switch(((Control)sender).Name)
            {
                case "editButton":
                    if (user.havePermission(PermissionManager.GetPermission(4)) && user.havePermission(PermissionManager.GetPermission(5)))
                        MessageBox.Show("Düzenlemeye Basıldı!");
                    return;
                case "removeButton":
                    if(user.havePermission(PermissionManager.GetPermission(4)))
                        MessageBox.Show("Silmeye Basıldı!");
                    return;
                default:
                    break;
            }
            
            if (buttonPanel.Visible)
                buttonPanel.Visible = false;
            else
                buttonPanel.Visible = true;
        }


        public Image image
        {
            get
            {
                return PRODUCTIMAGE;
            }
            set
            {
                this.PRODUCTIMAGE = value;
            }
        }
        public Product Product { 
            get
            {
                return PRODUCT;
            }
            set
            {
                this.PRODUCT = value;
            }
        }
        public Color BackColor
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
        public Color ForeColor
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
