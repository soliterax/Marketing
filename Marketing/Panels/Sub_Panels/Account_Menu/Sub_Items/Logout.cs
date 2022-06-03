using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Marketing.Panels.Sub_Panels.Account_Menu.Sub_Items
{
    public class Logout : AccountMenuItem
    {

        public Logout()
        {
            base.backColor = Color.Transparent;
            base.fontColor = Color.White;
            base.itemText = "Çıkış Yap";
            base.itemImage = Properties.Resources.Logout;
        }

        protected override void Click_Event(object sender, EventArgs e)
        {
            Application.OpenForms[0].Controls[1].Dispose();
            Application.OpenForms[0].Controls.Remove(Application.OpenForms[0].Controls[1]);
            Login login = new Login();
            login.InitializeComponents(Application.OpenForms[0].Size);
            Application.OpenForms[0].Controls.Add(login.GetPanel());
            GC.Collect();
        }

    }
}
