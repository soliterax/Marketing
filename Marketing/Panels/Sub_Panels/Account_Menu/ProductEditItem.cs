using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Marketing.Panels.Sub_Panels.Account_Menu
{
    public class ProductEditItem : AccountMenuItem
    {

        public ProductEditItem()
        {
            base.itemText = "Ürün Düzenleme";
            base.backColor = Color.Transparent;
            base.fontColor = Color.White;
            base.itemImage = Properties.Resources.Products;
        }

        protected override void Click_Event(object sender, EventArgs e)
        {
            MessageBox.Show("Ürün Düzenleme Ekranı Açılacak");
        }
    }
}
