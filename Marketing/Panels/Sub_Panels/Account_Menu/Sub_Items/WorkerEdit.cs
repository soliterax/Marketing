using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Marketing.Panels.Sub_Panels.Account_Menu.Sub_Items
{
    public class WorkerEdit : AccountMenuItem
    {

        public WorkerEdit()
        {
            base.itemText = "Çalışanlar";
            base.backColor = Color.Transparent;
            base.fontColor = Color.White;
            base.itemImage = Properties.Resources.Workers;
        }

        protected override void Click_Event(object sender, EventArgs e)
        {
            Application.OpenForms[0].Controls[1].Dispose();
            Application.OpenForms[0].Controls.Remove(Application.OpenForms[0].Controls[1]);
            WorkersPanel p = new WorkersPanel();
            p.InitializeComponents(Application.OpenForms[0].Size);
            Application.OpenForms[0].Controls.Add(p.GetPanel());
            GC.Collect();
        }
    }
}
