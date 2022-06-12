namespace sales_management.UI
{
    partial class employees
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
            this.full_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password_field = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.user_name = new System.Windows.Forms.TextBox();
            this.first_record_button = new System.Windows.Forms.Button();
            this.last_record_button = new System.Windows.Forms.Button();
            this.next_button = new System.Windows.Forms.Button();
            this.previous_button = new System.Windows.Forms.Button();
            this.is_manager_check = new System.Windows.Forms.CheckBox();
            this.user_id = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // full_name
            // 
            this.full_name.Location = new System.Drawing.Point(142, 97);
            this.full_name.Name = "full_name";
            this.full_name.Size = new System.Drawing.Size(285, 20);
            this.full_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "إسم المستخدم :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "الإسم الكامل :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "الرقم السري :";
            // 
            // password_field
            // 
            this.password_field.Location = new System.Drawing.Point(142, 157);
            this.password_field.Name = "password_field";
            this.password_field.Size = new System.Drawing.Size(285, 20);
            this.password_field.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "الصلاحية :";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(74, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 38);
            this.button1.TabIndex = 9;
            this.button1.Text = "حفظ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(378, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 38);
            this.button2.TabIndex = 10;
            this.button2.Text = "حذف";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // user_name
            // 
            this.user_name.Location = new System.Drawing.Point(142, 39);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(285, 20);
            this.user_name.TabIndex = 137;
            // 
            // first_record_button
            // 
            this.first_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.first_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.first_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_record_button.Image = global::sales_management.Properties.Resources.last_btn;
            this.first_record_button.Location = new System.Drawing.Point(154, 273);
            this.first_record_button.Name = "first_record_button";
            this.first_record_button.Size = new System.Drawing.Size(50, 38);
            this.first_record_button.TabIndex = 136;
            this.first_record_button.UseVisualStyleBackColor = false;
            this.first_record_button.Click += new System.EventHandler(this.first_record_button_Click);
            // 
            // last_record_button
            // 
            this.last_record_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.last_record_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.last_record_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.last_record_button.Image = global::sales_management.Properties.Resources.first_btn;
            this.last_record_button.Location = new System.Drawing.Point(320, 273);
            this.last_record_button.Name = "last_record_button";
            this.last_record_button.Size = new System.Drawing.Size(50, 38);
            this.last_record_button.TabIndex = 135;
            this.last_record_button.UseVisualStyleBackColor = false;
            this.last_record_button.Click += new System.EventHandler(this.last_record_button_Click);
            // 
            // next_button
            // 
            this.next_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next_button.Image = global::sales_management.Properties.Resources.next_btn;
            this.next_button.Location = new System.Drawing.Point(210, 273);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(50, 38);
            this.next_button.TabIndex = 134;
            this.next_button.UseVisualStyleBackColor = false;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // previous_button
            // 
            this.previous_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previous_button.Image = global::sales_management.Properties.Resources.prev_btn;
            this.previous_button.Location = new System.Drawing.Point(266, 273);
            this.previous_button.Name = "previous_button";
            this.previous_button.Size = new System.Drawing.Size(50, 38);
            this.previous_button.TabIndex = 133;
            this.previous_button.UseVisualStyleBackColor = false;
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // is_manager_check
            // 
            this.is_manager_check.AutoSize = true;
            this.is_manager_check.Location = new System.Drawing.Point(142, 219);
            this.is_manager_check.Name = "is_manager_check";
            this.is_manager_check.Size = new System.Drawing.Size(124, 17);
            this.is_manager_check.TabIndex = 138;
            this.is_manager_check.Text = "التعيين ك مدير للنظام";
            this.is_manager_check.UseVisualStyleBackColor = true;
            // 
            // user_id
            // 
            this.user_id.Location = new System.Drawing.Point(37, 12);
            this.user_id.Name = "user_id";
            this.user_id.Size = new System.Drawing.Size(44, 20);
            this.user_id.TabIndex = 139;
            this.user_id.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(12, 273);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 38);
            this.button3.TabIndex = 140;
            this.button3.Text = "جديد";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 325);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.user_id);
            this.Controls.Add(this.is_manager_check);
            this.Controls.Add(this.user_name);
            this.Controls.Add(this.first_record_button);
            this.Controls.Add(this.last_record_button);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.previous_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.password_field);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.full_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "employees";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الموظفين";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox full_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password_field;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button previous_button;
        private System.Windows.Forms.Button first_record_button;
        private System.Windows.Forms.Button last_record_button;
        private System.Windows.Forms.TextBox user_name;
        private System.Windows.Forms.CheckBox is_manager_check;
        private System.Windows.Forms.TextBox user_id;
        private System.Windows.Forms.Button button3;
    }
}