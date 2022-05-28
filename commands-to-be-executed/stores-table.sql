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

truncate table settings;
truncate table products;
truncate table product_untis;
truncate table accounts;

TRUNCATE TABLE document_details;
truncate table withdraw_document; 
truncate table stores;
truncate table ReturnPayment;
truncate table ReturnInvoice;
truncate table resources;
truncate table Payment;
truncate table journals;
truncate table journal_details;
truncate table invoice_sales;
truncate table invoice_return_sales;
truncate table invoice_return_purchases;
truncate table invoice_purchases;
truncate table inventory;
truncate table Invoice;
truncate table employees;
truncate table Customer;
truncate table cost_centers;
truncate table categories;

truncate table __purchase_invoice;
truncate table ____purchase_invoice;
truncate table ____invoice_sales; 

 



------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_Sale_Invoice_Data_Set]    Script Date: 5/28/2022 4:08:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Get_Sale_Invoice_Data_Set]


@doc_type INT

AS

SELECT * FROM [dbo].invoice_sales INNER JOIN [dbo].journals ON [dbo].invoice_sales.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 0;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;
---------------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_Return_Sales_Invoice_Data_Set]    Script Date: 5/28/2022 4:10:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Get_Return_Sales_Invoice_Data_Set]


@doc_type INT

AS

SELECT * FROM [dbo].invoice_return_sales INNER JOIN [dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 2;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;
-----------------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_Return_Purchase_Invoice_Data_Set]    Script Date: 5/28/2022 4:11:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[Get_Return_Purchase_Invoice_Data_Set]

@doc_type INT

AS

SELECT * FROM [dbo].invoice_return_purchases INNER JOIN [dbo].journals ON [dbo].invoice_return_purchases.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 3;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;

----------------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Report_Statement_Document]    Script Date: 5/28/2022 4:24:45 PM ******/
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

IF @paid_balance IS NULL 
	SET @paid_balance = 0;
	
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


----------------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_Purchase_Invoice_Data_Set]    Script Date: 5/28/2022 4:12:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[Get_Purchase_Invoice_Data_Set]

@doc_type INT

AS

SELECT * FROM [dbo].invoice_purchases INNER JOIN [dbo].journals ON [dbo].invoice_purchases.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 1;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;



------------------------------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Create_Purchase_Invoice_Id]    Script Date: 5/28/2022 7:18:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROC [dbo].[Create_Purchase_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_purchases) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_purchases ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_purchases(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'شراء بضاعه نقدا' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مشتريات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		1 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_purchases  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_purchases.id = [dbo].journals.doc_id AND [dbo].journals.doc_type = 1
			ORDER BY  [dbo].invoice_purchases.id DESC;
			
			
			
--------------------------------------------------------------------------

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Create_Return_Purchase_Invoice_Id]    Script Date: 5/28/2022 7:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
ALTER PROC [dbo].[Create_Return_Purchase_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_purchases) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_purchases ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_purchases(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'مردود مشتريات' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردود مشتريات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		3 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_purchases  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_purchases.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 3
			ORDER BY  [dbo].invoice_return_purchases.id DESC;




--------------------------------------------------------------------------

ALTER PROC [dbo].[Create_Return_Sales_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_sales(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'مردود فاتورة مبيعات' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردود مببعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		2 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id AND [dbo].journals.doc_type = 2
			ORDER BY  [dbo].invoice_return_sales.id DESC;
			

--------------------------------------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Create_Sale_Invoice_Id]    Script Date: 5/28/2022 7:25:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
ALTER PROC [dbo].[Create_Sale_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_sales(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'بيع بضاعه نقدا' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مبيعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		0 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_sales.id = [dbo].journals.doc_id AND [dbo].journals.doc_type = 0
			ORDER BY  [dbo].invoice_sales.id DESC;











============================================
DECLARE @assets_number AS VARCHAR(50);
SET @assets_number = ( select asset_account from settings WHERE asset_account != '');

DECLARE @equity_number AS VARCHAR(50);
SET @equity_number = ( select debits_account from settings WHERE debits_account != '');

DECLARE @revenues_number AS VARCHAR(50);
SET @revenues_number = ( select profits_account from settings WHERE profits_account != '');

DECLARE @owners_number AS VARCHAR(50);
SET @owners_number = ( select owners_account from settings WHERE owners_account != '');

DECLARE @expenses_number AS VARCHAR(50);
SET @expenses_number = ( select expenses_account from settings WHERE expenses_account != '');
 

SELECT SUM(credit), SUM(debit) FROM journal_details WHERE account_number LIKE '1%'; 
SELECT SUM(credit), SUM(debit) FROM journal_details WHERE account_number LIKE '2%'; 
SELECT SUM(credit), SUM(debit) FROM journal_details WHERE account_number LIKE '3%'; 
SELECT SUM(credit), SUM(debit) FROM journal_details WHERE account_number LIKE '4%'; 
SELECT SUM(credit), SUM(debit) FROM journal_details WHERE account_number LIKE '5%'; 


SELECT (SUM(debit) - SUM(credit)) 'balance'  FROM journal_details WHERE account_number LIKE '1101%' OR account_number LIKE '1102%'; 