
namespace sales_management.UI
{
    partial class Add_New_Entry
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
            this.entry_number_field = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.entry_details_field = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.entry_date_field = new System.Windows.Forms.DateTimePicker();
            this.datagrid_entry_accounts = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.debit_label_text = new System.Windows.Forms.Label();
            this.credit_label_text = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.entry_id_field = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_entry_accounts)).BeginInit();
            this.SuspendLayout();
            // 
            // entry_number_field
            // 
            this.entry_number_field.Location = new System.Drawing.Point(81, 17);
            this.entry_number_field.Name = "entry_number_field";
            this.entry_number_field.ReadOnly = true;
            this.entry_number_field.Size = new System.Drawing.Size(119, 20);
            this.entry_number_field.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "رقم القيد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "البيان";
            // 
            // entry_details_field
            // 
            this.entry_details_field.Location = new System.Drawing.Point(549, 17);
            this.entry_details_field.Name = "entry_details_field";
            this.entry_details_field.Size = new System.Drawing.Size(297, 20);
            this.entry_details_field.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "التاريخ";
            // 
            // entry_date_field
            // 
            this.entry_date_field.Location = new System.Drawing.Point(263, 17);
            this.entry_date_field.Name = "entry_date_field";
            this.entry_date_field.Size = new System.Drawing.Size(213, 20);
            this.entry_date_field.TabIndex = 5;
            // 
            // datagrid_entry_accounts
            // 
            this.datagrid_entry_accounts.AllowUserToResizeColumns = false;
            this.datagrid_entry_accounts.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            this.datagrid_entry_accounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.datagrid_entry_accounts.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.datagrid_entry_accounts.ColumnHeadersHeight = 26;
            this.datagrid_entry_accounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.datagrid_entry_accounts.GridColor = System.Drawing.Color.DodgerBlue;
            this.datagrid_entry_accounts.Location = new System.Drawing.Point(13, 54);
            this.datagrid_entry_accounts.MultiSelect = false;
            this.datagrid_entry_accounts.Name = "datagrid_entry_accounts";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagrid_entry_accounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datagrid_entry_accounts.RowHeadersVisible = false;
            this.datagrid_entry_accounts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Azure;
            this.datagrid_entry_accounts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.datagrid_entry_accounts.RowTemplate.Height = 30;
            this.datagrid_entry_accounts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.datagrid_entry_accounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.datagrid_entry_accounts.ShowEditingIcon = false;
            this.datagrid_entry_accounts.Size = new System.Drawing.Size(833, 343);
            this.datagrid_entry_accounts.TabIndex = 31;
            this.datagrid_entry_accounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_entry_accounts_CellClick);
            this.datagrid_entry_accounts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_entry_accounts_CellValueChanged);
            this.datagrid_entry_accounts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.datagrid_entry_accounts_EditingControlShowing);
            this.datagrid_entry_accounts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datagrid_entry_accounts_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(622, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "إجمالي المدين";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(756, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "إجمالى الدائن";
            // 
            // debit_label_text
            // 
            this.debit_label_text.AutoSize = true;
            this.debit_label_text.Font = new System.Drawing.Font("Tahoma", 14F);
            this.debit_label_text.Location = new System.Drawing.Point(617, 451);
            this.debit_label_text.Name = "debit_label_text";
            this.debit_label_text.Size = new System.Drawing.Size(46, 23);
            this.debit_label_text.TabIndex = 34;
            this.debit_label_text.Text = "0.00";
            // 
            // credit_label_text
            // 
            this.credit_label_text.AutoSize = true;
            this.credit_label_text.Font = new System.Drawing.Font("Tahoma", 14F);
            this.credit_label_text.Location = new System.Drawing.Point(749, 451);
            this.credit_label_text.Name = "credit_label_text";
            this.credit_label_text.Size = new System.Drawing.Size(46, 23);
            this.credit_label_text.TabIndex = 35;
            this.credit_label_text.Text = "0.00";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 36;
            this.button1.Text = "حفظ التعديلات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 31);
            this.button2.TabIndex = 37;
            this.button2.Text = "إلغاء";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // entry_id_field
            // 
            this.entry_id_field.Location = new System.Drawing.Point(206, -3);
            this.entry_id_field.Name = "entry_id_field";
            this.entry_id_field.Size = new System.Drawing.Size(21, 20);
            this.entry_id_field.TabIndex = 38;
            this.entry_id_field.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(139, 424);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 31);
            this.button3.TabIndex = 39;
            this.button3.Text = "حذف";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Add_New_Entry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 504);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.entry_id_field);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.credit_label_text);
            this.Controls.Add(this.debit_label_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.datagrid_entry_accounts);
            this.Controls.Add(this.entry_date_field);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.entry_details_field);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.entry_number_field);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Add_New_Entry";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تحديث القيد";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Add_New_Entry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_entry_accounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entry_number_field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox entry_details_field;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker entry_date_field;
        public System.Windows.Forms.DataGridView datagrid_entry_accounts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label debit_label_text;
        private System.Windows.Forms.Label credit_label_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox entry_id_field;
        private System.Windows.Forms.Button button3;
    }
}