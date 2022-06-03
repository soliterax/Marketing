using Marketing.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoliteraxControlLibrary;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;

namespace Marketing.Panels.Sub_Panels.Workers_Menu
{
    public class WorkerAddPanel : PanelTemplate
    {

        Panel panel = new Panel();

        CustomTextBox tx_name = new CustomTextBox();
        CustomTextBox tx_surname = new CustomTextBox();
        CustomTextBox tx_username = new CustomTextBox();
        CustomTextBox tx_password = new CustomTextBox();
        CustomTextBox tx_salary = new CustomTextBox();
        CustomTextBox tx_title = new CustomTextBox();

        CustomButton tx_permission = new CustomButton();

        CustomButton addButton = new CustomButton();

        Panel permPanel = new Panel();
        CheckBox ch_default = new CheckBox();
        CheckBox ch_superAdmin = new CheckBox();
        CheckBox ch_productAdd = new CheckBox();
        CheckBox ch_productSee = new CheckBox();
        CheckBox ch_productDelete = new CheckBox();
        CheckBox ch_workerAdd = new CheckBox();
        CheckBox ch_workerSee = new CheckBox();
        CheckBox ch_workerDelete = new CheckBox();
        CustomButton ch_Accept = new CustomButton();

        public WorkerAddPanel()
        {

        }

        public WorkerAddPanel(User user)
        {

        }

        public void InitializeComponents(Size size)
        {
            panel.Size = new Size((int)(size.Width), (int)(size.Height));
            panel.Location = new Point(0, 0);
            panel.BackColor = ColorTranslator.FromHtml("#212121");
            panel.Name = "WorkerAddPanel";

            //TextBox Contents
            tx_name.Size = new Size((int)(panel.Size.Width * 0.33), (int)(panel.Size.Height * 0.05));
            tx_name.Location = new Point(0, 0);
            tx_name.Name = "tx_name";
            tx_name.BackColor = panel.BackColor;
            tx_name.ForeColor = Color.White;
            tx_name.BorderColor = tx_name.ForeColor;
            tx_name.Font = new Font(tx_name.Font.FontFamily, 12);
            tx_name.UnderlinedStyle = true;
            tx_name.PlaceholderText = "Name";

            tx_surname.Size = tx_name.Size;
            tx_surname.Location = new Point(panel.Size.Width - tx_name.Size.Width, 0);
            tx_surname.Name = "tx_surname";
            tx_surname.BackColor = tx_name.BackColor;
            tx_surname.ForeColor = tx_name.ForeColor;
            tx_surname.BorderColor = tx_name.BorderColor;
            tx_surname.Font = tx_name.Font;
            tx_surname.UnderlinedStyle = tx_name.UnderlinedStyle;
            tx_surname.BorderSize = tx_name.BorderSize;
            tx_surname.PlaceholderText = "Surname";

            tx_username.Size = tx_name.Size;
            tx_username.Location = new Point(0, tx_name.Size.Height + 50);
            tx_username.Name = "tx_username";
            tx_username.BackColor = tx_name.BackColor;
            tx_username.ForeColor = tx_name.ForeColor;
            tx_username.BorderColor = tx_name.BorderColor;
            tx_username.Font = tx_name.Font;
            tx_username.UnderlinedStyle = tx_name.UnderlinedStyle;
            tx_username.BorderSize = tx_name.BorderSize;
            tx_username.PlaceholderText = "Username";

            tx_password.Size = tx_name.Size;
            tx_password.Location = new Point(panel.Size.Width - tx_username.Size.Width, tx_username.Location.Y);
            tx_password.Name = "tx_password";
            tx_password.BackColor = tx_name.BackColor;
            tx_password.ForeColor = tx_name.ForeColor;
            tx_password.BorderColor = tx_name.BorderColor;
            tx_password.Font = tx_name.Font;
            tx_password.UnderlinedStyle = tx_name.UnderlinedStyle;
            tx_password.BorderSize = tx_name.BorderSize;
            tx_password.PlaceholderText = "Password";

            tx_salary.Size = tx_name.Size;
            tx_salary.Location = new Point(0, tx_username.Location.Y + tx_username.Size.Height + 50);
            tx_salary.Name = "tx_salary";
            tx_salary.BackColor = tx_name.BackColor;
            tx_salary.ForeColor = tx_name.ForeColor;
            tx_salary.BorderColor = tx_name.BorderColor;
            tx_salary.Font = tx_name.Font;
            tx_salary.UnderlinedStyle = tx_name.UnderlinedStyle;
            tx_salary.BorderSize = tx_name.BorderSize;
            tx_salary.PlaceholderText = "Salary";

            tx_title.Size = tx_name.Size;
            tx_title.Location = new Point(panel.Size.Width - tx_salary.Size.Width, tx_salary.Location.Y);
            tx_title.Name = "tx_title";
            tx_title.BackColor = tx_name.BackColor;
            tx_title.ForeColor = tx_name.ForeColor;
            tx_title.BorderColor = tx_name.BorderColor;
            tx_title.Font = tx_name.Font;
            tx_title.UnderlinedStyle = tx_name.UnderlinedStyle;
            tx_title.BorderSize = tx_name.BorderSize;
            tx_title.PlaceholderText = "Title";


            //Button Contents
            tx_permission.Size = new Size(panel.Size.Width / 3, tx_name.Size.Height * 2);
            tx_permission.Location = new Point((panel.Size.Width / 2) - (tx_permission.Size.Width / 2), panel.Size.Height - (tx_permission.Size.Height * 2 + 20));
            tx_permission.Name = "PermissionButton";
            tx_permission.BackColor = Color.Transparent;
            tx_permission.ForeColor = Color.White;
            tx_permission.Font = new Font(addButton.Font.FontFamily, 12);
            tx_permission.TextAlign = ContentAlignment.MiddleCenter;
            tx_permission.Text = "Set Permissions";
            tx_permission.BorderSize = 2;
            tx_permission.BorderColor = addButton.ForeColor;
            tx_permission.BorderRadius = 20;
            tx_permission.Click += PermButton_Click;

            addButton.Size = tx_permission.Size;
            addButton.Location = new Point((panel.Size.Width / 2) - (addButton.Size.Width / 2), panel.Size.Height - addButton.Size.Height);
            addButton.Name = "";
            addButton.BackColor = Color.Transparent;
            addButton.ForeColor = Color.White;
            addButton.Font = new Font(addButton.Font.FontFamily, 12);
            addButton.TextAlign = ContentAlignment.MiddleCenter;
            addButton.Text = "AddWorker";
            addButton.BorderSize = 2;
            addButton.BorderColor = addButton.ForeColor;
            addButton.BorderRadius = 20;
            addButton.Click += AddButton_Click;

            permPanelInitialize();
            permPanel.Visible = false;

            panel.Controls.Add(permPanel);
            panel.Controls.Add(tx_name);
            panel.Controls.Add(tx_surname);
            panel.Controls.Add(tx_username);
            panel.Controls.Add(tx_password);
            panel.Controls.Add(tx_salary);
            panel.Controls.Add(tx_title);
            panel.Controls.Add(tx_permission);
            panel.Controls.Add(addButton);
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!tx_name.Texts.Equals(string.Empty))
                user.user_Name = tx_name.Texts;
            else
                user.user_Name = "-";
            if (!tx_surname.Texts.Equals(string.Empty))
                user.user_Surname = tx_surname.Texts;
            else
                user.user_Surname = "-";
            if (!tx_username.Texts.Equals(string.Empty))
                user.user_username = tx_username.Texts;
            else
                user.user_username = "-";
            if (!tx_password.Texts.Equals(string.Empty))
                user.user_password = tx_password.Texts;
            else
                user.user_password = "-";
            if (!tx_title.Texts.Equals(String.Empty))
                user.user_Title = tx_title.Texts;
            else
                user.user_Title = "-";
            if (!tx_salary.Texts.Equals(string.Empty))
                user.user_Bill = decimal.Parse(tx_salary.Texts);
            else
                user.user_Bill = 0;
            panel.Dispose();
            GC.Collect();
            AddClicked.Invoke(user, null);
        }

        private void PermButton_Click(object sender, EventArgs e)
        {
            permPanel.Visible = true;
        }

        public void permPanelInitialize()
        {
            permPanel.Size = panel.Size;
            permPanel.Location = new Point(0, 0);
            permPanel.Name = "PermPanel";
            permPanel.BackColor = ColorTranslator.FromHtml("#212121");

            ch_default.Size = new Size((int)(permPanel.Size.Height / 3), (int)(permPanel.Size.Height * 0.2));
            ch_default.Location = new Point(0, 0);
            ch_default.Name = "ch_default";
            ch_default.BackColor = permPanel.BackColor;
            ch_default.ForeColor = Color.White;
            ch_default.Checked = true;
            ch_default.Text = "default";
            ch_default.Font = tx_username.Font;

            ch_superAdmin.Size = ch_default.Size;
            ch_superAdmin.Location = new Point(ch_default.Size.Width, 0);
            ch_superAdmin.Name = "ch_superAdmin";
            ch_superAdmin.BackColor = permPanel.BackColor;
            ch_superAdmin.ForeColor = ch_default.ForeColor;
            ch_superAdmin.Checked = false;
            ch_superAdmin.Text = "Super Admin";
            ch_superAdmin.Font = tx_username.Font;

            ch_productAdd.Size = ch_default.Size;
            ch_productAdd.Location = new Point(0, ch_default.Size.Height + 20);
            ch_productAdd.Name = "ch_productAdd";
            ch_productAdd.BackColor = permPanel.BackColor;
            ch_productAdd.ForeColor = ch_default.ForeColor;
            ch_productAdd.Checked = false;
            ch_productAdd.Text = "Add Product";
            ch_productAdd.Font = tx_username.Font;

            ch_productSee.Size = ch_default.Size;
            ch_productSee.Location = new Point(ch_productAdd.Size.Width, ch_default.Size.Height + 20);
            ch_productSee.Name = "ch_productSee";
            ch_productSee.BackColor = permPanel.BackColor;
            ch_productSee.ForeColor = ch_default.ForeColor;
            ch_productSee.Checked = false;
            ch_productSee.Text = "See Product";
            ch_productSee.Font = tx_username.Font;

            ch_productDelete.Size = ch_default.Size;
            ch_productDelete.Location = new Point(ch_productSee.Location.X + ch_productSee.Size.Width, ch_default.Size.Height + 20);
            ch_productDelete.Name = "ch_productDelete";
            ch_productDelete.BackColor = permPanel.BackColor;
            ch_productDelete.ForeColor = ch_default.ForeColor;
            ch_productDelete.Checked = false;
            ch_productDelete.Text = "Delete Product";
            ch_productDelete.Font = tx_username.Font;

            ch_workerAdd.Size = ch_default.Size;
            ch_workerAdd.Location = new Point(0, ch_productAdd.Location.Y + ch_productAdd.Size.Height + 20);
            ch_workerAdd.Name = "ch_workerAdd";
            ch_workerAdd.BackColor = permPanel.BackColor;
            ch_workerAdd.ForeColor = ch_default.ForeColor;
            ch_workerAdd.Checked = false;
            ch_workerAdd.Text = "Add Worker";
            ch_workerAdd.Font = tx_username.Font;

            ch_workerSee.Size = ch_default.Size;
            ch_workerSee.Location = new Point(ch_workerAdd.Size.Width, ch_productAdd.Location.Y + ch_productAdd.Size.Height + 20);
            ch_workerSee.Name = "ch_workerSee";
            ch_workerSee.BackColor = permPanel.BackColor;
            ch_workerSee.ForeColor = ch_default.ForeColor;
            ch_workerSee.Checked = false;
            ch_workerSee.Text = "See Worker";
            ch_workerSee.Font = tx_username.Font;

            ch_workerDelete.Size = ch_default.Size;
            ch_workerDelete.Location = new Point(ch_workerSee.Location.X + ch_workerSee.Size.Width, ch_productAdd.Location.Y + ch_productAdd.Size.Height + 20);
            ch_workerDelete.Name = "ch_workerDelete";
            ch_workerDelete.BackColor = permPanel.BackColor;
            ch_workerDelete.ForeColor = ch_default.ForeColor;
            ch_workerDelete.Checked = false;
            ch_workerDelete.Text = "Delete Worker";
            ch_workerDelete.Font = tx_username.Font;

            ch_Accept.Size = ch_workerDelete.Size;
            ch_Accept.Location = new Point((permPanel.Size.Width / 2) - (ch_Accept.Size.Width / 2), permPanel.Size.Height - ch_Accept.Size.Height);
            ch_Accept.Name = "ch_Accept";
            ch_Accept.BackColor = permPanel.BackColor;
            ch_Accept.ForeColor = ch_default.ForeColor;
            ch_Accept.BorderColor = ch_Accept.ForeColor;
            ch_Accept.BorderSize = 2;
            ch_Accept.Text = "Accept";
            ch_Accept.Click += Button_Click;

            permPanel.Controls.Add(ch_default);
            permPanel.Controls.Add(ch_superAdmin);
            permPanel.Controls.Add(ch_productAdd);
            permPanel.Controls.Add(ch_productSee);
            permPanel.Controls.Add(ch_productDelete);
            permPanel.Controls.Add(ch_workerAdd);
            permPanel.Controls.Add(ch_workerSee);
            permPanel.Controls.Add(ch_workerDelete);
            permPanel.Controls.Add(ch_Accept);

        }
        User user = new User();
        private void Button_Click(object sender, EventArgs e)
        {
            switch (((Control)sender).Name)
            {
                case "ch_Accept":
                    permPanel.Visible = false;
                    LinkedList<Permissions> perms = new LinkedList<Permissions>();
                    if (ch_default.Checked)
                        perms.AddLast(PermissionManager.GetPermission(0));
                    if (ch_superAdmin.Checked)
                        perms.AddLast(PermissionManager.GetPermission(-1));
                    if (ch_productSee.Checked)
                        perms.AddLast(PermissionManager.GetPermission(1));
                    if (ch_productAdd.Checked)
                        perms.AddLast(PermissionManager.GetPermission(2));
                    if (ch_productDelete.Checked)
                        perms.AddLast(PermissionManager.GetPermission(3));
                    if (ch_workerSee.Checked)
                        perms.AddLast(PermissionManager.GetPermission(4));
                    if (ch_workerAdd.Checked)
                        perms.AddLast(PermissionManager.GetPermission(5));
                    if (ch_workerDelete.Checked)
                        perms.AddLast(PermissionManager.GetPermission(6));

                    user.user_Permissions = perms.ToArray();
                    break;
                default:
                    break;
            }
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }

        public Control GetPanel()
        {
            return panel;
        }

        public event EventHandler AddClicked;
    }
}
