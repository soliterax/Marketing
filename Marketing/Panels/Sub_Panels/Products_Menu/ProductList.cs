using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SoliteraxControlLibrary;

namespace Marketing.Panels.Sub_Panels.Products_Menu
{
    public class ProductList : Utils.Interfaces.PanelTemplate
    {

        LinkedList<Sub_Items.ProductListItem> items = new LinkedList<Sub_Items.ProductListItem>();

        Panel panel = new Panel();

        Panel navigationBar = new Panel();
        PictureBox imageColumn = new PictureBox();
        CustomLabel nameText = new CustomLabel();
        CustomLabel categoryText = new CustomLabel();
        CustomLabel kdvText = new CustomLabel();
        CustomLabel priceText = new CustomLabel();

        Panel ListPanel = new Panel();
        Panel RowPanel = new Panel();
        
        public ProductList()
        {

        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size();
            panel.Location = new Point();
            panel.Name = "";
            panel.BackColor = Color.Transparent;

            navigationBar.Size = new Size();
            navigationBar.Location = new Point();
            navigationBar.BackColor = Color.Transparent;
            navigationBar.Name = "";

            imageColumn.Size = new Size();
            imageColumn.Location = new Point();
            imageColumn.BackColor = Color.Transparent;
            imageColumn.Image = null;
            imageColumn.SizeMode = PictureBoxSizeMode.StretchImage;

            nameText.Size = new Size();
            nameText.Location = new Point();
            nameText.BackColor = Color.Transparent;
            nameText.ForeColor = Color.White;
            nameText.Name = "";
            nameText.Text = "";
            nameText.TextAlign = ContentAlignment.MiddleCenter;
            nameText.BorderColor = Color.Blue;
            nameText.BorderSize = 1;
            nameText.haveBorder = true;

            categoryText.Size = new Size();
            categoryText.Location = new Point();
            categoryText.BackColor = Color.Transparent;
            categoryText.ForeColor = Color.White;
            categoryText.Name = "";
            categoryText.Text = "";
            categoryText.TextAlign = ContentAlignment.MiddleCenter;
            categoryText.BorderColor = Color.Blue;
            categoryText.BorderSize = 1;
            categoryText.haveBorder = true;

            kdvText.Size = new Size();
            kdvText.Location = new Point();
            kdvText.BackColor = Color.Transparent;
            kdvText.ForeColor = Color.White;
            kdvText.Name = "";
            kdvText.Text = "";
            kdvText.TextAlign = ContentAlignment.MiddleCenter;
            kdvText.BorderColor = Color.Blue;
            kdvText.BorderSize = 1;
            kdvText.haveBorder = true;

            priceText.Size = new Size();
            priceText.Location = new Point();
            priceText.BackColor = Color.Transparent;
            priceText.ForeColor = Color.White;
            priceText.Name = "";
            priceText.Text = "";
            priceText.TextAlign = ContentAlignment.MiddleCenter;
            priceText.BorderColor = Color.Blue;
            priceText.BorderSize = 1;
            priceText.haveBorder = true;

            navigationBar.Controls.Add(imageColumn);
            navigationBar.Controls.Add(nameText);
            navigationBar.Controls.Add(categoryText);
            navigationBar.Controls.Add(kdvText);
            navigationBar.Controls.Add(priceText);

            ListPanel.Size = new Size(panel.Size.Width, panel.Size.Height - navigationBar.Size.Height);
            ListPanel.Location = new Point(navigationBar.Location.X, navigationBar.Size.Height);
            ListPanel.BackColor = Color.Transparent;
            ListPanel.Name = "ListPanel";


            RowPanel.Size = new Size(ListPanel.Size.Width, ((this.items.Count < 1) ? (this.items.Count * this.items.ToArray()[0].GetPanel().Size.Height) : 0));
            RowPanel.Location = ListPanel.Location;
            RowPanel.BackColor = ListPanel.BackColor;
            RowPanel.Name = "RowPanel";

            ListPanel.Controls.Add(RowPanel);

            panel.Controls.Add(navigationBar);
            panel.Controls.Add(ListPanel);

        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
