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






USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_Current_Cash_Bank_Balance]    Script Date: 5/30/2022 1:22:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Get_Current_Cash_Bank_Balance]

AS


select accounts.account_number, 0 'type', (SUM(debit) - SUM(credit)) 'balance' from accounts, journal_details 
where accounts.account_number = journal_details.account_number and accounts.account_number LIKE '11010%'
group by accounts.account_number

UNION ALL

SELECT '1101' 'account_number', 0 'type', (SUM(debit) - SUM(credit)) 'balance' FROM journal_details WHERE account_number LIKE '1101%' 

UNION ALL

select accounts.account_number, 1 'type', (SUM(debit) - SUM(credit)) 'balance' from accounts, journal_details 
where accounts.account_number = journal_details.account_number and accounts.account_number LIKE '11020%'
group by accounts.account_number
	
UNION ALL

SELECT '1102' 'account_number', 1 'type', (SUM(debit) - SUM(credit)) 'balance' FROM journal_details WHERE account_number LIKE '1102%';






------------------------------------------------------------------------------------------






declare @date_from  as DATETIME;
set @date_from = '2014-10-10 00:00:00.000';

declare @date_to as DATETIME;
set @date_to = '2025-10-10 00:00:00.000';
 

--==========================================================
--			SALES NET TOTAL
--========================================================== 

-- total sales
DECLARE @net_total_sales AS DECIMAL(18,2);
SET @net_total_sales = (SELECT SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT sales_account FROM settings WHERE sales_account != '' ) AND journals.updated_date BETWEEN @date_from AND @date_to);

IF @net_total_sales IS NULL 
	SET @net_total_sales = 0;

-- total return sales
DECLARE @net_return_sales AS DECIMAL(18,2);
SET @net_return_sales = (SELECT SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT return_sales_account FROM settings WHERE return_sales_account != '' ) AND journals.updated_date BETWEEN @date_from AND @date_to);

IF @net_return_sales IS NULL 
	SET @net_return_sales = 0;

-- allowed discount 
DECLARE @sales_allowed_discounts AS DECIMAL(18,2);
SET @sales_allowed_discounts = (select SUM(COALESCE(debit, 0)) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '5104' AND journals.updated_date between @date_from and @date_to);

IF @sales_allowed_discounts IS NULL
	SET @sales_allowed_discounts = 0;


-- Net Sales Calculations 
DECLARE @net_sales AS DECIMAL(18,2);
SET @net_sales = ( SELECT @net_total_sales ) - ( ( SELECT @net_return_sales ) + ( SELECT @sales_allowed_discounts ) );

IF @net_sales IS NULL
SET @net_sales = 0;

--==========================================================
--			COST OF GOOD SOLD 
--========================================================== 

-- cost of sold goods 
DECLARE @cost_of_good_sold AS DECIMAL(18,2);
SET @cost_of_good_sold = (SELECT   SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) - SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT cost_of_goods_account FROM settings WHERE cost_of_goods_account != '' ) AND journals.updated_date BETWEEN @date_from AND @date_to);

IF @cost_of_good_sold IS NULL
SET @cost_of_good_sold = 0;

-- allowed discount 
DECLARE @cost_allowed_discounts AS DECIMAL(18,2);
SET @cost_allowed_discounts = (select SUM(CAST(COALESCE(credit, 0) AS decimal(18,2))) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '4103' AND journals.updated_date between @date_from and @date_to);

IF @cost_allowed_discounts IS NULL
SET @cost_allowed_discounts = 0;
 
-- Net Cost Of Goods Calculations 
DECLARE @net_cost_of_goods AS DECIMAL(18,2);
SET @net_cost_of_goods = ((SELECT @cost_of_good_sold) - (SELECT @cost_allowed_discounts));

IF @net_cost_of_goods IS NULL
SET @net_cost_of_goods = 0;

SELECT @cost_of_good_sold;
--==========================================================
--			Total Profit
--========================================================== 

DECLARE @total_profits AS DECIMAL(18,2);
SET @total_profits = (( SELECT @net_sales ) - (SELECT @net_cost_of_goods));

IF @total_profits IS NULL 
SET @total_profits = 0;

--==========================================================
--			Other Revenues 
--========================================================== 
DECLARE @other_revenuse AS DECIMAL(18,2);
SET @other_revenuse = (SELECT SUM( CAST(COALESCE(debit, 0) AS decimal(18,2)) - CAST(COALESCE(credit, 0) AS decimal(18,2)) ) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '420%'); 

IF @other_revenuse IS NULL 
SET @other_revenuse = 0;


--==========================================================
--			Sell Expenses and distributions  
--========================================================== 
DECLARE @market_publish AS DECIMAL(18,2);
SET @market_publish = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '520%'); 

IF @market_publish IS NULL 
SET @market_publish = 0; 

--==========================================================
--			Management And General Expenses  
--========================================================== 
DECLARE @management_ingeneral_exp AS DECIMAL(18,2);
SET @management_ingeneral_exp = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '530%'); 

IF @management_ingeneral_exp IS NULL 
SET @management_ingeneral_exp = 0;

--==========================================================
--			Other Expenses  
--========================================================== 
DECLARE @other_expenses AS DECIMAL(18,2);
SET @other_expenses = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '540%'); 

IF @other_expenses IS NULL 
SET @other_expenses = 0;



--==========================================================
--			Calculations   
--==========================================================
DECLARE @total_expenses AS DECIMAL(18,2);
SET @total_expenses = ( SELECT @other_expenses ) + ( SELECT @management_ingeneral_exp ) + (SELECT @market_publish) + (SELECT @other_expenses);

DECLARE @total_income AS DECIMAL(18,2);
SET @total_income = ( (  ( SELECT @total_profits ) + ( SELECT @other_revenuse )  ) - ( SELECT @total_expenses ) );



SELECT 
	CAST(@net_sales AS DECIMAL(18,2)) 'total_sales',
	CAST(@net_cost_of_goods AS DECIMAL(18,2)) 'total_costs',
	CAST(@total_profits AS DECIMAL(18,2)) 'net_profit',
	-----------------------------
	CAST(@other_revenuse AS DECIMAL(18,2)) 'other_revenues',
	
	CAST(@market_publish AS DECIMAL(18,2)) 'sells_marketing_expenses',
	CAST(@management_ingeneral_exp AS DECIMAL(18,2)) 'management_expenses',
	CAST(@other_expenses AS DECIMAL(18,2)) 'other_expenses',
	CAST(@total_expenses AS DECIMAL(18,2)) 'total_expenses',
	--------------------------------
	CAST(@total_income AS DECIMAL(18,2)) 'total_income',
	@date_from 'date_from',
	@date_to 'date_to',
	'قائمة الدخل عن الفترة' 'title'


























----------------------------

select (SUM(debit) - SUM(credit)), COUNT(*) from journal_details where account_number LIKE '11020%';



select accounts.account_number, 0 'type', (SUM(debit) - SUM(credit)) 'balance' from accounts, journal_details 
where accounts.account_number = journal_details.account_number and accounts.account_number LIKE '11010%'
group by accounts.account_number

UNION ALL

SELECT '1101' 'account_number', 0 'type', (SUM(debit) - SUM(credit)) 'balance' FROM journal_details WHERE account_number LIKE '1101%' 

UNION ALL

select accounts.account_number, 1 'type', (SUM(debit) - SUM(credit)) 'balance' from accounts, journal_details 
where accounts.account_number = journal_details.account_number and accounts.account_number LIKE '11020%'
group by accounts.account_number
	
UNION ALL

SELECT '1102' 'account_number', 1 'type', (SUM(debit) - SUM(credit)) 'balance' FROM journal_details WHERE account_number LIKE '1102%';

