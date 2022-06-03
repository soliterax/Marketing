using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marketing.Utils.Interfaces;
using SoliteraxControlLibrary;

namespace Marketing.Panels.Sub_Panels.Products_Menu
{
    public class ProductAddPanel : PanelTemplate
    {

        Panel panel = new Panel();

        CustomTextBox tx_name = new CustomTextBox();
        CustomTextBox tx_category = new CustomTextBox();
        CustomTextBox tx_price = new CustomTextBox();

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size((int)(size.Width), (int)(size.Height));
            panel.Location = new Point(0, 0);
            panel.BackColor = ColorTranslator.FromHtml("#212121");
            panel.Name = "ProductAddPanel";

            tx_name.Size = new Size();
            tx_name.Location = new Point();
            tx_name.Name = "";
            tx_name.BackColor = panel.BackColor;
            tx_name.ForeColor = Color.White;
            tx_name.BorderColor = tx_name.ForeColor;
            tx_name.UnderlinedStyle = true;
            tx_name.PlaceholderColor = Color.Gray;
            tx_name.PlaceholderText = "Product Name";
            tx_name.Font = new Font(tx_name.Font.FontFamily, 12);

            tx_category.Size = new Size();
            tx_category.Location = new Point();
            tx_category.Name = "";
            tx_category.BackColor = panel.BackColor;
            tx_category.ForeColor = Color.White;
            tx_category.BorderColor = tx_name.ForeColor;
            tx_category.UnderlinedStyle = true;
            tx_category.PlaceholderColor = Color.Gray;
            tx_category.PlaceholderText = "Product Name";
            tx_category.Font = new Font(tx_name.Font.FontFamily, 12);

            tx_price.Size = new Size();
            tx_price.Location = new Point();
            tx_price.Name = "";
            tx_price.BackColor = panel.BackColor;
            tx_price.ForeColor = Color.White;
            tx_price.BorderColor = tx_name.ForeColor;
            tx_price.UnderlinedStyle = true;
            tx_price.PlaceholderColor = Color.Gray;
            tx_price.PlaceholderText = "Product Name";
            tx_price.Font = new Font(tx_name.Font.FontFamily, 12);

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
