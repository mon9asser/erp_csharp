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
    public partial class FRM_Stores : Form
    {

        PL.Stores Store = new PL.Stores();
        public FRM_Stores that;

        public FRM_Stores()
        {
            InitializeComponent();
            that = this;
        }

        public void load_datagridview_stores() {


            datagrid_accounts_tree.DataSource = Store.Get_All_Stores();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable table = Store.Get_Sotore_Id();


            UI.FRM_UpdateStore newStore = new UI.FRM_UpdateStore(
                table,
                that
            );

            newStore.ShowDialog();
            this.load_datagridview_stores();
        }
    }
}
