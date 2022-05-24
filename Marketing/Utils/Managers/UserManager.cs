using Marketing.Utils.Base_Classes;
using SoliteraxLibrary.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Utils.Managers
{
    public class UserManager
    {

        static LinkedList<User> items = new LinkedList<User>();

        static string path = Environment.CurrentDirectory + "/Users";

        public static User loggedUser;

        public UserManager()
        {
            SaveAllSaves();
        }

        public static void SaveAllSaves()
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                SoliteraxFile data = new SoliteraxFile(file);
                items.AddLast(CalculateAndGetProduct(data.ReadAllLines()));
            }
        }

        public static User Login(string username, string password)
        {
            foreach(User user in items)
            {
                if (username.Equals(user.user_username) && password.Equals(user.user_password))
                {
                    loggedUser = user;
                    return user;
                }
            }

            return null;
        }
        public static User GetUser(int id)
        {
            foreach(User s in items)
            {
                if (s.user_Id == id)
                    return s;
            }
            return null;
        }

        private static User CalculateAndGetProduct(string[] data)
        {
            User user = new User();

            user.user_Id = int.Parse(data[0]);
            user.user_username = data[1];
            user.user_password = data[2];
            user.user_Name = data[3];
            user.user_Surname = data[4];
            user.user_Title = data[5];
            user.user_Bill = decimal.Parse(data[6]);
            LinkedList<Permissions> perms = new LinkedList<Permissions>();
            for(int i = 6; i < data.Length; i++)
            {
                perms.AddLast(PermissionManager.GetPermission(int.Parse(data[i])));
            }
            user.user_Permissions = perms.ToArray();
            perms.Clear();
            perms = null;
            GC.Collect();
            return user;
        }
    }
}
