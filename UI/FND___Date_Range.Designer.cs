namespace sales_management.UI
{
    partial class FND___Date_Range
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FND___Date_Range));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date_from = new System.Windows.Forms.DateTimePicker();
            this.date_to = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.Statements = new FastReport.Report();
            this.journals_statment = new sales_management.DSet.DailyEntries();
            this.statements_dataset = new sales_management.DSet.Statments();
            this.Entry_Report = new FastReport.Report();
            this.withdraw_Report1 = new sales_management.DSet.Withdraw_Report();
            this.Withdraw_Report = new FastReport.Report();
            ((System.ComponentModel.ISupportInitialize)(this.Statements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.journals_statment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statements_dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Entry_Report)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.withdraw_Report1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Withdraw_Report)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "من تاريخ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "إلي تاريخ :";
            // 
            // date_from
            // 
            this.date_from.Location = new System.Drawing.Point(12, 41);
            this.date_from.Name = "date_from";
            this.date_from.Size = new System.Drawing.Size(257, 20);
            this.date_from.TabIndex = 2;
            // 
            // date_to
            // 
            this.date_to.Location = new System.Drawing.Point(13, 129);
            this.date_to.Name = "date_to";
            this.date_to.Size = new System.Drawing.Size(257, 20);
            this.date_to.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(15, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "عرض التقرير";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Statements
            // 
            this.Statements.NeedRefresh = false;
            this.Statements.ReportResourceString = resources.GetString("Statements.ReportResourceString");
            this.Statements.RegisterData(this.journals_statment, "journals_statment");
            // 
            // journals_statment
            // 
            this.journals_statment.DataSetName = "DailyEntries";
            this.journals_statment.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statements_dataset
            // 
            this.statements_dataset.DataSetName = "Statments";
            this.statements_dataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Entry_Report
            // 
            this.Entry_Report.NeedRefresh = false;
            this.Entry_Report.ReportResourceString = resources.GetString("Entry_Report.ReportResourceString");
            this.Entry_Report.RegisterData(this.journals_statment, "journals_statment");
            // 
            // withdraw_Report1
            // 
            this.withdraw_Report1.DataSetName = "Withdraw_Report_DS";
            this.withdraw_Report1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Withdraw_Report
            // 
            this.Withdraw_Report.NeedRefresh = false;
            this.Withdraw_Report.ReportResourceString = resources.GetString("Withdraw_Report.ReportResourceString");
            this.Withdraw_Report.RegisterData(this.withdraw_Report1, "withdraw_Report1");
            // 
            // FND___Date_Range
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date_to);
            this.Controls.Add(this.date_from);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FND___Date_Range";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خلال الفترة";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Statements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.journals_statment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statements_dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Entry_Report)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.withdraw_Report1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Withdraw_Report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker date_from;
        private System.Windows.Forms.DateTimePicker date_to;
        private System.Windows.Forms.Button button1;
        private FastReport.Report Statements;
        private DSet.Statments statements_dataset;
        private DSet.DailyEntries journals_statment;
        private FastReport.Report Entry_Report;
        private DSet.Withdraw_Report withdraw_Report1;
        private FastReport.Report Withdraw_Report;
    }
}