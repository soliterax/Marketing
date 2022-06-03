using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Marketing.Panels.Sub_Panels.Account_Menu.Sub_Items
{
    public class PropertiesItem : AccountMenuItem
    {

        public PropertiesItem()
        {
            base.itemText = "Ayarlar";
            base.itemImage = Properties.Resources.SettingsItemImage;
            base.backColor = Color.Transparent;
            base.fontColor = Color.White;
        }

        protected override void Click_Event(object sender, EventArgs e)
        {
            MessageBox.Show("This menu is under the maintenance!\nComing in version 16.8.9.3", "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

    }
}
