using Marketing.Panels;
using Marketing.Utils.Base_Classes;
using Marketing.Utils.Managers;
using SoliteraxControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Marketing
{
    public partial class Main_Form : Form
    {
        protected static int C_Width = Screen.PrimaryScreen.WorkingArea.Width;
        protected static int C_Height = Screen.PrimaryScreen.WorkingArea.Height;
        protected static string ProgramName = "";


        NavigationBar nav = new NavigationBar();
        Login login = new Login();

        public Main_Form()
        {
            InitializeComponent();
            ControlSystem();
        }


        private void Login_Panel_Load(object sender, EventArgs e)
        {
            //this.SizeChanged += SizeChangedM;
            Main();
        }
        bool maximized = false;

        void Test()
        {
            MessageBox.Show("ID: " + ProductManager.GetProduct(0).product_Id.ToString() + Environment.NewLine +
                "Name: " + ProductManager.GetProduct(0).product_Name.ToString() + Environment.NewLine +
                "Category Name: " + ProductManager.GetProduct(0).product_Category.category_Name.ToString() + Environment.NewLine +
                "Price: " + ProductManager.GetProduct(0).product_Price.ToString() + " TL");
            /*SoliteraxLibrary.UI.CircularProgressBar progress = new SoliteraxLibrary.UI.CircularProgressBar();
            progress.Progress_Color = Color.Red;
            progress.Progress_TextColor = Color.Red;
            progress.BackColor = Color.White;
            progress.Progress_TextSize = 20;
            progress.Progress_Value = 10;
            progress.Progress_MaxValue = 100;
            progress.Size = new Size(100, 100);
            progress.Location = new Point(0, 0);

            this.Controls.Add(progress);*/
        }

        void ControlSystem()
        {
            //What is AI sir?
            if(!Directory.Exists(Environment.CurrentDirectory + "/Categories"))
                if(!Directory.Exists(Environment.CurrentDirectory + "/History"))
                    if(!Directory.Exists(Environment.CurrentDirectory + "/Logs"))
                        if(!Directory.Exists(Environment.CurrentDirectory + "/Permissions"))
                            if(!Directory.Exists(Environment.CurrentDirectory + "/Products"))
                                if(!Directory.Exists(Environment.CurrentDirectory + "/Users"))
                                {
                                    Directory.CreateDirectory(Environment.CurrentDirectory + "/Categories");
                                    Directory.CreateDirectory(Environment.CurrentDirectory + "/History");
                                    Directory.CreateDirectory(Environment.CurrentDirectory + "/Logs");
                                    Directory.CreateDirectory(Environment.CurrentDirectory + "/Permissions");
                                    Directory.CreateDirectory(Environment.CurrentDirectory + "/Products");                  //This is AI
                                    Directory.CreateDirectory(Environment.CurrentDirectory + "/Users");
                                }

            LoadSystem();
        }

        void LoadSystem()
        {
            new PermissionManager();
            new CategoryManager();
            new ProductManager();
            new UserManager();
            this.Load += Login_Panel_Load;
            User user = new User();
            user.user_Id = -1;
            user.user_username = "SecretAdmin";
            user.user_password = "secretadmin1234";
            user.user_Permissions = new Permissions[]
            {
                PermissionManager.GetPermission(1),
                PermissionManager.GetPermission(2),
                PermissionManager.GetPermission(3),
                PermissionManager.GetPermission(4),
                PermissionManager.GetPermission(5),
                PermissionManager.GetPermission(6)
            };
            user.user_Title = "Administrator";
            user.user_Bill = 0;
            user.user_Name = "??????";
            user.user_Surname = "????????";
            UserManager.loggedUser = user;
        }

        void Main()
        {
            this.Controls.Clear();
            SetMainContents();
        }

        void SetMainContents()
        {
            
            //Form Contents
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = (maximized) ? new Size(C_Width, C_Height) : new Size((int)(C_Width * 0.8), (int)(C_Height * 0.8));
            this.Location = (maximized) ? new Point(0, 0) : new Point((C_Width / 2) - (this.Size.Width / 2), (C_Height / 2) - (this.Size.Height / 2));
            this.BackColor = ColorTranslator.FromHtml("#212121");//ColorTranslator.FromHtml("#9FC2C2"); Aydınlık Temaya bu kod olucak

            //Navigation Bar
            nav.InitializeComponents(this.Size);
            Panel _nav = (Panel)nav.GetPanel();
            _nav.Location = new Point(0,0);
            
            //login Panel
            login.InitializeComponents(new Size(this.Size.Width, this.Size.Height - _nav.Size.Height));
            Panel p = (Panel)login.GetPanel();
            p.Location = new Point(0, _nav.Size.Height);

            //Form Add Control
            this.Controls.Add(_nav);
            this.Controls.Add(p);
        }

        private void SizeChangedM(object sender, EventArgs e)
        {
            //Utils.Managers.PanelManager.RecalculateControl(this.Size);
        }

    }
}
//2351 satır