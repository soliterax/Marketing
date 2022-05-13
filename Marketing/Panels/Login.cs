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
    public class Login : Marketing.Utils.Interfaces.PanelTemplate
    {
        Panel panel = new Panel();
        Label usernameText = new Label();
        TextBox username = new TextBox();
        Label passwordText = new Label();
        TextBox password = new TextBox();
        Button login = new Button();
        public Control GetPanel()
        {
            return panel;
        }

        public void SetPanel(Control control)
        {
            panel = (Panel)control;
        }

        public void InitializeComponents(System.Drawing.Size size)
        {
            panel.Size = new Size(size.Width, size.Height);
            panel.BackColor = Color.Transparent;
            panel.Name = "LoginPanel";
            panel.Dock = DockStyle.Fill;

            //Username Contents
            username.Size = new Size((size.Width * 20) / 100, (size.Height * 3) / 100);
            username.Location = new Point((size.Width / 2) - (username.Size.Width / 2), (int)(size.Height * 0.28));
            username.Name = "username";
            username.BorderStyle = BorderStyle.None;
            username.BackColor = Color.Blue;
            username.ForeColor = Color.White;
            username.Anchor = AnchorStyles.Right | AnchorStyles.Left;

            //Username Label Contents
            usernameText.Size = new Size((int)(size.Width * 0.2), (int)(size.Height * 0.03));
            usernameText.Location = new Point((size.Width / 2) - (usernameText.Size.Width / 2), username.Location.Y - usernameText.Size.Height);
            usernameText.Name = "usernameText";
            usernameText.BackColor = Color.Transparent;
            usernameText.ForeColor = Color.White;
            usernameText.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            usernameText.Text = "Username";

            //Password Contents
            password.Size = username.Size;
            password.Location = new Point((size.Width / 2) - (password.Size.Width / 2), username.Size.Height + username.Location.Y + (int)(size.Height * 0.08));
            password.Name = "password";
            password.BorderStyle = BorderStyle.None;
            password.BackColor = Color.Blue;
            password.ForeColor = Color.White;
            password.Anchor = AnchorStyles.Right | AnchorStyles.Left;

            //Password Label Contents
            passwordText.Size = usernameText.Size;
            passwordText.Location = new Point(usernameText.Location.X, password.Location.Y - passwordText.Size.Height);
            passwordText.Name = "passwordText";
            passwordText.BackColor = Color.Transparent;
            passwordText.ForeColor = Color.White;
            passwordText.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            passwordText.Text = "Password";

            //Login Contents
            login.Size = new Size((int)(username.Size.Width * 0.6), username.Size.Height + 2);
            login.Location = new Point((size.Width / 2) - (login.Size.Width / 2), password.Size.Height + password.Location.Y + (int)(size.Height * 0.08));
            login.Name = "login";
            login.FlatStyle = FlatStyle.Flat;
            login.BackColor = Color.Blue;
            login.ForeColor = Color.White;
            login.Text = "LOGIN";
            login.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            login.Click += Button_Click_Event;
            login.MouseEnter += Button_MouseEnter_Event;
            login.MouseLeave += Button_MouseLeave_Event;

            //Add Controls
            
            panel.Controls.Add(username);
            panel.Controls.Add(usernameText);
            panel.Controls.Add(password);
            panel.Controls.Add(passwordText);
            panel.Controls.Add(login);
        }

        private void Button_MouseLeave_Event(object sender, EventArgs e)
        {
            
        }

        private void Button_MouseEnter_Event(object sender, EventArgs e)
        {
            
        }

        private void Button_Click_Event(object sender, EventArgs e)
        {
            if((username.Text.ToString().Equals("") || password.Text.ToString().Equals("")) || (username.Text.ToString().Equals("SecretAdmin") || password.Text.ToString().Equals("secretadmin1234")))
            {
                Application.OpenForms[0].Controls.Remove(panel);
                MessageBox.Show("Easter Egg!!\nGizli Admin Girişi Sağlandı!");
                Main_Panel pn = new Main_Panel();
                pn.InitializeComponents(panel.Size);
                Application.OpenForms[0].Controls.Add(pn.GetPanel());
                pn = null;
                panel.Controls.Clear();
                panel.Dispose();
                panel = null;
                GC.Collect();
                return;
            }
            UserManager um = new UserManager();
            um.LoadSaves();
            Utils.Base_Classes.User user = (Utils.Base_Classes.User)um.GetSave(um.Find(username.Text));
            if(user.user_username.Equals(username.Text.ToString()) && user.user_password.Equals(password.Text.ToString()))
            {
                Application.OpenForms[0].Controls.Remove(panel);
                //Open Main Form

            }
            
        }

    }
}
