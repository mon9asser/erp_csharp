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

 




alter PROC Income_Statement_List

@date_from DATETIME,
@date_to DATETIME

AS  
--==========================================================
--			SALES NET TOTAL
--========================================================== 

DECLARE @net_total_sales AS DECIMAL; 

-- SALES DATA
DECLARE @total_sales AS DECIMAL
SET @total_sales = (SELECT SUM(COALESCE(CAST(total_price AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_sales ON document_details.doc_id = invoice_sales.id  
WHERE document_details.is_out=  1 AND document_details.doc_type = 0 and invoice_sales.[date] between @date_from and @date_to) ;
--SELECT @total_sales AS sales_value;

-- Commercial Discounts 
DECLARE @commercial_discount AS DECIMAL
SET @commercial_discount = (SELECT SUM(COALESCE(CAST(discount_name AS DECIMAL(18,2)), 0 )) FROM invoice_sales WHERE invoice_sales.[date] between @date_from and @date_to );
--SELECT @commercial_discount AS commercial_discount;
 
-- RETURN SALES DATA
DECLARE @return_sales AS DECIMAL
SET @return_sales = (SELECT SUM(COALESCE(CAST(total_price AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_return_sales ON document_details.doc_id = invoice_return_sales.id  
WHERE document_details.is_out=  0 AND document_details.doc_type = 2 and invoice_return_sales.[date] between @date_from and @date_to) ;
--SELECT @return_sales AS return_sales;


-- Commercial Discounts FOR RETURNS 
DECLARE @return_commercial_discount AS DECIMAL
SET @return_commercial_discount = (SELECT SUM(COALESCE(CAST(discount_name AS DECIMAL(18,2)), 0 )) FROM invoice_return_sales WHERE invoice_return_sales.[date] between @date_from and @date_to );
--SELECT @return_commercial_discount AS commercial_discount;

-- ALLOWED DISCOUNTS
DECLARE @sales_allowed_discounts AS DECIMAL
SET @sales_allowed_discounts = (select SUM(COALESCE(debit, 0)) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '5104' AND journals.updated_date between @date_from and @date_to);


SET @total_sales = ( ( SELECT @total_sales ) - ( SELECT @commercial_discount ) );
SET @return_sales = ( ( SELECT @return_sales ) - ( SELECT @return_commercial_discount ) );
DECLARE @total_net_sales AS DECIMAL ;
SET @total_net_sales = (SELECT @total_sales) - (SELECT @return_sales);

--==========================================================
--			COST OF SELL GODS
--========================================================== 

-- COST OF SOLD GODS
DECLARE @total_cost AS DECIMAL
SET @total_cost = (SELECT SUM(COALESCE(CAST(total_cost AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_sales ON document_details.doc_id = invoice_sales.id  
WHERE document_details.is_out=  1 AND document_details.doc_type = 0 and invoice_sales.[date] between @date_from and @date_to) ;
--SELECT @total_cost AS total_cost;


-- RETURN SALES COST 
DECLARE @return_sales_cost AS DECIMAL
SET @return_sales_cost = (SELECT SUM(COALESCE(CAST(total_cost AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_return_sales ON document_details.doc_id = invoice_return_sales.id  
WHERE document_details.is_out= 0 AND document_details.doc_type = 2 and invoice_return_sales.[date] between @date_from and @date_to) ;
--SELECT @return_sales_cost AS return_total_cost;


-- ALLOWED DISCOUNTS
DECLARE @cost_allowed_discounts AS DECIMAL
SET @cost_allowed_discounts = (select SUM(CAST(COALESCE(credit, 0) AS decimal(18,2))) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '4103' AND journals.updated_date between @date_from and @date_to);
--select @cost_allowed_discounts;

-- PURCHASE EXPENSES
DECLARE @purchase_expenses AS DECIMAL
SET @purchase_expenses = (select SUM(CAST(COALESCE(credit, 0) AS decimal(18,2)) - CAST(COALESCE(debit, 0) AS decimal(18,2))) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '5102' AND journals.updated_date between @date_from and @date_to);
--select @purchase_expenses;
IF @return_sales_cost IS NULL 
SET @return_sales_cost = 0;

IF @cost_allowed_discounts IS NULL 
SET @cost_allowed_discounts = 0;

IF @purchase_expenses IS NULL 
SET @purchase_expenses = 0;

SET @total_cost = ( SELECT @total_cost ) - ( SELECT @return_sales_cost );
SET @total_cost = ( SELECT @total_cost ) - ( SELECT @cost_allowed_discounts );
SET @total_cost = ( SELECT @total_cost ) + ( SELECT @purchase_expenses );



--==========================================================
--			OTHER REVENUES
--========================================================== 
DECLARE @other_revenuse AS DECIMAL;
SET @other_revenuse = (SELECT SUM(CAST(COALESCE(credit, 0) AS decimal(18,2)) - CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '420%'); 

IF @other_revenuse IS NULL 
SET @other_revenuse = 0;


--==========================================================
--			MARKETING AND PUBLISHING EXPENSES
--========================================================== 
DECLARE @market_publish AS DECIMAL;
SET @market_publish = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '520%'); 

IF @market_publish IS NULL 
SET @market_publish = 0;



--==========================================================
--			MANAGEMENT AND INGENERAL EXPENSES
--========================================================== 
DECLARE @management_ingeneral_exp AS DECIMAL;
SET @management_ingeneral_exp = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '530%'); 

IF @management_ingeneral_exp IS NULL 
SET @management_ingeneral_exp = 0;

 

 --==========================================================
--			CALCULATIONS 
--========================================================== 
DECLARE @net_profit AS DECIMAL
SET @net_profit = ( ( SELECT @total_net_sales ) - ( SELECT @total_cost ) );
 

declare @total_expenses as decimal
SET @total_expenses =  ( SELECT @market_publish ) + (SELECT @management_ingeneral_exp);
 
  --( SELECT @other_revenuse )
DECLARE @total_income AS DECIMAL;
SET @total_income = ( ( SELECT @net_profit ) + ( select @other_revenuse ) ) - (SELECT @total_expenses);


SELECT 
	CAST(@total_net_sales AS DECIMAL(18,2)) 'total_sales',
	CAST(@total_cost AS DECIMAL(18,2)) 'total_costs',
	CAST(@net_profit AS DECIMAL(18,2)) 'net_profit',
	-----------------------------
	CAST(@other_revenuse AS DECIMAL(18,2)) 'other_revenues',
	CAST(@market_publish AS DECIMAL(18,2)) 'sells_marketing_expenses',
	CAST(@management_ingeneral_exp AS DECIMAL(18,2)) 'management_expenses',

	CAST(@total_expenses AS DECIMAL(18,2)) 'total_expenses',
	--------------------------------
	CAST(@total_income AS DECIMAL(18,2)) 'total_income',
	@date_from 'date_from',
	@date_to 'date_to',
	'قائمة الدخل عن الفترة' 'title'