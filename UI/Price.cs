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
    public partial class Price : Form
    {
         
        public static int doc_type = -1;
        public static Price frm;

        public int Set_Document_Type
        {
            get { return doc_type; }
            set { doc_type = value; }
        }

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static Price GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Price();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }
        

        public Price() {

            InitializeComponent();

            if(doc_type == -1 )
            {
                return;
            }

            MessageBox.Show(doc_type.ToString());
        }



    }
}
