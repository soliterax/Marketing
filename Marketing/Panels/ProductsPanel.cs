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

namespace Marketing.Panels
{
    public class ProductsPanel : Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();
        User user = UserManager.loggedUser;
        Sub_Panels.Products_Menu.ProductList productList;
        
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

            productList.InitializeComponents(size);

            panel.Controls.Add(productList.GetPanel());

        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
