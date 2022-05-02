using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Base_Classes
{
    public class Product
    {
        public int product_Id { get; set; }
        public string product_Name { get; set; }
        public decimal product_Price { get; set; }
        public long product_Amount { get; set; }
        public long product_Barcode { get; set; }
        public Category product_Category { get; set; }
    }
}
