using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels.Sub_Panels
{
    public class AccountMenu : Utils.Interfaces.PanelTemplate
    {

        LinkedList<AccountMenuItem> item = new LinkedList<AccountMenuItem>();

        Panel panel = new Panel();

        public void SetMenuItems(AccountMenuItem[] accountMenuItems)
        {
            foreach(AccountMenuItem item in accountMenuItems)
            {
                this.item.AddLast(item);
            }
        }

        public void AddMenuItem(AccountMenuItem accountMenuItem)
        {
            item.AddLast(accountMenuItem);
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size(size.Width, size.Height * 3);
            panel.Name = "";
            panel.BackColor = Color.Red;//ColorTranslator.FromHtml("#212121");
            panel.Visible = false;

        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
