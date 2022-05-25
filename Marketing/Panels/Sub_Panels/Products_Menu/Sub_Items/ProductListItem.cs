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

        Panel mainPanel = new Panel();
        PictureBox productImage = new PictureBox();
        CustomLabel productName = new CustomLabel();
        CustomLabel productCategory = new CustomLabel();
        CustomLabel productKdv = new CustomLabel();
        CustomLabel productPrice = new CustomLabel();

        Panel buttonPanel = new Panel();
        PictureBox remove = new PictureBox();
        PictureBox edit = new PictureBox();

        Panel editPanel = new Panel();
        PictureBox editPanelSave = new PictureBox();
        CustomTextBox tx_productName = new CustomTextBox();
        CustomTextBox tx_productCategory = new CustomTextBox();
        CustomTextBox tx_productKdv = new CustomTextBox();
        CustomTextBox tx_productPrice = new CustomTextBox();

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
            
            panel.Size = new Size(size.Width, (int)(size.Height * 0.08));
            panel.Name = "ProductListItem";
            panel.BackColor = BACKCOLOR;
            panel.haveBorder = true;
            panel.borderColor = Color.Blue;
            panel.borderSize = 2;

            #region Main Panel Controls
            mainPanel.Size = panel.Size;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.BackColor = BACKCOLOR;

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
           
            productName.TextAlign = ContentAlignment.MiddleCenter;
            productName.Font = new Font(productName.Font.FontFamily, 12f);
            productName.haveBorder = true;
            productName.BorderSize = 2;
            productName.BorderColor = Color.Blue;
            

            productCategory.Size = productName.Size;
            productCategory.Location = new Point(productName.Location.X + productName.Size.Width, 0);
            productCategory.Name = "productCategory";
            productCategory.BackColor = BACKCOLOR;
            productCategory.ForeColor = FORECOLOR;
            productCategory.TextAlign = productName.TextAlign;
            productCategory.Font = productName.Font;
            
            productCategory.haveBorder = true;
            productCategory.BorderColor = Color.Blue;
            productCategory.BorderSize = 2;
            productCategory.borderLeftSize = 0;
            

            productKdv.Size = productCategory.Size;
            productKdv.Location = new Point(productCategory.Location.X + productCategory.Size.Width, 0);
            productKdv.Name = "productKdv";
            productKdv.BackColor = BACKCOLOR;
            productKdv.ForeColor = FORECOLOR;
            productKdv.TextAlign = productName.TextAlign;
            productKdv.Font = productName.Font;
            
            productKdv.haveBorder = true;
            productKdv.BorderColor = Color.Blue;
            productKdv.BorderSize = 2;
            productKdv.borderLeftSize = 0;
            

            productPrice.Size = productKdv.Size;
            productPrice.Location = new Point(productKdv.Location.X + productKdv.Size.Width, 0);
            productPrice.Name = "productPrice";
            productPrice.BackColor = BACKCOLOR;
            productPrice.ForeColor = FORECOLOR;
            productPrice.TextAlign = productName.TextAlign;
            productPrice.Font = productName.Font;
            
            productPrice.haveBorder = true;
            productPrice.BorderColor = Color.Blue;
            productPrice.BorderSize = 2;
            productPrice.borderLeftSize = 0;

            SetTexts();
            #endregion

            #region Buttons Panel Controls
            buttonPanel.Size = panel.Size;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.BackColor = BACKCOLOR;
            buttonPanel.Visible = false;
            
            edit.Size = new Size((int)(panel.Size.Height * 0.88), (int)(panel.Size.Height * 0.88));
            edit.Location = new Point(((panel.Size.Width / 2) - (edit.Size.Width * 2 / 2)) - edit.Size.Width, (panel.Size.Height / 2) - (edit.Size.Height / 2));
            edit.BackColor = Color.Transparent;
            edit.Name = "editButton";
            edit.Image = Properties.Resources.editPictureButton;
            edit.SizeMode = PictureBoxSizeMode.StretchImage;
            
            remove.Size = edit.Size;
            remove.Location = new Point(((panel.Size.Width / 2) - (remove.Size.Width)) + remove.Size.Width, (panel.Size.Height / 2) - (remove.Size.Height / 2));
            remove.BackColor = Color.Transparent;
            remove.Name = "removeButton";
            remove.Image = Properties.Resources.RemovePictureButton;
            remove.SizeMode = PictureBoxSizeMode.StretchImage;
            #endregion

            editPanel.Size = panel.Size;
            editPanel.Location = new Point(0, 0);
            editPanel.Name = "editPanel";
            editPanel.BackColor = BACKCOLOR;
            editPanel.Visible = false;

            editPanelSave.Size = new Size((int)(editPanel.Size.Height * 0.88), (int)(editPanel.Size.Height * 0.88));
            editPanelSave.Location = new Point((int)(editPanel.Size.Height * 0.12), (editPanel.Size.Height / 2)-(editPanelSave.Size.Height / 2));
            editPanelSave.Name = "editPanelSave";
            editPanelSave.BackColor = BACKCOLOR;
            editPanelSave.Image = Properties.Resources.successfulPictureButton;
            editPanelSave.SizeMode = PictureBoxSizeMode.StretchImage;

            tx_productName.Size = new Size((editPanel.Size.Width - editPanelSave.Location.X + editPanelSave.Size.Width) / 4, editPanelSave.Size.Height);
            tx_productName.Location = new Point(editPanelSave.Size.Width, editPanelSave.Location.Y);
            tx_productName.Name = "tx_productName";
            tx_productName.BackColor = BACKCOLOR;
            tx_productName.ForeColor = FORECOLOR;
            tx_productName.PlaceholderColor = Color.Gray;
            tx_productName.PlaceholderText = PRODUCT.product_Name.ToString();
            tx_productName.BorderColor = FORECOLOR;
            tx_productName.BorderSize = 2;
            tx_productName.UnderlinedStyle = true;
            

            tx_productCategory.Size = tx_productName.Size;
            tx_productCategory.Location = new Point(tx_productName.Location.X + tx_productName.Size.Width, tx_productName.Location.Y);
            tx_productCategory.Name = "tx_productCategory";
            tx_productCategory.BackColor = tx_productName.BackColor;
            tx_productCategory.ForeColor = tx_productName.ForeColor;
            tx_productCategory.PlaceholderColor = tx_productName.PlaceholderColor;
            tx_productCategory.PlaceholderText = PRODUCT.product_Category.category_Name.ToString();
            tx_productCategory.BorderColor = tx_productName.BorderColor;
            tx_productCategory.BorderSize = tx_productName.BorderSize;
            tx_productCategory.UnderlinedStyle = tx_productName.UnderlinedStyle;

            tx_productKdv.Size = tx_productName.Size;
            tx_productKdv.Location = new Point(tx_productCategory.Location.X + tx_productCategory.Size.Width, tx_productCategory.Location.Y);
            tx_productKdv.Name = "tx_productKdv";
            tx_productKdv.BackColor = tx_productName.BackColor;
            tx_productKdv.ForeColor = tx_productName.ForeColor;
            tx_productKdv.PlaceholderColor = tx_productName.PlaceholderColor;
            tx_productKdv.PlaceholderText = PRODUCT.product_Category.KDV.ToString();
            tx_productKdv.BorderColor = tx_productName.BorderColor;
            tx_productKdv.BorderSize = tx_productName.BorderSize;
            tx_productKdv.UnderlinedStyle = tx_productName.UnderlinedStyle;

            tx_productPrice.Size = tx_productName.Size;
            tx_productPrice.Location = new Point(tx_productKdv.Location.X + tx_productKdv.Size.Width, tx_productKdv.Location.Y);
            tx_productPrice.Name = "tx_productPrice";
            tx_productPrice.BackColor = tx_productName.BackColor;
            tx_productPrice.ForeColor = tx_productName.ForeColor;
            tx_productPrice.PlaceholderColor = tx_productName.PlaceholderColor;
            tx_productPrice.PlaceholderText = PRODUCT.product_Price.ToString();
            tx_productPrice.BorderColor = tx_productName.BorderColor;
            tx_productPrice.BorderSize = tx_productName.BorderSize;
            tx_productPrice.UnderlinedStyle = tx_productName.UnderlinedStyle;

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
                editPanelSave.Click += Panel_Enter;
            }

            buttonPanel.Controls.Add(edit);
            buttonPanel.Controls.Add(remove);

            
            mainPanel.Controls.Add(productImage);
            mainPanel.Controls.Add(productName);
            mainPanel.Controls.Add(productCategory);
            mainPanel.Controls.Add(productKdv);
            mainPanel.Controls.Add(productPrice);

            editPanel.Controls.Add(editPanelSave);
            editPanel.Controls.Add(tx_productName);
            editPanel.Controls.Add(tx_productCategory);
            editPanel.Controls.Add(tx_productKdv);
            editPanel.Controls.Add(tx_productPrice);

            panel.Controls.Add(editPanel);
            panel.Controls.Add(buttonPanel);
            panel.Controls.Add(mainPanel);

        }

        void SetTexts()
        {
            productName.Text = PRODUCT.product_Name;
            productCategory.Text = PRODUCT.product_Category.category_Name;
            productKdv.Text = "% " + PRODUCT.product_Category.KDV;
            productPrice.Text = PRODUCT.product_Price + " TL";
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
                    {
                        buttonPanel.Visible = false;
                        editPanel.Visible = true;
                    }    
                    return;
                case "removeButton":
                    if(user.havePermission(PermissionManager.GetPermission(4)))
                        MessageBox.Show("Silmeye Basıldı!");
                    return;
                case "editPanelSave":
                    PRODUCT.product_Name = tx_productName.Texts;
                    PRODUCT.product_Category = CategoryManager.FindCategory(tx_productCategory.Texts);
                    PRODUCT.product_Price = decimal.Parse(tx_productPrice.Texts);
                    ProductManager.SaveProduct(PRODUCT);
                    SetTexts();
                    editPanel.Visible = false;
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
