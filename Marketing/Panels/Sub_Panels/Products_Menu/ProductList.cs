using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Marketing.Framework;

namespace Marketing.Panels.Sub_Panels.Products_Menu
{
    public class ProductList : Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();

        Panel navigationBar = new Panel();
        PictureBox imageColumn = new PictureBox();
        CustomLabel nameText = new CustomLabel();
        CustomLabel categoryText = new CustomLabel();
        CustomLabel kdvText = new CustomLabel();
        CustomLabel priceText = new CustomLabel();

        Panel ListPanel = new Panel();
        Panel RowPanel = new Panel();
        


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

        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
