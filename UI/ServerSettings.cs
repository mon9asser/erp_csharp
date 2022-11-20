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
                isIntegratedCheckbox.Checked = Convert.ToBoolean(SystemConf.isIntegratedSecurity());
                //isIntegratedCheckbox.Checked = Convert.ToBoolean(SystemConf.isIntegratedSecurity());
                enable_edit.Checked = Convert.ToBoolean(SystemConf.isEnabledEditable());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Store Json File 
                DB.Server serverInformation = new DB.Server()
                {
                    Id = 1,
                    ServerId = networkid_text.Text.ToString(),
                    Port = networkpost_text.Text.ToString(),
                    DatabaseName = databasename_text.Text.ToString(),
                    UserName = username_text.Text.ToString(),
                    Password = password_text.Text.ToString(),
                    isIntegrated = Convert.ToBoolean(isIntegratedCheckbox.Checked),
                    isEnabled = Convert.ToBoolean(enable_edit.Checked)
                };

                SystemConf.CreateServerInformation(serverInformation);


                // Test The Connection 
                DB.DataAccessLayer database = new DB.DataAccessLayer();

                database.Open();

                if (database.CheckStatus().ToString() != "Open")
                {
                    MessageBox.Show("Failed Connection");
                }
                else
                {
                    MessageBox.Show("Connection Successfully");
                }

                database.Close();

            } catch
            {
                MessageBox.Show("Failed Connection");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isIntegratedCheckbox_CheckedChanged(object sender, EventArgs e)
        { 
            if (isIntegratedCheckbox.Checked)
            {
                networkpost_text.Enabled = true;
                username_text.Enabled = true;
                password_text.Enabled = true;

            }
            else
            {
                networkpost_text.Enabled = false;
                username_text.Enabled = false;
                password_text.Enabled = false;
            }
        }
    }
}
