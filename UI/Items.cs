﻿using System;
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
        public int DGRowIndex = -1;

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

            this.DGRowIndex = UI.Purchase.GetForm.lastRow;

            this.Load_Grid_View();

        }

        public void Load_Grid_View( bool isVis = true ) {

            PL.Products prod = new PL.Products();
            items_view_grids.DataSource = prod.Get_All_Products();


            if ( isVis ) { 
                
                items_view_grids.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
                items_view_grids.Columns["id"].Visible = false;
                items_view_grids.EnableHeadersVisualStyles = true;
                items_view_grids.ColumnHeadersHeight = 35;

                items_view_grids.Columns["name"].Visible = true;
                items_view_grids.Columns["name"].Width = 220;
                items_view_grids.Columns["name"].HeaderText = "إسم الصنف";
            }
        }

        private void items_view_grids_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int index = UI.Items.GetForm.DGRowIndex;
            UI.Purchase.GetForm.Set_Datagrid_View(index, Convert.ToInt32(items_view_grids.Rows[e.RowIndex].Cells[0].Value));

            this.Close();
        }

        private void Items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Space) {
                return;
            }

            int rowIndex = items_view_grids.CurrentCell.OwningRow.Index;

            if (rowIndex == -1) return;

            int index = UI.Items.GetForm.DGRowIndex;
            UI.Purchase.GetForm.Set_Datagrid_View(index, Convert.ToInt32(items_view_grids.Rows[rowIndex].Cells[0].Value));

            this.Close();

        }
    }
}