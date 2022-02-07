namespace sales_management.UI
{
    partial class AccTree
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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.main_account_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.account_name_en = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.account_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.account_number = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.account_type = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.accounting_tree = new System.Windows.Forms.TreeView();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.progress_panel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.progress_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "رقم الحساب التابع له :";
            // 
            // main_account_number
            // 
            this.main_account_number.Location = new System.Drawing.Point(26, 38);
            this.main_account_number.Name = "main_account_number";
            this.main_account_number.ReadOnly = true;
            this.main_account_number.Size = new System.Drawing.Size(218, 20);
            this.main_account_number.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "الإسم الإنجليزي :";
            // 
            // account_name_en
            // 
            this.account_name_en.Location = new System.Drawing.Point(26, 164);
            this.account_name_en.Name = "account_name_en";
            this.account_name_en.Size = new System.Drawing.Size(218, 20);
            this.account_name_en.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "إسم الحساب :";
            // 
            // account_name
            // 
            this.account_name.Location = new System.Drawing.Point(26, 120);
            this.account_name.Name = "account_name";
            this.account_name.Size = new System.Drawing.Size(218, 20);
            this.account_name.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "رقم الحساب :";
            // 
            // account_number
            // 
            this.account_number.Location = new System.Drawing.Point(26, 76);
            this.account_number.Name = "account_number";
            this.account_number.Size = new System.Drawing.Size(218, 20);
            this.account_number.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.account_type);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.account_number);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.account_name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.main_account_number);
            this.panel1.Controls.Add(this.account_name_en);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(325, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 269);
            this.panel1.TabIndex = 22;
            // 
            // account_type
            // 
            this.account_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.account_type.FormattingEnabled = true;
            this.account_type.Items.AddRange(new object[] {
            "مدين",
            "دائن"});
            this.account_type.Location = new System.Drawing.Point(26, 212);
            this.account_type.Name = "account_type";
            this.account_type.Size = new System.Drawing.Size(218, 21);
            this.account_type.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(302, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "نوع الحساب :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.accounting_tree);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 269);
            this.panel2.TabIndex = 23;
            // 
            // accounting_tree
            // 
            this.accounting_tree.Location = new System.Drawing.Point(3, 3);
            this.accounting_tree.Name = "accounting_tree";
            this.accounting_tree.RightToLeftLayout = true;
            this.accounting_tree.Size = new System.Drawing.Size(301, 263);
            this.accounting_tree.TabIndex = 0;
            this.accounting_tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.accounting_tree_AfterSelect);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(547, 300);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 34);
            this.button4.TabIndex = 7;
            this.button4.Text = "تعديل";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(627, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "حساب جديد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(12, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "إستيراد شجرة حسابات";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(467, 300);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 34);
            this.button3.TabIndex = 6;
            this.button3.Text = "حفظ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.Location = new System.Drawing.Point(367, 300);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 34);
            this.button5.TabIndex = 27;
            this.button5.Text = "حذف حساب";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.Location = new System.Drawing.Point(167, 300);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(149, 34);
            this.button6.TabIndex = 29;
            this.button6.Text = "حذف الشجرة الحالية";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // progress_panel
            // 
            this.progress_panel.Controls.Add(this.progressBar);
            this.progress_panel.Controls.Add(this.label5);
            this.progress_panel.Location = new System.Drawing.Point(4, -1);
            this.progress_panel.Name = "progress_panel";
            this.progress_panel.Size = new System.Drawing.Size(730, 352);
            this.progress_panel.TabIndex = 30;
            this.progress_panel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(167, 141);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(396, 12);
            this.progressBar.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(229, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "من فضلك إنتظر .. جاري إعداد شجرة الحسابات ...";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // AccTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 351);
            this.Controls.Add(this.progress_panel);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AccTree";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شجرة الحســــــابات";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.progress_panel.ResumeLayout(false);
            this.progress_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox main_account_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox account_name_en;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox account_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox account_number;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView accounting_tree;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox account_type;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel progress_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
    }
}