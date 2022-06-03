using Marketing.Panels.Sub_Panels.Workers_Menu;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels
{
    public class WorkersPanel : Utils.Interfaces.PanelTemplate
    {
        Panel panel = new Panel();
        User user = UserManager.loggedUser;
        WorkerList workerList;

        PictureBox addWorkerButton = new PictureBox();


        PictureBox backButton = new PictureBox();
        WorkerAddPanel addPanel = new WorkerAddPanel();

        public WorkersPanel()
        {
            workerList = new WorkerList();
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Location = new Point(0, Application.OpenForms[0].Controls[0].Size.Height);
            panel.Name = "ProductsPanel";
            panel.BackColor = Color.Transparent;
            panel.Dock = DockStyle.Fill;

            backButton.Size = new Size(50, 50);
            backButton.Location = new Point(0, Application.OpenForms[0].Controls[0].Size.Height);
            backButton.Name = "BackButton";
            backButton.BackColor = Color.Transparent;
            backButton.Image = Properties.Resources.BackButton;
            backButton.SizeMode = PictureBoxSizeMode.StretchImage;
            backButton.Click += Button_Click;

            

            workerList.InitializeComponents(size);
            

            addWorkerButton.Size = new Size((int)(panel.Size.Height * 0.5), (int)(panel.Size.Height * 0.5));
            addWorkerButton.Location = new Point(((workerList.GetPanel().Location.X + workerList.GetPanel().Size.Width) / 2) - (addWorkerButton.Size.Width / 2) + 30, workerList.GetPanel().Location.Y + workerList.GetPanel().Size.Height + 20);
            addWorkerButton.Name = "addWorkerButton";
            addWorkerButton.BackColor = panel.BackColor;
            addWorkerButton.Image = Properties.Resources.AddImage;
            addWorkerButton.SizeMode = PictureBoxSizeMode.StretchImage;
            if(UserManager.loggedUser.havePermission(PermissionManager.GetPermission(5)) || UserManager.loggedUser.havePermission(PermissionManager.GetPermission(-1)))
                addWorkerButton.Click += Button_Click;

            panel.Controls.Add(backButton);
            panel.Controls.Add(addWorkerButton);
            panel.Controls.Add(workerList.GetPanel());
            

        }

        private void AddClicked(object sender, EventArgs e)
        {
            workerList.AddUser(((User)sender));
            addWorkerButton.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch(((Control)sender).Name)
            {
                case "addWorkerButton":
                    addPanel.InitializeComponents(workerList.GetPanel().Size);
                    addPanel.AddClicked += AddClicked;
                    Control c = addPanel.GetPanel();
                    c.Location = workerList.GetPanel().Location;
                    panel.Controls.Add(c);
                    c.BringToFront();
                    break;
                case "BackButton":
                    panel.Dispose();
                    Main_Panel m = new Main_Panel();
                    m.InitializeComponents(Application.OpenForms[0].Size);
                    Application.OpenForms[0].Controls.Add(m.GetPanel());
                    break;
                default:
                    break;
            }
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
