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
            MessageBox.Show("İşçiler ekranı açılacak!");
        }
    }
}
