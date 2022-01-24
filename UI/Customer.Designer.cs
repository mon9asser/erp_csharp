
namespace sales_management.UI
{
    partial class Customer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resource_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.resource_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resource_address = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resource_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.resource_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resource_phone = new System.Windows.Forms.TextBox();
            this.save_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delete_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resource_id);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.resource_code);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.resource_address);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.resource_name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.resource_email);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.resource_phone);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 163);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   إضافة جديد   ";
            // 
            // resource_id
            // 
            this.resource_id.Location = new System.Drawing.Point(341, 105);
            this.resource_id.Name = "resource_id";
            this.resource_id.Size = new System.Drawing.Size(22, 20);
            this.resource_id.TabIndex = 12;
            this.resource_id.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(667, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "كود العميل";
            // 
            // resource_code
            // 
            this.resource_code.Location = new System.Drawing.Point(400, 107);
            this.resource_code.Name = "resource_code";
            this.resource_code.ReadOnly = true;
            this.resource_code.Size = new System.Drawing.Size(244, 20);
            this.resource_code.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "إسم العميل";
            // 
            // resource_address
            // 
            this.resource_address.Location = new System.Drawing.Point(21, 72);
            this.resource_address.Multiline = true;
            this.resource_address.Name = "resource_address";
            this.resource_address.Size = new System.Drawing.Size(284, 55);
            this.resource_address.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "العنوان";
            // 
            // resource_name
            // 
            this.resource_name.Location = new System.Drawing.Point(400, 33);
            this.resource_name.Name = "resource_name";
            this.resource_name.Size = new System.Drawing.Size(244, 20);
            this.resource_name.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(667, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "رقم الهاتف";
            // 
            // resource_email
            // 
            this.resource_email.Location = new System.Drawing.Point(21, 28);
            this.resource_email.Name = "resource_email";
            this.resource_email.Size = new System.Drawing.Size(284, 20);
            this.resource_email.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "الإيميل";
            // 
            // resource_phone
            // 
            this.resource_phone.Location = new System.Drawing.Point(400, 71);
            this.resource_phone.Name = "resource_phone";
            this.resource_phone.Size = new System.Drawing.Size(244, 20);
            this.resource_phone.TabIndex = 4;
            // 
            // save_button
            // 
            this.save_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_button.Enabled = false;
            this.save_button.Location = new System.Drawing.Point(479, 393);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(88, 34);
            this.save_button.TabIndex = 18;
            this.save_button.Text = "حفظ";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // edit_button
            // 
            this.edit_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.edit_button.Location = new System.Drawing.Point(573, 393);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(88, 34);
            this.edit_button.TabIndex = 19;
            this.edit_button.Text = "تعديل";
            this.edit_button.UseVisualStyleBackColor = true;
            this.edit_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(12, 183);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DimGray;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(744, 195);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // delete_button
            // 
            this.delete_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete_button.Location = new System.Drawing.Point(667, 393);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(88, 34);
            this.delete_button.TabIndex = 21;
            this.delete_button.Text = "حذف";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // add_button
            // 
            this.add_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add_button.Location = new System.Drawing.Point(12, 395);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(104, 34);
            this.add_button.TabIndex = 22;
            this.add_button.Text = "إضافة جديد";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 439);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Customer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "العملاء";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.TextBox resource_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox resource_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox resource_address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox resource_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resource_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resource_phone;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button add_button;
    }
}