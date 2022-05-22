using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Marketing.Panels
{
    public class ProductsPanel : Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();

        

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size();
            panel.Location = new Point();
            panel.Name = "ProductsPanel";
            panel.BackColor = Color.Transparent;
            panel.Dock = DockStyle.Fill;
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
