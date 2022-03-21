
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.deletion_et_button = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.total_without_vat_field = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.price_includ_vat = new System.Windows.Forms.CheckBox();
            this.vat_amount = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.customer_id = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.legend_number = new System.Windows.Forms.TextBox();
            this.cost_center_number = new System.Windows.Forms.TextBox();
            this.cost_center_name = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cost_center_id = new System.Windows.Forms.TextBox();
            this.total_field_text = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.payment_condition = new System.Windows.Forms.ComboBox();
            this.current_invoice_page = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.total_label_text = new System.Windows.Forms.Label();
            this.add_new_button = new System.Windows.Forms.Button();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.time_data = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // invoice_serial
            // 
            this.invoice_serial.Location = new System.Drawing.Point(111, 22);
            this.invoice_serial.Name = "invoice_serial";
            this.invoice_serial.Size = new System.Drawing.Size(276, 20);
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
            this.datemade.Location = new System.Drawing.Point(111, 60);
            this.datemade.Name = "datemade";
            this.datemade.Size = new System.Drawing.Size(197, 20);
            this.datemade.TabIndex = 28;
            // 
            // invoice_id
            // 
            this.invoice_id.Location = new System.Drawing.Point(442, 22);
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
            this.payment_methods.Location = new System.Drawing.Point(111, 96);
            this.payment_methods.Name = "payment_methods";
            this.payment_methods.Size = new System.Drawing.Size(352, 21);
            this.payment_methods.TabIndex = 34;
            this.payment_methods.SelectedIndexChanged += new System.EventHandler(this.payment_methods_SelectedIndexChanged);
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
            this.details.Location = new System.Drawing.Point(658, 53);
            this.details.Multiline = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(348, 56);
            this.details.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "البيان :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "حساب الأستاذ :";
            // 
            // legend_name
            // 
            this.legend_name.Location = new System.Drawing.Point(766, 23);
            this.legend_name.Name = "legend_name";
            this.legend_name.ReadOnly = true;
            this.legend_name.Size = new System.Drawing.Size(240, 20);
            this.legend_name.TabIndex = 38;
            this.legend_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.legend_name_MouseClick);
            this.legend_name.TextChanged += new System.EventHandler(this.legend_name_TextChanged);
            // 
            // items_datagridview
            // 
            this.items_datagridview.AllowUserToAddRows = false;
            this.items_datagridview.AllowUserToDeleteRows = false;
            this.items_datagridview.AllowUserToResizeColumns = false;
            this.items_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.items_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.items_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.items_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.items_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deletion_et_button});
            this.items_datagridview.Location = new System.Drawing.Point(20, 153);
            this.items_datagridview.MultiSelect = false;
            this.items_datagridview.Name = "items_datagridview";
            this.items_datagridview.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.items_datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.items_datagridview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.items_datagridview.RowTemplate.Height = 35;
            this.items_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.items_datagridview.Size = new System.Drawing.Size(993, 294);
            this.items_datagridview.TabIndex = 39;
            this.items_datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellClick);
            this.items_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellContentClick);
            this.items_datagridview.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.items_datagridview_CellMouseClick);
            this.items_datagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellMouseEnter);
            this.items_datagridview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellValueChanged);
            this.items_datagridview.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.items_datagridview_EditingControlShowing);
            this.items_datagridview.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.items_datagridview_RowsAdded);
            this.items_datagridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.items_datagridview_KeyDown);
            // 
            // deletion_et_button
            // 
            this.deletion_et_button.HeaderText = "حذف";
            this.deletion_et_button.Image = global::sales_management.Properties.Resources.icons8_delete_20;
            this.deletion_et_button.Name = "deletion_et_button";
            // 
            // customer_name
            // 
            this.customer_name.Enabled = false;
            this.customer_name.Location = new System.Drawing.Point(658, 117);
            this.customer_name.Name = "customer_name";
            this.customer_name.ReadOnly = true;
            this.customer_name.Size = new System.Drawing.Size(348, 20);
            this.customer_name.TabIndex = 41;
            this.customer_name.Click += new System.EventHandler(this.customer_name_Click);
            this.customer_name.MouseClick += new System.Windows.Forms.MouseEventHandler(this.customer_name_MouseClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(598, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "العميل :";
            // 
            // legend_id
            // 
            this.legend_id.Location = new System.Drawing.Point(683, 23);
            this.legend_id.Name = "legend_id";
            this.legend_id.Size = new System.Drawing.Size(13, 20);
            this.legend_id.TabIndex = 42;
            this.legend_id.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "شرط الدفع :";
            this.label7.Visible = false;
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
            this.discount_value.Location = new System.Drawing.Point(71, 493);
            this.discount_value.Name = "discount_value";
            this.discount_value.Size = new System.Drawing.Size(124, 20);
            this.discount_value.TabIndex = 49;
            this.discount_value.TextChanged += new System.EventHandler(this.discount_value_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 497);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 48;
            this.label9.Text = "خصم :";
            // 
            // dicount_percentage
            // 
            this.dicount_percentage.Location = new System.Drawing.Point(267, 493);
            this.dicount_percentage.Name = "dicount_percentage";
            this.dicount_percentage.Size = new System.Drawing.Size(75, 20);
            this.dicount_percentage.TabIndex = 51;
            this.dicount_percentage.TextChanged += new System.EventHandler(this.dicount_percentage_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 496);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "( % ) :";
            // 
            // discount_not_more_than
            // 
            this.discount_not_more_than.Location = new System.Drawing.Point(115, 532);
            this.discount_not_more_than.Name = "discount_not_more_than";
            this.discount_not_more_than.Size = new System.Drawing.Size(228, 20);
            this.discount_not_more_than.TabIndex = 53;
            this.discount_not_more_than.TextChanged += new System.EventHandler(this.discount_not_more_than_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 535);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 52;
            this.label11.Text = "الخصم لا يزيد عن :";
            // 
            // total_without_vat_field
            // 
            this.total_without_vat_field.Location = new System.Drawing.Point(532, 458);
            this.total_without_vat_field.Name = "total_without_vat_field";
            this.total_without_vat_field.Size = new System.Drawing.Size(98, 20);
            this.total_without_vat_field.TabIndex = 55;
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
            this.price_includ_vat.Location = new System.Drawing.Point(432, 494);
            this.price_includ_vat.Name = "price_includ_vat";
            this.price_includ_vat.Size = new System.Drawing.Size(129, 17);
            this.price_includ_vat.TabIndex = 56;
            this.price_includ_vat.Text = "الأسعار شاملة الضريبة";
            this.price_includ_vat.UseVisualStyleBackColor = true;
            this.price_includ_vat.CheckedChanged += new System.EventHandler(this.price_includ_vat_CheckedChanged);
            // 
            // vat_amount
            // 
            this.vat_amount.Location = new System.Drawing.Point(511, 531);
            this.vat_amount.Name = "vat_amount";
            this.vat_amount.Size = new System.Drawing.Size(123, 20);
            this.vat_amount.TabIndex = 58;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(430, 532);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "قيمة الضريبة :";
            // 
            // customer_id
            // 
            this.customer_id.Location = new System.Drawing.Point(579, 118);
            this.customer_id.Name = "customer_id";
            this.customer_id.Size = new System.Drawing.Size(13, 20);
            this.customer_id.TabIndex = 59;
            this.customer_id.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(699, 535);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(113, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "ريال سعودي فقط لا غير";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(699, 455);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "الإجمالي :";
            // 
            // legend_number
            // 
            this.legend_number.Location = new System.Drawing.Point(702, 23);
            this.legend_number.Name = "legend_number";
            this.legend_number.ReadOnly = true;
            this.legend_number.Size = new System.Drawing.Size(58, 20);
            this.legend_number.TabIndex = 64;
            this.legend_number.MouseClick += new System.Windows.Forms.MouseEventHandler(this.legend_name_MouseClick);
            this.legend_number.TextChanged += new System.EventHandler(this.legend_number_TextChanged);
            // 
            // cost_center_number
            // 
            this.cost_center_number.Location = new System.Drawing.Point(127, 147);
            this.cost_center_number.Name = "cost_center_number";
            this.cost_center_number.Size = new System.Drawing.Size(58, 20);
            this.cost_center_number.TabIndex = 67;
            this.cost_center_number.Visible = false;
            // 
            // cost_center_name
            // 
            this.cost_center_name.Location = new System.Drawing.Point(191, 147);
            this.cost_center_name.Name = "cost_center_name";
            this.cost_center_name.Size = new System.Drawing.Size(117, 20);
            this.cost_center_name.TabIndex = 66;
            this.cost_center_name.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(40, 149);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "مركز التكلفة :";
            this.label17.Visible = false;
            // 
            // cost_center_id
            // 
            this.cost_center_id.Location = new System.Drawing.Point(21, 146);
            this.cost_center_id.Name = "cost_center_id";
            this.cost_center_id.Size = new System.Drawing.Size(13, 20);
            this.cost_center_id.TabIndex = 68;
            this.cost_center_id.Visible = false;
            // 
            // total_field_text
            // 
            this.total_field_text.Location = new System.Drawing.Point(760, 452);
            this.total_field_text.Name = "total_field_text";
            this.total_field_text.Size = new System.Drawing.Size(27, 20);
            this.total_field_text.TabIndex = 75;
            this.total_field_text.Visible = false;
            // 
            // search_button
            // 
            this.search_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.search_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Location = new System.Drawing.Point(393, 18);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(68, 29);
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
            "الدفع بعد 15 يوم",
            "الدفع بعد 30 يوم ",
            "الدفع بعد شهر ونصف"});
            this.payment_condition.Location = new System.Drawing.Point(89, 217);
            this.payment_condition.Name = "payment_condition";
            this.payment_condition.Size = new System.Drawing.Size(219, 21);
            this.payment_condition.TabIndex = 82;
            this.payment_condition.Visible = false;
            this.payment_condition.SelectedIndexChanged += new System.EventHandler(this.payment_condition_SelectedIndexChanged);
            // 
            // current_invoice_page
            // 
            this.current_invoice_page.AutoSize = true;
            this.current_invoice_page.Font = new System.Drawing.Font("Tahoma", 16F);
            this.current_invoice_page.Location = new System.Drawing.Point(510, 590);
            this.current_invoice_page.Name = "current_invoice_page";
            this.current_invoice_page.Size = new System.Drawing.Size(82, 27);
            this.current_invoice_page.TabIndex = 83;
            this.current_invoice_page.Text = "00 / 00";
            this.current_invoice_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // total_label_text
            // 
            this.total_label_text.AutoSize = true;
            this.total_label_text.Font = new System.Drawing.Font("Tahoma", 35F);
            this.total_label_text.Location = new System.Drawing.Point(679, 475);
            this.total_label_text.Name = "total_label_text";
            this.total_label_text.Size = new System.Drawing.Size(143, 57);
            this.total_label_text.TabIndex = 85;
            this.total_label_text.Text = "00.00";
            // 
            // add_new_button
            // 
            this.add_new_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_button.Image = global::sales_management.Properties.Resources.add_new;
            this.add_new_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_new_button.Location = new System.Drawing.Point(11, 585);
            this.add_new_button.Name = "add_new_button";
            this.add_new_button.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.add_new_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.add_new_button.Size = new System.Drawing.Size(152, 39);
            this.add_new_button.TabIndex = 86;
            this.add_new_button.Text = "إضافة فاتورة جديدة";
            this.add_new_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_new_button.UseVisualStyleBackColor = true;
            this.add_new_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // first_record_button
            // 
            this.first_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.first_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_record_button.Image = global::sales_management.Properties.Resources.last_btn;
            this.first_record_button.Location = new System.Drawing.Point(398, 585);
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
            this.last_record_button.Image = global::sales_management.Properties.Resources.first_btn;
            this.last_record_button.Location = new System.Drawing.Point(660, 585);
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
            this.next_button.Image = global::sales_management.Properties.Resources.next_btn;
            this.next_button.Location = new System.Drawing.Point(454, 585);
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
            this.previous_button.Image = global::sales_management.Properties.Resources.prev_btn;
            this.previous_button.Location = new System.Drawing.Point(604, 585);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(50, 38);
            this.previous_button.TabIndex = 77;
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_button.Image = global::sales_management.Properties.Resources.icons8_update_20;
            this.edit_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edit_button.Location = new System.Drawing.Point(934, 588);
            this.edit_button.Name = "edit_button";
            this.edit_button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.edit_button.Size = new System.Drawing.Size(72, 39);
            this.edit_button.TabIndex = 73;
            this.edit_button.Text = "تعديل";
            this.edit_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // print
            // 
            this.print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.print.Enabled = false;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print.Image = global::sales_management.Properties.Resources.print_btn;
            this.print.Location = new System.Drawing.Point(855, 588);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(73, 39);
            this.print.TabIndex = 71;
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.Image = global::sales_management.Properties.Resources.save_data;
            this.save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_button.Location = new System.Drawing.Point(169, 585);
            this.save_button.Name = "save_button";
            this.save_button.Padding = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.save_button.Size = new System.Drawing.Size(92, 38);
            this.save_button.TabIndex = 70;
            this.save_button.Text = " حفظ";
            this.save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // time_data
            // 
            this.time_data.Location = new System.Drawing.Point(360, 60);
            this.time_data.Name = "time_data";
            this.time_data.Size = new System.Drawing.Size(103, 20);
            this.time_data.TabIndex = 87;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(317, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 88;
            this.label14.Text = "الوقت";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(472, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 13);
            this.label18.TabIndex = 89;
            this.label18.Text = "HH:MM:SS";
            // 
            // salesInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1018, 634);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.time_data);
            this.Controls.Add(this.add_new_button);
            this.Controls.Add(this.total_label_text);
            this.Controls.Add(this.current_invoice_page);
            this.Controls.Add(this.payment_condition);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.total_field_text);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.print);
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
            this.Controls.Add(this.total_without_vat_field);
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
        private System.Windows.Forms.TextBox invoice_id;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Label current_invoice_page;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        public System.Windows.Forms.TextBox legend_name;
        public System.Windows.Forms.TextBox legend_number;
        public System.Windows.Forms.TextBox legend_id;
        public System.Windows.Forms.TextBox invoice_serial;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker datemade;
        public System.Windows.Forms.ComboBox payment_methods;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox details;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView items_datagridview;
        public System.Windows.Forms.TextBox customer_name;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox net_total;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox discount_value;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox dicount_percentage;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox discount_not_more_than;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox total_without_vat_field;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.CheckBox price_includ_vat;
        public System.Windows.Forms.TextBox vat_amount;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox customer_id;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox cost_center_number;
        public System.Windows.Forms.TextBox cost_center_name;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox cost_center_id;
        public System.Windows.Forms.TextBox total_field_text;
        public System.Windows.Forms.Button search_button;
        public System.Windows.Forms.ComboBox payment_condition;
        private System.Windows.Forms.Label total_label_text;
        private System.Windows.Forms.Button add_new_button;
        private System.Windows.Forms.DataGridViewImageColumn deletion_et_button;
        public System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.TextBox time_data;
        public System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
    }
}