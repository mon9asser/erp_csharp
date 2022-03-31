 public int invoiceType = -1;
       // public int DGRowIndex;
        //public int doc_type;
         
        public static Price frm;
        PL.Products prod = new PL.Products();

        public int doc_typex { get; set; }

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

          
        public static Price Get_Form
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

        public Price()
        {

            InitializeComponent();

            if (frm == null)
            {
                frm = this;
            }
    
            int id = -1;

            MessageBox.Show(doc_typex.ToString());
            return;
             /*
            switch (UI.Price.Get_Form.doc_type) {
                
                // Sales Invoice
                case 0:
                    this.DGRowIndex = UI.salesInvoice.GetForm.lastRow;
                    id = Convert.ToInt32(UI.salesInvoice.GetForm.items_datagridview.Rows[this.DGRowIndex].Cells["product_id"].Value);
                    break;

                // Purchase Invoice
                case 1:
                    this.DGRowIndex = UI.purchaseInvoice.GetForm.lastRow;
                    id = Convert.ToInt32(UI.purchaseInvoice.GetForm.items_datagridview.Rows[this.DGRowIndex].Cells["product_id"].Value);
                    break;
            }
             
            if(id != -1) 
                this.load_prices( id, UI.Price.Get_Form.doc_type);
            */
        }

         
        public void load_prices(int id, int invoiceType ) {

            DataTable product = prod.Get_Product_By_Id(id);
            DataTable units = prod.Get_All_Product_Units();
            DataTable table = new DataTable();

            if(product.Rows.Count == 0 || units.Rows.Count == 0 )
            {
                return;
            }

            table.Columns.Add("unit_id");
            table.Columns.Add("units");
            table.Columns.Add("unit_shortcut");
            table.Columns.Add("price");
            table.Columns.Add("factor");
            table.Columns.Add("code");

            DataRow row = table.NewRow();
            if (invoiceType == 1 || invoiceType == 2)
            {

                // Default Price 
                foreach (DataRow unitRow in units.Rows) {
                    if (Convert.ToInt32(product.Rows[0]["unit_id"]).Equals(Convert.ToInt32(unitRow["id"]))) {
                        row["unit_id"] = unitRow["id"].ToString();
                        row["units"] = unitRow["title"].ToString();
                        row["unit_shortcut"] = unitRow["shortcut"].ToString();
                        break;
                    }
                }

                row["price"] = product.Rows[0]["purchase_price"].ToString();
                row["factor"] = 1;
                row["code"] = product.Rows[0]["code"].ToString();


                if ( Convert.ToDecimal(product.Rows[0]["purchase_price"]) != 0)
                    table.Rows.Add(row);
                 

                // Fill Groups 

                for ( int i =1; i<= 6; i++ )
                {
                    DataRow rowx = table.NewRow();
                    foreach (DataRow unitRow in units.Rows)
                    {
                        if (Convert.ToInt32(product.Rows[0]["gr" + i + "_unit_id"]).Equals(Convert.ToInt32(unitRow["id"])))
                        {
                            rowx["unit_id"] = unitRow["id"].ToString();
                            rowx["units"] = unitRow["title"].ToString();
                            rowx["unit_shortcut"] = unitRow["shortcut"].ToString();
                            break;
                        }
                    }

                    rowx["price"] = product.Rows[0]["gr" + i + "_purchase_price"].ToString();
                    rowx["factor"] = product.Rows[0]["gr" + i + "_transform"].ToString();
                    rowx["code"] = product.Rows[0]["gr" + i + "_barcode"].ToString();

                    if (  Convert.ToInt32(product.Rows[0]["gr" + i + "_purchase_price"]) != 0 && Convert.ToInt32(product.Rows[0]["gr" + i + "_transform"]) != 0)
                        table.Rows.Add(rowx);

                }


            }
            else if(invoiceType == 3 || invoiceType == 0)
            {
                // Default Price 
                foreach (DataRow unitRow in units.Rows)
                {
                    if (Convert.ToInt32(product.Rows[0]["unit_id"]).Equals(Convert.ToInt32(unitRow["id"])))
                    {
                        row["unit_id"] = unitRow["id"].ToString();
                        row["units"] = unitRow["title"].ToString();
                        row["unit_shortcut"] = unitRow["shortcut"].ToString();
                        break;
                    }
                }

                row["price"] = product.Rows[0]["default_sale_price"].ToString();
                row["factor"] = 1;
                row["code"] = product.Rows[0]["code"].ToString();

                if (  Convert.ToDecimal(product.Rows[0]["default_sale_price"]) != 0)
                    table.Rows.Add(row);


                // Fill Groups 

                for (int i = 1; i <= 6; i++)
                {
                    DataRow rowx = table.NewRow();
                    foreach (DataRow unitRow in units.Rows)
                    {
                        if (Convert.ToInt32(product.Rows[0]["gr" + i + "_unit_id"]).Equals(Convert.ToInt32(unitRow["id"])))
                        {
                            rowx["unit_id"] = unitRow["id"].ToString();
                            rowx["units"] = unitRow["title"].ToString();
                            rowx["unit_shortcut"] = unitRow["shortcut"].ToString();
                            break;
                        }
                    }

                    rowx["price"] = product.Rows[0]["gr" + i + "_sale_price"].ToString();
                    rowx["factor"] = product.Rows[0]["gr" + i + "_transform"].ToString();
                    rowx["code"] = product.Rows[0]["gr" + i + "_barcode"].ToString();
                  
                    if ( Convert.ToDecimal(product.Rows[0]["gr" + i + "_sale_price"]) != 0 && Convert.ToInt32(product.Rows[0]["gr" + i + "_transform"]) != 0 )
                        table.Rows.Add(rowx);

                }
            }

             
            datagridview_prices.DataSource = table;

            datagridview_prices.Columns["unit_id"].Visible = false;
            datagridview_prices.Columns["unit_shortcut"].Visible = false;
            datagridview_prices.Columns["factor"].Visible = false;
            datagridview_prices.Columns["code"].Visible = false;

            datagridview_prices.Columns["price"].HeaderText = "السعر";
            datagridview_prices.Columns["units"].HeaderText = "الأوزان والكميات";
            datagridview_prices.Columns["units"].Width = 200;
            
        }

        private void datagridview_prices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;


            //int index = UI.Price.Get_Form.DGRowIndex;
            int unit_id = Convert.ToInt32(datagridview_prices.Rows[e.RowIndex].Cells["unit_id"].Value);
            string factor = datagridview_prices.Rows[e.RowIndex].Cells["factor"].Value.ToString();
            string price = datagridview_prices.Rows[e.RowIndex].Cells["price"].Value.ToString();
            string shortcut = datagridview_prices.Rows[e.RowIndex].Cells["unit_shortcut"].Value.ToString();
            string code = datagridview_prices.Rows[e.RowIndex].Cells["code"].Value.ToString();
            //MessageBox.Show(UI.Price.Get_Form.doc_type.ToString());
            /*
            switch (UI.Price.Get_Form.doc_type)
            {

                // Sales Invoice
                case 0:
                    UI.salesInvoice.GetForm.change_price_field(unit_id, factor, price, shortcut, code);
                    break;

                // Purchase Invoice
                case 1:
                    UI.purchaseInvoice.GetForm.change_price_field(unit_id, factor, price, shortcut, code);
                    break;
            }
            */
            /*
            int index = UI.Price.Get_Form.DGRowIndex;
            int unit_id = Convert.ToInt32(datagridview_prices.Rows[e.RowIndex].Cells["unit_id"].Value);
            string factor =  datagridview_prices.Rows[e.RowIndex].Cells["factor"].Value.ToString();
            string price = datagridview_prices.Rows[e.RowIndex].Cells["price"].Value.ToString();
            string shortcut = datagridview_prices.Rows[e.RowIndex].Cells["unit_shortcut"].Value.ToString();
            UI.Purchase.GetForm.Set_Datagrid_View_New_Price(index, unit_id, factor, price, shortcut );
            */
            this.Close();
        }

        private void datagridview_prices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space)
            {
                return;
            }

            int rowIndex = datagridview_prices.CurrentCell.OwningRow.Index;


            //int index = UI.Price.Get_Form.DGRowIndex;
            int unit_id = Convert.ToInt32(datagridview_prices.Rows[rowIndex].Cells["unit_id"].Value);
            string factor = datagridview_prices.Rows[rowIndex].Cells["factor"].Value.ToString();
            string price = datagridview_prices.Rows[rowIndex].Cells["price"].Value.ToString();
            string shortcut = datagridview_prices.Rows[rowIndex].Cells["unit_shortcut"].Value.ToString();
            string code = datagridview_prices.Rows[rowIndex].Cells["code"].Value.ToString();
            /*
            switch (UI.Price.Get_Form.doc_type)
            {

                // Sales Invoice
                case 0:
                    UI.salesInvoice.GetForm.change_price_field(unit_id, factor, price, shortcut, code);
                    break;

                // Purchase Invoice
                case 1:
                    UI.purchaseInvoice.GetForm.change_price_field(unit_id, factor, price, shortcut, code);
                    break;
            }
            */
            //UI.Purchase.GetForm.Set_Datagrid_View_New_Price(index, unit_id, factor, price, shortcut);

            this.Close();
        }