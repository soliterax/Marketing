using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SoliteraxControlLibrary;

namespace Marketing.Panels
{
    public class ProductsPanel : Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();

        Sub_Panels.Products_Menu.ProductList productList = new Sub_Panels.Products_Menu.ProductList();
        

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
