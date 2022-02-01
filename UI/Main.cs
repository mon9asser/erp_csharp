using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace sales_management.UI
{
    public partial class Main : Form
    {
        
        private int userId = 1;
        private string userName = "Montasser";
        private string fullName = "Montasser Mossallem";

        public static Main frm;
        static void frm_formClosed(object sernder, FormClosedEventArgs e) {
            frm = null; 
        }
        public static Main getMainForm
        {
            get
            {
                
                if (frm == null ) {
                    frm = new Main();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public void setUserInfo( int userId, string userName, string fullName ) {
            this.userId = userId;
            this.userName = userName;
            this.fullName = fullName;
        }

        public string[] getUserInfo() {

            string[] userInfo = new string[3];

            userInfo[0] = this.userId.ToString();
            userInfo[1] = this.userName;
            userInfo[2] = this.fullName;

            return userInfo;
        }


        public Main()
        {
            InitializeComponent();

           // this.skinEngines.SkinFile = "Skins/SteelBlack.ssk";

            if( frm == null )
            {
                frm = this;
            }
        }

        private void فحصالإتصالبالسيرفرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.ServerSettings serverSettings = new UI.ServerSettings();
            serverSettings.Show();
        }

        private void إعداداتالنظامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.SystemSettings settings = new UI.SystemSettings();
            settings.Show(); 
        }

        private void تهيةالبياناتالأفتراضيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.DefaultData defData = new UI.DefaultData();
            defData.Show();
        }

        private void نسخةإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Backups beackup = new UI.Backups();
            beackup.Show();
        }

        private void إدارةصلاحياتالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Permissions Perm = new UI.Permissions();
            Perm.Show();
        }

        private void إدارةالمنتجاتوالفئاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Products.getForm.Show();
        }

        private void إدارةالفئاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Categories.getForm.Show();
        }

        private void إدارةالوحداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Units units = new UI.Units();
            units.Show();
        }

        private void شجرةالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void الموردينوالتجارToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Resource.GetForm.Show();
        }

        private void كشفالرواتبالشهريToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void العملاءوالمناديبToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UI.Customer.GetForm.Show();
           

        }

        private void شجرةالحساباتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void فاتورةالمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Purchase pur = new UI.Purchase();
            pur.Show();
        }

         
    }
}
