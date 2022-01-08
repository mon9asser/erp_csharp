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
        
        private int userId;
        private string userName;
        private string fullName;

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
    }
}
