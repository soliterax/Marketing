using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Utils.Interfaces
{
    public interface PanelTemplate
    {

        void InitializeComponents(System.Drawing.Size size);

        Control GetPanel();

        void SetPanel(Control control);

    }
}
