using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Utils.Managers
{
    public class PanelManager
    {

        static Dictionary<string, Marketing.Utils.Interfaces.PanelTemplate> panels = new Dictionary<string, Marketing.Utils.Interfaces.PanelTemplate>();

        public PanelManager()
        {

        }

        public static Panel GetPanel(string panelId)
        {
            return (Panel)panels[panelId].GetPanel();
        }

        public static void AddPanel(string panelId, Marketing.Utils.Interfaces.PanelTemplate panel)
        {
            panels.Add(panelId, panel);
        }

        public static void RecalculateControl(System.Drawing.Size formNewSize)
        {
            for(int i = 0; i < Application.OpenForms[0].Controls.Count; i++)
            {
                switch(Application.OpenForms[0].Controls[i].Name.ToString())
                {
                    case "LoginPanel":
                        Application.OpenForms[0].Controls.Remove(Application.OpenForms[0].Controls[i]);
                        Marketing.Panels.Login l = new Panels.Login();
                        l.InitializeComponents(formNewSize);
                        Application.OpenForms[0].Controls.Add(l.GetPanel());
                        break;
                    case "navigation":
                        Application.OpenForms[0].Controls.Remove(Application.OpenForms[0].Controls[i]);
                        Panels.NavigationBar n = new Panels.NavigationBar();
                        n.InitializeComponents(formNewSize);
                        Application.OpenForms[0].Controls.Add(n.GetPanel());
                        break;
                    case "Main_Panel":
                        Application.OpenForms[0].Controls.Remove(Application.OpenForms[0].Controls[i]);
                        Panels.Main_Panel m = new Panels.Main_Panel();
                        m.InitializeComponents(formNewSize);
                        Application.OpenForms[0].Controls.Add(m.GetPanel());
                        break;
                    default:
                        Console.WriteLine(Application.OpenForms[0].Controls[i].Name.ToString() + " not found!");
                        break;
                }
            }
        }

    }
}
