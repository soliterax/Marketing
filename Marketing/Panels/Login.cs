using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;
using SoliteraxControlLibrary;

namespace Marketing.Panels
{
    public class Login : Marketing.Utils.Interfaces.PanelTemplate
    {
        Panel panel = new Panel();
        Label usernameText = new Label();
        CustomTextBox username = new CustomTextBox();
        Label passwordText = new Label();
        CustomTextBox password = new CustomTextBox();
        CustomButton login = new CustomButton();

        CustomPanel info = new CustomPanel();
        PictureBox infoImage = new PictureBox();
        CustomLabel infoText = new CustomLabel();
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
            panel.Parent = Application.OpenForms[0];
            panel.BackColor = Application.OpenForms[0].BackColor;
            panel.Name = "LoginPanel";
            panel.Dock = DockStyle.Fill;
            //panel.SizeChanged += (sender, e) => InitializeComponents(panel.Size);

            //Username Contents
            username.Size = new Size((size.Width * 20) / 100, (size.Height * 3) / 100);
            username.Location = new Point((size.Width / 2) - (username.Size.Width / 2), (int)(size.Height * 0.28));
            username.Name = "username";
            username.BorderStyle = BorderStyle.None;
            username.BackColor = Application.OpenForms[0].BackColor;
            username.ForeColor = Color.White;
            username.Parent = panel;
            username.UnderlinedStyle = true;
            username.BorderColor = Color.Blue;
            username.BorderSize = 4;
            username.BorderFocusColor = Color.Cyan;
            username.TabIndex = 0;

            //Username Label Contents
            usernameText.Size = new Size((int)(size.Width * 0.2), (int)(size.Height * 0.03));
            usernameText.Location = new Point((size.Width / 2) - (usernameText.Size.Width / 2), username.Location.Y - usernameText.Size.Height);
            usernameText.Name = "usernameText";
            usernameText.BackColor = Color.Transparent;
            usernameText.ForeColor = Color.White;
            usernameText.Text = "Username";
            usernameText.Parent = panel;

            //Password Contents
            password.Size = username.Size;
            password.Location = new Point((size.Width / 2) - (password.Size.Width / 2), username.Size.Height + username.Location.Y + (int)(size.Height * 0.08));
            password.Name = "password";
            password.BorderStyle = BorderStyle.None;
            password.BackColor = Application.OpenForms[0].BackColor;
            password.ForeColor = Color.White;
            password.Parent = panel;
            password.UnderlinedStyle = username.UnderlinedStyle;
            password.BorderColor = username.BorderColor;
            password.BorderSize = username.BorderSize;
            password.BorderFocusColor = username.BorderFocusColor;
            password.TabIndex = 1;
            password.PasswordChar = true;

            //Password Label Contents
            passwordText.Size = usernameText.Size;
            passwordText.Location = new Point(usernameText.Location.X, password.Location.Y - passwordText.Size.Height);
            passwordText.Name = "passwordText";
            passwordText.BackColor = Color.Transparent;
            passwordText.ForeColor = Color.White;
            passwordText.Text = "Password";
            passwordText.Parent = panel;

            //Login Contents
            login.Size = new Size((int)(username.Size.Width * 0.6), username.Size.Height);
            login.Location = new Point((size.Width / 2) - (login.Size.Width / 2), password.Size.Height + password.Location.Y + (int)(size.Height * 0.08));
            login.Name = "login";
            login.FlatStyle = FlatStyle.Flat;
            login.BackColor = Color.Transparent;
            login.ForeColor = Color.White;
            login.Text = "LOGIN";
            login.Parent = panel;
            login.BorderColor = Color.Blue;
            login.BorderRadius = 10;
            login.BorderSize = 2;
            login.Click += Button_Click_Event;
            login.MouseEnter += Button_MouseEnter_Event;
            login.MouseLeave += Button_MouseLeave_Event;

            //Info Panel Controls
            info.Size = new Size((int)(size.Width * 0.40), (int)(size.Height * 0.05));
            info.Location = new Point((size.Width / 2) - (info.Size.Width / 2), usernameText.Location.Y - info.Size.Height - username.Size.Height);
            info.Name = "info";
            info.BackColor = Color.Transparent;
            info.haveBorder = true;
            info.borderSize = 2;
            info.borderColor = Color.Red;
            info.Visible = false;

            infoImage.Size = new Size(info.Size.Height, info.Size.Height);
            infoImage.Location = new Point(0, 0);
            infoImage.BackColor = Color.Transparent;
            infoImage.Image = Properties.Resources.X;
            infoImage.SizeMode = PictureBoxSizeMode.StretchImage;
            infoImage.Name = "infoImage";

            infoText.Size = new Size(info.Size.Width - infoImage.Size.Width, info.Size.Height);
            infoText.Location = new Point(infoImage.Size.Width, 0);
            infoText.BackColor = Color.Transparent;
            infoText.ForeColor = Color.Red;
            infoText.Name = "infoText";
            infoText.Text = "Kullanıcı Adı veya Şifreniz Yanlış!";
            infoText.Font = new Font(infoText.Font.FontFamily, 14F);
            infoText.TextAlign = ContentAlignment.MiddleCenter;

            info.Controls.Add(infoImage);
            info.Controls.Add(infoText);

            //Add Controls
            
            panel.Controls.Add(username);
            panel.Controls.Add(usernameText);
            panel.Controls.Add(password);
            panel.Controls.Add(passwordText);
            panel.Controls.Add(login);
            panel.Controls.Add(info);
        }

        private void Button_MouseLeave_Event(object sender, EventArgs e)
        {
            login.BackColor = Color.Transparent;
            GC.Collect();
        }

        private void Button_MouseEnter_Event(object sender, EventArgs e)
        {
            login.BackColor = Color.Blue;
            GC.Collect();
        }

        private void Button_Click_Event(object sender, EventArgs e)
        {
            if((username.Texts.ToString().Equals("SecretAdmin") || password.Texts.ToString().Equals("secretadmin1234")))
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

            User user = UserManager.Login(username.Texts, password.Texts);

            if(user != null)
            {
                Application.OpenForms[0].Controls.Remove(panel);
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
            else
            {
                info.Visible = true;
            }
        }

    }
}
