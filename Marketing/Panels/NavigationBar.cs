﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketing.Panels
{
    public class NavigationBar : Utils.Interfaces.PanelTemplate
    {
        Panel navigation = new Panel();
        PictureBox nav_Image = new PictureBox();
        Label nav_Text = new Label();
        PictureBox nav_Minimize = new PictureBox();
        PictureBox nav_Maximize = new PictureBox();
        PictureBox nav_Shutdown = new PictureBox();
        public Control GetPanel()
        {
            return navigation;
        }

        public void InitializeComponents(Size size)
        {
            navigation.Size = new Size(size.Width, (int)(size.Height * 0.06));
            navigation.Location = new Point(0, 0);
            navigation.Name = "navigation";
            navigation.BackColor = Color.Black;
            navigation.Dock = DockStyle.Top;
            navigation.MouseDown += Start_MoveForm;
            navigation.MouseUp += Stop_MoveForm;
            navigation.MouseMove += Start_Move;

            //Shutdown Contents
            nav_Shutdown.Size = new Size((int)(navigation.Size.Height * 0.75), (int)(navigation.Size.Height * 0.75));
            nav_Shutdown.Location = new Point(navigation.Size.Width - nav_Shutdown.Size.Width - ((int)(navigation.Size.Height * 0.25)), (navigation.Size.Height / 2) - (nav_Shutdown.Size.Height / 2));
            nav_Shutdown.Name = "nav_Shutdown";
            nav_Shutdown.BackColor = Color.Transparent;
            nav_Shutdown.Image = Properties.Resources.shutdown;
            nav_Shutdown.SizeMode = PictureBoxSizeMode.StretchImage;
            nav_Shutdown.Anchor = AnchorStyles.Right;
            nav_Shutdown.Click += Button_Click_Event;
            nav_Shutdown.MouseEnter += Button_MouseEnter_Event;
            nav_Shutdown.MouseLeave += Button_MouseLeave_Event;

            //Maximize Contents
            nav_Maximize.Size = nav_Shutdown.Size;
            nav_Maximize.Location = new Point(nav_Shutdown.Location.X - nav_Maximize.Size.Width - ((int)(navigation.Size.Height * 0.25)), (navigation.Size.Height / 2) - (nav_Maximize.Size.Height / 2));
            nav_Maximize.Name = "nav_Maximize";
            nav_Maximize.BackColor = Color.Transparent;
            nav_Maximize.Image = Properties.Resources.maximize;
            nav_Maximize.SizeMode = PictureBoxSizeMode.StretchImage;
            nav_Maximize.Anchor = AnchorStyles.Right;
            nav_Maximize.Click += Button_Click_Event;
            nav_Maximize.MouseEnter += Button_MouseEnter_Event;
            nav_Maximize.MouseLeave += Button_MouseLeave_Event;

            //Minimize Contents
            nav_Minimize.Size = nav_Shutdown.Size;
            nav_Minimize.Location = new Point(nav_Maximize.Location.X - nav_Minimize.Size.Width - ((int)(navigation.Size.Height * 0.25)), (navigation.Size.Height / 2) - (nav_Minimize.Size.Height / 2));
            nav_Minimize.Name = "nav_Minimize";
            nav_Minimize.BackColor = Color.Transparent;
            nav_Minimize.Image = Properties.Resources.minimize;
            nav_Minimize.SizeMode = PictureBoxSizeMode.StretchImage;
            nav_Minimize.Anchor = AnchorStyles.Right;
            nav_Minimize.Click += Button_Click_Event;
            nav_Minimize.MouseEnter += Button_MouseEnter_Event;
            nav_Minimize.MouseLeave += Button_MouseLeave_Event;

            //Image Contets
            nav_Image.Size = nav_Shutdown.Size;
            nav_Image.Location = new Point(((int)(navigation.Size.Height * 0.25)), (navigation.Size.Height / 2) - (nav_Image.Size.Height / 2));
            nav_Image.Name = "nav_Image";
            nav_Image.BackColor = Color.Transparent;
            nav_Image.Image = Properties.Resources.logo;
            nav_Image.SizeMode = PictureBoxSizeMode.StretchImage;
            nav_Image.Anchor = AnchorStyles.Left;

            //Text Contents
            nav_Text.Size = new Size(navigation.Size.Width - (navigation.Size.Width - nav_Minimize.Location.X - (nav_Image.Location.X + nav_Image.Size.Width + ((int)(navigation.Size.Height * 0.25)))), navigation.Size.Height);
            nav_Text.Location = new Point(nav_Image.Location.X + nav_Image.Size.Width, 0);
            nav_Text.Name = "nav_Text";
            nav_Text.BackColor = Color.Transparent;
            nav_Text.ForeColor = Color.White;
            nav_Text.Anchor = AnchorStyles.Left;
            nav_Text.Text = $"{ConfigurationManager.AppSettings.Get("Name")} - {ConfigurationManager.AppSettings.Get("Version")}";
            nav_Text.TextAlign = ContentAlignment.MiddleLeft;
            nav_Text.Font = new Font(nav_Text.Font.FontFamily, 10);
            nav_Text.MouseDown += Start_MoveForm;
            nav_Text.MouseUp += Stop_MoveForm;
            nav_Text.MouseMove += Start_Move;

            //Add Controls
            navigation.Controls.Add(nav_Shutdown);
            navigation.Controls.Add(nav_Maximize);
            navigation.Controls.Add(nav_Minimize);
            navigation.Controls.Add(nav_Image);
            navigation.Controls.Add(nav_Text);
        }

        public void SetPanel(Control control)
        {
            this.navigation = (Panel)control;
        }

        Point fMouseLocation = Point.Empty;
        private void Start_MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                fMouseLocation = new Point(e.X, e.Y);
        }

        private void Stop_MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                fMouseLocation = Point.Empty;
        }

        private void Start_Move(object sender, MouseEventArgs e)
        {
            if (fMouseLocation != Point.Empty)
                Application.OpenForms[0].Location = new Point(Application.OpenForms[0].Left + e.X - fMouseLocation.X, Application.OpenForms[0].Top + e.Y - fMouseLocation.Y);
            /*
            Point mouseLocation = new Point(Cursor.Position.X, Cursor.Position.Y);
            this.Location = new Point(
                (mouseLocation.X > fMouseLocation.X) ? this.Location.X + (mouseLocation.X - fMouseLocation.X): this.Location.X - (fMouseLocation.X - mouseLocation.X), 
                (mouseLocation.Y > fMouseLocation.Y) ? this.Location.Y + (mouseLocation.Y - fMouseLocation.Y) : this.Location.Y - (fMouseLocation.Y - mouseLocation.Y));
            */
        }

        int slipValue = 5;

        //Decrease Size of Button
        private void Button_MouseLeave_Event(object sender, EventArgs e)
        {
            Control enteredButton = ((Control)sender);
            if (enteredButton.Name.Equals("nav_Shutdown") || enteredButton.Name.Equals("nav_Maximize") || enteredButton.Name.Equals("nav_Minimize"))
            {
                Size s = enteredButton.Size;
                enteredButton.Size = new Size((int)(navigation.Size.Height * 0.75), (int)(navigation.Size.Height * 0.75));
                enteredButton.Location = new Point(enteredButton.Location.X + slipValue, (navigation.Size.Height / 2) - (enteredButton.Size.Height / 2));
            }
        }

        //Increase Size of button
        private void Button_MouseEnter_Event(object sender, EventArgs e)
        {
            Control enteredButton = ((Control)sender);
            if (enteredButton.Name.Equals("nav_Shutdown") || enteredButton.Name.Equals("nav_Maximize") || enteredButton.Name.Equals("nav_Minimize"))
            {
                Size s = enteredButton.Size;
                enteredButton.Size = new Size(navigation.Size.Height, navigation.Size.Height);
                enteredButton.Location = new Point(enteredButton.Location.X - slipValue, 0);
            }
        }

        void Button_Click_Event(object sender, EventArgs args)
        {
            try
            {
                Control clickedButton = ((Control)sender);
                switch (clickedButton.Name)
                {
                    case "nav_Shutdown":
                        Application.Exit();
                        break;
                    case "nav_Maximize":
                        if (Application.OpenForms[0].WindowState == FormWindowState.Normal)
                            Application.OpenForms[0].WindowState = FormWindowState.Maximized;
                        else
                            Application.OpenForms[0].WindowState = FormWindowState.Normal;
                        break;
                    case "nav_Minimize":
                        Application.OpenForms[0].WindowState = FormWindowState.Minimized;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}