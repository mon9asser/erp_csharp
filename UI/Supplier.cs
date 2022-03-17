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
    public partial class Supplier : Form
    {

        DataTable resoueceTable;


        public static Supplier frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Supplier GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new Supplier();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public Supplier()
        {
            InitializeComponent();
            
            if (frm == null)
            {
                frm = this;
            }

            this.Read_All_resources();
        }
         

        public void Read_All_resources( bool isDisable = false ) {

            PL.Resources Sup = new PL.Resources();

            suppliers_datagridview.DataSource = Sup.Get_All_Resource_Data( 0 );

            if (isDisable == false ) { 

                suppliers_datagridview.EnableHeadersVisualStyles = true;
                suppliers_datagridview.ColumnHeadersHeight = 35;

                suppliers_datagridview.Columns[0].Visible = false;
                suppliers_datagridview.Columns[2].Visible = false;
                suppliers_datagridview.Columns[5].Visible = false;
                suppliers_datagridview.Columns[6].Visible = false;
                suppliers_datagridview.Columns[7].Visible = false;
                suppliers_datagridview.Columns[8].Visible = false;


                suppliers_datagridview.Columns[1].HeaderText = "كـود المورد";
                suppliers_datagridview.Columns[3].HeaderText = "إسم المورد";
                suppliers_datagridview.Columns[4].HeaderText = "الهاتف";
                suppliers_datagridview.Columns[9].HeaderText = "الرقم الضريبي";
                suppliers_datagridview.Columns[10].HeaderText = "إسم المنشأة";

                suppliers_datagridview.Columns[3].Width = 150;
                suppliers_datagridview.Columns[10].Width = 180;
             
                // Add Update Button 
                DataGridViewButtonColumn edit_btn = new DataGridViewButtonColumn();
                edit_btn.HeaderText = "تحديث";
                edit_btn.Text = "تعديل";
                edit_btn.UseColumnTextForButtonValue = true;
                suppliers_datagridview.Columns.Add(edit_btn);

                // Add Delete Button  
                DataGridViewButtonColumn delete_btn = new DataGridViewButtonColumn();
                delete_btn.HeaderText = "حذف";
                delete_btn.Text = "حذف";
                delete_btn.UseColumnTextForButtonValue = true;
                suppliers_datagridview.Columns.Add(delete_btn);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            
            PL.Resources Resource = new PL.Resources();
            this.resoueceTable = Resource.Create_Resource_Id(0);
            UI.AddSupplier.GetForm.Set_Data_Of_Suppliers(this.resoueceTable );
            UI.AddSupplier.GetForm.ShowDialog();

        }

        private void suppliers_datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&  e.RowIndex >= 0)
            {
                
                // Edit and update
                if (e.ColumnIndex == 0) {
                    
                    if ( e.RowIndex >= 0 ) {

                        DataTable table = new DataTable();
                        DataRow row = null;
                      

                        table.Columns.Add("resource_name");
                        table.Columns.Add("resource_phone");
                        table.Columns.Add("resource_address");
                        table.Columns.Add("resource_email");
                        table.Columns.Add("id");
                        table.Columns.Add("resource_code");
                        table.Columns.Add("vat_number");
                        table.Columns.Add("establishment_name");

                        row = table.NewRow();
                        row["id"] = suppliers_datagridview.Rows[e.RowIndex].Cells[2].Value;
                        row["resource_code"] = suppliers_datagridview.Rows[e.RowIndex].Cells[3].Value;
                        row["resource_name"] = suppliers_datagridview.Rows[e.RowIndex].Cells[5].Value;
                        row["resource_phone"] = suppliers_datagridview.Rows[e.RowIndex].Cells[6].Value;
                        row["resource_address"] = suppliers_datagridview.Rows[e.RowIndex].Cells[7].Value;
                        row["resource_email"] = suppliers_datagridview.Rows[e.RowIndex].Cells[8].Value;
                        row["vat_number"] = suppliers_datagridview.Rows[e.RowIndex].Cells[11].Value;
                        row["establishment_name"] = suppliers_datagridview.Rows[e.RowIndex].Cells[12].Value;

                        table.Rows.Add(row);


                        UI.AddSupplier.GetForm.Set_Data_Of_Suppliers(table);
                        UI.AddSupplier.GetForm.ShowDialog();
                    }
                }

                // Delete 
                if (e.ColumnIndex == 1) {

                    PL.Resources Sup = new PL.Resources();
                    int id = Convert.ToInt32(suppliers_datagridview.Rows[e.RowIndex].Cells[2].Value);
                    Sup.Delete_Resource_Data(id, 0);
                    suppliers_datagridview.Rows.RemoveAt(e.RowIndex);
                }

            }
        }
    }
}
