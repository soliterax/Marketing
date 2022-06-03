using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Interfaces;
using Marketing.Utils.Managers;
using SoliteraxControlLibrary;

namespace Marketing.Panels.Sub_Panels.Products_Menu
{
    public class ProductAddPanel : PanelTemplate
    {

        Panel panel = new Panel();

        CustomTextBox tx_name = new CustomTextBox();
        CustomComboBox tx_category = new CustomComboBox();
        CustomTextBox tx_price = new CustomTextBox();

        CustomButton button = new CustomButton();

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size((int)(size.Width), (int)(size.Height));
            panel.Location = new Point(0, 0);
            panel.BackColor = ColorTranslator.FromHtml("#212121");
            panel.Name = "ProductAddPanel";

            tx_name.Size = new Size(panel.Size.Width / 3, (int)(panel.Size.Height * 0.05));
            tx_name.Location = new Point((panel.Size.Width / 2) - (tx_name.Size.Width / 2), 20);
            tx_name.Name = "tx_name";
            tx_name.BackColor = panel.BackColor;
            tx_name.ForeColor = Color.White;
            tx_name.BorderColor = tx_name.ForeColor;
            tx_name.UnderlinedStyle = true;
            tx_name.PlaceholderColor = Color.Gray;
            tx_name.PlaceholderText = "Product Name";
            tx_name.Font = new Font(tx_name.Font.FontFamily, 12);

            tx_category.Size = tx_name.Size;
            tx_category.Location = new Point(tx_name.Location.X, tx_name.Location.Y + tx_name.Size.Height + 20);
            tx_category.Name = "tx_category";
            tx_category.BackColor = panel.BackColor;
            tx_category.ForeColor = Color.White;
            tx_category.BorderColor = tx_name.ForeColor;
            tx_category.ListBackColor = tx_category.BackColor;
            tx_category.ListTextColor = tx_category.ForeColor;
            tx_category.IconColor = tx_category.BorderColor;
            tx_category.Font = new Font(tx_name.Font.FontFamily, 12);
            tx_category.Texts = "Product Category";
            foreach(Category c in CategoryManager.GetAllCategories())
            {
                ComboboxItems item = new ComboboxItems();
                item.Text = c.category_Name;
                item.Value = c.category_Id;
                tx_category.Items.Add(item);
            }

            tx_price.Size = tx_name.Size;
            tx_price.Location = new Point(tx_name.Location.X, tx_category.Location.Y + tx_category.Size.Height + 20);
            tx_price.Name = "tx_price";
            tx_price.BackColor = panel.BackColor;
            tx_price.ForeColor = Color.White;
            tx_price.BorderColor = tx_name.ForeColor;
            tx_price.UnderlinedStyle = true;
            tx_price.PlaceholderColor = Color.Gray;
            tx_price.PlaceholderText = "Product Price";
            tx_price.Font = new Font(tx_name.Font.FontFamily, 12);

            button.Size = new Size(tx_name.Size.Width, tx_name.Size.Height * 2);
            button.Location = new Point((panel.Size.Width / 2) - (button.Size.Width / 2), panel.Size.Height - button.Size.Height);
            button.Name = "";
            button.BackColor = panel.BackColor;
            button.ForeColor = tx_name.ForeColor;
            button.TextColor = tx_name.ForeColor;
            button.BorderColor = tx_name.BorderColor;
            button.BorderSize = 2;
            button.BorderRadius = 30;
            button.Text = "Add Product";
            button.Click += Button_Click;

            panel.Controls.Add(tx_name);
            panel.Controls.Add(tx_category);
            panel.Controls.Add(tx_price);
            panel.Controls.Add(button);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.product_Name = tx_name.Texts;
            p.product_Category = CategoryManager.GetCategory((int)((tx_category.SelectedItem as ComboboxItems).Value));
            p.product_Price = decimal.Parse(tx_price.Texts);

            panel.Dispose();
            ProductAddClicked.Invoke(p, null);
        }

        public event EventHandler ProductAddClicked;

        class ComboboxItems
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
