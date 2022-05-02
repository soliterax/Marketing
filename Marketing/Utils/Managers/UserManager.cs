using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class UserManager : Marketing.Utils.Interfaces.ManagerTemplate
    {

        static LinkedList<Marketing.Utils.Base_Classes.User> users = new LinkedList<Marketing.Utils.Base_Classes.User>();
        
        public object GetSave(int id)
        {
            return null;
        }

        public void LoadSaves()
        {
            
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
                if (user.user_Name.Equals(value))
                    return user.user_Id;
            }
            throw new NullReferenceException();
        }
    }
}
