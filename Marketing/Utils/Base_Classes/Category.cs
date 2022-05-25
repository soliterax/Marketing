using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Base_Classes
{
    public class Category
    {
        public int category_Id { get; set; }
        public int KDV { get; set; }
        public string category_Name { get; set; }

        public override string ToString()
        {
            return category_Id.ToString() + Environment.NewLine +
                category_Name.ToString() + Environment.NewLine +
                KDV.ToString() + Environment.NewLine;
        }
    }
}
