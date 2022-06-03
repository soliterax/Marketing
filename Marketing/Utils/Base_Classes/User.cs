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

        public string user_Title;

        public decimal user_Bill;

        public Permissions[] user_Permissions = new List<Permissions>().ToArray();

        public override string ToString()
        {
            string text = user_Id.ToString() + Environment.NewLine +
                user_username.ToString() + Environment.NewLine +
                user_password.ToString() + Environment.NewLine +
                user_Name.ToString() + Environment.NewLine +
                user_Surname.ToString() + Environment.NewLine +
                user_Title.ToString() + Environment.NewLine +
                user_Bill.ToString();

            foreach(Permissions perm in user_Permissions)
                text += Environment.NewLine + perm.permission_Id.ToString();

            return text;
        }

        public bool havePermission(Permissions perm)
        {
            
            return user_Permissions.Contains(perm);
        }

    }
}
