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
truncate table withdraw_document;
truncate table withdraw_document;
truncate table withdraw_document;
truncate table withdraw_document;
truncate table stores;
truncate table settings;
truncate table ReturnPayment;
truncate table ReturnInvoice;
truncate table resources;
truncate table products;
truncate table product_untis;
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
truncate table accounts;
truncate table __purchase_invoice;
truncate table ____purchase_invoice;
truncate table ____invoice_sales; 






----===============================
--- Add To Settings Table these fields first 

asset_account
debits_account
profits_account
owners_account
expenses_account

----===============================

 

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


@sale_cash_account varchar(50),
@sale_credit_account varchar(50),
@sale_bank_account varchar(50),
@sales_account varchar(50),
@sales_vat_account varchar(50), 
@purchase_cash_account varchar(50),
@purchase_credit_account varchar(50),
@purchase_bank_account varchar(50),
@purchases_account varchar(50),
@purchases_vat_account varchar(50), 
@cost_of_goods_account varchar(50),
@inventory_account varchar(50),
@customers_account varchar(50),
@suppliers_account varchar(50),

@return_sales_account varchar(50),
@return_purchase_account varchar(50),
 
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
			sale_cash_account,
			sale_credit_account,
			sale_bank_account,
			sales_account,
			sales_vat_account, 
			purchase_cash_account,
			purchase_credit_account,
			purchase_bank_account,
			purchases_account,
			purchases_vat_account, 
			cost_of_goods_account,
			inventory_account,
			customers_account,
			suppliers_account,
			
			return_sales_account,
			return_purchase_account,

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

			@sale_cash_account,
			@sale_credit_account,
			@sale_bank_account,
			@sales_account,
			@sales_vat_account, 
			@purchase_cash_account,
			@purchase_credit_account,
			@purchase_bank_account,
			@purchases_account,
			@purchases_vat_account, 
			@cost_of_goods_account,
			@inventory_account,
			@customers_account,
			@suppliers_account,

			@return_sales_account,
			@return_purchase_account,

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

			sale_cash_account = @sale_cash_account,
			sale_credit_account = @sale_credit_account,
			sale_bank_account = @sale_bank_account,
			sales_account = @sales_account,
			sales_vat_account = @sales_vat_account, 
			purchase_cash_account = @purchase_cash_account,
			purchase_credit_account = @purchase_credit_account,
			purchase_bank_account = @purchase_bank_account,
			purchases_account = @purchases_account,
			purchases_vat_account = @purchases_vat_account, 
			cost_of_goods_account = @cost_of_goods_account,
			inventory_account = @inventory_account,
			customers_account = @customers_account,
			suppliers_account = @suppliers_account,

			return_sales_account=@return_sales_account,
			return_purchase_account=@return_purchase_account,

			asset_account=@asset_account,
			debits_account=@debits_account,
			profits_account=@profits_account,
			owners_account=@owners_account,
			expenses_account=@expenses_account
		WHERE id = @id
		 
	END



