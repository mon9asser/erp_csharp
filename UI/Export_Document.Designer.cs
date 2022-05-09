
namespace sales_management.UI
{
    partial class Export_Document
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.date_made = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.account_name = new System.Windows.Forms.TextBox();
            this.account_number = new System.Windows.Forms.TextBox();
            this.datagrid_product_details = new System.Windows.Forms.DataGridView();
            this.current_invoice_page = new System.Windows.Forms.Label();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.total_label_text = new System.Windows.Forms.Label();
            this.total_price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.total_quantity = new System.Windows.Forms.Label();
            this.Exep_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_product_details)).BeginInit();
            this.SuspendLayout();
            // 
            // date_made
            // 
            this.date_made.Location = new System.Drawing.Point(116, 16);
            this.date_made.Name = "date_made";
            this.date_made.Size = new System.Drawing.Size(297, 20);
            this.date_made.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "تاريخ الصرف :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "سبب الصرف :";
            // 
            // details
            // 
            this.details.Location = new System.Drawing.Point(499, 14);
            this.details.Multiline = true;
            this.details.Name = "details";
            this.details.Size = new System.Drawing.Size(337, 62);
            this.details.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "حساب الأستاذ :";
            // 
            // account_name
            // 
            this.account_name.Location = new System.Drawing.Point(116, 56);
            this.account_name.Name = "account_name";
            this.account_name.Size = new System.Drawing.Size(297, 20);
            this.account_name.TabIndex = 5;
            // 
            // account_number
            // 
            this.account_number.Location = new System.Drawing.Point(419, 56);
            this.account_number.Name = "account_number";
            this.account_number.Size = new System.Drawing.Size(32, 20);
            this.account_number.TabIndex = 6;
            this.account_number.Visible = false;
            // 
            // datagrid_product_details
            // 
            this.datagrid_product_details.AllowUserToAddRows = false;
            this.datagrid_product_details.AllowUserToDeleteRows = false;
            this.datagrid_product_details.AllowUserToResizeColumns = false;
            this.datagrid_product_details.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_product_details.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.datagrid_product_details.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_product_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_product_details.GridColor = System.Drawing.Color.DodgerBlue;
            this.datagrid_product_details.Location = new System.Drawing.Point(16, 97);
            this.datagrid_product_details.MultiSelect = false;
            this.datagrid_product_details.Name = "datagrid_product_details";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_product_details.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.datagrid_product_details.RowHeadersVisible = false;
            this.datagrid_product_details.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.datagrid_product_details.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_product_details.RowTemplate.Height = 26;
            this.datagrid_product_details.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_product_details.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid_product_details.ShowEditingIcon = false;
            this.datagrid_product_details.Size = new System.Drawing.Size(818, 307);
            this.datagrid_product_details.TabIndex = 32;
            // 
            // current_invoice_page
            // 
            this.current_invoice_page.AutoSize = true;
            this.current_invoice_page.Font = new System.Drawing.Font("Tahoma", 16F);
            this.current_invoice_page.Location = new System.Drawing.Point(319, 436);
            this.current_invoice_page.Name = "current_invoice_page";
            this.current_invoice_page.Size = new System.Drawing.Size(82, 27);
            this.current_invoice_page.TabIndex = 145;
            this.current_invoice_page.Text = "00 / 00";
            this.current_invoice_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // first_record_button
            // 
            this.first_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.first_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_record_button.Image = global::sales_management.Properties.Resources.last_btn;
            this.first_record_button.Location = new System.Drawing.Point(197, 431);
            this.first_record_button.Name = "first_record_button";
            this.first_record_button.Size = new System.Drawing.Size(50, 38);
            this.first_record_button.TabIndex = 144;
            this.first_record_button.UseVisualStyleBackColor = false;
            // 
            // last_record_button
            // 
            this.last_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.last_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.last_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last_record_button.Image = global::sales_management.Properties.Resources.first_btn;
            this.last_record_button.Location = new System.Drawing.Point(475, 431);
            this.last_record_button.Name = "last_record_button";
            this.last_record_button.Size = new System.Drawing.Size(50, 38);
            this.last_record_button.TabIndex = 143;
            this.last_record_button.UseVisualStyleBackColor = false;
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Image = global::sales_management.Properties.Resources.next_btn;
            this.next_button.Location = new System.Drawing.Point(253, 431);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(50, 38);
            this.next_button.TabIndex = 142;
            this.next_button.UseVisualStyleBackColor = false;
            // 
            // previous_button
            // 
            this.previous_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous_button.Image = global::sales_management.Properties.Resources.prev_btn;
            this.previous_button.Location = new System.Drawing.Point(419, 431);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(50, 38);
            this.previous_button.TabIndex = 141;
            this.previous_button.UseVisualStyleBackColor = false;
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_button.Image = global::sales_management.Properties.Resources.save_data;
            this.save_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save_button.Location = new System.Drawing.Point(92, 431);
            this.save_button.Name = "save_button";
            this.save_button.Padding = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.save_button.Size = new System.Drawing.Size(99, 38);
            this.save_button.TabIndex = 140;
            this.save_button.Text = " حفظ";
            this.save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // total_label_text
            // 
            this.total_label_text.AutoSize = true;
            this.total_label_text.Font = new System.Drawing.Font("Tahoma", 35F);
            this.total_label_text.Location = new System.Drawing.Point(687, 424);
            this.total_label_text.Name = "total_label_text";
            this.total_label_text.Size = new System.Drawing.Size(143, 57);
            this.total_label_text.TabIndex = 147;
            this.total_label_text.Text = "00.00";
            // 
            // total_price
            // 
            this.total_price.Location = new System.Drawing.Point(793, 407);
            this.total_price.Name = "total_price";
            this.total_price.Size = new System.Drawing.Size(32, 20);
            this.total_price.TabIndex = 149;
            this.total_price.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(567, 421);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "إجمالي الكميات :";
            // 
            // total_quantity
            // 
            this.total_quantity.AutoSize = true;
            this.total_quantity.Font = new System.Drawing.Font("Tahoma", 20F);
            this.total_quantity.Location = new System.Drawing.Point(567, 437);
            this.total_quantity.Name = "total_quantity";
            this.total_quantity.Size = new System.Drawing.Size(83, 33);
            this.total_quantity.TabIndex = 151;
            this.total_quantity.Text = "00.00";
            // 
            // Exep_id
            // 
            this.Exep_id.Location = new System.Drawing.Point(91, 16);
            this.Exep_id.Name = "Exep_id";
            this.Exep_id.Size = new System.Drawing.Size(19, 20);
            this.Exep_id.TabIndex = 152;
            this.Exep_id.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(704, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 153;
            this.label5.Text = "إجمالي التكلفة :";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::sales_management.Properties.Resources.add_new;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(16, 431);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button1.Size = new System.Drawing.Size(47, 38);
            this.button1.TabIndex = 154;
            this.button1.Text = " ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Export_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 494);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Exep_id);
            this.Controls.Add(this.total_quantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.total_price);
            this.Controls.Add(this.total_label_text);
            this.Controls.Add(this.current_invoice_page);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.datagrid_product_details);
            this.Controls.Add(this.account_number);
            this.Controls.Add(this.account_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.details);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_made);
            this.MaximizeBox = false;
            this.Name = "Export_Document";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إذن الصرف";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_product_details)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker date_made;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox details;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox account_name;
        private System.Windows.Forms.TextBox account_number;
        public System.Windows.Forms.DataGridView datagrid_product_details;
        private System.Windows.Forms.Label current_invoice_page;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label total_label_text;
        private System.Windows.Forms.TextBox total_price;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label total_quantity;
        private System.Windows.Forms.TextBox Exep_id;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}