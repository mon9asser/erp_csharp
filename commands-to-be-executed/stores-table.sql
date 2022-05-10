
/*
id 
date_made
details
account_number
account_name
total_quantity
total_price 
type ==> 0 => decrement 1 => 
*/


-----------------------------------
------ تقرير المسحوبات عن الفترة
-- كميات البيع
-- كميات متبقية
--اجمالي السعر
----- التاريخ من وإلي
----- شامل إذونات الصرف 
----- شامل المردودات ( المشتريات )
-----------------------------------
------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن
-----------------------------------

 if (items_datagridview.ReadOnly == true)
            {
                return;
            }

            if (e.RowIndex == -1)
            {
                return;
            }

            UI.Items.GetForm.DGRowIndex = e.RowIndex;
            
            // Select Item By Code 
            if (e.ColumnIndex == 1 && false == this.is_change_price)
            {

                string item_code_value = items_datagridview.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                bool is_found = false;

                foreach (DataRow row in this.Codes.Rows)
                {

                    if (row["code"].ToString() == item_code_value.ToString())
                    {
                        is_found = true;
                        // Setup Item In Current Row 
                        items_datagridview.Rows[e.RowIndex].Cells["doc_id"].Value = Exep_id.Text.ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["doc_type"].Value = this.documentType;
                        items_datagridview.Rows[e.RowIndex].Cells["product_id"].Value = row["id"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["unit_id"].Value = row["unit_id"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["factor"].Value = row["factor"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["is_out"].Value = this.is_out; 
                        items_datagridview.Rows[e.RowIndex].Cells["quantity"].Value = "1";
                        items_datagridview.Rows[e.RowIndex].Cells["unit_price"].Value = row["unit_price"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["unit_cost"].Value = row["unit_cost"].ToString();
                        items_datagridview.Rows[e.RowIndex].Cells["product_name"].Value = row["name"].ToString();

                        string unit_shortcut = "جرام";
                        foreach (DataRow col in unitName.Rows)
                        {

                            if (Convert.ToInt32(col["id"]).Equals(Convert.ToInt32(row["unit_id"])))
                            {
                                unit_shortcut = col["shortcut"].ToString();
                                break;
                            }

                        }

                        items_datagridview.Rows[e.RowIndex].Cells["unit_name"].Value = unit_shortcut.ToString();

                        break;
                    }
                }

                if (is_found == false)
                {
                    foreach (DataGridViewColumn col in items_datagridview.Columns)
                    {

                        if (col.Name.ToString() != "deletion_et_button")
                        {

                            if (col.Name.ToString() == "id" || col.Name.ToString() == "doc_id" || col.Name.ToString() == "doc_type" || col.Name.ToString() == "product_id" || col.Name.ToString() == "unit_id")
                            {
                                items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = -1;
                            }
                            else if (col.Name.ToString() == "is_out")
                            {
                                items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = this.is_out; 
                            }
                            else
                            {
                                items_datagridview.Rows[e.RowIndex].Cells[col.Name.ToString()].Value = "";
                            }


                        }
                    }
                }

            }

            // Calcualte Row Of DataGridview 
            this.Calculate_Datagridview_Row(e.RowIndex);

            // Caluclate Total Fields 
            this.Fill_Total_Fields();
			
----------------------------------------------------------------------
if (e.ColumnIndex == 0)
            {
                this.items_datagridview.Cursor = Cursors.Hand;
            }
            else
            {
                this.items_datagridview.Cursor = Cursors.Default;
            }

-----------------------------------------------------------------
 e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            bool isCol = items_datagridview.CurrentCell.ColumnIndex == 1 || items_datagridview.CurrentCell.ColumnIndex == 5;

            if (isCol) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
------------------------------------------------------------
if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (items_datagridview.ReadOnly == true)
            {
                return;
            }

            UI.purchaseInvoice.GetForm.lastRow = e.RowIndex;
            UI.Items.GetForm.DGRowIndex = this.lastRow;
            UI.Items.GetForm.doc_type = this.documentType;
             
            if (e.ColumnIndex == 2)
            {
                UI.Items.GetForm.ShowDialog();
            }

            if (e.ColumnIndex == 4)
            {

                if (System.DBNull.Value.Equals(items_datagridview.Rows[UI.purchaseInvoice.GetForm.lastRow].Cells["product_name"].Value))
                {
                    return;
                }

                this.is_change_price = true;

                int product_id = Convert.ToInt32(items_datagridview.Rows[UI.purchaseInvoice.GetForm.lastRow].Cells["product_id"].Value);

                UI.ItemUnit item_units = new UI.ItemUnit(
                    this.documentType,
                    product_id,
                    this.Prods,
                    this.unitName,
                    e.RowIndex
                );

                item_units.ShowDialog();

            }
			
--------------------------------------------
if (items_datagridview.ReadOnly == true)
            {
                return;
            }

            if (e.RowIndex == -1 || e.ColumnIndex == -1)
            {
                return;
            }

            string colName = items_datagridview.Columns[e.ColumnIndex].Name.ToString();

            if (colName != "deletion_et_button")
            {
                return;
            }

            // Empty Current Row 
            DataGridViewRow row = items_datagridview.Rows[e.RowIndex];
            foreach (DataGridViewColumn col in items_datagridview.Columns)
            {
                if (col.Name.ToString() != "deletion_et_button")
                {

                    if (col.Name.ToString() == "datagrid_id")
                    {
                        row.Cells[col.Name.ToString()].Value = Guid.NewGuid().ToString();
                    }
                    else if (col.Name.ToString() == "id" || col.Name.ToString() == "doc_id" || col.Name.ToString() == "doc_type" || col.Name.ToString() == "product_id" || col.Name.ToString() == "unit_id")
                    {
                        row.Cells[col.Name.ToString()].Value = 0;
                    }
                    else if (col.Name.ToString() == "is_out")
                    {
                        row.Cells[col.Name.ToString()].Value = this.is_out;
                    }
                    else
                    {
                        row.Cells[col.Name.ToString()].Value = "";
                    }

                }
            }