
namespace sales_management.UI
{
    partial class ServerSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.networkid_text = new System.Windows.Forms.TextBox();
            this.networkpost_text = new System.Windows.Forms.TextBox();
            this.databasename_text = new System.Windows.Forms.TextBox();
            this.username_text = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.isIntegratedCheckbox = new System.Windows.Forms.CheckBox();
            this.enable_edit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Network Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Network Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "User Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // networkid_text
            // 
            this.networkid_text.Location = new System.Drawing.Point(129, 27);
            this.networkid_text.Name = "networkid_text";
            this.networkid_text.Size = new System.Drawing.Size(303, 20);
            this.networkid_text.TabIndex = 5;
            // 
            // networkpost_text
            // 
            this.networkpost_text.Enabled = false;
            this.networkpost_text.Location = new System.Drawing.Point(129, 68);
            this.networkpost_text.Name = "networkpost_text";
            this.networkpost_text.Size = new System.Drawing.Size(303, 20);
            this.networkpost_text.TabIndex = 6;
            // 
            // databasename_text
            // 
            this.databasename_text.Location = new System.Drawing.Point(129, 109);
            this.databasename_text.Name = "databasename_text";
            this.databasename_text.Size = new System.Drawing.Size(303, 20);
            this.databasename_text.TabIndex = 7;
            // 
            // username_text
            // 
            this.username_text.Enabled = false;
            this.username_text.Location = new System.Drawing.Point(129, 149);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(303, 20);
            this.username_text.TabIndex = 8;
            // 
            // password_text
            // 
            this.password_text.Enabled = false;
            this.password_text.Location = new System.Drawing.Point(129, 192);
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(303, 20);
            this.password_text.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "Check status";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // isIntegratedCheckbox
            // 
            this.isIntegratedCheckbox.AutoSize = true;
            this.isIntegratedCheckbox.Location = new System.Drawing.Point(129, 235);
            this.isIntegratedCheckbox.Name = "isIntegratedCheckbox";
            this.isIntegratedCheckbox.Size = new System.Drawing.Size(132, 17);
            this.isIntegratedCheckbox.TabIndex = 12;
            this.isIntegratedCheckbox.Text = "Is Integrated Security";
            this.isIntegratedCheckbox.UseVisualStyleBackColor = true;
            this.isIntegratedCheckbox.CheckedChanged += new System.EventHandler(this.isIntegratedCheckbox_CheckedChanged);
            // 
            // enable_edit
            // 
            this.enable_edit.AutoSize = true;
            this.enable_edit.Location = new System.Drawing.Point(283, 235);
            this.enable_edit.Name = "enable_edit";
            this.enable_edit.Size = new System.Drawing.Size(58, 17);
            this.enable_edit.TabIndex = 13;
            this.enable_edit.Text = "Enable";
            this.enable_edit.UseVisualStyleBackColor = true;
            // 
            // ServerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 328);
            this.Controls.Add(this.enable_edit);
            this.Controls.Add(this.isIntegratedCheckbox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.databasename_text);
            this.Controls.Add(this.networkpost_text);
            this.Controls.Add(this.networkid_text);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ServerSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Server Settings";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox networkid_text;
        private System.Windows.Forms.TextBox networkpost_text;
        private System.Windows.Forms.TextBox databasename_text;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox isIntegratedCheckbox;
        private System.Windows.Forms.CheckBox enable_edit;
    }
}