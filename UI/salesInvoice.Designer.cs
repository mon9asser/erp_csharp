
namespace sales_management.UI
{
    partial class salesInvoice
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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.current_invoice_page = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.add_new_button = new System.Windows.Forms.Button();
            this.total_label_text = new System.Windows.Forms.Label();
            this.payment_condition = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.total_field_text = new System.Windows.Forms.TextBox();
            this.edit_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.cost_center_id = new System.Windows.Forms.TextBox();
            this.cost_center_number = new System.Windows.Forms.TextBox();
            this.cost_center_name = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.legend_number = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.customer_id = new System.Windows.Forms.TextBox();
            this.vat_amount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.price_includ_vat = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.items_datagridview = new System.Windows.Forms.DataGridView();
            this.deletion_et_button = new System.Windows.Forms.DataGridViewImageColumn();
            this.legend_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.payment_methods = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.invoice_id = new System.Windows.Forms.TextBox();
            this.invoice_serial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datemade = new System.Windows.Forms.DateTimePicker();
            this.total_without_vat_field = new System.Windows.Forms.TextBox();
            this.discount_not_more_than = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dicount_percentage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.discount_value = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.net_total = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.legend_id = new System.Windows.Forms.TextBox();
            this.customer_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.enable_zakat_taxes = new System.Windows.Forms.CheckBox();
            this.entry_id = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // current_invoice_page
            // 
            this.current_invoice_page.AutoSize = true;
            this.current_invoice_page.Font = new System.Drawing.Font("Tahoma", 16F);
            this.current_invoice_page.Location = new System.Drawing.Point(485, 584);
            this.current_invoice_page.Name = "current_invoice_page";
            this.current_invoice_page.Size = new System.Drawing.Size(82, 27);
            this.current_invoice_page.TabIndex = 137;
            this.current_invoice_page.Text = "00 / 00";
            this.current_invoice_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // add_new_button
            // 
            this.add_new_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_button.Image = global::sales_management.Properties.Resources.add_new;
            this.add_new_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_new_button.Location = new System.Drawing.Point(13, 579);
            this.add_new_button.Name = "add_new_button";
            this.add_new_button.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.add_new_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.add_new_button.Size = new System.Drawing.Size(152, 39);
            this.add_new_button.TabIndex = 139;
            this.add_new_button.Text = "إضافة فاتورة جديدة";
            this.add_new_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_new_button.UseVisualStyleBackColor = true;
            this.add_new_button.Click += new System.EventHandler(this.add_new_button_Click);
            // 
            // total_label_text
            // 
            this.total_label_text.AutoSize = true;
            this.total_label_text.Font = new System.Drawing.Font("Tahoma", 35F);
            this.total_label_text.Location = new System.Drawing.Point(673, 469);
            this.total_label_text.Name = "total_label_text";
            this.total_label_text.Size = new System.Drawing.Size(143, 57);
            this.total_label_text.TabIndex = 138;
            this.total_label_text.Text = "00.00";
            // 
            // payment_condition
            // 
            this.payment_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_condition.FormattingEnabled = true;
            this.payment_condition.Items.AddRange(new object[] {
            "الدفع بعد 15 يوم",
            "الدفع بعد 30 يوم ",
            "الدفع بعد شهر ونصف"});
            this.payment_condition.Location = new System.Drawing.Point(83, 211);
            this.payment_condition.Name = "payment_condition";
            this.payment_condition.Size = new System.Drawing.Size(219, 21);
            this.payment_condition.TabIndex = 136;
            this.payment_condition.Visible = false;
            // 
            // search_button
            // 
            this.search_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Location = new System.Drawing.Point(377, 12);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(68, 29);
            this.search_button.TabIndex = 135;
            this.search_button.Text = "بحث";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // first_record_button
            // 
            this.first_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.first_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_record_button.Image = global::sales_management.Properties.Resources.last_btn;
            this.first_record_button.Location = new System.Drawing.Point(349, 579);
            this.first_record_button.Name = "first_record_button";
            this.first_record_button.Size = new System.Drawing.Size(50, 38);
            this.first_record_button.TabIndex = 134;
            this.first_record_button.UseVisualStyleBackColor = false;
            this.first_record_button.Click += new System.EventHandler(this.first_record_button_Click);
            // 
            // last_record_button
            // 
            this.last_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.last_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.last_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last_record_button.Image = global::sales_management.Properties.Resources.first_btn;
            this.last_record_button.Location = new System.Drawing.Point(649, 579);
            this.last_record_button.Name = "last_record_button";
            this.last_record_button.Size = new System.Drawing.Size(50, 38);
            this.last_record_button.TabIndex = 133;
            this.last_record_button.UseVisualStyleBackColor = false;
            this.last_record_button.Click += new System.EventHandler(this.last_record_button_Click);
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Image = global::sales_management.Properties.Resources.next_btn;
            this.next_button.Location = new System.Drawing.Point(405, 579);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(50, 38);
            this.next_button.TabIndex = 132;
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous_button.Image = global::sales_management.Properties.Resources.prev_btn;
            this.previous_button.Location = new System.Drawing.Point(593, 579);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(50, 38);
            this.previous_button.TabIndex = 131;
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // total_field_text
            // 
            this.total_field_text.Location = new System.Drawing.Point(754, 446);
            this.total_field_text.Name = "total_field_text";
            this.total_field_text.Size = new System.Drawing.Size(27, 20);
            this.total_field_text.TabIndex = 130;
            this.total_field_text.Visible = false;
            // 
            // edit_button
            // 
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_button.Image = global::sales_management.Properties.Resources.icons8_update_20;
            this.edit_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edit_button.Location = new System.Drawing.Point(928, 582);
            this.edit_button.Name = "edit_button";
            this.edit_button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.edit_button.Size = new System.Drawing.Size(72, 39);
            this.edit_button.TabIndex = 129;
            this.edit_button.Text = "تعديل";
            this.edit_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.Image = global::sales_management.Properties.Resources.save_data;
            this.save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_button.Location = new System.Drawing.Point(171, 579);
            this.save_button.Name = "save_button";
            this.save_button.Padding = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.save_button.Size = new System.Drawing.Size(92, 38);
            this.save_button.TabIndex = 127;
            this.save_button.Text = " حفظ";
            this.save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // cost_center_id
            // 
            this.cost_center_id.Location = new System.Drawing.Point(15, 140);
            this.cost_center_id.Name = "cost_center_id";
            this.cost_center_id.Size = new System.Drawing.Size(13, 20);
            this.cost_center_id.TabIndex = 126;
            this.cost_center_id.Visible = false;
            // 
            // cost_center_number
            // 
            this.cost_center_number.Location = new System.Drawing.Point(121, 141);
            this.cost_center_number.Name = "cost_center_number";
            this.cost_center_number.Size = new System.Drawing.Size(58, 20);
            this.cost_center_number.TabIndex = 125;
            this.cost_center_number.Visible = false;
            // 
            // cost_center_name
            // 
            this.cost_center_name.Location = new System.Drawing.Point(185, 141);
            this.cost_center_name.Name = "cost_center_name";
            this.cost_center_name.Size = new System.Drawing.Size(117, 20);
            this.cost_center_name.TabIndex = 124;
            this.cost_center_name.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(34, 143);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 123;
            this.label17.Text = "مركز التكلفة :";
            this.label17.Visible = false;
            // 
            // legend_number
            // 
            this.legend_number.Location = new System.Drawing.Point(696, 17);
            this.legend_number.Name = "legend_number";
            this.legend_number.ReadOnly = true;
            this.legend_number.Size = new System.Drawing.Size(58, 20);
            this.legend_number.TabIndex = 122;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(693, 449);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 121;
            this.label16.Text = "الإجمالي :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(693, 529);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 120;
            this.label15.Text = "ريال سعودي فقط لا غير";
            // 
            // customer_id
            // 
            this.customer_id.Location = new System.Drawing.Point(573, 112);
            this.customer_id.Name = "customer_id";
            this.customer_id.Size = new System.Drawing.Size(13, 20);
            this.customer_id.TabIndex = 119;
            this.customer_id.Visible = false;
            // 
            // vat_amount
            // 
            this.vat_amount.Location = new System.Drawing.Point(505, 525);
            this.vat_amount.Name = "vat_amount";
            this.vat_amount.Size = new System.Drawing.Size(123, 20);
            this.vat_amount.TabIndex = 118;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(424, 526);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 117;
            this.label13.Text = "قيمة الضريبة :";
            // 
            // price_includ_vat
            // 
            this.price_includ_vat.AutoSize = true;
            this.price_includ_vat.Checked = true;
            this.price_includ_vat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.price_includ_vat.Location = new System.Drawing.Point(426, 488);
            this.price_includ_vat.Name = "price_includ_vat";
            this.price_includ_vat.Size = new System.Drawing.Size(129, 17);
            this.price_includ_vat.TabIndex = 116;
            this.price_includ_vat.Text = "الأسعار شاملة الضريبة";
            this.price_includ_vat.UseVisualStyleBackColor = true;
            this.price_includ_vat.CheckedChanged += new System.EventHandler(this.price_includ_vat_CheckedChanged_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(424, 455);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 114;
            this.label12.Text = "الصافي بعد الخصم :";
            // 
            // items_datagridview
            // 
            this.items_datagridview.AllowUserToAddRows = false;
            this.items_datagridview.AllowUserToDeleteRows = false;
            this.items_datagridview.AllowUserToResizeColumns = false;
            this.items_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.items_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.items_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.items_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deletion_et_button});
            this.items_datagridview.Location = new System.Drawing.Point(14, 147);
            this.items_datagridview.MultiSelect = false;
            this.items_datagridview.Name = "items_datagridview";
            this.items_datagridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.items_datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.items_datagridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.items_datagridview.RowTemplate.Height = 35;
            this.items_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.items_datagridview.Size = new System.Drawing.Size(993, 294);
            this.items_datagridview.TabIndex = 101;
            this.items_datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellClick);
            this.items_datagridview.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.items_datagridview_CellMouseClick);
            this.items_datagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellMouseEnter);
            this.items_datagridview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellValueChanged);
            this.items_datagridview.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.items_datagridview_EditingControlShowing);
            this.items_datagridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.items_datagridview_KeyDown);
            // 
            // deletion_et_button
            // 
            this.deletion_et_button.HeaderText = "حذف";
            this.deletion_et_button.Image = global::sales_management.Properties.Resources.icons8_delete_20;
            this.deletion_et_button.Name = "deletion_et_button";
            // 
            // legend_name
            // 
            this.legend_name.Location = new System.Drawing.Point(760, 17);
            this.legend_name.Name = "legend_name";
            this.legend_name.ReadOnly = true;
            this.legend_name.Size = new System.Drawing.Size(240, 20);
            this.legend_name.TabIndex = 100;
            this.legend_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.legend_name_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "حساب الأستاذ :";
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(652, 47);
            this.details.Multiline = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(348, 56);
            this.details.TabIndex = 98;
            this.details.Text = "بيع بضاعه نقدا";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(592, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "البيان :";
            // 
            // payment_methods
            // 
            this.payment_methods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_methods.FormattingEnabled = true;
            this.payment_methods.Items.AddRange(new object[] {
            "نقدي",
            "أجل",
            "شبكة ",
            "تحويل بنكي"});
            this.payment_methods.Location = new System.Drawing.Point(105, 90);
            this.payment_methods.Name = "payment_methods";
            this.payment_methods.Size = new System.Drawing.Size(352, 21);
            this.payment_methods.TabIndex = 96;
            this.payment_methods.SelectedIndexChanged += new System.EventHandler(this.payment_methods_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "طريقة الدقع :";
            // 
            // invoice_id
            // 
            this.invoice_id.Location = new System.Drawing.Point(105, 17);
            this.invoice_id.Name = "invoice_id";
            this.invoice_id.Size = new System.Drawing.Size(212, 20);
            this.invoice_id.TabIndex = 94;
            // 
            // invoice_serial
            // 
            this.invoice_serial.Location = new System.Drawing.Point(334, 17);
            this.invoice_serial.Name = "invoice_serial";
            this.invoice_serial.Size = new System.Drawing.Size(37, 20);
            this.invoice_serial.TabIndex = 93;
            this.invoice_serial.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "التاريخ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "رقم الفاتوره :";
            // 
            // datemade
            // 
            this.datemade.Location = new System.Drawing.Point(105, 54);
            this.datemade.Name = "datemade";
            this.datemade.Size = new System.Drawing.Size(197, 20);
            this.datemade.TabIndex = 90;
            // 
            // total_without_vat_field
            // 
            this.total_without_vat_field.Location = new System.Drawing.Point(526, 452);
            this.total_without_vat_field.Name = "total_without_vat_field";
            this.total_without_vat_field.Size = new System.Drawing.Size(98, 20);
            this.total_without_vat_field.TabIndex = 115;
            // 
            // discount_not_more_than
            // 
            this.discount_not_more_than.Location = new System.Drawing.Point(109, 526);
            this.discount_not_more_than.Name = "discount_not_more_than";
            this.discount_not_more_than.Size = new System.Drawing.Size(228, 20);
            this.discount_not_more_than.TabIndex = 113;
            this.discount_not_more_than.TextChanged += new System.EventHandler(this.discount_not_more_than_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 529);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 112;
            this.label11.Text = "الخصم لا يزيد عن :";
            // 
            // dicount_percentage
            // 
            this.dicount_percentage.Location = new System.Drawing.Point(261, 487);
            this.dicount_percentage.Name = "dicount_percentage";
            this.dicount_percentage.Size = new System.Drawing.Size(75, 20);
            this.dicount_percentage.TabIndex = 111;
            this.dicount_percentage.TextChanged += new System.EventHandler(this.dicount_percentage_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(216, 490);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 110;
            this.label10.Text = "( % ) :";
            // 
            // discount_value
            // 
            this.discount_value.Location = new System.Drawing.Point(65, 487);
            this.discount_value.Name = "discount_value";
            this.discount_value.Size = new System.Drawing.Size(124, 20);
            this.discount_value.TabIndex = 109;
            this.discount_value.TextChanged += new System.EventHandler(this.discount_value_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 491);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "خصم :";
            // 
            // net_total
            // 
            this.net_total.Location = new System.Drawing.Point(66, 450);
            this.net_total.Name = "net_total";
            this.net_total.Size = new System.Drawing.Size(271, 20);
            this.net_total.TabIndex = 107;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 453);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 106;
            this.label8.Text = "الصافي :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "شرط الدفع :";
            this.label7.Visible = false;
            // 
            // legend_id
            // 
            this.legend_id.Location = new System.Drawing.Point(677, 17);
            this.legend_id.Name = "legend_id";
            this.legend_id.Size = new System.Drawing.Size(13, 20);
            this.legend_id.TabIndex = 104;
            this.legend_id.Visible = false;
            // 
            // customer_name
            // 
            this.customer_name.Enabled = false;
            this.customer_name.Location = new System.Drawing.Point(652, 111);
            this.customer_name.Name = "customer_name";
            this.customer_name.ReadOnly = true;
            this.customer_name.Size = new System.Drawing.Size(348, 20);
            this.customer_name.TabIndex = 103;
            this.customer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.customer_name_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(592, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 102;
            this.label6.Text = "المورد :";
            // 
            // enable_zakat_taxes
            // 
            this.enable_zakat_taxes.AutoSize = true;
            this.enable_zakat_taxes.Checked = true;
            this.enable_zakat_taxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enable_zakat_taxes.Location = new System.Drawing.Point(377, 54);
            this.enable_zakat_taxes.Name = "enable_zakat_taxes";
            this.enable_zakat_taxes.Size = new System.Drawing.Size(94, 17);
            this.enable_zakat_taxes.TabIndex = 143;
            this.enable_zakat_taxes.Text = "خاضعة للضريبه";
            this.enable_zakat_taxes.UseVisualStyleBackColor = true;
            this.enable_zakat_taxes.CheckedChanged += new System.EventHandler(this.enable_zakat_taxes_CheckedChanged);
            // 
            // entry_id
            // 
            this.entry_id.Location = new System.Drawing.Point(469, 17);
            this.entry_id.Name = "entry_id";
            this.entry_id.Size = new System.Drawing.Size(100, 20);
            this.entry_id.TabIndex = 144;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::sales_management.Properties.Resources.print_btn;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(797, 582);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(125, 39);
            this.button2.TabIndex = 146;
            this.button2.Text = "حفظ و طباعة";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // salesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 634);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.entry_id);
            this.Controls.Add(this.enable_zakat_taxes);
            this.Controls.Add(this.current_invoice_page);
            this.Controls.Add(this.add_new_button);
            this.Controls.Add(this.total_label_text);
            this.Controls.Add(this.payment_condition);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.total_field_text);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.cost_center_id);
            this.Controls.Add(this.cost_center_number);
            this.Controls.Add(this.cost_center_name);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.legend_number);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.customer_id);
            this.Controls.Add(this.vat_amount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.price_includ_vat);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.items_datagridview);
            this.Controls.Add(this.legend_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.payment_methods);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.invoice_id);
            this.Controls.Add(this.invoice_serial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datemade);
            this.Controls.Add(this.total_without_vat_field);
            this.Controls.Add(this.discount_not_more_than);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dicount_percentage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.discount_value);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.net_total);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.legend_id);
            this.Controls.Add(this.customer_name);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "salesInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المشتريات";
            this.Load += new System.EventHandler(this.salesInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label current_invoice_page;
        public System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button add_new_button;
        private System.Windows.Forms.Label total_label_text;
        public System.Windows.Forms.ComboBox payment_condition;
        public System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        public System.Windows.Forms.TextBox total_field_text;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button save_button;
        public System.Windows.Forms.TextBox cost_center_id;
        public System.Windows.Forms.TextBox cost_center_number;
        public System.Windows.Forms.TextBox cost_center_name;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox legend_number;
        public System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox customer_id;
        public System.Windows.Forms.TextBox vat_amount;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.CheckBox price_includ_vat;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.DataGridView items_datagridview;
        private System.Windows.Forms.DataGridViewImageColumn deletion_et_button;
        public System.Windows.Forms.TextBox legend_name;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox details;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox payment_methods;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox invoice_id;
        public System.Windows.Forms.TextBox invoice_serial;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker datemade;
        public System.Windows.Forms.TextBox total_without_vat_field;
        public System.Windows.Forms.TextBox discount_not_more_than;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox dicount_percentage;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox discount_value;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox net_total;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox legend_id;
        public System.Windows.Forms.TextBox customer_name;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox enable_zakat_taxes;
        private System.Windows.Forms.TextBox entry_id;
        private System.Windows.Forms.Button button2;
    }
}