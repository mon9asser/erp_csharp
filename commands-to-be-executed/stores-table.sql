
/*
id 
date_made
details
account_number
account_name
total_quantity
total_price 
type ==> 0 => decrement 1 => 
*/

 
-----------------------------------
------ تقرير المسحوبات عن الفترة
-- كميات البيع
-- كميات متبقية
--اجمالي السعر
----- التاريخ من وإلي
----- شامل إذونات الصرف 
----- شامل المردودات ( المشتريات )
-----------------------------------
------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن

ALTER PROC Report_Statement_Document

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)


AS 

	IF @account_2 != '-1' 
	BEGIN
		
		-- STATEMENT 
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1 OR a.account_number = @account_2
	
		)

		SELECT a.id, a.date, a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date >= @date_from AND a.date <= @date_to

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET FIRST BALANCE  
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1 OR a.account_number = @account_2
	
		)

		SELECT a.id, a.date, a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date <= @date_from

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET LAST BALANCE
		SELECT SUM(COALESCE(debit ,0)) 'debit', SUM(COALESCE(credit ,0)) 'credit' FROM journal_details WHERE 
		[date] >=  @date_from AND [date] <= @date_to
		AND 
		account_number = @account_1 OR account_number = @account_2;

	END
		ELSE
	BEGIN
		-- STATEMENT 
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1  
	
		)

		SELECT a.id, a.date, a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date >= @date_from AND a.date <= @date_to

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET FIRST BALANCE  
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1  
	
		)

		SELECT a.id, a.date, a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date <= @date_from

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET LAST BALANCE
		SELECT SUM(COALESCE(debit ,0)) 'debit', SUM(COALESCE(credit ,0)) 'credit' FROM journal_details WHERE 
		[date] >=  @date_from AND [date] <= @date_to
		AND 
		account_number = @account_1  
	END
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	-----==================================================
	ALTER PROC Report_Statement_Document

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)


AS 

	IF @account_2 != '-1' 
	BEGIN
		
		-- STATEMENT 
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1 OR a.account_number = @account_2
	
		)

		SELECT a.id, CAST(a.date as DATE), a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date >= @date_from AND a.date <= @date_to

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET FIRST BALANCE  
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1 OR a.account_number = @account_2
	
		)

		SELECT a.id, CAST(a.date as DATE), a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date <= @date_from

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET LAST BALANCE
		SELECT SUM(COALESCE(debit ,0)) 'debit', SUM(COALESCE(credit ,0)) 'credit' FROM journal_details WHERE 
		[date] >=  @date_from AND [date] <= @date_to
		AND 
		account_number = @account_1 OR account_number = @account_2;

	END
		ELSE
	BEGIN
		-- STATEMENT 
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1  
	
		)

		SELECT a.id, CAST(a.date as DATE), a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date >= @date_from AND a.date <= @date_to

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET FIRST BALANCE  
		WITH tempDebitCredit AS (

			SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
			FROM journal_details a where a.account_number = @account_1  
	
		)

		SELECT a.id, CAST(a.date as DATE), a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date <= @date_from

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;

		-- GET LAST BALANCE
		SELECT SUM(COALESCE(debit ,0)) 'debit', SUM(COALESCE(credit ,0)) 'credit' FROM journal_details WHERE 
		[date] >=  @date_from AND [date] <= @date_to
		AND 
		account_number = @account_1;

	END


























----------------------------------------------
WITH tempDebitCredit AS (
	SELECT a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details', a.id, a.debit  
	 
	FROM journal_details a where a.account_number = 1104
	
)
SELECT a.id, a.date, a.account_number, a.details , a.debit, a.credit, SUM(b.diff) 'balance'
FROM   tempDebitCredit a,
	   tempDebitCredit b
WHERE 
	b.id <= a.id  
	and 
	a.date >= '2014-05-14 18:51:23.000' AND a.date <= '2026-01-20' 

GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, a.details;
		
-------------------------------------------------------
CREATE PROC Report_Statement_Document

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)


AS 
 
	IF @account_2 != '-1' 
	BEGIN
		
		-- STATMENT
		 WITH tempDebitCredit AS (
			SELECT a.id, a.debit, a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details'
			FROM journal_details a where a.account_number = @account_1 OR a.account_number = @account_2 
		)
		SELECT a.id, a.date, a.account_number, b.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date >= @date_from AND a.date <= @date_to
			AND
			a.account_number = @account_1 OR a.account_number = @account_2 

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, b.details;
		
		-- FIRST BALANACE
		WITH tempDebitCredit AS (
			SELECT a.id, a.debit, a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details'
			FROM journal_details a where a.account_number = @account_1 OR a.account_number = @account_2  
		)
		SELECT a.id, a.date, a.account_number, b.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date <= @date_from
			AND
			a.account_number = @account_1 OR a.account_number = @account_2 

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, b.details;
	    
		-- LAST TOTALS
		SELECT SUM(COALESCE(debit ,0)) 'debit', SUM(COALESCE(credit ,0)) 'credit' FROM journal_details WHERE 
		[date] >=  @date_from AND [date] <= @date_to
		AND 
		account_number = @account_1 OR account_number = @account_2;



	END
		ELSE
	BEGIN
		
		-- STATMENT
		WITH tempDebitCredit AS (
			SELECT a.id, a.debit, a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details'
			FROM journal_details a where a.account_number = @account_1  		)
		SELECT a.id, a.date, a.account_number, b.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date >= @date_from AND a.date <= @date_to
			AND
			a.account_number = @account_1  

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, b.details;

		-- FIRST BALANACE
		WITH tempDebitCredit AS (
			SELECT a.id, a.debit, a.credit, a.date, a.account_number, a.journal_id, COALESCE(a.credit ,0) - COALESCE(a.debit,0) 'diff', CAST(a.[description] as varchar(1150) ) 'details'
			FROM journal_details a where a.account_number = @account_1    
		)
		SELECT a.id, a.date, a.account_number, b.details , a.debit, a.credit, SUM(b.diff) 'balance'
		FROM   tempDebitCredit a,
			   tempDebitCredit b
		WHERE 
			b.id <= a.id  
			and 
			a.date <= @date_from
			AND
			a.account_number = @account_1  

		GROUP BY a.id,a.debit, a.credit, a.date, a.account_number, b.details;

		-- LAST TOTALS
		SELECT SUM(COALESCE(debit ,0)) 'debit', SUM(COALESCE(credit ,0)) 'credit' FROM journal_details WHERE 
		[date] >=  @date_from AND [date] <= @date_to
		AND account_number = @account_1;

	END
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	----------------------------------------------------------------------------------
	using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace sales_management.UI
{
    public partial class Vat_Statment_Viewer : Form
    {
        DateTime date_from;
        DateTime date_to;
        PL.Installings installs = new PL.Installings();
        PL.DailyEntries Entries = new PL.DailyEntries();
        PL.AccountingTree Accounts = new PL.AccountingTree();
        DSet.Statments DSet = new DSet.Statments();
        DataSet dstables;
        DataTable Settings;
        ReportDocument cryRpt = new ReportDocument();
        public Vat_Statment_Viewer(DateTime date_from, DateTime date_to)
        {
            
            this.date_from = date_from;
            this.date_to = date_to;
            this.Settings = this.installs.Get_All_System_Settings();
            
            InitializeComponent();

            if (this.Settings.Rows.Count == 0) {
                return;
            }

            DataRow row = this.Settings.Rows[0];
            string sale_vat = row["sales_vat_account"].ToString();
            string purchase_vat = row["purchases_vat_account"].ToString();


            string account_1 = sale_vat;
            string account_2 = sale_vat == purchase_vat ? "-1": purchase_vat;

            this.dstables = Entries.Get_Report_Statment(account_1, date_from, date_to, account_2 );

            DataTable statments = this.dstables.Tables[0];
            DataTable first_balance = this.dstables.Tables[1];
            DataTable totals = this.dstables.Tables[2];


            // First Balance
            DataTable define_first_balance = new DataTable();
            define_first_balance.Columns.Add("balance_title");
            define_first_balance.Columns.Add("balance_value");
            define_first_balance.Columns.Add("date");
            DataRow define_first_balance_row = define_first_balance.NewRow();
            define_first_balance_row["balance_title"] = "رصيد أول المدة";
            
            if (first_balance.Rows.Count == 0)
            {
                define_first_balance_row["balance_value"] = "0.00";
                define_first_balance_row["date"] = date_from.ToString("yyyy-MM-dd");
            }
            else {
                define_first_balance_row["balance_value"] = first_balance.Rows[first_balance.Rows.Count - 1]["balance"];
                define_first_balance_row["date"] = Convert.ToDateTime(first_balance.Rows[first_balance.Rows.Count - 1]["date"]).ToString("yyyy-MM-dd");
            }
            define_first_balance.Rows.Add(define_first_balance_row);
             
            // Totals 
            DataTable define_totals = new DataTable();
            define_totals.Columns.Add("debit");
            define_totals.Columns.Add("credit");
            define_totals.Columns.Add("balance");
            DataRow define_totals_row = define_totals.NewRow();
            if (totals.Rows.Count == 0)
            {
                define_totals_row["debit"] = "0.00";
                define_totals_row["credit"] = "0.00";
                define_totals_row["balance"] = "0.00";
            }
            else {
                define_totals_row["debit"] = totals.Rows[0]["debit"];
                define_totals_row["credit"] = totals.Rows[0]["credit"];
                define_totals_row["balance"] = statments.Rows[statments.Rows.Count - 1]["balance"];
            }
            define_totals.Rows.Add(define_totals_row);

            // Add Account Details   
            DSet.Tables["Statement"].Merge(statments);
            DSet.Tables["First_Balance"].Merge(define_first_balance);
            DSet.Tables["Totals"].Merge(define_totals);
             
            // Fill Statement Data 
            string path = Application.StartupPath + "\\Reports\\Statement.rpt";
            this.cryRpt.Load(path);
            this.cryRpt.SetDataSource(this.DSet);
            this.cryRpt.Refresh();
            crystalReportViewer1.ReportSource = this.cryRpt;
        }

        public string Extract_Account_Name (string account_number) {
            string name = "";
            DataTable accs = Accounts.Get_Accounting_Tree();
            
            foreach (DataRow row in accs.Rows) {
                if (row["account_number"].Equals(account_number)) {
                    name = row["account_name"].ToString();
                }
            }

            return name;
        }


    }
}
