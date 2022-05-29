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
/****** Object:  StoredProcedure [dbo].[Update_System_Settings]    Script Date: 5/29/2022 1:07:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROC [dbo].[Update_System_Settings] 

@id int,
@establishment_name varchar(50),
@vat_number varchar(50),
@address varchar(50),
@vat_percentage int,
@vat_percentage_value varchar(50),
@product_barcode_type  int,
@enable_delete_invoices bit,
@enable_edit_invoices bit,
@show_address_in_invoice bit,
@created_by_id int, 
@update_by_id int,
@mod_date datetime,
@date_made datetime,
@is_enabled_vat bit,


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
@expenses_account varchar(50)

AS

IF NOT EXISTS ( SELECT * FROM [dbo].settings WHERE id = @id)

	BEGIN
		INSERT INTO [dbo].[settings](

			establishment_name,
			address,
			vat_number,
			vat_percentage,
			vat_value,
			product_barcode_type,
			enable_delete_invoices,
			enable_edit_invoices,
			show_address_in_invoice, 
			created_by_id,
			update_by_id,
			mod_date,
			date_made,
			enabled_vat,


			cash_account,
			bank_account,
			sales_account,
			sales_vat_account,
			purchases_vat_account,
			cost_of_goods_account,
			inventory_account,
			customers_account,
			suppliers_account,
			return_sales_account,
			asset_account,
			debits_account,
			profits_account,
			owners_account,
			expenses_account
		) VALUES(

			@establishment_name,
			@address,
			@vat_number,
			@vat_percentage,
			@vat_percentage_value,
			@product_barcode_type,
			@enable_delete_invoices,
			@enable_edit_invoices,
			@show_address_in_invoice, 
			@created_by_id, 
			@update_by_id,
			@mod_date,
			@date_made,
			@is_enabled_vat,

			@cash_account,
			@bank_account,
			@sales_account,
			@sales_vat_account,
			@purchases_vat_account,
			@cost_of_goods_account,
			@inventory_account,
			@customers_account,
			@suppliers_account,
			@return_sales_account,
			@asset_account,
			@debits_account,
			@profits_account,
			@owners_account,
			@expenses_account
		)
	END

ELSE 
	
	BEGIN
		
		UPDATE [dbo].settings SET
			
			establishment_name = @establishment_name ,
			address = @address,
			vat_number = @vat_number,
			vat_value = @vat_percentage_value,
			vat_percentage = @vat_percentage ,
			product_barcode_type= @product_barcode_type,
			enable_delete_invoices = @enable_delete_invoices,
			enable_edit_invoices = @enable_edit_invoices,
			show_address_in_invoice = @show_address_in_invoice,
			update_by_id=@update_by_id,
			mod_date=@mod_date,
			enabled_vat=@is_enabled_vat,

			cash_account=@cash_account,
			bank_account=@bank_account,
			sales_account=@sales_account,
			sales_vat_account=@sales_vat_account,
			purchases_vat_account=@purchases_vat_account,
			cost_of_goods_account=@cost_of_goods_account,
			inventory_account=@inventory_account,
			customers_account=@customers_account,
			suppliers_account=@suppliers_account,
			return_sales_account=@return_sales_account,
			asset_account=@asset_account,
			debits_account=@debits_account,
			profits_account=@profits_account,
			owners_account=@owners_account,
			expenses_account=@expenses_account
		WHERE id = @id
		 
	END





























 

============================================

sale_cash_account		| => cash_account_number
purchase_cash_account	| 

sale_bank_account		| => bank_account_number
purchase_bank_account	|


| => X DELETE 
purchases_account 		 
return_purchase_account  
sale_credit_account		 
purchase_credit_account	 


----------------------------- FIELDS 

sale_cash_account_field			| => cash_account_number_field
sale_cash_account_field_name	| => cash_account_number_field_name

sale_bank_account_field			| => bank_account_number_field
sale_bank_account_field_name	| => bank_account_number_field_name

sale_credit_account_field
sale_credit_account_field_name
purchases_account_field_name
purchases_account_field
purchase_cash_account_field_name
purchase_cash_account_field
purchase_credit_account_field_name
purchase_credit_account_field
purchase_bank_account_field_name
purchase_bank_account_field
return_purchase_account_name
return_purchase_account_field
============================================

string cash_account
string customers_account,
string bank_account 

string sales_account,
string sales_vat_account, 
string purchases_vat_account,
string cost_of_goods_account,
string inventory_account,

string suppliers_account, 
string return_sales_account, 
 


string asset_account_field,
string debits_account_field,
string profits_account_field,
string owners_account_field,
string expenses_account_field
		

return_purchase_account
purchases_account
purchase_bank_account
purchase_credit_account
purchase_cash_account  
sale_bank_account
sale_credit_account
sale_cash_account

		
 sysSettings.Update_Settings_System(

                settingsID, 
                name, 
                address, 
                vat_number, 
                vat_percentage, 
                vat_value, 
                0, 
                delete_enable, 
                edit_enable, 
                address_enable, 
                userId, 
                userId, 
                DateTime.Now, 
                DateTime.Now, 
                isEnabledVat, 

                cash_account_number_field.Text,
                //sale_credit_account_field.Text,
                sale_bank_account_field.Text,
                sales_account_field.Text,
                sales_vat_account_field.Text,
               // purchase_cash_account_field.Text,
               // purchase_credit_account_field.Text,
               // purchase_bank_account_field.Text,
               // purchases_account_field.Text,
                purchases_vat_account_field.Text,
                cost_of_goods_account_field.Text,
                inventory_account_field.Text,
                customers_account_field.Text,
                suppliers_account_field.Text, 

                return_sales_account_field.Text,
                //return_purchase_account_field.Text,


                asset_account_field.Text,
                debits_account_field.Text,
                profits_account_field.Text,
                owners_account_field.Text,
                expenses_account_field.Text
            );
			
			
			
			
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
