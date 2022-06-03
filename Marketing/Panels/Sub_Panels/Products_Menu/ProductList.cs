using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SoliteraxControlLibrary;
using Marketing.Panels.Sub_Panels.Products_Menu.Sub_Items;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;

namespace Marketing.Panels.Sub_Panels.Products_Menu
{
    public class ProductList : Utils.Interfaces.PanelTemplate
    {

        LinkedList<Sub_Items.ProductListItem> items = new LinkedList<Sub_Items.ProductListItem>();

        User user = UserManager.loggedUser;

        CustomPanel panel = new CustomPanel();

        Panel navigationBar = new Panel();
        PictureBox imageColumn = new PictureBox();
        CustomLabel nameText = new CustomLabel();
        CustomLabel categoryText = new CustomLabel();
        CustomLabel kdvText = new CustomLabel();
        CustomLabel priceText = new CustomLabel();

        

        PictureBox addProductButton = new PictureBox();

        Panel ListPanel = new Panel();
        CustomPanel RowPanel = new CustomPanel();
        
        public ProductList(User user)
        {
            this.user = user;
            foreach(Product cat in ProductManager.GetAllProducts())
            {
                items.AddLast(new ProductListItem(this)
                {
                    BackColor = ColorTranslator.FromHtml("#212121"),
                    ForeColor = Color.White,
                    Product = cat,
                    image = null
                });
                
            }
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size((int)(size.Width * 0.85), (int)(size.Height * 0.72));
            panel.Location = new Point((size.Width / 2) - (panel.Size.Width / 2), (size.Height / 2) - (panel.Size.Height / 2));
            panel.Name = "ProductList";
            panel.BackColor = Color.Transparent;
            panel.borderColor = Color.White;
            panel.borderSize = 2;
            panel.haveBorder = true;

            navigationBar.Size = new Size(panel.Size.Width, (int)(panel.Size.Height * 0.08));
            navigationBar.Location = new Point(0, 0);
            navigationBar.BackColor = ColorTranslator.FromHtml("#404FCF");
            navigationBar.Name = "navigationBar";

            imageColumn.Size = new Size(navigationBar.Size.Height, navigationBar.Size.Height);
            imageColumn.Location = new Point(0, 0);
            imageColumn.BackColor = Color.Transparent;
            imageColumn.Name = "imageColumn";
            imageColumn.Image = Properties.Resources.X;
            imageColumn.SizeMode = PictureBoxSizeMode.StretchImage;

            nameText.Size = new Size((navigationBar.Size.Width - imageColumn.Size.Width) / 4, navigationBar.Size.Height);
            nameText.Location = new Point(imageColumn.Size.Width, 0);
            nameText.BackColor = Color.Transparent;
            nameText.ForeColor = Color.White;
            nameText.Name = "nameText";
            nameText.Text = "Ürün Adı";
            nameText.TextAlign = ContentAlignment.MiddleCenter;
            nameText.Font = new Font(nameText.Font.FontFamily, 14);
            nameText.BorderColor = Color.White;
            nameText.BorderSize = 0;
            nameText.borderLeftSize = 2;
            nameText.borderRightSize = 2;
            nameText.haveBorder = true;

            categoryText.Size = nameText.Size;
            categoryText.Location = new Point(nameText.Location.X + nameText.Size.Width, 0);
            categoryText.BackColor = Color.Transparent;
            categoryText.ForeColor = Color.White;
            categoryText.Name = "categoryText";
            categoryText.Text = "Kategori Adı";
            categoryText.TextAlign = ContentAlignment.MiddleCenter;
            categoryText.Font = nameText.Font;
            categoryText.BorderColor = Color.White;
            categoryText.BorderSize = 0;
            categoryText.borderRightSize = 2;
            categoryText.haveBorder = true;

            kdvText.Size = categoryText.Size;
            kdvText.Location = new Point(categoryText.Location.X + categoryText.Size.Width, 0);
            kdvText.BackColor = Color.Transparent;
            kdvText.ForeColor = Color.White;
            kdvText.Name = "kdvText";
            kdvText.Text = "KDV";
            kdvText.TextAlign = ContentAlignment.MiddleCenter;
            kdvText.Font = nameText.Font;
            kdvText.BorderColor = Color.White;
            kdvText.BorderSize = 0;
            kdvText.borderRightSize = 2;
            kdvText.haveBorder = true;

            priceText.Size = kdvText.Size;
            priceText.Location = new Point(kdvText.Location.X + kdvText.Size.Width, 0);
            priceText.BackColor = Color.Transparent;
            priceText.ForeColor = Color.White;
            priceText.Name = "priceText";
            priceText.Text = "Fiyat";
            priceText.TextAlign = ContentAlignment.MiddleCenter;
            priceText.Font = nameText.Font;
            priceText.BorderColor = Color.White;
            priceText.BorderSize = 0;
            priceText.haveBorder = false;

            navigationBar.Controls.Add(imageColumn);
            navigationBar.Controls.Add(nameText);
            navigationBar.Controls.Add(categoryText);
            navigationBar.Controls.Add(kdvText);
            navigationBar.Controls.Add(priceText);

            ListPanel.Size = new Size(panel.Size.Width, panel.Size.Height - navigationBar.Size.Height);
            ListPanel.Location = new Point(navigationBar.Location.X, navigationBar.Size.Height);
            ListPanel.BackColor = Color.Transparent;
            ListPanel.Name = "ListPanel";


            RowPanel.Size = new Size(ListPanel.Size.Width, ((this.items.Count >= 1) ? (this.items.Count * this.items.ToArray()[0].GetPanel().Size.Height) : 0));
            RowPanel.Location = new Point(0, 0);
            RowPanel.BackColor = ListPanel.BackColor;
            RowPanel.Name = "RowPanel";

            if (items.Count >= 1)
            {
                ProductListItem a = items.ToArray()[0];
                a.InitializeComponents(panel.Size);
                Panel _p = (Panel)a.GetPanel();
                _p.Location = new Point(0, 0);
                RowPanel.Controls.Add(_p);
                for (int i = 1; i < items.Count; i++)
                {
                    ProductListItem item = items.ToArray()[i];
                    item.InitializeComponents(panel.Size);
                    Panel p = (Panel)item.GetPanel();
                    p.Location = new Point(0, items.ToArray()[i - 1].GetPanel().Location.Y + items.ToArray()[i - 1].GetPanel().Size.Height);
                    RowPanel.Controls.Add(p);
                }
            }

            ListPanel.Controls.Add(RowPanel);

            panel.Controls.Add(navigationBar);
            panel.Controls.Add(ListPanel);

        }

        internal void AddProduct(Product sender)
        {
            if (ProductManager.GetAllProducts().Length >= 1)
                sender.product_Id = ProductManager.GetAllProducts()[ProductManager.GetAllProducts().Length - 1].product_Id + 1;
            else
                sender.product_Id = 1;
            ProductManager.AddProduct(sender);
            ProductListItem item = new ProductListItem(this)
            {
                BackColor = ColorTranslator.FromHtml("#212121"),
                ForeColor = Color.White,
                Product = sender,
                image = null
            };

            item.InitializeComponents(panel.Size);

            RowPanel.Size = new Size(RowPanel.Size.Width, RowPanel.Size.Height + item.GetPanel().Size.Height);
            Control c = item.GetPanel();
            if (RowPanel.Controls.Count >= 1)
                c.Location = new Point(0, RowPanel.Controls[RowPanel.Controls.Count - 1].Location.Y + RowPanel.Controls[RowPanel.Controls.Count - 1].Size.Height);
            else
                c.Location = new Point(0, 0);
            RowPanel.Controls.Add(c);
            items.AddLast(item);
            GC.Collect();
        }

        public void SetPanel(Control control)
        {
            this.panel = (CustomPanel)control;
        }
    }
}
