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
            LoadAllSaves();
        }

        public static void LoadAllSaves()
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                SoliteraxFile data = new SoliteraxFile(file);
                items.AddLast(CalculateAndGetUser(data.ReadAllLines()));
                /*items.AddLast(
                    CalculateAndGetUser(
                        EncryptionManager.DecryptTexts(
                            data.ReadAllLines()
                            )
                        )
                    );*/
            }
        }

        public static void SaveAllSaves()
        {
            foreach(User user in items)
            {
                SoliteraxFile data = new SoliteraxFile(path + "/" + user.user_Id.ToString() + ".user");
                data.Write(CalculateAndGetSave(user));
            }
        }

        public static User[] GetAllUsers()
        {
            return items.ToArray();
        }

        public static void SaveUser(User user)
        {
            SoliteraxFile data = new SoliteraxFile(path + "/" + user.user_Id + ".user");
            data.Write(user.ToString());
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

        public static void AddUser(User user)
        {
            items.AddLast(user);
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

        private static User CalculateAndGetUser(string[] data)
        {
            User user = new User();

            user.user_Id = int.Parse(data[0]);
            user.user_Name = data[1];
            user.user_Surname = data[2];
            user.user_username = data[3];
            user.user_password = data[4];
            user.user_Title = data[5];
            user.user_Bill = decimal.Parse(data[6]);
            LinkedList<Permissions> perms = new LinkedList<Permissions>();
            for(int i = 6; i < data.Length; i++)
            {
                if(!data[i].ToString().Equals(String.Empty))
                    perms.AddLast(PermissionManager.GetPermission(int.Parse(data[i])));
            }
            user.user_Permissions = perms.ToArray();
            perms.Clear();
            perms = null;
            GC.Collect();
            return user;
        }

        public static string[] CalculateAndGetSaveData(User user)
        {
            LinkedList<string> str = new LinkedList<string>();

            str.AddLast(user.user_Id.ToString());
            str.AddLast(user.user_Name);
            str.AddLast(user.user_Surname);
            str.AddLast(user.user_username);
            str.AddLast(user.user_password);
            str.AddLast(user.user_Title);
            str.AddLast(user.user_Bill.ToString());
            foreach(Permissions perm in user.user_Permissions) 
                if(perm != null)
                    str.AddLast(perm.permission_Id.ToString());

            return str.ToArray();
        }

        public static string CalculateAndGetSave(User user)
        {
            string str = "";
            try
            {
                str += user.user_Id.ToString() + Environment.NewLine;
                str += user.user_Name + Environment.NewLine;
                str += user.user_Surname + Environment.NewLine;
                str += user.user_username + Environment.NewLine;
                str += user.user_password + Environment.NewLine;
                str += user.user_Title + Environment.NewLine;
                str += user.user_Bill.ToString();

                foreach (Permissions perm in user.user_Permissions)
                    if (perm != null)
                        str += Environment.NewLine + perm.permission_Id.ToString();
            }
            catch (NullReferenceException)
            {
                File.Delete(path + "/Users/" + user.user_Id.ToString() + ".user");
            }

            return str;
        }
    }
}
