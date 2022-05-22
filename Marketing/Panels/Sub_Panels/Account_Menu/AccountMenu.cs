using SoliteraxControlLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels.Sub_Panels.Account_Menu
{
    public class AccountMenu : Utils.Interfaces.PanelTemplate
    {

        LinkedList<AccountMenuItem> item = new LinkedList<AccountMenuItem>();

        CustomPanel panel = new CustomPanel();

        public AccountMenu()
        {
            
            this.item.AddLast(new Sub_Items.PropertiesItem());
            this.item.AddLast(new Sub_Items.Logout());
            AddMenuItem(new Sub_Items.WorkerEdit());
            AddMenuItem(new Sub_Items.ProductEditItem());
        }

        public void SetMenuItems(AccountMenuItem[] accountMenuItems)
        {
            foreach(AccountMenuItem item in accountMenuItems)
            {
                this.item.AddFirst(item);
            }
        }

        public void AddMenuItem(AccountMenuItem accountMenuItem)
        {
            item.AddFirst(accountMenuItem);
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size(size.Width, (int)((size.Height * 3) * 0.20) * item.Count);
            panel.Name = "AccountMenu";
            panel.BackColor = ColorTranslator.FromHtml("#212121");//ColorTranslator.FromHtml("#212121");
            panel.Visible = false;
            panel.haveBorder = true;
            panel.borderSize = 1;
            panel.borderColor = ColorTranslator.FromHtml("#404FCF");

            foreach(AccountMenuItem item in this.item)
            {
                item.InitializeComponents(new Size(size.Width, size.Height * 3));
            }

            item.ToArray()[0].GetPanel().Location = new Point(0, 0);
            panel.Controls.Add(item.ToArray()[0].GetPanel());
            for(int i = 1; i < item.ToArray().Length; i++) 
            {
                Control p = item.ToArray()[i].GetPanel();
                p.Location = new Point(0, item.ToArray()[i - 1].GetPanel().Size.Height + item.ToArray()[i-1].GetPanel().Location.Y);
                panel.Controls.Add(p);
            }

        }

        public void SetPanel(Control control)
        {
            this.panel = (CustomPanel)control;
        }
    }
}
