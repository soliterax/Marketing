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

namespace Marketing.Panels.Sub_Panels.Workers_Menu.Sub_Items
{
    public class WorkerListItem
    {

        CustomPanel panel = new CustomPanel();

        private Image USERIMAGE = null;
        private User WORKER = null;
        private Color BACKCOLOR = Color.Transparent;
        private Color FORECOLOR = Color.White;

        WorkerList listPanel;
        User user = UserManager.loggedUser;

        Panel mainPanel = new Panel();
        PictureBox userImage = new PictureBox();
        CustomLabel userName = new CustomLabel();
        CustomLabel userSurname = new CustomLabel();
        CustomLabel userUsername = new CustomLabel();
        CustomLabel userPassword = new CustomLabel();

        Panel buttonPanel = new Panel();
        PictureBox remove = new PictureBox();
        PictureBox edit = new PictureBox();

        Panel editPanel = new Panel();
        PictureBox editPanelSave = new PictureBox();
        CustomTextBox tx_userName = new CustomTextBox();
        CustomTextBox tx_userSurname = new CustomTextBox();
        CustomTextBox tx_userUsername = new CustomTextBox();
        CustomTextBox tx_userPassword = new CustomTextBox();

        public WorkerListItem(WorkerList panel)
        {
            this.listPanel = panel;
        }

        public Control GetPanel()
        {
            return panel;
        }

        public void InitializeComponents(Size size)
        {

            panel.Size = new Size(size.Width, (int)(size.Height * 0.08));
            panel.Name = "WorkerListItem";
            panel.BackColor = BACKCOLOR;
            panel.haveBorder = true;
            panel.borderColor = Color.Blue;
            panel.borderSize = 2;

            #region Main Panel Controls
            mainPanel.Size = panel.Size;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.BackColor = BACKCOLOR;

            userImage.Size = new Size(panel.Size.Height, panel.Size.Height);
            userImage.Location = new Point(0, 0);
            userImage.Name = "userImage";
            userImage.BackColor = BACKCOLOR;
            userImage.Image = USERIMAGE;
            userImage.SizeMode = PictureBoxSizeMode.StretchImage;


            userName.Size = new Size((size.Width - userImage.Size.Width) / 4, panel.Size.Height);
            userName.Location = new Point(userImage.Size.Width, 0);
            userName.Name = "userName";
            userName.BackColor = BACKCOLOR;
            userName.ForeColor = FORECOLOR;

            userName.TextAlign = ContentAlignment.MiddleCenter;
            userName.Font = new Font(userName.Font.FontFamily, 12f);
            userName.haveBorder = true;
            userName.BorderSize = 2;
            userName.BorderColor = Color.Blue;


            userSurname.Size = userName.Size;
            userSurname.Location = new Point(userName.Location.X + userName.Size.Width, 0);
            userSurname.Name = "userSurname";
            userSurname.BackColor = BACKCOLOR;
            userSurname.ForeColor = FORECOLOR;
            userSurname.TextAlign = userName.TextAlign;
            userSurname.Font = userName.Font;

            userSurname.haveBorder = true;
            userSurname.BorderColor = Color.Blue;
            userSurname.BorderSize = 2;
            userSurname.borderLeftSize = 0;


            userUsername.Size = userSurname.Size;
            userUsername.Location = new Point(userSurname.Location.X + userSurname.Size.Width, 0);
            userUsername.Name = "userUsername";
            userUsername.BackColor = BACKCOLOR;
            userUsername.ForeColor = FORECOLOR;
            userUsername.TextAlign = userSurname.TextAlign;
            userUsername.Font = userSurname.Font;

            userUsername.haveBorder = true;
            userUsername.BorderColor = Color.Blue;
            userUsername.BorderSize = 2;
            userUsername.borderLeftSize = 0;


            userPassword.Size = userUsername.Size;
            userPassword.Location = new Point(userUsername.Location.X + userUsername.Size.Width, 0);
            userPassword.Name = "userPassword";
            userPassword.BackColor = BACKCOLOR;
            userPassword.ForeColor = FORECOLOR;
            userPassword.TextAlign = userUsername.TextAlign;
            userPassword.Font = userUsername.Font;

            userPassword.haveBorder = true;
            userPassword.BorderColor = Color.Blue;
            userPassword.BorderSize = 2;
            userPassword.borderLeftSize = 0;

            SetTexts();
            #endregion

            #region Buttons Panel Controls
            buttonPanel.Size = panel.Size;
            buttonPanel.Location = new Point(0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.BackColor = BACKCOLOR;
            buttonPanel.Visible = false;

            edit.Size = new Size((int)(panel.Size.Height * 0.88), (int)(panel.Size.Height * 0.88));
            edit.Location = new Point(((panel.Size.Width / 2) - (edit.Size.Width * 2 / 2)) - edit.Size.Width, (panel.Size.Height / 2) - (edit.Size.Height / 2));
            edit.BackColor = Color.Transparent;
            edit.Name = "editButton";
            edit.Image = Properties.Resources.editPictureButton;
            edit.SizeMode = PictureBoxSizeMode.StretchImage;

            remove.Size = edit.Size;
            remove.Location = new Point(((panel.Size.Width / 2) - (remove.Size.Width)) + remove.Size.Width, (panel.Size.Height / 2) - (remove.Size.Height / 2));
            remove.BackColor = Color.Transparent;
            remove.Name = "removeButton";
            remove.Image = Properties.Resources.RemovePictureButton;
            remove.SizeMode = PictureBoxSizeMode.StretchImage;
            #endregion

            editPanel.Size = panel.Size;
            editPanel.Location = new Point(0, 0);
            editPanel.Name = "editPanel";
            editPanel.BackColor = BACKCOLOR;
            editPanel.Visible = false;

            editPanelSave.Size = new Size((int)(editPanel.Size.Height * 0.88), (int)(editPanel.Size.Height * 0.88));
            editPanelSave.Location = new Point((int)(editPanel.Size.Height * 0.12), (editPanel.Size.Height / 2) - (editPanelSave.Size.Height / 2));
            editPanelSave.Name = "editPanelSave";
            editPanelSave.BackColor = BACKCOLOR;
            editPanelSave.Image = Properties.Resources.successfulPictureButton;
            editPanelSave.SizeMode = PictureBoxSizeMode.StretchImage;

            tx_userName.Size = new Size((editPanel.Size.Width - editPanelSave.Location.X + editPanelSave.Size.Width) / 4, editPanelSave.Size.Height);
            tx_userName.Location = new Point(editPanelSave.Size.Width, editPanelSave.Location.Y);
            tx_userName.Name = "tx_userName";
            tx_userName.BackColor = BACKCOLOR;
            tx_userName.ForeColor = FORECOLOR;
            tx_userName.PlaceholderColor = Color.Gray;
            tx_userName.PlaceholderText = WORKER.user_Name.ToString();
            tx_userName.BorderColor = FORECOLOR;
            tx_userName.BorderSize = 2;
            tx_userName.UnderlinedStyle = true;


            tx_userSurname.Size = tx_userName.Size;
            tx_userSurname.Location = new Point(tx_userName.Location.X + tx_userName.Size.Width, tx_userName.Location.Y);
            tx_userSurname.Name = "tx_userSurname";
            tx_userSurname.BackColor = tx_userName.BackColor;
            tx_userSurname.ForeColor = tx_userName.ForeColor;
            tx_userSurname.PlaceholderColor = tx_userName.PlaceholderColor;
            tx_userSurname.PlaceholderText = WORKER.user_Surname.ToString();
            tx_userSurname.BorderColor = tx_userName.BorderColor;
            tx_userSurname.BorderSize = tx_userName.BorderSize;
            tx_userSurname.UnderlinedStyle = tx_userName.UnderlinedStyle;

            tx_userUsername.Size = tx_userName.Size;
            tx_userUsername.Location = new Point(tx_userSurname.Location.X + tx_userSurname.Size.Width, tx_userSurname.Location.Y);
            tx_userUsername.Name = "tx_userUsername";
            tx_userUsername.BackColor = tx_userName.BackColor;
            tx_userUsername.ForeColor = tx_userName.ForeColor;
            tx_userUsername.PlaceholderColor = tx_userName.PlaceholderColor;
            tx_userUsername.PlaceholderText = WORKER.user_username.ToString();
            tx_userUsername.BorderColor = tx_userName.BorderColor;
            tx_userUsername.BorderSize = tx_userName.BorderSize;
            tx_userUsername.UnderlinedStyle = tx_userName.UnderlinedStyle;

            tx_userPassword.Size = tx_userName.Size;
            tx_userPassword.Location = new Point(tx_userUsername.Location.X + tx_userUsername.Size.Width, tx_userUsername.Location.Y);
            tx_userPassword.Name = "tx_userPassword";
            tx_userPassword.BackColor = tx_userName.BackColor;
            tx_userPassword.ForeColor = tx_userName.ForeColor;
            tx_userPassword.PlaceholderColor = tx_userName.PlaceholderColor;
            tx_userPassword.PlaceholderText = WORKER.user_password.ToString();
            tx_userPassword.BorderColor = tx_userName.BorderColor;
            tx_userPassword.BorderSize = tx_userName.BorderSize;
            tx_userPassword.UnderlinedStyle = tx_userName.UnderlinedStyle;

            //Events
            if (user.havePermission(PermissionManager.GetPermission(4)) || user.havePermission(PermissionManager.GetPermission(5)) || UserManager.loggedUser.havePermission(PermissionManager.GetPermission(-1)))
            {
                panel.Click += Panel_Enter;
                userImage.Click += Panel_Enter;
                userName.Click += Panel_Enter;
                userSurname.Click += Panel_Enter;
                userUsername.Click += Panel_Enter;
                userPassword.Click += Panel_Enter;
                buttonPanel.Click += Panel_Enter;
                edit.Click += Panel_Enter;
                remove.Click += Panel_Enter;
                editPanelSave.Click += Panel_Enter;
            }

            buttonPanel.Controls.Add(edit);
            buttonPanel.Controls.Add(remove);


            mainPanel.Controls.Add(userImage);
            mainPanel.Controls.Add(userName);
            mainPanel.Controls.Add(userSurname);
            mainPanel.Controls.Add(userUsername);
            mainPanel.Controls.Add(userPassword);

            editPanel.Controls.Add(editPanelSave);
            editPanel.Controls.Add(tx_userName);
            editPanel.Controls.Add(tx_userSurname);
            editPanel.Controls.Add(tx_userUsername);
            editPanel.Controls.Add(tx_userPassword);

            panel.Controls.Add(editPanel);
            panel.Controls.Add(buttonPanel);
            panel.Controls.Add(mainPanel);

        }

        public event EventHandler SaveUser;

        void SetTexts()
        {
            userName.Text = WORKER.user_Name;
            userSurname.Text = WORKER.user_Surname;
            userUsername.Text = WORKER.user_username;
            userPassword.Text = WORKER.user_password;
        }


        public void SetPanel(Control control)
        {
            this.panel = (CustomPanel)control;
        }

        private void Panel_Enter(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "editButton":
                    if ((user.havePermission(PermissionManager.GetPermission(5)) && user.havePermission(PermissionManager.GetPermission(6))) || UserManager.loggedUser.havePermission(PermissionManager.GetPermission(-1)))
                    {
                        buttonPanel.Visible = false;
                        editPanel.Visible = true;
                    }
                    return;
                case "removeButton":
                    if (user.havePermission(PermissionManager.GetPermission(6)) || UserManager.loggedUser.havePermission(PermissionManager.GetPermission(-1)))
                    {
                        UserManager.RemoveUser(WORKER);
                        changedValues.Invoke(null, null);
                    }
                    return;
                case "editPanelSave":
                    if(!tx_userName.Texts.Equals(string.Empty))
                        WORKER.user_Name = tx_userName.Texts;
                    else
                        WORKER.user_Name = tx_userName.PlaceholderText;
                    if(!tx_userSurname.Texts.Equals(string.Empty))
                        WORKER.user_Surname = tx_userSurname.Texts;
                    else
                        WORKER.user_Surname = tx_userSurname.PlaceholderText;
                    if (!tx_userUsername.Texts.Equals(string.Empty))
                        WORKER.user_username = tx_userUsername.Texts;
                    else
                        WORKER.user_username = tx_userUsername.PlaceholderText;
                    if (!tx_userPassword.Texts.Equals(string.Empty))
                        WORKER.user_password = tx_userPassword.Texts;
                    else
                        WORKER.user_password = tx_userPassword.PlaceholderText;
                    UserManager.SaveUser(WORKER);
                    SetTexts();
                    editPanel.Visible = false;
                    SaveUser.Invoke(WORKER, null);
                    return;
                default:
                    break;
            }

            if (buttonPanel.Visible)
                buttonPanel.Visible = false;
            else
                buttonPanel.Visible = true;
        }

        public event EventHandler changedValues;


        public Image image
        {
            get
            {
                return USERIMAGE;
            }
            set
            {
                this.USERIMAGE = value;
            }
        }
        public User Worker
        {
            get
            {
                return WORKER;
            }
            set
            {
                this.WORKER = value;
            }
        }
        public Color BackColor
        {
            get
            {
                return BACKCOLOR;
            }
            set
            {
                this.BACKCOLOR = value;
            }
        }
        public Color ForeColor
        {
            get
            {
                return FORECOLOR;
            }
            set
            {
                this.FORECOLOR = value;
            }
        }

    }
}
