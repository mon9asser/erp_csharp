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
            try {
                that = this;
                this.load_datagridview_stores();
            } catch (Exception) { }

        }

        public void load_datagridview_stores() {

            try {
                datagrid_accounts_tree.DataSource = Store.Get_All_Stores();
                datagrid_accounts_tree.Columns["id"].Visible = false;
                datagrid_accounts_tree.Columns["fax"].Visible = false;
                datagrid_accounts_tree.Columns["updated_by"].Visible = false;
                datagrid_accounts_tree.Columns["datemade"].Visible = false;
                datagrid_accounts_tree.Columns["created_by"].Visible = false;
                datagrid_accounts_tree.Columns["store_name"].Width = 120;
                datagrid_accounts_tree.Columns["address"].Width = 170;
                datagrid_accounts_tree.Columns["code"].HeaderText = "كود";
                datagrid_accounts_tree.Columns["store_name"].HeaderText = "المخازن";
                datagrid_accounts_tree.Columns["store_branch"].HeaderText = "الفروع";
                datagrid_accounts_tree.Columns["telephone"].HeaderText = "تليفون";
                datagrid_accounts_tree.Columns["address"].HeaderText = "عنوان";
                datagrid_accounts_tree.Columns["cost_center_id"].HeaderText = "مراكز التكلفة";
                datagrid_accounts_tree.ReadOnly = true;
            } catch (Exception) { }


        }

        private void button8_Click(object sender, EventArgs e)
        {
            try {
                int id = -1;
                if (idselected.Text != "")
                {
                    id = Convert.ToInt32(datagrid_accounts_tree.Rows[Convert.ToInt32(idselected.Text)].Cells["id"].Value.ToString());
                }

                if (id == -1) {
                    MessageBox.Show("من فضلك حدد الصف المراد تحديثه من الجدول");
                    return;
                }

                DataTable table = new DataTable();
                DataRow rowx;

                foreach (DataGridViewColumn col in datagrid_accounts_tree.Columns)
                {
                    table.Columns.Add(col.Name.ToString());
                }

                foreach (DataGridViewRow row in datagrid_accounts_tree.Rows)
                {

                    if (Convert.ToInt32(row.Cells["id"].Value).Equals(id))
                    {
                        rowx = table.NewRow();
                        foreach (DataGridViewColumn col in datagrid_accounts_tree.Columns)
                        {
                            rowx[col.Name.ToString()] = row.Cells[col.Name.ToString()].Value.ToString();
                        }
                        table.Rows.Add(rowx);
                    }

                }

                UI.FRM_UpdateStore newStore = new UI.FRM_UpdateStore(
                    table,
                    that
                );

                newStore.ShowDialog();
                this.load_datagridview_stores();
            } catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {

                int id = -1;
                if (idselected.Text != "")
                {
                    id = Convert.ToInt32(datagrid_accounts_tree.Rows[Convert.ToInt32(idselected.Text)].Cells["id"].Value.ToString());
                }

                if (id == -1)
                {
                    MessageBox.Show("من فضلك حدد الصف المراد حذفه من الجدول");
                    return;
                }

                DialogResult dig = MessageBox.Show("سيأثر حذف المخزن في العمليات الحسابيه هل انت متأكد من الحذف", "تأكيد", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == dig)
                {
                     
                    Store.Delete_Store_By_Id(id);
                    this.load_datagridview_stores();

                }

            } catch (Exception) { }

            
        }

        private void datagrid_accounts_tree_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex == -1)
                {
                    return;
                }

                datagrid_accounts_tree.Rows[e.RowIndex].Cells["id"].Value.ToString();
                idselected.Text = e.RowIndex.ToString();
            } catch (Exception) { }            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {

                DataTable table = Store.Create_Store_Id(); ;

                UI.FRM_UpdateStore newStore = new UI.FRM_UpdateStore(
                    table,
                    that
                );

                newStore.ShowDialog();
                this.load_datagridview_stores();
            }
            catch (Exception) { }
        }
    }
}
