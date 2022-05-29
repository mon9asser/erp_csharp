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

 

------------------------------------------------

CREATE PROC Get_Current_Cash_Bank_Balance

AS

DECLARE @balance AS DECIMAL(18,2);
SET @balance = (SELECT (SUM(debit) - SUM(credit)) 'balance'  FROM journal_details WHERE account_number LIKE '1101%' OR account_number LIKE '1102%'); 

IF @balance IS NULL 
SET @balance = 0;

 
SELECT @balance 'balance';


------------------------------------------------

CREATE PROC Get_Inventory_Counts 

As 
-- Purchases ( In )
SELECT product_id 'product_id', SUM(CAST(total_quantity AS DECIMAL(18,2))) 'total_quantity' FROM document_details where is_out = 0 GROUP BY product_id ;


-- Sales ( OUT )
SELECT product_id 'product_id', SUM(CAST(total_quantity AS DECIMAL(18,2))) 'total_quantity' FROM document_details where is_out = 1 GROUP BY product_id ;





























  		
			
cash_account
bank_account
sales_account
sales_vat_account
purchases_vat_account
cost_of_goods_account
inventory_account
customers_account
suppliers_account
return_sales_account
asset_account
debits_account
profits_account
owners_account
expenses_account

@cash_account
@bank_account
@sales_account
@sales_vat_account
@purchases_vat_account
@cost_of_goods_account
@inventory_account
@customers_account
@suppliers_account
@return_sales_account
@asset_account
@debits_account
@profits_account
@owners_account
@expenses_account


@cash_account varchar(50),
@bank_account varchar(50),
@sales_account varchar(50),
@sales_vat_account varchar(50),
@purchases_vat_account varchar(50),
@cost_of_goods_account varchar(50),
@inventory_account varchar(50),
@customers_account varchar(50),
@suppliers_account varchar(50),
@return_sales_account varchar(50),
@asset_account varchar(50),
@debits_account varchar(50),
@profits_account varchar(50),
@owners_account varchar(50),
@expenses_account varchar(50),


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
