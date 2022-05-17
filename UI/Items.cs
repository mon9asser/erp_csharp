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
    public partial class Items : Form
    {

        public static Items frm;

        public Export_Document expo_doc;
        public salesInvoice Sales_Document;
        public purchaseInvoice Purchase_Document;
        public salesReturnInvoice Return_Sales_Document;
        public purchaseReturnInvoice Return_Purchase_Document;

        public int DGRowIndex = -1;
        public int doc_type = -1;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Items GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Items();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public Items()
        {
            InitializeComponent();


            if (frm == null)
            {
                frm = this;
            }

            //this.DGRowIndex = UI.Purchase.GetForm.lastRow;

            this.Load_Grid_View();

        }

        public Items(int rowIndex, int docType, Export_Document expo_doc)
        {
            InitializeComponent();
            this.DGRowIndex = rowIndex;
            this.doc_type = docType;
            this.expo_doc = expo_doc;
            this.Load_Grid_View();

        }

        public Items(int rowIndex, int docType, salesInvoice sales_document)
        {
            InitializeComponent();
            this.DGRowIndex = rowIndex;
            this.doc_type = docType;
            this.Sales_Document = sales_document;
            this.Load_Grid_View();

        }

        public Items(int rowIndex, int docType, purchaseInvoice purchase_document)
        {
            InitializeComponent();
            this.DGRowIndex = rowIndex;
            this.doc_type = docType;
            this.Purchase_Document = purchase_document;
            this.Load_Grid_View();

        }

        public Items(int rowIndex, int docType, salesReturnInvoice return_sales_document)
        {
            InitializeComponent();
            this.DGRowIndex = rowIndex;
            this.doc_type = docType;
            this.Return_Sales_Document = return_sales_document;
            this.Load_Grid_View();

        }
        public Items(int rowIndex, int docType, purchaseReturnInvoice return_purchase_document)
        {
            InitializeComponent();
            this.DGRowIndex = rowIndex;
            this.doc_type = docType;
            this.Return_Purchase_Document = return_purchase_document;
            this.Load_Grid_View();

        }

        public void Load_Grid_View(bool isVis = true) {

            PL.Products prod = new PL.Products();
            items_view_grids.DataSource = prod.Get_All_Products();


            if (isVis) {

                items_view_grids.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
                items_view_grids.Columns["id"].Visible = false;
                items_view_grids.EnableHeadersVisualStyles = true;
                items_view_grids.ColumnHeadersHeight = 35;

                items_view_grids.Columns["name"].Visible = true;
                items_view_grids.Columns["name"].Width = 220;
                items_view_grids.Columns["name"].HeaderText = "إسم الصنف";
            }
        }

        public void Execute_Event_Callback(int rowIndex, int index )
        {

            if (index == -1) return;
            

            // By document type 
            switch (this.doc_type)
            {

                    // Sales Invoice
                    case 0:
                        this.Sales_Document.Add_Item_To_Row(index, Convert.ToInt32(items_view_grids.Rows[rowIndex].Cells[0].Value));
                break;

                    // Purchase Invoice 
                    case 1: 
                        this.Purchase_Document.Add_Item_To_Row(index, Convert.ToInt32(items_view_grids.Rows[rowIndex].Cells[0].Value));
                break;
                     
                    // Sales Invoice
                    case 2:
                        this.Return_Sales_Document.Add_Item_To_Row(index, Convert.ToInt32(items_view_grids.Rows[rowIndex].Cells[0].Value));
                break;

                    case 3:
                        this.Return_Purchase_Document.Add_Item_To_Row(index, Convert.ToInt32(items_view_grids.Rows[rowIndex].Cells[0].Value));
                break;

                    case 6:
                        this.expo_doc.Add_Item_To_Row(index, Convert.ToInt32(items_view_grids.Rows[rowIndex].Cells[0].Value));
                break;

            }
        }
        private void items_view_grids_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             
            if (e.RowIndex == -1) return;

            int rowIndex = e.RowIndex;
            int index = this.DGRowIndex;

            this.Execute_Event_Callback(rowIndex, index);

            this.Close();

        }

        private void Items_KeyDown(object sender, KeyEventArgs e)
        {

           

            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space) {
                return;
            }

            // Old Purchase Invoice 
            int rowIndex = items_view_grids.CurrentCell.OwningRow.Index;
            if (rowIndex == -1) return;

            int index = this.DGRowIndex;
            if (index == -1) return;

            // By document type 
            this.Execute_Event_Callback(rowIndex, index); 
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            this.Load_Grid_View();

            // Data Values 
            string searchValue = textBox1.Text;
            if ( searchValue == "" ) {
                return;
            }

            DataTable tbl = (DataTable) items_view_grids.DataSource;

            DataTable newTable = new DataTable();
            foreach (DataColumn col in tbl.Columns) {
                newTable.Columns.Add(col.ToString());
            }


            DataRow[] filteredRows = tbl.Select("name LIKE '%" + searchValue + "%'");

            if (filteredRows.Length != 0) {
                
                DataRow new_row;
                
                for ( int i=0; i < filteredRows.Length; i++ ) {

                    new_row = newTable.NewRow(); 

                    foreach (DataGridViewColumn col in items_view_grids.Columns) {
                        new_row[col.Name.ToString()] = filteredRows[i][col.Name.ToString()];
                    }

                    newTable.Rows.Add(new_row);

                }

            }
            
            items_view_grids.DataSource = newTable;
            
        }
    }
}
