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
    public partial class DefaultData : Form
    {
        public DefaultData()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Add Default User
            PL.Installings install = new PL.Installings();
            install.Install_Default_data();

            MessageBox.Show("Default Data are ready now");

        }
    }
}
