/**
Document Types
=====================
0 => Sales Invoices
1 => Purchase Invoices 
2 => Return Sales Invoices 
3 => Return Purchase Invoices 
4 => Direct Entry 

*/
/*
id 
date_made
details
account_number
account_name
total_quantity
total_price 
type ==> 0 => decrement 1 => 
*/ 

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_Sale_Invoice_Data_Set]    Script Date: 5/22/2022 11:49:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Update_Sale_Invoice_Data_Set] 
	
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
	@qrcode Image,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY 
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_sales WHERE id = @id )
	BEGIN 
		UPDATE invoice_sales SET 
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
			qrcode = @qrcode
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 0 AND  doc_id = @id )
				
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
						WHERE [dbo].document_details.doc_type = 0 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 0 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 0 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
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
				entry_number = table_value.entry_number,
				updated_date  = table_value.updated_date
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

	
















USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_Return_Sales_Invoice_Data_Set]    Script Date: 5/22/2022 11:52:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Update_Return_Sales_Invoice_Data_Set] 
	
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
				entry_number = table_value.entry_number,
				updated_date = table_value.updated_date
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

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_Return_Purchase_Invoice_Data_Set]    Script Date: 5/22/2022 11:53:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Update_Return_Purchase_Invoice_Data_Set] 
	
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
	@details_entry AS [dbo].journal_details READONLY
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_return_purchases WHERE id = @id )
	BEGIN 
		UPDATE invoice_return_purchases SET 
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
			enabled_zakat_vat=@enabled_zakat_vat
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 3 AND  doc_id = @id )
				
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
						WHERE [dbo].document_details.doc_type = 3 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 3 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 3 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
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
				entry_number = table_value.entry_number,
				updated_date = table_value.updated_date

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















USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_Purchase_Invoice_Data_Set]    Script Date: 5/22/2022 11:54:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Update_Purchase_Invoice_Data_Set] 
	
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
	@details_entry AS [dbo].journal_details READONLY
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_purchases WHERE id = @id )
	BEGIN 
		UPDATE invoice_purchases SET 
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
			enabled_zakat_vat=@enabled_zakat_vat
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 1 AND  doc_id = @id )
				
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
						WHERE [dbo].document_details.doc_type = 1 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 1 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 1 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
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
				entry_number = table_value.entry_number,
				updated_date = table_value.updated_date
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

	










USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Report_Statement_Document]    Script Date: 5/22/2022 11:59:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Report_Statement_Document]

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)
	 
AS 
	
-- BUILDING OPENING BALANCE WITH AUTOMAIC ROW 
DECLARE @id AS INT 
SET @id = NULL;

DECLARE @jid AS INT 
SET @jid = NULL;

DECLARE @description AS VARCHAR(50) 
SET @description = 'رصيد أول المدة';

DECLARE @ccid AS VARCHAR(50) 
SET @ccid = NULL;

DECLARE @cdate AS DATETIME
SET @cdate = @date_from;

DECLARE @accnumber AS VARCHAR(50)
SET @accnumber = NULL;

DECLARE @credit AS DECIMAL(18,2)
SET @credit = NULL;

DECLARE @debit AS DECIMAL(18,2)
SET @debit = NULL;

DECLARE @balance AS DECIMAL(18,2) 
SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND account_number = @account_1 ); 

IF @account_2 != '-1'
	SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND ( account_number = @account_1 OR account_number = @account_2 ) );

IF @balance IS NULL 
	SET @balance= 0.00;


-- BUILDING MAIN QUERY ( COLLECT IT WITH THE OPENING BALANCE )
SELECT @id AS 'id', 
	   @jid AS 'journal_id',
	   @description AS 'description',
	   @ccid AS 'cost_center_number',
	   @cdate AS 'date',
	   @accnumber AS 'account_number',
	   @credit AS 'credit',
	   @debit AS 'debit',
	   @balance AS 'balance' 
	
	   UNION ALL   

	   SELECT 
			id,
			journal_id,
			[description],
			cost_center_number,
			[date], 
			[account_number],
			credit,
			debit,
			( SELECT @balance ) + SUM( COALESCE(credit ,0) - COALESCE(debit,0) )  OVER(ORDER BY id)  balance
			FROM journal_details WHERE [date] BETWEEN @date_from AND @date_to AND ( account_number = @account_1 OR account_number = @account_2  )

-- CLOSING BALANCE 
SELECT 
	SUM( COALESCE(credit ,0)) AS 'credit', 
	SUM( COALESCE(debit ,0)) AS 'debit',
	( ( SELECT @balance ) ) + ( SUM( COALESCE(credit ,0)) - SUM( COALESCE(debit ,0) ) ) AS 'balance' 
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 ) AND [date] BETWEEN @date_from AND @date_to;






+++++++++++++++++
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Report_Statement_Document]    Script Date: 5/22/2022 11:59:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Report_Statement_Document]

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)
	 
AS 
	
-- BUILDING OPENING BALANCE WITH AUTOMAIC ROW 
DECLARE @id AS INT 
SET @id = NULL;

DECLARE @jid AS INT 
SET @jid = NULL;

DECLARE @description AS VARCHAR(50) 
SET @description = 'رصيد أول المدة';

DECLARE @ccid AS VARCHAR(50) 
SET @ccid = NULL;

DECLARE @cdate AS DATETIME
SET @cdate = @date_from;

DECLARE @accnumber AS VARCHAR(50)
SET @accnumber = NULL;

DECLARE @credit AS DECIMAL(18,2)
SET @credit = NULL;

DECLARE @debit AS DECIMAL(18,2)
SET @debit = NULL;

DECLARE @balance AS DECIMAL(18,2) 
SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND account_number = @account_1 ); 

IF @account_2 != '-1'
	SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND ( account_number = @account_1 OR account_number = @account_2 ) );

IF @balance IS NULL 
	SET @balance= 0.00;


-- BUILDING MAIN QUERY ( COLLECT IT WITH THE OPENING BALANCE )
SELECT @id AS 'id', 
	   @jid AS 'journal_id',
	   @description AS 'description',
	   @ccid AS 'cost_center_number',
	   @cdate AS 'date',
	   @accnumber AS 'account_number',
	   @credit AS 'credit',
	   @debit AS 'debit',
	   @balance AS 'balance' 
	
	   UNION ALL   

	   SELECT 
			id,
			journal_id,
			[description],
			cost_center_number,
			[date], 
			[account_number],
			credit,
			debit,
			( SELECT @balance ) + SUM( COALESCE(credit ,0) - COALESCE(debit,0) )  OVER(ORDER BY id)  balance
			FROM journal_details WHERE [date] BETWEEN @date_from AND @date_to AND ( account_number = @account_1 OR account_number = @account_2  )

-- CLOSING BALANCE 
SELECT 
	SUM( COALESCE(credit ,0)) AS 'credit', 
	SUM( COALESCE(debit ,0)) AS 'debit',
	( SUM( COALESCE(credit ,0)) - SUM( COALESCE(debit ,0) ) ) AS 'balance' 
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 );


	
	
	
	
-----------------------------------
------ تقرير المسحوبات عن الفترة
-- كميات البيع
-- كميات متبقية
--اجمالي السعر
----- التاريخ من وإلي
----- شامل إذونات الصرف 
----- شامل المردودات ( المشتريات )
-----------------------------------
------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن
 
 