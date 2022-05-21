using Marketing.Panels;
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
            this.Load += Login_Panel_Load;
        }

        private void Login_Panel_Load(object sender, EventArgs e)
        {
            //this.SizeChanged += SizeChangedM;
            Main();
        }
        bool maximized = false;

        void Test()
        {
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
        void Main()
        {
            SetMainContents();
        }

        void SetMainContents()
        {
            
            //Form Contents
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = (maximized) ? new Size(C_Width, C_Height) : new Size((int)(C_Width * 0.8), (int)(C_Height * 0.8));
            this.Location = (maximized) ? new Point(0, 0) : new Point((C_Width / 2) - (this.Size.Width / 2), (C_Height / 2) - (this.Size.Height / 2));
            this.BackColor = ColorTranslator.FromHtml("#212121");

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
            Utils.Managers.PanelManager.RecalculateControl(this.Size);
        }

    }
}
