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
    public partial class FRM_ProductUnits : Form
    {

        PL.Products prods = new PL.Products();

        public FRM_ProductUnits()
        {
            InitializeComponent(); 
        }

        public void load_all_product_units() {

            datagrid_product_units.DataSource = prods.Get_All_Product_Units();

            datagrid_product_units.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
             
            datagrid_product_units.Columns["title"].Visible = true;
            datagrid_product_units.Columns["shortcut"].Visible = true;

            datagrid_product_units.Columns["title"].Width = 200;
            datagrid_product_units.Columns["shortcut"].Width = 150;

            datagrid_product_units.Columns["title"].HeaderText = "إسم الوحدة";
            datagrid_product_units.Columns["shortcut"].HeaderText = "إختصار لإسم الوحدة";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(datagrid_product_units.Rows.Count == 0 )
            {
                return;
            }

            if (datagrid_product_units.Rows[0].Cells["title"].Value == null) {
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("title");
            table.Columns.Add("shortcut");
            DataRow drow;
            foreach (DataGridViewRow row in datagrid_product_units.Rows ) {
                if (row.Cells["title"].Value != null && row.Cells["shortcut"].Value != null) { 
                    drow = table.NewRow();
                    drow["title"] = row.Cells["title"].Value.ToString();
                    drow["shortcut"] = row.Cells["shortcut"].Value.ToString();
                    table.Rows.Add(drow);
                }
            }

            prods.Update_Product_Units_DataSet(table);
        }

        private void FRM_ProductUnits_Load(object sender, EventArgs e)
        {
            // Store DataGridview Data 
            this.load_all_product_units();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show( "من الممكن أن يتأثر بعض عمليات الفواتير إذا تم إجراء الحذف هل أنت موافق ؟", "تأكيد", MessageBoxButtons.YesNo );

            if (datagrid_product_units.Rows.Count == 0) {
                return;
            }

            if (datagrid_product_units.Rows[0].Cells["title"].Value == null) {
                return;
            }

            if (result == DialogResult.Yes && datagrid_product_units.CurrentCell.RowIndex != -1) {
                int index = datagrid_product_units.CurrentCell.RowIndex;

                if(datagrid_product_units.Rows[index].Cells["title"].Value != null ) { 
                    datagrid_product_units.Rows.RemoveAt(index);
                }
            }
            
        }
    }
}
