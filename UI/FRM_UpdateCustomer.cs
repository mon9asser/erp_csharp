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
    public partial class FRM_UpdateCustomer : Form
    {
        public static FRM_UpdateCustomer frm;

        static void frm_formClosed(object sernder, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_UpdateCustomer GetForm
        {
            get
            {

                if (frm == null)
                {
                    frm = new FRM_UpdateCustomer();
                    frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
                }

                return frm;

            }
        }

        public FRM_UpdateCustomer()
        {
            InitializeComponent();

            if (frm == null)
            {
                frm = this;
            }
        }
        public void Set_Data_Of_Suppliers(DataTable table)
        {
            try {
                if (table.Rows.Count > 0)
                {

                    DataRow row = table.Rows[0];
                    resource_name.Text = row["resource_name"].ToString();
                    phone_number.Text = row["resource_phone"].ToString();
                    address.Text = row["resource_address"].ToString();
                    email_text.Text = row["resource_email"].ToString();
                    id_text.Text = row["id"].ToString();
                    account_number.Text = row["resource_code"].ToString();
                    vat_number.Text = row["vat_number"].ToString();
                    establishment_name.Text = row["establishment_name"].ToString();
                }
            } catch (Exception) { }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            try {
                PL.Resources Sup = new PL.Resources();
                Sup.Update_Resource_Data(Convert.ToInt32(id_text.Text), resource_name.Text.ToString(), phone_number.Text.ToString(), address.Text.ToString(), email_text.Text.ToString(), establishment_name.Text.ToString(), vat_number.Text.ToString(), 1);

                UI.FRM_Customers.GetForm.Read_All_resources(true);
                this.Close();
            } catch (Exception) { }
        }
    }
}
