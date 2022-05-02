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
        TextBox username = new TextBox();
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

            //Username Contents
            username.Size = new Size((size.Width * 20) / 100, (size.Height * 3) / 100);
            username.Location = new Point((size.Width / 2) - (username.Size.Width / 2), (int)(size.Height * 0.28));
            username.Name = "username";
            username.BorderStyle = BorderStyle.None;
            username.BackColor = Color.Blue;
            username.ForeColor = Color.White;
            username.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            //Password Contents
            password.Size = username.Size;
            password.Location = new Point((size.Width / 2) - (password.Size.Width / 2), username.Size.Height + username.Location.Y + (int)(size.Height * 0.08));
            password.Name = "password";
            password.BorderStyle = BorderStyle.None;
            password.BackColor = Color.Blue;
            password.ForeColor = Color.White;
            password.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;

            //Login Contents
            login.Size = new Size((int)(username.Size.Width * 0.6), username.Size.Height);
            login.Location = new Point((size.Width / 2) - (login.Size.Width / 2), password.Size.Height + password.Location.Y + (int)(size.Height * 0.08));
            login.Name = "login";
            login.FlatStyle = FlatStyle.Flat;
            login.BackColor = Color.Blue;
            login.ForeColor = Color.White;
            login.Anchor = AnchorStyles.Right | AnchorStyles.Left;
            login.Click += Button_Click_Event;
            login.MouseEnter += Button_MouseEnter_Event;
            login.MouseLeave += Button_MouseLeave_Event;

            //Add Controls
            panel.Controls.Add(username);
            panel.Controls.Add(password);
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
            
        }
    }
}
