using Marketing.Panels.Sub_Panels;
using Marketing.Panels.Sub_Panels.MainMenu;
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

        AccountPanel ap = new AccountPanel();
        ListPanel lp = new ListPanel();

        Button urun_ekle = new Button();
        Button odeme = new Button();
        public Main_Panel()
        {

        }
        public Main_Panel(Utils.Base_Classes.User user)
        {
            this.user = user;
        }

        public Control GetPanel()
        {
            GC.Collect();
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = size;
            panel.BackColor = Color.Transparent;
            panel.Name = "Main_Panel";
            panel.Dock = DockStyle.Fill;

            ap.InitializeComponents(size);
            lp.InitializeComponents(size);

            urun_ekle.Size = new Size((int)(size.Width * 0.05), (int)(size.Width * 0.05));
            urun_ekle.Location = new Point((size.Width / 2) - (urun_ekle.Size.Width * 2 / 2), lp.GetPanel().Location.Y + lp.GetPanel().Size.Height);
            urun_ekle.Name = "urunekleButton";
            urun_ekle.BackColor = ColorTranslator.FromHtml("#323232");
            urun_ekle.ForeColor = Color.White;
            urun_ekle.FlatStyle = FlatStyle.Flat;
            urun_ekle.Text = "";

            odeme.Size = urun_ekle.Size;
            odeme.Location = new Point(urun_ekle.Location.X + urun_ekle.Size.Width, urun_ekle.Location.Y);
            odeme.Name = "odemeButton";
            odeme.BackColor = urun_ekle.BackColor;
            odeme.ForeColor = urun_ekle.ForeColor;
            odeme.FlatStyle = urun_ekle.FlatStyle;
            odeme.Text = "";

            panel.Controls.Add(ap.GetPanel());
            panel.Controls.Add(lp.GetPanel());
            panel.Controls.Add(urun_ekle);
            panel.Controls.Add(odeme);
            
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
