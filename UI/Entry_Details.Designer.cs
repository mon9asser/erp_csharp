namespace sales_management.UI
{
    partial class Entry_Details
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
            this.entry_number_field = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.entry_id_field = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.description_field = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.datetime_field = new System.Windows.Forms.DateTimePicker();
            this.datagridview_items = new System.Windows.Forms.DataGridView();
            this.current_invoice_page = new System.Windows.Forms.Label();
            this.add_new_button = new System.Windows.Forms.Button();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.search_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.total_debit = new System.Windows.Forms.TextBox();
            this.total_credit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_items)).BeginInit();
            this.SuspendLayout();
            // 
            // entry_number_field
            // 
            this.entry_number_field.Location = new System.Drawing.Point(85, 23);
            this.entry_number_field.Name = "entry_number_field";
            this.entry_number_field.ReadOnly = true;
            this.entry_number_field.Size = new System.Drawing.Size(211, 20);
            this.entry_number_field.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "رقم القيد :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // entry_id_field
            // 
            this.entry_id_field.Location = new System.Drawing.Point(302, 23);
            this.entry_id_field.Name = "entry_id_field";
            this.entry_id_field.ReadOnly = true;
            this.entry_id_field.Size = new System.Drawing.Size(21, 20);
            this.entry_id_field.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "البيان :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // description_field
            // 
            this.description_field.Location = new System.Drawing.Point(385, 23);
            this.description_field.Multiline = true;
            this.description_field.Name = "description_field";
            this.description_field.Size = new System.Drawing.Size(274, 62);
            this.description_field.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "التاريخ :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // datetime_field
            // 
            this.datetime_field.Location = new System.Drawing.Point(85, 65);
            this.datetime_field.Name = "datetime_field";
            this.datetime_field.Size = new System.Drawing.Size(211, 20);
            this.datetime_field.TabIndex = 7;
            // 
            // datagridview_items
            // 
            this.datagridview_items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_items.Location = new System.Drawing.Point(11, 109);
            this.datagridview_items.Name = "datagridview_items";
            this.datagridview_items.Size = new System.Drawing.Size(868, 294);
            this.datagridview_items.TabIndex = 8;
            this.datagridview_items.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_items_CellContentClick);
            this.datagridview_items.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_items_CellDoubleClick);
            this.datagridview_items.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.datagridview_items_CellParsing);
            this.datagridview_items.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.datagridview_items_DataError);
            this.datagridview_items.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // current_invoice_page
            // 
            this.current_invoice_page.AutoSize = true;
            this.current_invoice_page.Font = new System.Drawing.Font("Tahoma", 16F);
            this.current_invoice_page.Location = new System.Drawing.Point(449, 429);
            this.current_invoice_page.Name = "current_invoice_page";
            this.current_invoice_page.Size = new System.Drawing.Size(82, 27);
            this.current_invoice_page.TabIndex = 145;
            this.current_invoice_page.Text = "00 / 00";
            this.current_invoice_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // add_new_button
            // 
            this.add_new_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_new_button.Image = global::sales_management.Properties.Resources.add_new;
            this.add_new_button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_new_button.Location = new System.Drawing.Point(12, 423);
            this.add_new_button.Name = "add_new_button";
            this.add_new_button.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.add_new_button.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.add_new_button.Size = new System.Drawing.Size(133, 39);
            this.add_new_button.TabIndex = 146;
            this.add_new_button.Text = "إضافة  جديدة";
            this.add_new_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_new_button.UseVisualStyleBackColor = true;
            this.add_new_button.Click += new System.EventHandler(this.add_new_button_Click);
            // 
            // first_record_button
            // 
            this.first_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.first_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_record_button.Image = global::sales_management.Properties.Resources.last_btn;
            this.first_record_button.Location = new System.Drawing.Point(329, 424);
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
            this.last_record_button.Location = new System.Drawing.Point(599, 424);
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
            this.next_button.Location = new System.Drawing.Point(385, 424);
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
            this.previous_button.Location = new System.Drawing.Point(543, 424);
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
            this.save_button.Location = new System.Drawing.Point(152, 423);
            this.save_button.Name = "save_button";
            this.save_button.Padding = new System.Windows.Forms.Padding(20, 0, 5, 0);
            this.save_button.Size = new System.Drawing.Size(98, 38);
            this.save_button.TabIndex = 140;
            this.save_button.Text = " حفظ";
            this.save_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_button.Image = global::sales_management.Properties.Resources.icons8_update_20;
            this.edit_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edit_button.Location = new System.Drawing.Point(728, 422);
            this.edit_button.Name = "edit_button";
            this.edit_button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.edit_button.Size = new System.Drawing.Size(72, 39);
            this.edit_button.TabIndex = 147;
            this.edit_button.Text = "تعديل";
            this.edit_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // search_button
            // 
            this.search_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Image = global::sales_management.Properties.Resources.icons8_update_20;
            this.search_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_button.Location = new System.Drawing.Point(806, 422);
            this.search_button.Name = "search_button";
            this.search_button.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.search_button.Size = new System.Drawing.Size(72, 39);
            this.search_button.TabIndex = 148;
            this.search_button.Text = "بحث";
            this.search_button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(693, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 149;
            this.label4.Text = "إجمالى المدين :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // total_debit
            // 
            this.total_debit.Location = new System.Drawing.Point(786, 27);
            this.total_debit.Name = "total_debit";
            this.total_debit.ReadOnly = true;
            this.total_debit.Size = new System.Drawing.Size(92, 20);
            this.total_debit.TabIndex = 150;
            // 
            // total_credit
            // 
            this.total_credit.Location = new System.Drawing.Point(786, 60);
            this.total_credit.Name = "total_credit";
            this.total_credit.ReadOnly = true;
            this.total_credit.Size = new System.Drawing.Size(92, 20);
            this.total_credit.TabIndex = 152;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(693, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 151;
            this.label5.Text = "إجمالى الدائن :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Entry_Details
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 476);
            this.Controls.Add(this.total_credit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.total_debit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.current_invoice_page);
            this.Controls.Add(this.add_new_button);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.datagridview_items);
            this.Controls.Add(this.datetime_field);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.description_field);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.entry_id_field);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entry_number_field);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Entry_Details";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قيود اليومية";
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_items)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entry_number_field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox entry_id_field;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox description_field;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker datetime_field;
        private System.Windows.Forms.DataGridView datagridview_items;
        private System.Windows.Forms.Label current_invoice_page;
        private System.Windows.Forms.Button add_new_button;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox total_debit;
        private System.Windows.Forms.TextBox total_credit;
        private System.Windows.Forms.Label label5;
    }
}