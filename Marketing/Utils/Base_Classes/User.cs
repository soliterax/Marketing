using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Base_Classes
{
    public class User
    {
        public int user_Id
        {
            get
            {
                return user_Id;
            }
            set
            {
                user_Id = value;
            }
        }

        public string user_username
        {
            get
            {
                return user_username;
            }
            set
            {
                user_username = value;
            }
        }

        public string user_password
        {
            get
            {
                return user_password;
            }
            set
            {
                user_password = value;
            }
        }

        public string user_Name
        {
            get
            {
                return user_Name;
            }
            set
            {
                user_Name = value;
            }
        }

        public string user_Surname
        {
            get
            {
                return user_Surname;
            }
            set
            {
                user_Surname = value;
            }
        }

        public Permissions[] user_Permissions {
            get
            {
                return user_Permissions;
            }
            set
            {
                user_Permissions = value;
            }
        }

        public decimal user_Bill
        {
            get
            {
                return user_Bill;
            }
            set
            {
                user_Bill = value;
            }
        }
    }
}
