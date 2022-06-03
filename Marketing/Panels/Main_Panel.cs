using SoliteraxControlLibrary;
using Marketing.Panels.Sub_Panels.Account_Menu;
using Marketing.Panels.Sub_Panels.MainMenu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marketing.Utils.Managers;

namespace Marketing.Panels
{
    public class Main_Panel : Marketing.Utils.Interfaces.PanelTemplate
    {

        Panel panel = new Panel();
        Utils.Base_Classes.User user = UserManager.loggedUser;

        AccountPanel ap;
        
        ListPanel lp;

        CustomPictureBox urun_ekle = new CustomPictureBox();
        CustomPictureBox odeme = new CustomPictureBox();
        
        public Main_Panel()
        {
            ap = new AccountPanel();
            lp = new ListPanel();
        }

        public Control GetPanel()
        {
            GC.Collect();
            return panel;
        }

        public void InitializeComponents(Size size)
        {

            panel.Size = size;
            panel.BackColor = Color.Transparent;
            panel.Name = "Main_Panel";
            panel.Dock = DockStyle.Fill;

            ap.InitializeComponents(size);
            lp.InitializeComponents(size);


            urun_ekle.Size = new Size((int)(size.Width * 0.05), (int)(size.Width * 0.05));
            urun_ekle.Location = new Point((size.Width / 2) - (urun_ekle.Size.Width * 2 / 2 - 10), lp.GetPanel().Location.Y + lp.GetPanel().Size.Height);
            urun_ekle.Name = "urunekleButton";
            urun_ekle.BackColor = ColorTranslator.FromHtml("#323232");
            urun_ekle.Image = Properties.Resources.Cart_Picture;
            urun_ekle.SizeMode = PictureBoxSizeMode.StretchImage;
            urun_ekle.haveBorder = true;
            urun_ekle.borderSize = 1;
            urun_ekle.borderColor = Color.White;
            urun_ekle.Click += Button_Click;

            odeme.Size = urun_ekle.Size;
            odeme.Location = new Point(urun_ekle.Location.X + urun_ekle.Size.Width + 10, urun_ekle.Location.Y);
            odeme.Name = "odemeButton";
            odeme.BackColor = urun_ekle.BackColor;
            odeme.Image = Properties.Resources.Bill_Picture;
            odeme.SizeMode = PictureBoxSizeMode.StretchImage;
            odeme.haveBorder = urun_ekle.haveBorder;
            odeme.borderSize = urun_ekle.borderSize;
            odeme.borderColor = urun_ekle.borderColor;
            odeme.Click += Button_Click;

            panel.Controls.Add(ap.GetPanel());
            panel.Controls.Add(lp.GetPanel());
            panel.Controls.Add(urun_ekle);
            panel.Controls.Add(odeme);
            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            switch(c.Name.ToString())
            {
                case "odemeButton":
                    MessageBox.Show("Ödemeye basıldı!");
                    break;
                case "urunekleButton":
                    MessageBox.Show("Ürün eklemeye basıldı!");
                    break;
                default:
                    throw new Exception();

            }
        }

        public void SetPanel(Control control)
        {
            this.panel = (Panel)control;
        }
    }
}
