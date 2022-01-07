using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sales_management.UI
{
    public partial class ServerSettings : Form
    {
        DB.Config SystemConf = new DB.Config();

        public ServerSettings()
        {
            InitializeComponent();

            this.LoadSystemConfiguration(); 
        }
         

        public void LoadSystemConfiguration() {

            if (SystemConf.isFileExists()) { 
                
                SystemConf.LoadSystemConfiguration();
                networkid_text.Text = SystemConf.GetNetworkId();
                databasename_text.Text = SystemConf.GetDatabaseName();
                password_text.Text = SystemConf.GetPassword();
                username_text.Text = SystemConf.GetUserName();
                networkpost_text.Text = SystemConf.GetPort();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Store Json File 
            DB.Server serverInformation = new DB.Server()
            {
                Id = 1,
                ServerId = networkid_text.Text.ToString(),
                Port = networkpost_text.Text.ToString(),
                DatabaseName = databasename_text.Text.ToString(),
                UserName = username_text.Text.ToString(),
                Password = password_text.Text.ToString() 
            };

            SystemConf.CreateServerInformation(serverInformation);


            // Test The Connection 


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
