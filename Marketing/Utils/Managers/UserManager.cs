using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class UserManager : Marketing.Utils.Interfaces.ManagerTemplate
    {

        static LinkedList<Marketing.Utils.Base_Classes.User> users = new LinkedList<Marketing.Utils.Base_Classes.User>();
        SoliteraxLibrary.SonsuzLock locker = new SoliteraxLibrary.SonsuzLock("h@x+@r", 3);
        SoliteraxLibrary.SAFile fileStream;

        public object GetSave(int id)
        {
            return users.ToArray()[id];
        }

        public void LoadSaves()
        {
            List<string> files = Directory.GetFiles(Environment.CurrentDirectory + "/Users", "*.user").ToList();
            foreach(string file in files)
            {
                string encodedText = encodeString(file);

            }
        }

        public void SaveSaves()
        {
            
        }

        public void SetSave(int id, object value)
        {
            
        }

        public int Find(object value)
        {
            foreach(Base_Classes.User user in users)
            {
                if (user.user_username.Equals(value))
                    return user.user_Id;
            }
            throw new NullReferenceException();
        }

        string encodeString(string value)
        {

            return null;
        }
    }
}
