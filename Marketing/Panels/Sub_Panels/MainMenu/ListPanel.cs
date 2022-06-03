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

namespace Marketing.Panels.Sub_Panels.MainMenu
{
    public class ListPanel : Marketing.Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();
        Panel listPanel = new Panel();
        Panel rowPanel = new Panel();

        Panel navPanel = new Panel();
        CustomLabel count = new CustomLabel();
        CustomLabel name = new CustomLabel();
        CustomLabel category = new CustomLabel();
        CustomLabel price = new CustomLabel();

        //Toplam Fiyatı Göstericek olan Panel
        Panel sumPanel = new Panel();
        TrackBar bar = new TrackBar();
        CustomLabel sumText = new CustomLabel();
        CustomLabel sumValue = new CustomLabel();

        decimal sumTotalPrice = 0;
        
        public void InitializeComponents(Size size)
        {

            #region Panel Contents
            //Base Panel Contents
            panel.Size = new Size((int)(size.Width * 0.85), (int)(size.Height * 0.72));
            panel.Location = new Point((size.Width / 2)-(panel.Size.Width / 2), (size.Height / 2) - (panel.Size.Height / 2));
            panel.Name = "ListPanel";
            panel.BackColor = ColorTranslator.FromHtml("#212121");

            //Navigation Panel Contents
            navPanel.Size = new Size(panel.Size.Width, (int)(panel.Size.Height * 0.08));
            navPanel.Location = new Point(0, 0);
            navPanel.Name = "navPanel";
            navPanel.BackColor = ColorTranslator.FromHtml("#404FCF");

            //Sum Panel Contents
            sumPanel.Size = new Size((int)(panel.Size.Width / 4), (int)(panel.Size.Height * 0.05));
            sumPanel.Location = new Point(panel.Size.Width - sumPanel.Size.Width, panel.Size.Height - sumPanel.Size.Height);
            sumPanel.Name = "sumPanel";
            sumPanel.BackColor = navPanel.BackColor;

            //Content List Panel Contents
            listPanel.Size = new Size(panel.Size.Width, panel.Size.Height - navPanel.Size.Height - sumPanel.Size.Height);
            listPanel.Location = new Point(0, navPanel.Size.Height);
            listPanel.Name = "listPanel";
            listPanel.BackColor = Color.Transparent;

            //Row Panel Contents
            rowPanel.Size = new Size(listPanel.Size.Width, 0);
            rowPanel.Location = listPanel.Location;
            rowPanel.Name = "rowPanel";
            rowPanel.BackColor = Color.Transparent;
            #endregion

            #region NAvigation Bar Contents

            //Count Label Contents
            count.Size = new Size(navPanel.Size.Width / 4, navPanel.Size.Height);
            count.Location = new Point(0, 0);
            count.Name = "countLabel";
            count.BackColor = Color.Transparent;
            count.ForeColor = Color.White;
            count.Text = "Miktar";
            count.Font = new Font(count.Font.FontFamily, 12);
            count.TextAlign = ContentAlignment.MiddleCenter;
            count.BorderSize = 3;
            count.BorderColor = ColorTranslator.FromHtml("#2D2D91");

            //Name Label Contents
            name.Size = count.Size;
            name.Location = new Point(count.Size.Width, 0);
            name.Name = "nameLabel";
            name.BackColor = Color.Transparent;
            name.ForeColor = Color.White;
            name.Text = "Ürün Adı";
            name.Font = count.Font;
            name.TextAlign = ContentAlignment.MiddleCenter;
            name.BorderSize = count.BorderSize;
            name.BorderColor = count.BorderColor;

            //Category Label Contents
            category.Size = count.Size;
            category.Location = new Point(name.Location.X + name.Size.Width, 0);
            category.Name = "categoryLabel";
            category.BackColor = Color.Transparent;
            category.ForeColor = Color.White;
            category.Text = "Kategori";
            category.Font = count.Font;
            category.TextAlign = ContentAlignment.MiddleCenter;
            category.BorderSize = count.BorderSize;
            category.BorderColor = count.BorderColor;

            //Price Label Contents
            price.Size = count.Size;
            price.Location = new Point(category.Location.X + category.Size.Width, 0);
            price.Name = "priceLabel";
            price.BackColor = Color.Transparent;
            price.ForeColor = Color.White;
            price.Text = "Fiyat";
            price.Font = count.Font;
            price.TextAlign = ContentAlignment.MiddleCenter;
            price.BorderSize = count.BorderSize;
            price.BorderColor = count.BorderColor;
            #endregion

            #region Sum Panel Contents
            //Sum Total Label Contents
            sumText.Size = new Size(sumPanel.Width / 2, sumPanel.Height);
            sumText.Location = new Point(0, 0);
            sumText.Name = "sumText";
            sumText.BackColor = Color.Transparent;
            sumText.ForeColor = Color.White;
            sumText.Text = "Toplam: ";
            sumText.Font = count.Font;
            sumText.TextAlign = ContentAlignment.MiddleCenter;
            sumText.BorderSize = 2;
            sumText.BorderColor = ColorTranslator.FromHtml("#323232");

            //Sum Total Value Contents
            sumValue.Size = sumText.Size;
            sumValue.Location = new Point(sumText.Size.Width, 0);
            sumValue.Name = "sumValue";
            sumValue.BackColor = Color.Transparent;
            sumValue.ForeColor = Color.White;
            sumValue.Text = "";
            sumValue.Font = count.Font;
            sumValue.TextAlign = ContentAlignment.MiddleCenter;
            sumValue.BorderSize = sumText.BorderSize;
            sumValue.BorderColor = sumText.BorderColor;
            #endregion

            bar.Size = sumPanel.Size;
            bar.Location = new Point(sumPanel.Location.X - bar.Size.Width, sumPanel.Location.Y);
            bar.Name = "bar";
            bar.BackColor = Color.Red;
            bar.Visible = false;
            if (UserManager.loggedUser.havePermission(PermissionManager.GetPermission(2)) && UserManager.loggedUser.havePermission(PermissionManager.GetPermission(3)))
            {
                bar.Maximum = 20;
                sumValue.Click += Bar_Click;
            }
            else if (UserManager.loggedUser.havePermission(PermissionManager.GetPermission(-1)))
            {
                bar.Maximum = 100;
                sumValue.Click += Bar_Click;
            }
            bar.Value = bar.Maximum;
            bar.Scroll += Bar_Scroll;

            #region Navigation Bar Add Panel Codes
            navPanel.Controls.Add(count);
            navPanel.Controls.Add(name);
            navPanel.Controls.Add(category);
            navPanel.Controls.Add(price);
            #endregion

            listPanel.Controls.Add(rowPanel);

            sumPanel.Controls.Add(sumText);
            sumPanel.Controls.Add(sumValue);

            panel.Controls.Add(navPanel);
            panel.Controls.Add(listPanel);
            panel.Controls.Add(sumPanel);
            panel.Controls.Add(bar);

        }

        private void Bar_Click(object sender, EventArgs e)
        {
            bar.Visible = true;
        }
        decimal existPrice = 0;
        private void Bar_Scroll(object sender, EventArgs e)
        {
            existPrice = (sumTotalPrice * bar.Value) / 100;
            sumValue.Text = existPrice.ToString() + " TL";
        }

        public void payJesusCrysis()
        {
            rowPanel.Size = new Size(listPanel.Size.Width, 0);
            rowPanel.Controls.Clear();
            sumValue.Text = "Payed!";
            sumTotalPrice = 0;
        }

        public void addProduct(Product product)
        {
            //ProductItem

            ListPanelItem item = new ListPanelItem()
            {
                product = product,
                backColor = ColorTranslator.FromHtml("#212121"),
                foreColor = Color.White
            };

            item.InitializeComponents(panel.Size);

            rowPanel.Size = new Size(rowPanel.Size.Width, rowPanel.Size.Height + item.GetPanel().Size.Height);
            Control c = item.GetPanel();
            if (rowPanel.Controls.Count >= 1)
                c.Location = new Point(0, rowPanel.Controls[rowPanel.Controls.Count - 1].Location.Y + rowPanel.Controls[rowPanel.Controls.Count - 1].Size.Height);
            else
                c.Location = new Point(0, 0);

            rowPanel.Controls.Add(c);

            sumTotalPrice += product.product_Price + (product.product_Price * product.product_Category.KDV) / 100;
            sumValue.Text = sumTotalPrice + " TL";
        }

        public decimal getTotalPrice()
        {
            return sumTotalPrice;
        }

        public Control GetPanel()
        {
            GC.Collect();
            return panel;
        }

        public void SetPanel(Control control)
        {
            panel = (Panel)control;
        }
    }
}
