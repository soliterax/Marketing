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

namespace Marketing.Panels.Sub_Panels.MainMenu
{
    public class CartAddItem : PanelTemplate
    {

        Panel panel = new Panel();

        CustomComboBox products = new CustomComboBox();
        CustomButton button = new CustomButton();

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size(size.Width, size.Height);
            panel.Location = new Point();
            panel.Name = "CartAddItem";
            panel.BackColor = ColorTranslator.FromHtml("#212121");


            products.Size = new Size(size.Width / 3, (int)(size.Height * 0.08));
            products.Location = new Point((size.Width / 2) - (products.Size.Width / 2), (size.Height / 2) - (products.Size.Height / 2));
            products.Name = "products";
            products.BackColor = panel.BackColor;
            products.ForeColor = Color.White;
            products.BorderColor = products.ForeColor;
            products.BorderSize = 2;
            products.IconColor = products.BorderColor;
            products.ListBackColor = products.BackColor;
            products.ListTextColor = products.ForeColor;
            products.Texts = "Please Select Product";
            foreach(Product value in ProductManager.GetAllProducts())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = value.product_Name;
                item.Value = value.product_Id;
                products.Items.Add(item);
            }

            button.Size = new Size(products.Size.Width, products.Size.Height * 2);
            button.Location = new Point(products.Location.X, panel.Size.Height - button.Size.Height - 20);
            button.Name = "button";
            button.BackColor = panel.BackColor;
            button.ForeColor = Color.White;
            button.BorderColor = button.ForeColor;
            button.BorderSize = 2;
            button.BorderRadius = 20;
            button.Text = "Add";
            button.Click += Button_Click;

            panel.Controls.Add(products);
            panel.Controls.Add(button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (products.Texts.Equals("Please Select Product"))
                return;

            addItem.Invoke((int)((products.SelectedItem as ComboboxItem).Value) - 1, null);
            panel.Visible = false;
        }

        public event EventHandler addItem;

        public Control GetPanel()
        {
            return panel;
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }

        class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
