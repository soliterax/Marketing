using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels
{
    public class Main_Panel : Marketing.Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();
        Utils.Base_Classes.User user;

        Panel productList = new Panel();
        Button addProductButton = new Button();
        Button removeProductButton = new Button();
        Button billButton = new Button();
        Button historyProductBuy = new Button();

        //Yetkili Sınıfları
        Button indirimButton = new Button();
        Button promosyonButton = new Button();

        public Main_Panel()
        {

        }
        public Main_Panel(Utils.Base_Classes.User user)
        {
            this.user = user;
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = size;
            panel.BackColor = Color.Transparent;
            panel.Name = "Main_Panel";
            panel.Dock = DockStyle.Fill;

            //ProductList Contents
            productList.Size = new Size((int)(panel.Size.Width * 0.92), (int)(panel.Size.Height * 0.72));
            productList.Location = new Point((panel.Size.Width / 2) - (productList.Size.Width / 2), (panel.Size.Height / 2) - (productList.Size.Height / 2));
            productList.Name = "productList";
            productList.BackColor = Color.Blue;
            productList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            panel.Controls.Add(productList);
            
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
