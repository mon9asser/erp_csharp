return_sales_account
return_purchase_account
---------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_System_Settings]    Script Date: 5/7/2022 11:30:30 AM ******/
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
@return_purchase_account varchar(50)

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
			return_purchase_account
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
			@return_purchase_account
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
			return_purchase_account=@return_purchase_account
		WHERE id = @id
		 
	END

return_sales_account_field.Text,
return_purchase_account_field.Text
---------------------
CREATE TABLE [dbo].[invoice_return_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_method] [int] NULL,
	[date] [datetime] NULL,
	[details] [text] NULL,
	[payment_condition_id] [int] NULL,
	[customer_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[account_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[cost_center_id] [int] NULL,
	[cost_center_number] [varchar](50) NULL,
	[cost_center_name] [varchar](50) NULL,
	[price_include_vat] [bit] NULL,
	[net_total] [varchar](50) NULL,
	[discount_name] [varchar](50) NULL,
	[discount_percentage] [varchar](50) NULL,
	[discount_not_more] [varchar](50) NULL,
	[total_without_vat] [varchar](50) NULL,
	[total_with_vat] [varchar](50) NULL,
	[vat_amount] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[serial] [varchar](50) NULL,
	[enabled_zakat_vat] [bit] NULL,
	[qrcode] [image] NULL,
 CONSTRAINT [PK_invoice_return_sales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



-----------------------------------------

CREATE TABLE [dbo].[invoice_return_purchases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_method] [int] NULL,
	[date] [datetime] NULL,
	[details] [text] NULL,
	[payment_condition_id] [int] NULL,
	[customer_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[account_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[cost_center_id] [int] NULL,
	[cost_center_number] [varchar](50) NULL,
	[cost_center_name] [varchar](50) NULL,
	[price_include_vat] [bit] NULL,
	[net_total] [varchar](50) NULL,
	[discount_name] [varchar](50) NULL,
	[discount_percentage] [varchar](50) NULL,
	[discount_not_more] [varchar](50) NULL,
	[total_without_vat] [varchar](50) NULL,
	[total_with_vat] [varchar](50) NULL,
	[vat_amount] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[serial] [varchar](50) NULL,
	[enabled_zakat_vat] [bit] NULL,
	[qrcode] [image] NULL,
 CONSTRAINT [PK_invoice_return_purchases] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


------------------------------------------------------------
create PROC [dbo].[Get_Return_Sales_Invoice_Data_Set]


@doc_type INT

AS

SELECT * FROM [dbo].invoice_return_sales INNER JOIN [dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;
--------------------------------------------------------------
create PROC [dbo].[Create_Return_Sales_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_sales(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'بيع بضاعه نقدا' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردودات مببعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		'2' );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id
			ORDER BY  [dbo].invoice_return_sales.id DESC;
			
			
-------------------------------------------------------------------
create proc [dbo].[Get_All_Return_Sales_Invoices]
	 as
	 select * from [dbo].invoice_return_sales

--------------------------------------------------------------------
 
create PROC [dbo].[Update_Return_Sales_Invoice_Data_Set] 
	
	@id INT,
	@payment_method INT, 
	@date DATETIME,
	@details VARCHAR(50),
	@payment_condition_id INT, 
	@customer_id INT, 
	@customer_name VARCHAR(50),
	@account_id INT, 
	@account_number VARCHAR(50),
	@account_name VARCHAR(50),
	@cost_center_number INT,
	@cost_center_id INT,
	@cost_center_name VARCHAR(50),
	@price_include_vat BIT,
	@net_total VARCHAR(50),
	@discount_name VARCHAR(50),
	@discount_percentage VARCHAR(50),
	@discount_not_more VARCHAR(50),
	@total_without_vat VARCHAR(50),
	@total_with_vat VARCHAR(50),
	@vat_amount VARCHAR(50),
	@updated_by INT,
	@enabled_zakat_vat BIT,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY,
	@qrcode IMAGE
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_return_sales WHERE id = @id )
	BEGIN 
		UPDATE invoice_return_sales SET 
			payment_method=@payment_method, 
			[date]=@date,
			details=@details,
			payment_condition_id=@payment_condition_id, 
			customer_id=@customer_id, 
			customer_name=@customer_name,
			account_id=@account_id, 
			account_number=@account_number,
			account_name=@account_name,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by,
			cost_center_id = @cost_center_id,
			enabled_zakat_vat=@enabled_zakat_vat,
			qrcode=@qrcode
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 2 AND  doc_id = @id )
				
				BEGIN
					
					-- UPDATE NEEDED DATA
					UPDATE [dbo].document_details SET
						product_code = items_table_value.product_code, 
						product_name = items_table_value.product_name, 
						unit_price = items_table_value.unit_price, 
						unit_name = items_table_value.unit_name, 
						quantity = items_table_value.quantity, 
						total_price = items_table_value.total_price, 
						doc_id = items_table_value.doc_id, 
						doc_type = items_table_value.doc_type, 
						product_id = items_table_value.product_id, 
						unit_id = items_table_value.unit_id, 
						factor = items_table_value.factor, 
						total_quantity = items_table_value.total_quantity,  
						is_out = items_table_value.is_out, 
						unit_cost = items_table_value.unit_cost, 
						total_cost  = items_table_value.total_cost
					FROM [dbo].document_details
						INNER JOIN @items_table AS items_table_value 
						ON [dbo].document_details.datagrid_id = items_table_value.datagrid_id
						WHERE [dbo].document_details.doc_type = 2 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 2 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type =2 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
				END

					ELSE
				-- INSERT NEW
				BEGIN
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table;
				END

		END

	-- Update Journal Details
	IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN
			
			UPDATE [dbo].journals SET
				
				updated_by = table_value.updated_by,
				[description]  = table_value.[description],
				is_forwarded  = table_value.is_forwarded,
				entry_number = table_value.entry_number

			FROM [dbo].journals

			INNER JOIN @header_entry AS table_value ON table_value.id = [dbo].journals.id

		END
	
	-- Update Journal Account 
	IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN  
			
			IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
			BEGIN
				DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
			END

			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END

	
	
	------------------------------------------------------------------------------------------
	
	 
create PROC [dbo].[Save_Updates_Invoice_Data_Return_Sale]

@id	INT,
@payment_method	INT,
@date DATETIME,
@details TEXT,
@payment_condition_id INT,
@customer_id INT,
@customer_name VARCHAR(50),
@account_id INT,
@account_number VARCHAR(50),
@account_name VARCHAR(50),
@cost_center_id INT,
@cost_center_number INT,
@cost_center_name VARCHAR(50),
@price_include_vat BIT,
@net_total  VARCHAR(50),
@discount_name  VARCHAR(50),
@discount_percentage  VARCHAR(50),
@discount_not_more  VARCHAR(50),
@total_without_vat  VARCHAR(50),
@total_with_vat  VARCHAR(50),
@vat_amount  VARCHAR(50),
@updated_by INT

AS
	
	IF EXISTS ( SELECT * FROM invoice_return_sales WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_return_sales SET
			payment_method = @payment_method,
			[date] = @date,
			details = @details,
			payment_condition_id= @payment_condition_id,
			customer_id = @customer_id,
			customer_name=@customer_name,
			account_id=@account_id,
			account_number=@account_number,
			account_name=@account_name,
			cost_center_id=@cost_center_id,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by
		WHERE id = @id 

		/* DAILY ENTRY */


	END
		 

