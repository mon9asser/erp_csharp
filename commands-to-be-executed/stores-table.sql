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



  
-- Current Assets 
SELECT journal_details.account_number, CAST(accounts.account_name AS VARCHAR(50)) 'name', SUM(debit) 'debit', SUM(credit) 'credit' FROM accounts 
	INNER JOIN journal_details ON accounts.account_number = journal_details.account_number
WHERE journal_details.account_number LIKE '5%' 
GROUP BY journal_details.account_number, CAST(accounts.account_name AS VARCHAR(50));