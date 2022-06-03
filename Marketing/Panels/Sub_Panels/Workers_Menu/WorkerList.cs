using Marketing.Panels.Sub_Panels.Workers_Menu.Sub_Items;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;
using SoliteraxControlLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels.Sub_Panels.Workers_Menu
{
    public class WorkerList : Utils.Interfaces.PanelTemplate
    {

        LinkedList<Sub_Items.WorkerListItem> items = new LinkedList<Sub_Items.WorkerListItem>();

        User user = UserManager.loggedUser;

        CustomPanel panel = new CustomPanel();

        Panel navigationBar = new Panel();
        PictureBox imageColumn = new PictureBox();
        CustomLabel nameText = new CustomLabel();
        CustomLabel surnameText = new CustomLabel();
        CustomLabel usernameText = new CustomLabel();
        CustomLabel passwordText = new CustomLabel();

        PictureBox addProductButton = new PictureBox();

        Panel ListPanel = new Panel();
        CustomPanel RowPanel = new CustomPanel();

        public WorkerList()
        {
            foreach (User cat in UserManager.GetAllUsers())
            {
                items.AddLast(new WorkerListItem(this)
                {
                    BackColor = ColorTranslator.FromHtml("#212121"),
                    ForeColor = Color.White,
                    Worker = cat,
                    image = null
                });

            }
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size((int)(size.Width * 0.85), (int)(size.Height * 0.72));
            panel.Location = new Point((size.Width / 2) - (panel.Size.Width / 2), (size.Height / 2) - (panel.Size.Height / 2));
            panel.Name = "WorkerList";
            panel.BackColor = Color.Transparent;
            panel.borderColor = Color.White;
            panel.borderSize = 2;
            panel.haveBorder = true;

            navigationBar.Size = new Size(panel.Size.Width, (int)(panel.Size.Height * 0.08));
            navigationBar.Location = new Point(0, 0);
            navigationBar.BackColor = ColorTranslator.FromHtml("#404FCF");
            navigationBar.Name = "navigationBar";

            imageColumn.Size = new Size(navigationBar.Size.Height, navigationBar.Size.Height);
            imageColumn.Location = new Point(0, 0);
            imageColumn.BackColor = Color.Transparent;
            imageColumn.Name = "imageColumn";
            imageColumn.Image = Properties.Resources.X;
            imageColumn.SizeMode = PictureBoxSizeMode.StretchImage;

            nameText.Size = new Size((navigationBar.Size.Width - imageColumn.Size.Width) / 4, navigationBar.Size.Height);
            nameText.Location = new Point(imageColumn.Size.Width, 0);
            nameText.BackColor = Color.Transparent;
            nameText.ForeColor = Color.White;
            nameText.Name = "nameText";
            nameText.Text = "Adı";
            nameText.TextAlign = ContentAlignment.MiddleCenter;
            nameText.Font = new Font(nameText.Font.FontFamily, 14);
            nameText.BorderColor = Color.White;
            nameText.BorderSize = 0;
            nameText.borderLeftSize = 2;
            nameText.borderRightSize = 2;
            nameText.haveBorder = true;

            surnameText.Size = nameText.Size;
            surnameText.Location = new Point(nameText.Location.X + nameText.Size.Width, 0);
            surnameText.BackColor = Color.Transparent;
            surnameText.ForeColor = Color.White;
            surnameText.Name = "categoryText";
            surnameText.Text = "Soyadı";
            surnameText.TextAlign = ContentAlignment.MiddleCenter;
            surnameText.Font = nameText.Font;
            surnameText.BorderColor = Color.White;
            surnameText.BorderSize = 0;
            surnameText.borderRightSize = 2;
            surnameText.haveBorder = true;

            usernameText.Size = surnameText.Size;
            usernameText.Location = new Point(surnameText.Location.X + surnameText.Size.Width, 0);
            usernameText.BackColor = Color.Transparent;
            usernameText.ForeColor = Color.White;
            usernameText.Name = "kdvText";
            usernameText.Text = "Kullanıcı Adı";
            usernameText.TextAlign = ContentAlignment.MiddleCenter;
            usernameText.Font = nameText.Font;
            usernameText.BorderColor = Color.White;
            usernameText.BorderSize = 0;
            usernameText.borderRightSize = 2;
            usernameText.haveBorder = true;

            passwordText.Size = usernameText.Size;
            passwordText.Location = new Point(usernameText.Location.X + usernameText.Size.Width, 0);
            passwordText.BackColor = Color.Transparent;
            passwordText.ForeColor = Color.White;
            passwordText.Name = "priceText";
            passwordText.Text = "Şifresi";
            passwordText.TextAlign = ContentAlignment.MiddleCenter;
            passwordText.Font = nameText.Font;
            passwordText.BorderColor = Color.White;
            passwordText.BorderSize = 0;
            passwordText.haveBorder = false;

            navigationBar.Controls.Add(imageColumn);
            navigationBar.Controls.Add(nameText);
            navigationBar.Controls.Add(surnameText);
            navigationBar.Controls.Add(usernameText);
            navigationBar.Controls.Add(passwordText);

            ListPanel.Size = new Size(panel.Size.Width, panel.Size.Height - navigationBar.Size.Height);
            ListPanel.Location = new Point(navigationBar.Location.X, navigationBar.Size.Height);
            ListPanel.BackColor = Color.Transparent;
            ListPanel.Name = "ListPanel";


            RowPanel.Size = new Size(ListPanel.Size.Width, ((this.items.Count >= 1) ? (this.items.Count * this.items.ToArray()[0].GetPanel().Size.Height) : 0));
            RowPanel.Location = new Point(0, 0);
            RowPanel.BackColor = ListPanel.BackColor;
            RowPanel.Name = "RowPanel";

            if (items.Count >= 1)
            {
                WorkerListItem a = items.ToArray()[0];
                a.SaveUser += A_SaveUser;
                a.InitializeComponents(panel.Size);
                Panel _p = (Panel)a.GetPanel();
                _p.Location = new Point(0, 0);
                RowPanel.Controls.Add(_p);
                for (int i = 1; i < items.Count; i++)
                {
                    WorkerListItem item = items.ToArray()[i];
                    item.InitializeComponents(panel.Size);
                    Panel p = (Panel)item.GetPanel();
                    p.Location = new Point(0, items.ToArray()[i - 1].GetPanel().Location.Y + items.ToArray()[i - 1].GetPanel().Size.Height);
                    RowPanel.Controls.Add(p);
                }
            }

            ListPanel.Controls.Add(RowPanel);

            panel.Controls.Add(navigationBar);
            panel.Controls.Add(ListPanel);

        }

        private void A_SaveUser(object sender, EventArgs e)
        {
            
        }

        public void AddUser(User user)
        {
            user.user_Id = UserManager.GetAllUsers().ToArray()[UserManager.GetAllUsers().Count() - 1].user_Id + 1;
            UserManager.AddUser(user);
            WorkerListItem item = new WorkerListItem(this)
            {
                BackColor = ColorTranslator.FromHtml("#212121"),
                ForeColor = Color.White,
                Worker = user,
                image = null
            };
            item.InitializeComponents(panel.Size);

            RowPanel.Size = new Size(RowPanel.Size.Width, RowPanel.Size.Height + item.GetPanel().Size.Height);
            Control c = item.GetPanel();
            c.Location = new Point(0, RowPanel.Controls[RowPanel.Controls.Count - 1].Location.Y + RowPanel.Controls[RowPanel.Controls.Count - 1].Size.Height);
            RowPanel.Controls.Add(c);
            items.AddLast(item);
            GC.Collect();
        }

        public void SetPanel(Control control)
        {
            this.panel = (CustomPanel)control;
        }

    }
}
