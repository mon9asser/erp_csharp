if (total_field_text.Text == "00" || total_field_text.Text == "")
            {
                return;
            }


            // Save Invoice Data
            if (invoice_id.Text != "")
            {


                if (customer_id.Text == "")
                {
                    customer_id.Text = "-1";
                }

                Purchase.Save_Updates_Invoice_Data(
                    Convert.ToInt32(invoice_id.Text),
                    Convert.ToInt32(payment_methods.SelectedIndex),
                    Convert.ToInt32(payment_condition.SelectedIndex),
                    Convert.ToInt32(customer_id.Text),
                    Convert.ToInt32(legend_id.Text),
                    Convert.ToInt32(legend_number.Text),
                    -1,
                    -1,
                    legend_name.Text.ToString(),
                    "",
                    customer_name.Text.ToString(),
                    details.Text.ToString(),
                    net_total.Text.ToString(),
                    discount_value.Text.ToString(),
                    dicount_percentage.Text.ToString(),
                    discount_not_more_than.Text.ToString(),
                    total_without_vat_field.Text.ToString(),
                    total_field_text.Text.ToString(),
                    vat_amount.Text.ToString(),
                    Convert.ToDateTime(datemade.Value),
                    Convert.ToBoolean(price_includ_vat.Checked)
                );


                // Save All Invoice Items 
                if (invoice_id.Text != "")
                {
                    foreach (DataGridViewRow row in items_datagridview.Rows)
                    {

                        // Product Name 
                        string productName = "";
                        if (row.Cells["product_name"].Value != System.DBNull.Value)
                        {
                            productName = row.Cells["product_name"].Value.ToString();
                        }

                        // Unit Name  
                        if (productName != "")
                        {

                            docs.Update_Document_Details(
                                 Convert.ToInt32(invoice_id.Text),
                                 Convert.ToInt32(this.documentType),
                                 Convert.ToInt32(row.Cells["product_id"].Value),
                                 Convert.ToInt32(row.Cells["unit_id"].Value),
                                 true,
                                 productName,
                                 row.Cells["unit_name"].Value.ToString(),
                                 row.Cells["unit_price"].Value.ToString(),
                                 row.Cells["factor"].Value.ToString(),
                                 row.Cells["quantity"].Value.ToString(),
                                 row.Cells["total_quantity"].Value.ToString(),
                                 row.Cells["datagrid_id"].Value.ToString(),
                                 row.Cells["product_code"].Value.ToString(),
                                 row.Cells["total_price"].Value.ToString()

                            );

                        }
                    }
                }

                // Restore All Invoices In The Same Object 
                 
                this.Purchase_Table = Purchase.Get_All_Purchase_Invoices();
                this.Purchase_Details = Purchase.Get_All_Purchase_Invoice_Details();
                bool cancleIt = true;
                // Save Daily Entry 
                /**
                 * document type
                 * document id 
                 * journal id
                 * table of accounts ( account_number, amount, is_debit, description ) 
                 * 
                 */
                if (cancleIt)
                {
                    DataTable jounral_table = new DataTable();
                    jounral_table.Columns.Add("account_number");
                    jounral_table.Columns.Add("amount");
                    jounral_table.Columns.Add("is_debit");
                    jounral_table.Columns.Add("description");
                    if (this.Settings.Rows.Count != 0)
                    {

                        DataRow sets = this.Settings.Rows[0];

                        // Cash Entry 
                        if (payment_methods.SelectedIndex == 0)
                        {


                            // From :-
                            DataRow row = jounral_table.NewRow();
                            row["account_number"] = sets["sales_cash_acc_number"].ToString();
                            row["amount"] = total_field_text.Text.ToString();
                            row["is_debit"] = true;
                            row["description"] = "بيع بضاعه نقدا";
                            if (dicount_percentage.Text != "" && dicount_percentage.Text != "0")
                            {

                                row["description"] += " - بخصم تجاري علي الفاتورة ";

                                if (dicount_percentage.Text != "" && dicount_percentage.Text != "0")
                                {
                                    row["description"] += " %" + dicount_percentage.Text;
                                }

                            }
                            jounral_table.Rows.Add(row);

                            // To :-
                            DataRow row1 = jounral_table.NewRow();
                            row1["account_number"] = sets["part_2_sales_cash_acc_number"].ToString();
                            row1["amount"] = total_without_vat_field.Text.ToString();
                            row1["is_debit"] = false;
                            row1["description"] = "بيع بضاعه نقدا";
                            jounral_table.Rows.Add(row1);


                        }
                        else if (payment_methods.SelectedIndex == 1)
                        {

                            if (customer_id.Text == "")
                            {
                                MessageBox.Show("هذه الفاتورة علي الحساب من فضلك قم بإختيار إسم العميل");
                                return;
                            }
                            // From :-
                            DataRow row = jounral_table.NewRow();
                            row["account_number"] = customer_id.Text.ToString();
                            row["amount"] = total_field_text.Text.ToString();
                            row["is_debit"] = true;
                            row["description"] = "بيع بضاعه بالأجل";
                            if (dicount_percentage.Text != "" && dicount_percentage.Text != "0")
                            {

                                row["description"] += " - بخصم تجاري علي الفاتورة ";

                                if (dicount_percentage.Text != "" && dicount_percentage.Text != "0")
                                {
                                    row["description"] += " %" + dicount_percentage.Text;
                                }

                            }
                            jounral_table.Rows.Add(row);


                            // To :-
                            DataRow row1 = jounral_table.NewRow();
                            row1["account_number"] = sets["part_2_sales_credit_acc_number"].ToString();
                            row1["amount"] = total_without_vat_field.Text.ToString();
                            row1["is_debit"] = false;
                            row1["description"] = "بيع بضاعه بالأجل";
                            jounral_table.Rows.Add(row1);

                        }
                        else if (payment_methods.SelectedIndex == 2 || payment_methods.SelectedIndex == 3)
                        {
                            // From :-
                            DataRow row = jounral_table.NewRow();
                            row["account_number"] = sets["sales_bank_acc_number"].ToString();
                            row["amount"] = total_field_text.Text.ToString();
                            row["is_debit"] = true;
                            row["description"] = "بيع بضاعه عن طريق البنك";
                            if (dicount_percentage.Text != "" && dicount_percentage.Text != "0")
                            {

                                row["description"] += " - بخصم تجاري علي الفاتورة ";

                                if (dicount_percentage.Text != "" && dicount_percentage.Text != "0")
                                {
                                    row["description"] += " %" + dicount_percentage.Text;
                                }

                            }

                            jounral_table.Rows.Add(row);

                            DataRow row1 = jounral_table.NewRow();
                            row1["account_number"] = sets["part_2_sales_bank_acc_number"].ToString();
                            row1["amount"] = total_without_vat_field.Text.ToString();
                            row1["is_debit"] = false;
                            row1["description"] = "بيع بضاعه عن طريق البنك";
                            jounral_table.Rows.Add(row1);
                        }

                        // To :- VAT ACCOUNT ( OUT )
                        DataRow row2 = jounral_table.NewRow();
                        row2["account_number"] = sets["vat_acc_number"].ToString();
                        row2["amount"] = vat_amount.Text.ToString();
                        row2["is_debit"] = false;
                        row2["description"] = "ضريبة مخرجات مستحقة";
                        jounral_table.Rows.Add(row2);


                        // Cost Of Sold Goods


                    }

                    //journals.Get_DataTable_Accounts_Parts();
                    bool allowDate = false;
                    if (time_data.Text != "")
                    {
                        allowDate = true;
                    }

                    journals.Update_Journal_Document_Details(Convert.ToInt32(invoice_id.Text), this.documentType, details.Text, datemade.Value, jounral_table, allowDate);
                }
                // Disable Everything 
                this.disable_elements(false);
                if (this.is_updating_data == false)
                {
                    this.currentInvoiceRowIndex = this.Purchase_Table.Rows.Count - 1;
                    this.Set_Invoice_Row_Page_Index();
                }
                else
                {
                    this.is_updating_data = false;
                }
            }
			
			





            // To Allow Add New Invoice 
            //invoice_id.Text = "";

            // Disable Fields And Elements To Read Only 