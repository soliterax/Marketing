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

        Label count = new Label();
        Label name = new Label();
        Label category = new Label();
        Label price = new Label();

        Panel sumPanel = new Panel();
        Label sumText = new Label();
        Label sumValue = new Label();
        
        public void InitializeComponents(Size size)
        {
            //Base Panel Contents
            panel.Size = new Size();
            panel.Location = new Point();
            panel.Name = "";
            panel.BackColor = Color.Transparent;

            //Count Label Contents
            count.Size = new Size();
            count.Location = new Point();
            count.Name = "";
            count.BackColor = Color.Transparent;
            count.ForeColor = Color.White;
            count.Text = "";
            count.Font = new Font(count.Font.FontFamily, 12);

            //Name Label Contents
            name.Size = new Size();
            name.Location = new Point();
            name.Name = "";
            name.BackColor = Color.Transparent;
            name.ForeColor = Color.White;
            name.Text = "";
            name.Font = count.Font;

            //Category Label Contents
            category.Size = new Size();
            category.Location = new Point();
            category.Name = "";
            category.BackColor = Color.Transparent;
            category.ForeColor = Color.White;
            category.Text = "";
            category.Font = count.Font;

            //Price Label Contents
            price.Size = new Size();
            price.Location = new Point();
            price.Name = "";
            price.BackColor = Color.Transparent;
            price.ForeColor = Color.White;
            price.Text = "";
            price.Font = count.Font;

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
