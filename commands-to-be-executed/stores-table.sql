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






 
CREATE TYPE [dbo].Trial_Balance AS TABLE(
	account_number varchar(50),
	account_name varchar(50),
	opening_debit DECIMAL(18,2),
	opening_credit DECIMAL(18,2),
	transaction_debit DECIMAL(18,2),
	transaction_credit DECIMAL(18,2),
	ending_debit DECIMAL(18,2),
	ending_credit  DECIMAL(18,2)
)
GO


------------------------------------------------

CREATE  PROC Get_Trial_Balance

@date_from varchar(50),
@date_to varchar(50)
  

  

AS
declare @trial_blce AS [dbo].Trial_Balance;


-- OPENING BALANCE 
insert @trial_blce
select 
	accounts.account_number 'account_number' , 
	accounts.account_name 'account_name',
	0 'opening_debit',
	0 'opening_credit', 
	COALESCE(x.debit,0) 'transaction_debit',  
	COALESCE(x.credit,0)  'transaction_credit',
	
	-- CALCULATE ENDING BALANCE   
	(CASE WHEN (( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0)) > 0) 
		THEN ( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0))
		ELSE 0 END) 'ending_debit', 
	(CASE WHEN (( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0)) < 0) 
		THEN ABS( ( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0)) )
		ELSE 0 END) 'ending_credit'   
	from accounts
 

FULL OUTER JOIN (
	SELECT 
	journal_details.account_number,  
	CAST(accounts.account_name AS VARCHAR(50)) 'name', 
	SUM(COALESCE(debit, 0)) 'debit', 
	SUM(COALESCE(credit, 0 )) 'credit' FROM accounts  
	INNER JOIN journal_details ON journal_details.account_number =  accounts.account_number
	INNER JOIN journals ON journal_details.journal_id =  journals.id 
	WHERE journal_details.account_number LIKE '%' AND
	journals.updated_date BETWEEN @date_from AND @date_to 
	GROUP BY 
		journal_details.account_number, 
		CAST(accounts.account_name AS VARCHAR(50))  
) x ON x.account_number = accounts.account_number WHERE 
	accounts.account_number NOT IN (100,200,300,400,500,110,120) 
	ORDER BY accounts.account_number;

	select 
			*
		from @trial_blce where (ending_debit !=0 and ending_credit =0) OR ( ending_credit!=0 and ending_debit =0);

	select 
			@date_from 'date_from',
			@date_to 'date_to',
			'ميزان المراجعه عن الفترة' 'titel',
			sum(transaction_debit) 'tran_debit', 
			sum(transaction_credit) 'tran_credit',
			sum(ending_debit) 'end_debit',
			ABS(sum(ending_credit )) 'end_credit'
		from @trial_blce where (ending_debit !=0 and ending_credit =0) OR ( ending_credit!=0 and ending_debit =0);









