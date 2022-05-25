using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Base_Classes
{
    public class Permissions
    {
        public string permission_Name { get; set; }
        public long permission_Id { get; set; }

        public override string ToString()
        {
            return permission_Id.ToString() + Environment.NewLine +
                permission_Name.ToString();
        }
    }
}
