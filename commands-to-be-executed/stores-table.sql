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







-- SALES DATA
DECLARE @total_sales AS DECIMAL
SET @total_sales = (SELECT SUM(COALESCE(CAST(total_price AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_sales ON document_details.doc_id = invoice_sales.id  
WHERE is_out=  1 AND doc_type = 0);
--SELECT @total_sales AS sales_value;
 
-- SALES COSTS 
DECLARE @total_costs AS DECIMAL
SET @total_costs = (SELECT SUM(COALESCE(CAST(total_cost AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_sales ON document_details.doc_id = invoice_sales.id  
WHERE is_out=  1 AND doc_type = 0);
--SELECT @total_costs AS total_cost;

-- RETURN SALES DATA
DECLARE @return_sales AS DECIMAL
SET @return_sales = (SELECT SUM(COALESCE(CAST(total_price AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_return_sales ON document_details.doc_id = invoice_return_sales.id  
WHERE is_out= 0 AND doc_type = 2);
--SELECT @return_sales AS return_sales;

-- RETURN SALES COSTS
DECLARE @return_sales_cost AS DECIMAL
SET @return_sales_cost = (SELECT SUM(COALESCE(CAST(total_cost AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_return_sales ON document_details.doc_id = invoice_return_sales.id  
WHERE is_out= 0 AND doc_type = 2); 

-- Calculations 
DECLARE @net_sale_data AS DECIMAL
SET @net_sale_data = (SELECT @total_sales) - (SELECT @total_costs);


DECLARE @net_return AS DECIMAL
SET @net_return = (SELECT @return_sales) - (SELECT @return_sales_cost);
 
DECLARE @net_sales AS DECIMAL 
SET @net_sales = ( SELECT @net_sale_data ) - ( SELECT @net_return);
SELECT @net_sales;


-- MINIUS ALLOWED DISCOUNTS 



























==========================================================
			SALES NET TOTAL
==========================================================

-- SALES DATA
DECLARE @total_sales AS DECIMAL
SET @total_sales = (SELECT SUM(COALESCE(CAST(total_price AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_sales ON document_details.doc_id = invoice_sales.id  
WHERE is_out=  1 AND doc_type = 0);
--SELECT @total_sales AS sales_value;

-- RETURN SALES DATA
DECLARE @return_sales AS DECIMAL
SET @return_sales = (SELECT SUM(COALESCE(CAST(total_price AS DECIMAL(18,2)), 0 )) FROM document_details 
	INNER JOIN invoice_return_sales ON document_details.doc_id = invoice_return_sales.id  
WHERE is_out= 0 AND doc_type = 2);
--SELECT @return_sales AS return_sales;

-- ALLOWED DISCOUNTS
DECLARE @sales_allowed_discounts AS DECIMAL
SET @sales_allowed_discounts = (select SUM(COALESCE(debit, 0)) from journal_details where account_number = '5104');
--SELECT @sales_allowed_discounts AS allowed_discounts;


DECLARE @total_net_sales AS DECIMAL;
SET @total_net_sales = ( SELECT @total_sales ) - ( ( SELECT @return_sales ) + ( SELECT @sales_allowed_discounts ) );

-- SALES NET TOTAL 
SELECT @total_net_sales AS total_net_sales;


==========================================================
			COST NET TOTAL
==========================================================