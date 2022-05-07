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

            this.load_all_product_units();
        }

        public void load_all_product_units() {

            try
            {

                DataTable prodUnits = prods.Get_All_Product_Units();

                 
                DataRow emptyRow;
                int counters = prodUnits.Rows.Count + 15;
                for (int i = prodUnits.Rows.Count; i < counters; i++)
                {
                    
                    emptyRow = prodUnits.NewRow();
                    emptyRow["id"] = -1;
                    emptyRow["created_by"] = -1;
                    emptyRow["updated_by"] = -1;
                    emptyRow["date_made"] = DateTime.Now;
                    emptyRow["mod_date"] = DateTime.Now;
                    emptyRow["title"] = "";
                    emptyRow["shortcut"] = "";
                    emptyRow["unit_counts"] = "";
                    emptyRow["datagride_id"] = Guid.NewGuid().ToString();
                    prodUnits.Rows.Add(emptyRow);
                }


                datagrid_product_units.DataSource = prodUnits;

                datagrid_product_units.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);

                datagrid_product_units.Columns["title"].Visible = true;
                datagrid_product_units.Columns["shortcut"].Visible = true;

                datagrid_product_units.Columns["title"].Width = 195;
                datagrid_product_units.Columns["shortcut"].Width = 140;

                datagrid_product_units.Columns["title"].HeaderText = "إسم الوحدة";
                datagrid_product_units.Columns["shortcut"].HeaderText = "إختصار لإسم الوحدة";
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (datagrid_product_units.Rows.Count == 0)
            {
                return;
            }

            if (datagrid_product_units.Rows[0].Cells["title"].Value == null)
            {
                return;
            }

            DataTable table = new DataTable();
            table.Columns.Add("title");
            table.Columns.Add("shortcut");
            table.Columns.Add("datagride_id");
            DataRow drow;
            foreach (DataGridViewRow row in datagrid_product_units.Rows)
            {
                if (row.Cells["title"].Value == System.DBNull.Value)
                {
                    continue;
                }


                if (row.Cells["title"].Value != null && row.Cells["shortcut"].Value != null && row.Cells["datagride_id"].Value != null)
                {
                    drow = table.NewRow();
                    drow["title"] = row.Cells["title"].Value.ToString();
                    drow["datagride_id"] = row.Cells["datagride_id"].Value.ToString();
                    drow["shortcut"] = row.Cells["shortcut"].Value.ToString();
                    table.Rows.Add(drow);
                }
            }

            prods.Update_Product_Units_DataSet(table);
        }

        private void FRM_ProductUnits_Load(object sender, EventArgs e)
        {
             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("من الممكن أن يتأثر بعض عمليات الفواتير إذا تم إجراء الحذف هل أنت موافق ؟", "تأكيد", MessageBoxButtons.YesNo);

                if (datagrid_product_units.Rows.Count == 0)
                {
                    return;
                }

                if (datagrid_product_units.Rows[0].Cells["title"].Value == null)
                {
                    return;
                }

                if (result == DialogResult.Yes && datagrid_product_units.CurrentCell.RowIndex != -1)
                {
                    int index = datagrid_product_units.CurrentCell.RowIndex;

                    if (datagrid_product_units.Rows[index].Cells["title"].Value != null)
                    {
                        datagrid_product_units.Rows.RemoveAt(index);
                    }
                }
            }
            catch (Exception) { }
            
        }

        private void datagrid_product_units_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex == -1) {
                return;
            }
             

           // datagrid_product_units.Rows[e.RowIndex].Cells["datagride_id"].Value = Guid.NewGuid().ToString();
        }
    }
}
