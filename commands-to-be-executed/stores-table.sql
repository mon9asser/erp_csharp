
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
ALTER PROC [dbo].[Report_Statement_Document]

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)
	 
AS 
	
-- BUILDING OPENING BALANCE WITH AUTOMAIC ROW 
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

DECLARE @balance AS DECIMAL(18,2)
SET @balance = ( SELECT sum(credit) - sum(debit) FROM journal_details where [date] < @date_from AND account_number = @account_1 ); 

IF @account_2 != '-1'
	SET @balance = ( SELECT sum(credit) - sum(debit) FROM journal_details where [date] < @date_from AND ( account_number = @account_1 OR account_number = @account_2 ) );

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
SELECT 
	SUM( COALESCE(credit ,0)) AS 'credit', 
	SUM( COALESCE(debit ,0)) AS 'debit',
	( ( SELECT @balance ) + SUM( COALESCE(credit ,0)) ) - SUM( COALESCE(debit ,0)) AS 'balance' 
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 ) AND [date] BETWEEN @date_from AND @date_to;


 
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

id int 
journal_id int 
description int 
cost_center_number VARCHAR(50) 
date datetime
account_number VARCHAR(50)
credit DECIMAL(18 , 2);
debit DECIMAL(18 , 2);


-- ID
declare @id as int
set @id = -1;

-- DATE
declare @date AS date
set @date = GETDATE();

-- CREDIT
declare @credit AS decimal(18, 2)
set @credit = 0.00

-- DEBIT
declare @debit AS decimal(18, 2)
set @debit = 0.00

-- DESCRIPTION
declare @description AS Varchar(50)
set @description = 'Opening Balance';

-- BALANCE
declare @opening_balance as decimal(18,2);
set @opening_balance = ( SELECT sum(credit) - sum(debit)  Openting FROM accounting where date < '2020-05-25' );
 
IF @opening_balance IS NULL 
set @opening_balance= 0.00;

SELECT @id as 'id', @date as 'date', @credit as 'credit' , @debit as 'debit', @description AS 'description', @opening_balance AS 'Balance' 
union all
SELECT id, date, credit, debit, description, ( select @opening_balance ) + SUM( COALESCE(credit ,0) - COALESCE(debit,0) )   over(order by id)  Balance FROM accounting
where date between '2020-05-25' and '2020-06-25'

----------------------------------------------------------------------------
					id,
				   journal_id,
				   [description],
				   cost_center_number,
				   [date], 
				   [account_number],
				   credit,
				   debit,
				   ( select @balance ) + SUM( COALESCE(credit ,0) - COALESCE(debit,0) )   over(order by id)  balance
				   
				   
				   
				   
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Report_Statement_Document]    Script Date: 5/16/2022 8:52:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
SET @cdate = ( SELECT DATEDIFF(DAY,  DATEADD(day, -1, CAST(@date_from AS DATETIME)), GETDATE()) );

DECLARE @accnumber AS INT
SET @accnumber = NULL;

DECLARE @credit AS DECIMAL(18,2)
SET @credit = NULL;

DECLARE @debit AS DECIMAL(18,2)
SET @debit = NULL;

DECLARE @balance AS DECIMAL(18,2)
SET @balance = ( SELECT sum(credit) - sum(debit) FROM journal_details where [date] < @date_from AND account_number = @account_1 ); 

IF @account_2 != '-1'
	BEGIN
		SET @balance = ( SELECT sum(credit) - sum(debit) FROM journal_details where [date] < @date_from AND account_number = @account_1 OR account_number = @account_2 ); 
	END

IF @balance IS NULL 
set @balance= 0.00;


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

....

-- BUILDING CLOSING BALANCE
