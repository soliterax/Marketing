using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class ProductManager : Interfaces.ManagerTemplate
    {

        LinkedList<Base_Classes.Product> products = new LinkedList<Base_Classes.Product>();

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
            throw new NotImplementedException();
        }
    }
}
