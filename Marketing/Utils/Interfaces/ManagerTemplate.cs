using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Interfaces
{
    public interface ManagerTemplate
    {

        void LoadSaves();

        void SaveSaves();

        Object GetSave(int id);

        void SetSave(int id, Object value);

    }
}
