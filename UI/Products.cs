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
    public partial class Products : Form
    {
        public bool isOpenUints = false;
        

        public static Products frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Products getForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Products();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public Products()
        {
            InitializeComponent();
            if(frm == null )
            {
                frm = this;
            }
        }

        // Disply uniit management
        private void textBox7_Click(object sender, EventArgs e)
        {
            UI.Units.getMainForm.Show();
            this.isOpenUints = true; 
             
        }
    }
}
