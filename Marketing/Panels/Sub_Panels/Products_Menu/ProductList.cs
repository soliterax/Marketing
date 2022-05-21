using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Marketing.Panels.Sub_Panels.Products_Menu
{
    public class ProductList : Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();

        Panel navigationBar = new Panel();

        Panel ListPanel = new Panel();
        Panel RowPanel = new Panel();

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
