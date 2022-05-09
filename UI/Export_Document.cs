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
    public partial class Export_Document : Form
    {
        public Export_Document()
        {

            InitializeComponent();

            // Get All Export Documents 
            this.Load_All_Documents();

            // Get All Documents 
            this.Load_All_Items();

            int id = -1;
            if (Exep_id.Text == "") {
                id = -1;
            }

            // Fill All Information 
            this.Load_DataGridView_And_Items(id);

        }

        public void Load_All_Documents() {

        }

        public void Load_All_Items() {

        }

        public void Load_DataGridView_And_Items(int id) {

        }


    }
}
