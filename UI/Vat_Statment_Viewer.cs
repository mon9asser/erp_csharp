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
    public partial class Vat_Statment_Viewer : Form
    {
        public Vat_Statment_Viewer()
        {
            InitializeComponent();
        }
        public Vat_Statment_Viewer(DateTime from_date, DateTime to_date)
        {
            InitializeComponent();
        }
     }
}
