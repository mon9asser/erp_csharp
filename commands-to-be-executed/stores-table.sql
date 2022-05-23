/**
Document Types
=====================
0 => Sales Invoices
1 => Purchase Invoices 
2 => Return Sales Invoices 
3 => Return Purchase Invoices 
4 => Direct Entry 
 
------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن
*/
  
/****** Object:  StoredProcedure [dbo].[Report_Statement_Document]    Script Date: 5/23/2022 4:10:06 PM ******/
ALTER PROC [dbo].[Report_Statement_Document]

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)
	 
AS 
	
-- BUILDING OPENING BALANCE WITH AUTOMAIC ROW 
DECLARE @id AS INT 
SET @id = NULL;

DECLARE @jid AS INT 
SET @jid = NULL;

DECLARE @description AS VARCHAR(50) 
SET @description = 'رصيد أول المدة';

DECLARE @ccid AS VARCHAR(50) 
SET @ccid = NULL;

DECLARE @cdate AS DATETIME
SET @cdate = @date_from;

DECLARE @accnumber AS VARCHAR(50)
SET @accnumber = NULL;

DECLARE @credit AS DECIMAL(18,2)
SET @credit = NULL;

DECLARE @debit AS DECIMAL(18,2)
SET @debit = NULL;

DECLARE @paid_balance AS DECIMAL(18,2)
SET @paid_balance = (SELECT  SUM( COALESCE(debit ,0) + COALESCE(credit ,0) ) from journal_details inner join journals on journal_details.journal_id = journals.id where journals.show_balances_in_period = 1 AND account_number = @account_1);

DECLARE @balance AS DECIMAL(18,2) 
SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND account_number = @account_1 ); 

IF @account_2 != '-1'
	SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND ( account_number = @account_1 OR account_number = @account_2 ) );

IF @account_2 != '-1'
	SET @paid_balance = (SELECT  SUM( COALESCE(debit ,0) + COALESCE(credit ,0) ) from journal_details inner join journals on journal_details.journal_id = journals.id where journals.show_balances_in_period = 1 and (account_number = @account_1 OR account_number = @account_2));

IF @balance IS NULL 
	SET @balance= 0.00;


-- BUILDING MAIN QUERY ( COLLECT IT WITH THE OPENING BALANCE )
SELECT @id AS 'id', 
	   @jid AS 'journal_id',
	   @description AS 'description',
	   @ccid AS 'cost_center_number',
	   @cdate AS 'date',
	   @accnumber AS 'account_number',
	   @credit AS 'credit',
	   @debit AS 'debit',
	   @balance AS 'balance' 
	
	   UNION ALL   

	   SELECT 
			id,
			journal_id,
			[description],
			cost_center_number,
			[date], 
			[account_number],
			credit,
			debit,
			( SELECT @balance ) + SUM( COALESCE(credit ,0) - COALESCE(debit,0) )  OVER(ORDER BY id)  balance
			FROM journal_details WHERE [date] BETWEEN @date_from AND @date_to AND ( account_number = @account_1 OR account_number = @account_2  )

-- CLOSING BALANCE 

/*
SELECT 
	SUM( COALESCE(credit ,0)) AS 'credit', 
	SUM( COALESCE(debit ,0)) AS 'debit',
	( SUM( COALESCE(credit ,0)) - SUM( COALESCE(debit ,0) ) ) AS 'balance',
	'الإجمالي' As 'title'
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 ) 
	
	UNION ALL
	*/
SELECT 
	( SUM( COALESCE(credit ,0) ) - ( SELECT @paid_balance ))  AS 'credit', 
	( SUM( COALESCE(debit ,0) ) - ( SELECT @paid_balance ))  AS 'debit', 
	( SUM( COALESCE(credit ,0)) - SUM( COALESCE(debit ,0) ) ) AS 'balance',
	'إجمالي الأرصدة المستحقة' As 'title'
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 );