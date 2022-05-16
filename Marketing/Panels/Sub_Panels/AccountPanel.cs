using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Interfaces;

namespace Marketing.Panels.Sub_Panels
{
    public class AccountPanel : PanelTemplate
    {

        User user;

        Panel panel = new Panel();
        PictureBox accountPhoto = new PictureBox();
        Label nameText = new Label();
        Label titleText = new Label();

        Image image;

        public AccountPanel()
        {
            this.user = new User();
            user.user_username = "SecretAdmin";
            user.user_Name = "Secret";
            user.user_Surname = "Admin";
            user.user_Id = 0;
            image = Properties.Resources.Admin;
        }

        public AccountPanel(User user)
        {
            this.user = user;
        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size((int)(size.Width * 0.20), (int)(size.Height * 0.08));
            panel.Location = new Point(size.Width - panel.Size.Width, Application.OpenForms[0].Controls[0].Size.Height);
            panel.BackColor = Color.Transparent;
            panel.Name = "accountPanel";
            panel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            panel.Click += Panel_Click;

            accountPhoto.Size = new Size(panel.Size.Height, panel.Size.Height);
            accountPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            accountPhoto.Location = new Point(panel.Size.Width - accountPhoto.Size.Width, 0);
            accountPhoto.BackColor = Color.Transparent;
            accountPhoto.Name = "accountPhoto";
            accountPhoto.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            accountPhoto.Image = image;
            accountPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            accountPhoto.Click += Panel_Click;

            nameText.Size = new Size(accountPhoto.Location.X, panel.Size.Height/2);
            nameText.Location = new Point(0, 0);
            nameText.BackColor = Color.Transparent;
            nameText.ForeColor = Color.White;
            nameText.Name = "nameText";
            nameText.Text = $"{user.user_Name} {user.user_Surname}";
            nameText.TextAlign = ContentAlignment.MiddleLeft;
            nameText.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            nameText.Click += Panel_Click;

            titleText.Size = nameText.Size;
            titleText.Location = new Point(0, nameText.Size.Height);
            titleText.BackColor = nameText.BackColor;
            titleText.ForeColor = nameText.ForeColor;
            titleText.Name = "titleText";
            titleText.Text = "Tester";
            titleText.TextAlign = ContentAlignment.MiddleLeft;
            titleText.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            titleText.Click += Panel_Click;

            panel.Controls.Add(accountPhoto);
            panel.Controls.Add(nameText);
            panel.Controls.Add(titleText);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menü Gösterilcek Unutma!");
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void SetPanel(Control control)
        {
            panel = (Panel)control;
        }

    }
}
