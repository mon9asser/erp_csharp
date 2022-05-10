
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.date_made = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.details = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.account_name = new System.Windows.Forms.TextBox();
            this.account_number = new System.Windows.Forms.TextBox();
            this.items_datagridview = new System.Windows.Forms.DataGridView();
            this.current_invoice_page = new System.Windows.Forms.Label();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.total_price_field = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.total_quantity = new System.Windows.Forms.Label();
            this.Exep_id = new System.Windows.Forms.TextBox();
            this.add_new_btn = new System.Windows.Forms.Button();
            this.deletion_button = new System.Windows.Forms.Button();
            this.total_quantity_field = new System.Windows.Forms.TextBox();
            this.journal_id = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).BeginInit();
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
            // items_datagridview
            // 
            this.items_datagridview.AllowUserToAddRows = false;
            this.items_datagridview.AllowUserToDeleteRows = false;
            this.items_datagridview.AllowUserToResizeColumns = false;
            this.items_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            this.items_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.items_datagridview.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.items_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.items_datagridview.GridColor = System.Drawing.Color.DodgerBlue;
            this.items_datagridview.Location = new System.Drawing.Point(16, 97);
            this.items_datagridview.MultiSelect = false;
            this.items_datagridview.Name = "items_datagridview";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.items_datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.items_datagridview.RowHeadersVisible = false;
            this.items_datagridview.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.items_datagridview.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.items_datagridview.RowTemplate.Height = 26;
            this.items_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.items_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.items_datagridview.ShowEditingIcon = false;
            this.items_datagridview.Size = new System.Drawing.Size(818, 307);
            this.items_datagridview.TabIndex = 32;
            this.items_datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellClick);
            this.items_datagridview.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.items_datagridview_CellMouseClick);
            this.items_datagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellMouseEnter);
            this.items_datagridview.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.items_datagridview_CellValueChanged);
            this.items_datagridview.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.items_datagridview_EditingControlShowing);
            this.items_datagridview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.items_datagridview_KeyDown);
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
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // total_price_field
            // 
            this.total_price_field.Location = new System.Drawing.Point(683, 449);
            this.total_price_field.Name = "total_price_field";
            this.total_price_field.Size = new System.Drawing.Size(32, 20);
            this.total_price_field.TabIndex = 149;
            this.total_price_field.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(740, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "إجمالي الكميات :";
            // 
            // total_quantity
            // 
            this.total_quantity.AutoSize = true;
            this.total_quantity.Font = new System.Drawing.Font("Tahoma", 20F);
            this.total_quantity.Location = new System.Drawing.Point(740, 436);
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
            // add_new_btn
            // 
            this.add_new_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_new_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_btn.Image = global::sales_management.Properties.Resources.add_new;
            this.add_new_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_new_btn.Location = new System.Drawing.Point(16, 431);
            this.add_new_btn.Name = "add_new_btn";
            this.add_new_btn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.add_new_btn.Size = new System.Drawing.Size(47, 38);
            this.add_new_btn.TabIndex = 154;
            this.add_new_btn.Text = " ";
            this.add_new_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_new_btn.UseVisualStyleBackColor = true;
            this.add_new_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // deletion_button
            // 
            this.deletion_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletion_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletion_button.Image = global::sales_management.Properties.Resources.icons8_delete_20;
            this.deletion_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deletion_button.Location = new System.Drawing.Point(559, 431);
            this.deletion_button.Name = "deletion_button";
            this.deletion_button.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.deletion_button.Size = new System.Drawing.Size(47, 38);
            this.deletion_button.TabIndex = 155;
            this.deletion_button.Text = " ";
            this.deletion_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deletion_button.UseVisualStyleBackColor = true;
            // 
            // total_quantity_field
            // 
            this.total_quantity_field.Location = new System.Drawing.Point(683, 421);
            this.total_quantity_field.Name = "total_quantity_field";
            this.total_quantity_field.Size = new System.Drawing.Size(32, 20);
            this.total_quantity_field.TabIndex = 156;
            this.total_quantity_field.Visible = false;
            // 
            // journal_id
            // 
            this.journal_id.Location = new System.Drawing.Point(457, 56);
            this.journal_id.Name = "journal_id";
            this.journal_id.Size = new System.Drawing.Size(19, 20);
            this.journal_id.TabIndex = 157;
            this.journal_id.Visible = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::sales_management.Properties.Resources.icons8_update_20;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(612, 431);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.button1.Size = new System.Drawing.Size(47, 38);
            this.button1.TabIndex = 158;
            this.button1.Text = " ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Export_Document
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 494);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.journal_id);
            this.Controls.Add(this.total_quantity_field);
            this.Controls.Add(this.deletion_button);
            this.Controls.Add(this.add_new_btn);
            this.Controls.Add(this.Exep_id);
            this.Controls.Add(this.total_quantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.total_price_field);
            this.Controls.Add(this.current_invoice_page);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.items_datagridview);
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
            ((System.ComponentModel.ISupportInitialize)(this.items_datagridview)).EndInit();
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
        public System.Windows.Forms.DataGridView items_datagridview;
        private System.Windows.Forms.Label current_invoice_page;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.TextBox total_price_field;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label total_quantity;
        private System.Windows.Forms.TextBox Exep_id;
        private System.Windows.Forms.Button add_new_btn;
        private System.Windows.Forms.Button deletion_button;
        private System.Windows.Forms.TextBox total_quantity_field;
        private System.Windows.Forms.TextBox journal_id;
        private System.Windows.Forms.Button button1;
    }
}