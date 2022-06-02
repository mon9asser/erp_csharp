/**
Document Types
=====================
0 => Sales Invoices
1 => Purchase Invoices 
2 => Return Sales Invoices 
3 => Return Purchase Invoices 
4 => Direct Entry 

SELECT name
FROM   sys.procedures
WHERE  Object_definition(object_id) LIKE '%purchase_credit_account%'+

------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن
*/

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Prepare_Balance_Sheet]    Script Date: 6/2/2022 4:33:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Prepare_Balance_Sheet]

AS
--==========================================================
--			INCOME STATEMENT 
--========================================================== 

-- total sales
DECLARE @net_total_sales AS DECIMAL(18,2);
SET @net_total_sales = (SELECT SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT sales_account FROM settings WHERE sales_account != '' ));

IF @net_total_sales IS NULL 
	SET @net_total_sales = 0;

-- total return sales
DECLARE @net_return_sales AS DECIMAL(18,2);
SET @net_return_sales = (SELECT SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT return_sales_account FROM settings WHERE return_sales_account != '' ));
	 
IF @net_return_sales IS NULL 
	SET @net_return_sales = 0;

-- allowed discount 
DECLARE @sales_allowed_discounts AS DECIMAL(18,2);
SET @sales_allowed_discounts = (select SUM(COALESCE(debit, 0)) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '5104' );

IF @sales_allowed_discounts IS NULL
	SET @sales_allowed_discounts = 0;

 
-- Net Sales Calculations 
DECLARE @net_sales AS DECIMAL(18,2);
SET @net_sales = ( SELECT @net_total_sales ) - ( ( SELECT @net_return_sales ) + ( SELECT @sales_allowed_discounts ) );

IF @net_sales IS NULL
SET @net_sales = 0;
 

 
-- cost of sold goods 
DECLARE @cost_of_good_sold AS DECIMAL(18,2);
SET @cost_of_good_sold = (SELECT   SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) - SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT cost_of_goods_account FROM settings WHERE cost_of_goods_account != '' ));
 
IF @cost_of_good_sold IS NULL
SET @cost_of_good_sold = 0; 

-- allowed discount 
DECLARE @cost_allowed_discounts AS DECIMAL(18,2);
SET @cost_allowed_discounts = (select SUM(CAST(COALESCE(credit, 0) AS decimal(18,2))) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '4103');

IF @cost_allowed_discounts IS NULL
SET @cost_allowed_discounts = 0;

-- Net Cost Of Goods Calculations 
DECLARE @net_cost_of_goods AS DECIMAL(18,2);
SET @net_cost_of_goods = ((SELECT @cost_of_good_sold) - (SELECT @cost_allowed_discounts));

IF @net_cost_of_goods IS NULL
SET @net_cost_of_goods = 0;
 
 
DECLARE @total_profits AS DECIMAL(18,2);
SET @total_profits = (( SELECT @net_sales ) - (SELECT @net_cost_of_goods));

IF @total_profits IS NULL 
SET @total_profits = 0;

DECLARE @other_revenuse AS DECIMAL(18,2);
SET @other_revenuse = (SELECT SUM( CAST(COALESCE(credit, 0) AS decimal(18,2)) - CAST(COALESCE(debit, 0) AS decimal(18,2)) ) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE account_number LIKE '420%'); 

IF @other_revenuse IS NULL 
SET @other_revenuse = 0;

 
DECLARE @market_publish AS DECIMAL(18,2);
SET @market_publish = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE account_number LIKE '520%'); 

IF @market_publish IS NULL 
SET @market_publish = 0; 
 
DECLARE @management_ingeneral_exp AS DECIMAL(18,2);
SET @management_ingeneral_exp = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE  account_number LIKE '530%'); 

IF @management_ingeneral_exp IS NULL 
SET @management_ingeneral_exp = 0;

DECLARE @other_expenses AS DECIMAL(18,2);
SET @other_expenses = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE  account_number LIKE '540%'); 

IF @other_expenses IS NULL 
SET @other_expenses = 0;
 
DECLARE @total_expenses AS DECIMAL(18,2);
SET @total_expenses =  ( SELECT @management_ingeneral_exp ) + (SELECT @market_publish) + (SELECT @other_expenses);

DECLARE @total_income AS DECIMAL(18,2);
SET @total_income = ( (  ( SELECT @total_profits ) + ( SELECT @other_revenuse )  ) - ( SELECT @total_expenses ) );



--==========================================================
--			BALANCE SHEET   
--========================================================== 

------------------------------------------------
-- ASSETS 
------------------------------------------------
----------------------
-- CURRENT ASSETS 
---------------------
IF EXISTS ( select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '11%' group by journal_details.account_number, cast(accounts.account_name as varchar(50)) )
BEGIN
	select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '11%' group by journal_details.account_number, cast(accounts.account_name as varchar(50))
END
	ELSE
BEGIN
	select '' 'account_number', '' 'account_name', 0 'total'  
END

select  'الأصول المتداولة' 'title', 'الإجمالى' 'total_title', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details where journal_details.account_number like '11%';

----------------------
-- FIXED ASSETS 
---------------------
IF EXISTS( select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '12%' group by journal_details.account_number, cast(accounts.account_name as varchar(50)) )
BEGIN
	select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '12%' group by journal_details.account_number, cast(accounts.account_name as varchar(50))
END
	ELSE
BEGIN
	select '' 'account_number', '' 'account_name', 0 'total' 
END
select  'الأصول الثابتة' 'title', 'الإجمالى' 'total_title', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details where journal_details.account_number like '12%';

------------------------------------------------
-- LIABILITIES AND EQUTY 
------------------------------------------------
----------------------
-- CURRENT EQUTY 
---------------------
IF EXISTS( select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '21%' group by journal_details.account_number, cast(accounts.account_name as varchar(50)) )
BEGIN
	select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '21%' group by journal_details.account_number, cast(accounts.account_name as varchar(50))
END
	ELSE
BEGIN
	select '' 'account_number', '' 'account_name', 0 'total'
END
select  'الخصوم المتداولة' 'title', 'الإجمالى' 'total_title', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details where journal_details.account_number like '21%';

----------------------
-- LONG EQUTY 
---------------------
IF EXISTS( select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '22%' group by journal_details.account_number, cast(accounts.account_name as varchar(50)) )
BEGIN
	select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '22%' group by journal_details.account_number, cast(accounts.account_name as varchar(50))
END
	ELSE
BEGIN
	select '' 'account_number', '' 'account_name', 0 'total'
END
select  'الخصوم طويلة الأجل' 'title', 'الإجمالى' 'total_title', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details where journal_details.account_number like '22%';


----------------------
-- OWNERS EQUTY 
---------------------
DECLARE @balance_year_profits AS DECIMAL(18,2);
SET @balance_year_profits = (SELECT sum(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number = '350' group by journal_details.account_number, cast(accounts.account_name as varchar(50)));

IF @balance_year_profits IS NULL
SET @balance_year_profits = 0;

select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '3%' AND journal_details.account_number != '350' group by journal_details.account_number, cast(accounts.account_name as varchar(50))

			UNION ALL

			SELECT '350' 'account_number', 'الأرباح المحتجزة' 'account_name', (( SELECT @total_income ) + ( SELECT @balance_year_profits ) ) 'total' ;
			

 
SELECT  'حقوق الملكية' 'title', 'الإجمالى' 'total_title', sum(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) 'total'  from journal_details where journal_details.account_number like '3%';



-----------------------------------
-- TOTAL ASSETS AND LIABILITIES
-----------------------------------
DECLARE @total_assets AS DECIMAL(18,2);
DECLARE @total_liabilities AS DECIMAL(18,2);

SET @total_assets = (
	
	( CASE WHEN ( ( SELECT  SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '11%' ) ) IS NULL THEN 0 ELSE ( SELECT  SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '11%' ) END )
	+
	( CASE WHEN ( ( SELECT SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '12%' ) ) IS NULL THEN 0 ELSE ( SELECT SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '12%' ) END )

);

SET @total_liabilities = (
	( CASE WHEN ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '21%') IS NULL THEN 0 ELSE ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '21%' ) END )
	+
	( CASE WHEN ( SELECT  SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '22%' ) IS NULL THEN 0 ELSE ( SELECT  SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '22%' ) END )
	+
	( CASE WHEN ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) from journal_details where journal_details.account_number like '3%' ) IS NULL THEN 0 ELSE ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) from journal_details where journal_details.account_number like '3%' ) END )
);

SELECT @total_assets 'total_assets', @total_liabilities 'total_liabilities';














































truncate table settings;
truncate table products;
truncate table product_untis;
truncate table accounts;

 
TRUNCATE TABLE document_details;
truncate table withdraw_document; 
truncate table stores;  
truncate table resources; 
truncate table journals;
truncate table journal_details;
truncate table invoice_sales;
truncate table invoice_return_sales;
truncate table invoice_return_purchases;
truncate table invoice_purchases;
truncate table inventory; 
truncate table employees; 
truncate table cost_centers;
truncate table categories;




 





