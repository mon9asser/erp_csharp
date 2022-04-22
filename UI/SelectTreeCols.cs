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
    public partial class SelectTreeCols : Form
    {

        private string[] All_Rows;
        private string[] All_Cols;

        public SelectTreeCols()
        {
            InitializeComponent();
        }

        public SelectTreeCols( string[] rows, string[] cols)
        {
            
            this.All_Rows = rows; // need extractions 
            this.All_Cols = cols;

            InitializeComponent();
            

        }


    }
}
