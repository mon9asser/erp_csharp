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
            this.invoice_detail_datagridview = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.invoice_number = new System.Windows.Forms.TextBox();
            this.datemade = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.payment_methods = new System.Windows.Forms.ComboBox();
            this.total_with_vat = new System.Windows.Forms.TextBox();
            this.vat_amount = new System.Windows.Forms.TextBox();
            this.total_without_vat = new System.Windows.Forms.TextBox();
            this.discount = new System.Windows.Forms.TextBox();
            this.enable_vat = new System.Windows.Forms.CheckBox();
            this.show = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.invoice_detail_datagridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // invoice_detail_datagridview
            // 
            this.invoice_detail_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invoice_detail_datagridview.Enabled = false;
            this.invoice_detail_datagridview.Location = new System.Drawing.Point(15, 90);
            this.invoice_detail_datagridview.Name = "invoice_detail_datagridview";
            this.invoice_detail_datagridview.Size = new System.Drawing.Size(911, 273);
            this.invoice_detail_datagridview.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.show);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(914, 79);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.Location = new System.Drawing.Point(767, 28);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(120, 30);
            this.button7.TabIndex = 6;
            this.button7.Text = "فاتورة جديدة";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(669, 28);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 30);
            this.button6.TabIndex = 5;
            this.button6.Text = "حذف";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(596, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 30);
            this.button5.TabIndex = 4;
            this.button5.Text = "تعديل";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(523, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "طباعه";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(450, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "حفظ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(74, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(24, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = ">";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(374, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "قيمة الضريبة :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(662, 391);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "الإجمالي شامل الضريبه :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "خصم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "الإجمالي بدون الضريبة :";
            // 
            // invoice_number
            // 
            this.invoice_number.Enabled = false;
            this.invoice_number.Location = new System.Drawing.Point(83, 18);
            this.invoice_number.Name = "invoice_number";
            this.invoice_number.Size = new System.Drawing.Size(200, 20);
            this.invoice_number.TabIndex = 0;
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
            // total_with_vat
            // 
            this.total_with_vat.Enabled = false;
            this.total_with_vat.Location = new System.Drawing.Point(793, 384);
            this.total_with_vat.Multiline = true;
            this.total_with_vat.Name = "total_with_vat";
            this.total_with_vat.Size = new System.Drawing.Size(133, 56);
            this.total_with_vat.TabIndex = 23;
            // 
            // vat_amount
            // 
            this.vat_amount.Enabled = false;
            this.vat_amount.Location = new System.Drawing.Point(459, 384);
            this.vat_amount.Multiline = true;
            this.vat_amount.Name = "vat_amount";
            this.vat_amount.Size = new System.Drawing.Size(133, 56);
            this.vat_amount.TabIndex = 24;
            // 
            // total_without_vat
            // 
            this.total_without_vat.Enabled = false;
            this.total_without_vat.Location = new System.Drawing.Point(137, 386);
            this.total_without_vat.Name = "total_without_vat";
            this.total_without_vat.Size = new System.Drawing.Size(70, 20);
            this.total_without_vat.TabIndex = 25;
            // 
            // discount
            // 
            this.discount.Enabled = false;
            this.discount.Location = new System.Drawing.Point(60, 420);
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(147, 20);
            this.discount.TabIndex = 26;
            // 
            // enable_vat
            // 
            this.enable_vat.AutoSize = true;
            this.enable_vat.Checked = true;
            this.enable_vat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enable_vat.Enabled = false;
            this.enable_vat.Location = new System.Drawing.Point(329, 50);
            this.enable_vat.Name = "enable_vat";
            this.enable_vat.Size = new System.Drawing.Size(129, 17);
            this.enable_vat.TabIndex = 19;
            this.enable_vat.Text = "الأسعار شاملة الضريبة";
            this.enable_vat.UseVisualStyleBackColor = true;
            // 
            // show
            // 
            this.show.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show.Location = new System.Drawing.Point(277, 28);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(67, 30);
            this.show.TabIndex = 7;
            this.show.Text = "عرض";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // Purchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 554);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.total_without_vat);
            this.Controls.Add(this.vat_amount);
            this.Controls.Add(this.total_with_vat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.enable_vat);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
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
            this.Name = "Purchase";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فاتورة المشتريات";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.invoice_detail_datagridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView invoice_detail_datagridview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox invoice_number;
        private System.Windows.Forms.DateTimePicker datemade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox details;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox payment_methods;
        private System.Windows.Forms.TextBox total_with_vat;
        private System.Windows.Forms.TextBox vat_amount;
        private System.Windows.Forms.TextBox total_without_vat;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox enable_vat;
        private System.Windows.Forms.Button show;
    }
}