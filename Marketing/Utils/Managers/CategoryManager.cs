using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class CategoryManager : Interfaces.ManagerTemplate
    {
        LinkedList<Base_Classes.Category> categories = new LinkedList<Base_Classes.Category>();

        public int Find(object value)
        {
            throw new NotImplementedException();
        }

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
    }
}
