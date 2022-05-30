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

