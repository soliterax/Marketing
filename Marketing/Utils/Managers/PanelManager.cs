using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Utils.Managers
{
    public class PanelManager
    {

        private Dictionary<string, Marketing.Utils.Interfaces.PanelTemplate> panels = new Dictionary<string, Marketing.Utils.Interfaces.PanelTemplate>();

        public PanelManager()
        {

        }

        public Marketing.Utils.Interfaces.PanelTemplate GetPanel(string panelId)
        {
            return panels[panelId];
        }

        public void AddPanel(string panelId, Marketing.Utils.Interfaces.PanelTemplate panel)
        {
            panels.Add(panelId, panel);
        }

        public Marketing.Utils.Interfaces.PanelTemplate RecalculateControl(System.Windows.Forms.Control panel, System.Drawing.Size formNewSize)
        {
            Marketing.Utils.Interfaces.PanelTemplate _panel = null;
            foreach(Interfaces.PanelTemplate value in panels.Values)
            {
                if(value.GetPanel().Name.Equals(panel.Name.ToString()))
                {
                    _panel = value;
                    break;
                }
            }
            
            return (_panel != null) ? _panel : null;
        }

    }
}
