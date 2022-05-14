
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