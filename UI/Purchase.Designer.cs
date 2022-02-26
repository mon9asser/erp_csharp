namespace sales_management.UI
{
    partial class Purchase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.invoice_detail_datagridview = new System.Windows.Forms.DataGridView();
            this.newInvoiceBtn = new System.Windows.Forms.Button();
            this.deleteInvoiceBtn = new System.Windows.Forms.Button();
            this.editInvoiceBtn = new System.Windows.Forms.Button();
            this.printInvoiceBtn = new System.Windows.Forms.Button();
            this.storeInvoiceBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.invoice_number = new System.Windows.Forms.TextBox();
            this.datemade = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.payment_methods = new System.Windows.Forms.ComboBox();
            this.total_without_vat = new System.Windows.Forms.TextBox();
            this.enable_vat = new System.Windows.Forms.CheckBox();
            this.invoice_serial = new System.Windows.Forms.TextBox();
            this.discount_value = new System.Windows.Forms.TextBox();
            this.total_with_vat = new System.Windows.Forms.TextBox();
            this.vat_amount = new System.Windows.Forms.TextBox();
            this.short_vat_amount = new System.Windows.Forms.TextBox();
            this.net_total = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.percentage_discount = new System.Windows.Forms.TextBox();
            this.not_more_than = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.invoice_detail_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // invoice_detail_datagridview
            // 
            this.invoice_detail_datagridview.AllowUserToAddRows = false;
            this.invoice_detail_datagridview.AllowUserToDeleteRows = false;
            this.invoice_detail_datagridview.AllowUserToResizeColumns = false;
            this.invoice_detail_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            this.invoice_detail_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.invoice_detail_datagridview.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.invoice_detail_datagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.invoice_detail_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.invoice_detail_datagridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.invoice_detail_datagridview.Enabled = false;
            this.invoice_detail_datagridview.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.invoice_detail_datagridview.Location = new System.Drawing.Point(15, 90);
            this.invoice_detail_datagridview.MultiSelect = false;
            this.invoice_detail_datagridview.Name = "invoice_detail_datagridview";
            this.invoice_detail_datagridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.invoice_detail_datagridview.RowTemplate.Height = 45;
            this.invoice_detail_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.invoice_detail_datagridview.Size = new System.Drawing.Size(911, 273);
            this.invoice_detail_datagridview.StandardTab = true;
            this.invoice_detail_datagridview.TabIndex = 16;
            this.invoice_detail_datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoice_detail_datagridview_CellClick);
            this.invoice_detail_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoice_detail_datagridview_CellContentClick);
            this.invoice_detail_datagridview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.invoice_detail_datagridview_CellValueChanged);
            this.invoice_detail_datagridview.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.invoice_detail_datagridview_EditingControlShowing);
            this.invoice_detail_datagridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.invoice_detail_datagridview_KeyDown);
            // 
            // newInvoiceBtn
            // 
            this.newInvoiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newInvoiceBtn.Location = new System.Drawing.Point(23, 503);
            this.newInvoiceBtn.Name = "newInvoiceBtn";
            this.newInvoiceBtn.Size = new System.Drawing.Size(120, 30);
            this.newInvoiceBtn.TabIndex = 6;
            this.newInvoiceBtn.Text = "فاتورة جديدة";
            this.newInvoiceBtn.UseVisualStyleBackColor = true;
            this.newInvoiceBtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // deleteInvoiceBtn
            // 
            this.deleteInvoiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteInvoiceBtn.Location = new System.Drawing.Point(368, 503);
            this.deleteInvoiceBtn.Name = "deleteInvoiceBtn";
            this.deleteInvoiceBtn.Size = new System.Drawing.Size(67, 30);
            this.deleteInvoiceBtn.TabIndex = 5;
            this.deleteInvoiceBtn.Text = "حذف";
            this.deleteInvoiceBtn.UseVisualStyleBackColor = true;
            this.deleteInvoiceBtn.Click += new System.EventHandler(this.deleteInvoiceBtn_Click);
            // 
            // editInvoiceBtn
            // 
            this.editInvoiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editInvoiceBtn.Location = new System.Drawing.Point(295, 503);
            this.editInvoiceBtn.Name = "editInvoiceBtn";
            this.editInvoiceBtn.Size = new System.Drawing.Size(67, 30);
            this.editInvoiceBtn.TabIndex = 4;
            this.editInvoiceBtn.Text = "تعديل";
            this.editInvoiceBtn.UseVisualStyleBackColor = true;
            // 
            // printInvoiceBtn
            // 
            this.printInvoiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printInvoiceBtn.Location = new System.Drawing.Point(222, 503);
            this.printInvoiceBtn.Name = "printInvoiceBtn";
            this.printInvoiceBtn.Size = new System.Drawing.Size(67, 30);
            this.printInvoiceBtn.TabIndex = 3;
            this.printInvoiceBtn.Text = "طباعه";
            this.printInvoiceBtn.UseVisualStyleBackColor = true;
            // 
            // storeInvoiceBtn
            // 
            this.storeInvoiceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.storeInvoiceBtn.Location = new System.Drawing.Point(149, 503);
            this.storeInvoiceBtn.Name = "storeInvoiceBtn";
            this.storeInvoiceBtn.Size = new System.Drawing.Size(67, 30);
            this.storeInvoiceBtn.TabIndex = 2;
            this.storeInvoiceBtn.Text = "حفظ";
            this.storeInvoiceBtn.UseVisualStyleBackColor = true;
            this.storeInvoiceBtn.Click += new System.EventHandler(this.storeInvoiceBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(417, 395);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "قيمة الضريبة :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(696, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "الإجمالي شامل الضريبه :-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "الإجمالي بدون الضريبة :";
            // 
            // invoice_number
            // 
            this.invoice_number.Enabled = false;
            this.invoice_number.Location = new System.Drawing.Point(289, 18);
            this.invoice_number.Name = "invoice_number";
            this.invoice_number.Size = new System.Drawing.Size(18, 20);
            this.invoice_number.TabIndex = 0;
            this.invoice_number.Visible = false;
            // 
            // datemade
            // 
            this.datemade.Enabled = false;
            this.datemade.Location = new System.Drawing.Point(83, 48);
            this.datemade.Name = "datemade";
            this.datemade.Size = new System.Drawing.Size(200, 20);
            this.datemade.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "رقم الفاتوره :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "التاريخ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "البيان :";
            // 
            // details
            // 
            this.details.Enabled = false;
            this.details.Location = new System.Drawing.Point(665, 19);
            this.details.Multiline = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(261, 49);
            this.details.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "طريقة الدقع :";
            // 
            // payment_methods
            // 
            this.payment_methods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_methods.Enabled = false;
            this.payment_methods.FormattingEnabled = true;
            this.payment_methods.Items.AddRange(new object[] {
            "نقدي",
            "أجل",
            "شبكة ",
            "تحويل بنكي"});
            this.payment_methods.Location = new System.Drawing.Point(403, 17);
            this.payment_methods.Name = "payment_methods";
            this.payment_methods.Size = new System.Drawing.Size(163, 21);
            this.payment_methods.TabIndex = 7;
            // 
            // total_without_vat
            // 
            this.total_without_vat.Enabled = false;
            this.total_without_vat.Location = new System.Drawing.Point(141, 461);
            this.total_without_vat.Name = "total_without_vat";
            this.total_without_vat.ReadOnly = true;
            this.total_without_vat.Size = new System.Drawing.Size(196, 20);
            this.total_without_vat.TabIndex = 25;
            // 
            // enable_vat
            // 
            this.enable_vat.AutoSize = true;
            this.enable_vat.Checked = true;
            this.enable_vat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enable_vat.Enabled = false;
            this.enable_vat.Location = new System.Drawing.Point(420, 426);
            this.enable_vat.Name = "enable_vat";
            this.enable_vat.Size = new System.Drawing.Size(129, 17);
            this.enable_vat.TabIndex = 19;
            this.enable_vat.Text = "الأسعار شاملة الضريبة";
            this.enable_vat.UseVisualStyleBackColor = true;
            this.enable_vat.CheckedChanged += new System.EventHandler(this.enable_vat_CheckedChanged);
            // 
            // invoice_serial
            // 
            this.invoice_serial.Enabled = false;
            this.invoice_serial.Location = new System.Drawing.Point(83, 18);
            this.invoice_serial.Name = "invoice_serial";
            this.invoice_serial.ReadOnly = true;
            this.invoice_serial.Size = new System.Drawing.Size(200, 20);
            this.invoice_serial.TabIndex = 27;
            // 
            // discount_value
            // 
            this.discount_value.Location = new System.Drawing.Point(77, 423);
            this.discount_value.Name = "discount_value";
            this.discount_value.Size = new System.Drawing.Size(54, 20);
            this.discount_value.TabIndex = 28;
            this.discount_value.TextChanged += new System.EventHandler(this.discount_value_TextChanged_1);
            // 
            // total_with_vat
            // 
            this.total_with_vat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.total_with_vat.Location = new System.Drawing.Point(826, 391);
            this.total_with_vat.Name = "total_with_vat";
            this.total_with_vat.ReadOnly = true;
            this.total_with_vat.Size = new System.Drawing.Size(95, 20);
            this.total_with_vat.TabIndex = 29;
            // 
            // vat_amount
            // 
            this.vat_amount.Location = new System.Drawing.Point(600, 392);
            this.vat_amount.Name = "vat_amount";
            this.vat_amount.ReadOnly = true;
            this.vat_amount.Size = new System.Drawing.Size(10, 20);
            this.vat_amount.TabIndex = 30;
            this.vat_amount.Visible = false;
            // 
            // short_vat_amount
            // 
            this.short_vat_amount.Location = new System.Drawing.Point(497, 393);
            this.short_vat_amount.Name = "short_vat_amount";
            this.short_vat_amount.ReadOnly = true;
            this.short_vat_amount.Size = new System.Drawing.Size(97, 20);
            this.short_vat_amount.TabIndex = 31;
            // 
            // net_total
            // 
            this.net_total.Location = new System.Drawing.Point(77, 387);
            this.net_total.Name = "net_total";
            this.net_total.ReadOnly = true;
            this.net_total.Size = new System.Drawing.Size(260, 20);
            this.net_total.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 389);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "الصافي :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 426);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "الخصم :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(140, 426);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 39;
            this.label13.Text = "( % ) :";
            // 
            // percentage_discount
            // 
            this.percentage_discount.Location = new System.Drawing.Point(185, 423);
            this.percentage_discount.Name = "percentage_discount";
            this.percentage_discount.Size = new System.Drawing.Size(30, 20);
            this.percentage_discount.TabIndex = 40;
            this.percentage_discount.TextChanged += new System.EventHandler(this.percentage_discount_TextChanged);
            // 
            // not_more_than
            // 
            this.not_more_than.Location = new System.Drawing.Point(296, 423);
            this.not_more_than.Name = "not_more_than";
            this.not_more_than.Size = new System.Drawing.Size(41, 20);
            this.not_more_than.TabIndex = 42;
            this.not_more_than.TextChanged += new System.EventHandler(this.not_more_than_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(229, 426);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "لا يزيد عن :";
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 557);
            this.Controls.Add(this.newInvoiceBtn);
            this.Controls.Add(this.deleteInvoiceBtn);
            this.Controls.Add(this.not_more_than);
            this.Controls.Add(this.editInvoiceBtn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.printInvoiceBtn);
            this.Controls.Add(this.percentage_discount);
            this.Controls.Add(this.storeInvoiceBtn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.net_total);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.short_vat_amount);
            this.Controls.Add(this.discount_value);
            this.Controls.Add(this.vat_amount);
            this.Controls.Add(this.total_with_vat);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.invoice_serial);
            this.Controls.Add(this.total_without_vat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.enable_vat);
            this.Controls.Add(this.invoice_detail_datagridview);
            this.Controls.Add(this.payment_methods);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datemade);
            this.Controls.Add(this.invoice_number);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Purchase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المشتريات";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.invoice_detail_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox invoice_number;
        private System.Windows.Forms.DateTimePicker datemade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox details;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox payment_methods;
        private System.Windows.Forms.TextBox total_without_vat;
        private System.Windows.Forms.Button deleteInvoiceBtn;
        private System.Windows.Forms.Button editInvoiceBtn;
        private System.Windows.Forms.Button printInvoiceBtn;
        private System.Windows.Forms.Button storeInvoiceBtn;
        private System.Windows.Forms.Button newInvoiceBtn;
        private System.Windows.Forms.CheckBox enable_vat;
        private System.Windows.Forms.TextBox invoice_serial;
        public System.Windows.Forms.DataGridView invoice_detail_datagridview;
        private System.Windows.Forms.TextBox discount_value;
        private System.Windows.Forms.TextBox total_with_vat;
        private System.Windows.Forms.TextBox vat_amount;
        private System.Windows.Forms.TextBox short_vat_amount;
        private System.Windows.Forms.TextBox net_total;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox percentage_discount;
        private System.Windows.Forms.TextBox not_more_than;
        private System.Windows.Forms.Label label14;
    }
}