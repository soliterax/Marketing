using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Base_Classes
{
    public class User
    {
        public int user_Id;

        public string user_username;

        public string user_password;

        public string user_Name;

        public string user_Surname;

        public Permissions[] user_Permissions;

        public decimal user_Bill;
    }
}
