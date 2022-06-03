using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SoliteraxControlLibrary;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;
using Marketing.Panels.Sub_Panels.Products_Menu;

namespace Marketing.Panels
{
    public class ProductsPanel : Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();
        User user = UserManager.loggedUser;
        Sub_Panels.Products_Menu.ProductList productList;
        ProductAddPanel productAddPanel = new ProductAddPanel();

        PictureBox addProductButton = new PictureBox();
        PictureBox backButton = new PictureBox();
        
        public ProductsPanel()
        {
            productList = new Sub_Panels.Products_Menu.ProductList(this.user);
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Location = new Point(0, Application.OpenForms[0].Controls[0].Size.Height);
            panel.Name = "ProductsPanel";
            panel.BackColor = Color.Transparent;
            panel.Dock = DockStyle.Fill;

            backButton.Size = new Size(50, 50);
            backButton.Location = new Point(0, Application.OpenForms[0].Controls[0].Size.Height);
            backButton.Name = "BackButton";
            backButton.BackColor = Color.Transparent;
            backButton.Image = Properties.Resources.BackButton;
            backButton.SizeMode = PictureBoxSizeMode.StretchImage;
            backButton.Click += Button_Click;

            productList.InitializeComponents(size);

            addProductButton.Size = new Size((int)(panel.Size.Height * 0.5), (int)(panel.Size.Height * 0.5));
            addProductButton.Location = new Point(((productList.GetPanel().Location.X + productList.GetPanel().Size.Width) / 2) - (addProductButton.Size.Width / 2) + 30, productList.GetPanel().Location.Y + productList.GetPanel().Size.Height + 20);
            addProductButton.Name = "addProductButton";
            addProductButton.BackColor = panel.BackColor;
            addProductButton.Image = Properties.Resources.AddImage;
            addProductButton.SizeMode = PictureBoxSizeMode.StretchImage;
            if(UserManager.loggedUser.havePermission(PermissionManager.GetPermission(2)) || UserManager.loggedUser.havePermission(PermissionManager.GetPermission(-1)))
                addProductButton.Click += Button_Click;

            panel.Controls.Add(backButton);
            panel.Controls.Add(addProductButton);
            panel.Controls.Add(productList.GetPanel());

        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "addProductButton":
                    productAddPanel.InitializeComponents(productList.GetPanel().Size);
                    productAddPanel.ProductAddClicked += ProductAddClicked;
                    Control c = productAddPanel.GetPanel();
                    c.Location = productList.GetPanel().Location;
                    panel.Controls.Add(c);
                    c.BringToFront();
                    break;
                case "BackButton":
                    panel.Dispose();
                    Main_Panel m = new Main_Panel();
                    m.InitializeComponents(Application.OpenForms[0].Size);
                    Application.OpenForms[0].Controls.Add(m.GetPanel());
                    break;
                default:
                    break;
            }
        }

        private void ProductAddClicked(object sender, EventArgs e)
        {
            productList.AddProduct((Product)sender);
            addProductButton.Click += Button_Click;
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
