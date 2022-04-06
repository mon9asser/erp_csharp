this.Purchase = new PL.Purchase();
            this.journals = new PL.Journals();
            this.products = new PL.Products();

            PL.AccountingTree Accs = new PL.AccountingTree();
            PL.Installings sysSettings = new PL.Installings();
            price.Set_Document_Type = 1;

            string thisDatexxxx = datemade.Value.ToString("yyyy-MM-dd");
            string thisTimexxxx = datemade.Value.ToString("HH:mm:ss");
            Console.WriteLine(thisDatexxxx + " " + thisTimexxxx);

            // Head Sales Invoices 
            this.Sales_Table = Purchase.Get_All_Purchase_Invoices();
            this.Sales_Details = Purchase.Get_All_Purchase_Invoice_Details();
            this.Accounts = Accs.Get_Accounting_Tree();
            this.Settings = sysSettings.Get_All_System_Settings();
            this.Codes = this.Load_All_Products_Codes();
            this.Prods = this.products.Get_All_Products();
            this.unitName = this.products.Get_All_Product_Units();

            // Load Default Data 
            if (0 != this.Sales_Table.Rows.Count)
            {
                this.currentInvoiceRowIndex = this.Sales_Table.Rows.Count - 1;
                DataRow rw = this.Sales_Table.Rows[this.currentInvoiceRowIndex];
                this.Fill_Invoice_Fields(rw);
            }

            int id = this.Sales_Table.Rows.Count != 0 ? Convert.ToInt32(this.Sales_Table.Rows[this.Sales_Table.Rows.Count - 1]["id"]) : -1;

            /* doc_type, invoiceId,  */
            items_datagridview.DataSource = Purchase.Get_Purchase_Invoice_Items(this.documentType, id);

            //table.Columns["product_code"].Count;
            items_datagridview.Columns["id"].Visible = false;
            items_datagridview.Columns["doc_id"].Visible = false;
            items_datagridview.Columns["doc_type"].Visible = false;
            items_datagridview.Columns["product_id"].Visible = false;
            items_datagridview.Columns["unit_id"].Visible = false;
            items_datagridview.Columns["factor"].Visible = false;
            items_datagridview.Columns["total_quantity"].Visible = false;
            items_datagridview.Columns["datagrid_id"].Visible = false;
            items_datagridview.Columns["is_out"].Visible = false;

            // Load Current Invoice Index 
            this.Set_Invoice_Row_Page_Index();

            items_datagridview.Columns["product_code"].HeaderText = "كود الصنف";
            items_datagridview.Columns["product_name"].HeaderText = "الصنف";
            items_datagridview.Columns["unit_name"].HeaderText = "اسم الوحدة";
            items_datagridview.Columns["quantity"].HeaderText = "الكميات";
            items_datagridview.Columns["total_price"].HeaderText = "إجمالي السعر";
            items_datagridview.Columns["unit_price"].HeaderText = "سعر الوحدة";

            items_datagridview.Columns["product_name"].ReadOnly = true;

            items_datagridview.Columns[2].Width = 330;
            items_datagridview.ColumnHeadersHeight = 40;

            items_datagridview.Columns["unit_price"].ReadOnly = true;
            items_datagridview.Columns["total_price"].ReadOnly = true;
            items_datagridview.Columns["unit_name"].ReadOnly = true;

            // Add Button To Remove The Item From invoice 
            this.Load_deletion_icon_in_datagridview();
            this.disable_elements();