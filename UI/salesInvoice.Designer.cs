
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
            this.invoice_serial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datemade = new System.Windows.Forms.DateTimePicker();
            this.invoice_id = new System.Windows.Forms.TextBox();
            this.payment_methods = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.legend_name = new System.Windows.Forms.TextBox();
            this.items_datagridview = new System.Windows.Forms.DataGridView();
            this.customer_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.legend_id = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.net_total = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.discount_value = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dicount_percentage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.discount_not_more_than = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.total_without_vat = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.price_includ_vat = new System.Windows.Forms.CheckBox();
            this.vat_amount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.customer_id = new System.Windows.Forms.TextBox();
            this.total_label_text = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.legend_number = new System.Windows.Forms.TextBox();
            this.cost_center_number = new System.Windows.Forms.TextBox();
            this.cost_center_name = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cost_center_id = new System.Windows.Forms.TextBox();
            this.print = new System.Windows.Forms.Button();
            this.print_and_save_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.total = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.payment_condition = new System.Windows.Forms.ComboBox();
            this.current_invoice_page = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.add_new_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // invoice_serial
            // 
            this.invoice_serial.Location = new System.Drawing.Point(91, 22);
            this.invoice_serial.Name = "invoice_serial";
            this.invoice_serial.Size = new System.Drawing.Size(151, 20);
            this.invoice_serial.TabIndex = 31;
            this.invoice_serial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.invoice_serial_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "التاريخ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "رقم الفاتوره :";
            // 
            // datemade
            // 
            this.datemade.Location = new System.Drawing.Point(91, 63);
            this.datemade.Name = "datemade";
            this.datemade.Size = new System.Drawing.Size(200, 20);
            this.datemade.TabIndex = 28;
            // 
            // invoice_id
            // 
            this.invoice_id.Location = new System.Drawing.Point(3, 22);
            this.invoice_id.Name = "invoice_id";
            this.invoice_id.Size = new System.Drawing.Size(19, 20);
            this.invoice_id.TabIndex = 32;
            this.invoice_id.Visible = false;
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
            this.payment_methods.Location = new System.Drawing.Point(91, 96);
            this.payment_methods.Name = "payment_methods";
            this.payment_methods.Size = new System.Drawing.Size(200, 21);
            this.payment_methods.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "طريقة الدقع :";
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(418, 22);
            this.details.Multiline = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(241, 56);
            this.details.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "البيان :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(735, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "حساب الأستاذ :";
            // 
            // legend_name
            // 
            this.legend_name.Location = new System.Drawing.Point(886, 58);
            this.legend_name.Name = "legend_name";
            this.legend_name.Size = new System.Drawing.Size(117, 20);
            this.legend_name.TabIndex = 38;
            // 
            // items_datagridview
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.items_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.items_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.items_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_datagridview.Location = new System.Drawing.Point(13, 134);
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
            this.items_datagridview.TabIndex = 39;
            // 
            // customer_name
            // 
            this.customer_name.Location = new System.Drawing.Point(786, 21);
            this.customer_name.Name = "customer_name";
            this.customer_name.Size = new System.Drawing.Size(217, 20);
            this.customer_name.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "العميل :";
            // 
            // legend_id
            // 
            this.legend_id.Location = new System.Drawing.Point(716, 58);
            this.legend_id.Name = "legend_id";
            this.legend_id.Size = new System.Drawing.Size(13, 20);
            this.legend_id.TabIndex = 42;
            this.legend_id.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "شرط الدفع :";
            // 
            // net_total
            // 
            this.net_total.Location = new System.Drawing.Point(72, 456);
            this.net_total.Name = "net_total";
            this.net_total.Size = new System.Drawing.Size(271, 20);
            this.net_total.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 459);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "الصافي :";
            // 
            // discount_value
            // 
            this.discount_value.Location = new System.Drawing.Point(72, 497);
            this.discount_value.Name = "discount_value";
            this.discount_value.Size = new System.Drawing.Size(124, 20);
            this.discount_value.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 501);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "خصم :";
            // 
            // dicount_percentage
            // 
            this.dicount_percentage.Location = new System.Drawing.Point(268, 497);
            this.dicount_percentage.Name = "dicount_percentage";
            this.dicount_percentage.Size = new System.Drawing.Size(75, 20);
            this.dicount_percentage.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(223, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "( % ) :";
            // 
            // discount_not_more_than
            // 
            this.discount_not_more_than.Location = new System.Drawing.Point(115, 536);
            this.discount_not_more_than.Name = "discount_not_more_than";
            this.discount_not_more_than.Size = new System.Drawing.Size(228, 20);
            this.discount_not_more_than.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 539);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "الخصم لا يزيد عن :";
            // 
            // total_without_vat
            // 
            this.total_without_vat.Location = new System.Drawing.Point(532, 458);
            this.total_without_vat.Name = "total_without_vat";
            this.total_without_vat.Size = new System.Drawing.Size(98, 20);
            this.total_without_vat.TabIndex = 55;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(430, 461);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 54;
            this.label12.Text = "الصافي بعد الخصم :";
            // 
            // price_includ_vat
            // 
            this.price_includ_vat.AutoSize = true;
            this.price_includ_vat.Checked = true;
            this.price_includ_vat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.price_includ_vat.Location = new System.Drawing.Point(433, 498);
            this.price_includ_vat.Name = "price_includ_vat";
            this.price_includ_vat.Size = new System.Drawing.Size(129, 17);
            this.price_includ_vat.TabIndex = 56;
            this.price_includ_vat.Text = "الأسعار شاملة الضريبة";
            this.price_includ_vat.UseVisualStyleBackColor = true;
            // 
            // vat_amount
            // 
            this.vat_amount.Location = new System.Drawing.Point(511, 535);
            this.vat_amount.Name = "vat_amount";
            this.vat_amount.Size = new System.Drawing.Size(123, 20);
            this.vat_amount.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 536);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "قيمة الضريبة :";
            // 
            // customer_id
            // 
            this.customer_id.Location = new System.Drawing.Point(716, 21);
            this.customer_id.Name = "customer_id";
            this.customer_id.Size = new System.Drawing.Size(13, 20);
            this.customer_id.TabIndex = 59;
            this.customer_id.Visible = false;
            // 
            // total_label_text
            // 
            this.total_label_text.AutoSize = true;
            this.total_label_text.Font = new System.Drawing.Font("Tahoma", 35F);
            this.total_label_text.Location = new System.Drawing.Point(749, 474);
            this.total_label_text.Name = "total_label_text";
            this.total_label_text.Size = new System.Drawing.Size(143, 57);
            this.total_label_text.TabIndex = 60;
            this.total_label_text.Text = "00.00";
            this.total_label_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(766, 539);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "ريال سعودي فقط لا غير";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(766, 454);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "الإجمالي :";
            // 
            // legend_number
            // 
            this.legend_number.Location = new System.Drawing.Point(822, 58);
            this.legend_number.Name = "legend_number";
            this.legend_number.Size = new System.Drawing.Size(58, 20);
            this.legend_number.TabIndex = 64;
            // 
            // cost_center_number
            // 
            this.cost_center_number.Location = new System.Drawing.Point(822, 93);
            this.cost_center_number.Name = "cost_center_number";
            this.cost_center_number.Size = new System.Drawing.Size(58, 20);
            this.cost_center_number.TabIndex = 67;
            // 
            // cost_center_name
            // 
            this.cost_center_name.Location = new System.Drawing.Point(886, 93);
            this.cost_center_name.Name = "cost_center_name";
            this.cost_center_name.Size = new System.Drawing.Size(117, 20);
            this.cost_center_name.TabIndex = 66;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(735, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "مركز التكلفة :";
            // 
            // cost_center_id
            // 
            this.cost_center_id.Location = new System.Drawing.Point(716, 92);
            this.cost_center_id.Name = "cost_center_id";
            this.cost_center_id.Size = new System.Drawing.Size(13, 20);
            this.cost_center_id.TabIndex = 68;
            this.cost_center_id.Visible = false;
            // 
            // print
            // 
            this.print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print.Location = new System.Drawing.Point(651, 584);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(73, 39);
            this.print.TabIndex = 71;
            this.print.Text = "طباعة";
            this.print.UseVisualStyleBackColor = true;
            // 
            // print_and_save_button
            // 
            this.print_and_save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.print_and_save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print_and_save_button.Location = new System.Drawing.Point(730, 584);
            this.print_and_save_button.Name = "print_and_save_button";
            this.print_and_save_button.Size = new System.Drawing.Size(125, 39);
            this.print_and_save_button.TabIndex = 72;
            this.print_and_save_button.Text = "حفظ و طباعه";
            this.print_and_save_button.UseVisualStyleBackColor = true;
            // 
            // edit_button
            // 
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_button.Location = new System.Drawing.Point(861, 584);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(72, 39);
            this.edit_button.TabIndex = 73;
            this.edit_button.Text = "تعديل";
            this.edit_button.UseVisualStyleBackColor = true;
            // 
            // delete_button
            // 
            this.delete_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_button.Location = new System.Drawing.Point(939, 584);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(64, 39);
            this.delete_button.TabIndex = 74;
            this.delete_button.Text = "حذف";
            this.delete_button.UseVisualStyleBackColor = true;
            // 
            // total
            // 
            this.total.Location = new System.Drawing.Point(827, 451);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(27, 20);
            this.total.TabIndex = 75;
            this.total.Visible = false;
            // 
            // search_button
            // 
            this.search_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Location = new System.Drawing.Point(248, 17);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(43, 29);
            this.search_button.TabIndex = 81;
            this.search_button.Text = "بحث";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // payment_condition
            // 
            this.payment_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.payment_condition.FormattingEnabled = true;
            this.payment_condition.Items.AddRange(new object[] {
            "نقدي",
            "أجل",
            "شبكة ",
            "تحويل بنكي"});
            this.payment_condition.Location = new System.Drawing.Point(440, 93);
            this.payment_condition.Name = "payment_condition";
            this.payment_condition.Size = new System.Drawing.Size(219, 21);
            this.payment_condition.TabIndex = 82;
            // 
            // current_invoice_page
            // 
            this.current_invoice_page.AutoSize = true;
            this.current_invoice_page.Font = new System.Drawing.Font("Tahoma", 16F);
            this.current_invoice_page.Location = new System.Drawing.Point(418, 591);
            this.current_invoice_page.Name = "current_invoice_page";
            this.current_invoice_page.Size = new System.Drawing.Size(70, 27);
            this.current_invoice_page.TabIndex = 83;
            this.current_invoice_page.Text = "10 / 1";
            this.current_invoice_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // first_record_button
            // 
            this.first_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.first_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_record_button.Location = new System.Drawing.Point(271, 585);
            this.first_record_button.Name = "first_record_button";
            this.first_record_button.Size = new System.Drawing.Size(50, 38);
            this.first_record_button.TabIndex = 80;
            this.first_record_button.UseVisualStyleBackColor = false;
            this.first_record_button.Click += new System.EventHandler(this.first_record_button_Click);
            // 
            // last_record_button
            // 
            this.last_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.last_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.last_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last_record_button.Location = new System.Drawing.Point(587, 585);
            this.last_record_button.Name = "last_record_button";
            this.last_record_button.Size = new System.Drawing.Size(50, 38);
            this.last_record_button.TabIndex = 79;
            this.last_record_button.UseVisualStyleBackColor = false;
            this.last_record_button.Click += new System.EventHandler(this.last_record_button_Click);
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Location = new System.Drawing.Point(327, 585);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(50, 38);
            this.next_button.TabIndex = 78;
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous_button.Location = new System.Drawing.Point(531, 585);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(50, 38);
            this.previous_button.TabIndex = 77;
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_button.Location = new System.Drawing.Point(170, 584);
            this.save_button.Name = "save_button";
            this.save_button.Padding = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.save_button.Size = new System.Drawing.Size(92, 38);
            this.save_button.TabIndex = 70;
            this.save_button.Text = "حفظ";
            this.save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // add_new_button
            // 
            this.add_new_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_new_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_new_button.Location = new System.Drawing.Point(13, 584);
            this.add_new_button.Name = "add_new_button";
            this.add_new_button.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.add_new_button.Size = new System.Drawing.Size(151, 39);
            this.add_new_button.TabIndex = 69;
            this.add_new_button.Text = "إضافة فاتورة جديدة";
            this.add_new_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_new_button.UseVisualStyleBackColor = true;
            this.add_new_button.Click += new System.EventHandler(this.add_new_button_Click);
            // 
            // salesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1018, 634);
            this.Controls.Add(this.current_invoice_page);
            this.Controls.Add(this.payment_condition);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.total);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.print_and_save_button);
            this.Controls.Add(this.print);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.add_new_button);
            this.Controls.Add(this.cost_center_id);
            this.Controls.Add(this.cost_center_number);
            this.Controls.Add(this.cost_center_name);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.legend_number);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.total_label_text);
            this.Controls.Add(this.customer_id);
            this.Controls.Add(this.vat_amount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.price_includ_vat);
            this.Controls.Add(this.total_without_vat);
            this.Controls.Add(this.label12);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "salesInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة مبيعات";
            this.Load += new System.EventHandler(this.salesInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox invoice_serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datemade;
        private System.Windows.Forms.TextBox invoice_id;
        private System.Windows.Forms.ComboBox payment_methods;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox details;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox legend_name;
        private System.Windows.Forms.DataGridView items_datagridview;
        private System.Windows.Forms.TextBox customer_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox legend_id;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox net_total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox discount_value;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dicount_percentage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox discount_not_more_than;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox total_without_vat;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox price_includ_vat;
        private System.Windows.Forms.TextBox vat_amount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox customer_id;
        private System.Windows.Forms.Label total_label_text;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox legend_number;
        private System.Windows.Forms.TextBox cost_center_number;
        private System.Windows.Forms.TextBox cost_center_name;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox cost_center_id;
        private System.Windows.Forms.Button add_new_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button print_and_save_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.TextBox total;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.ComboBox payment_condition;
        private System.Windows.Forms.Label current_invoice_page;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}