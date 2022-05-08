-------------------------------------------------
-- تقرير المبيعات
----------------------------
-- الفواتير الخاضعه للضريبة
-- من تاريخ إلي تاريخ
-- عرض اعداد الكميات
-------------------------------------------------
--  تقرير القيمة المضافه
----------------------------

 




CREATE PROC Search_On_Process_Reports

@date_from varchar(50),
@date_to varchar(50),
@filter_with int -- SHOULD CONTAIN A VALUE WITH 0 OR 1 OR 2

AS

IF @filter_with = 2 
	BEGIN
		
		SELECT * FROM invoice_sales where [date] >= @date_from and [date] <= @date_to;
		SELECT * FROM invoice_purchases where [date] >= @date_from and [date] <= @date_to;
		SELECT * FROM invoice_return_sales where [date] >= @date_from and [date] <= @date_to;
		SELECT * FROM invoice_return_purchases where [date] >= @date_from and [date] <= @date_to;

		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_sales  where [date] >= @date_from and [date] <= @date_to;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_purchases  where [date] >= @date_from and [date] <= @date_to;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_sales  where [date] >= @date_from and [date] <= @date_to;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_purchases  where [date] >= @date_from and [date] <= @date_to;

	END
		ELSE
	BEGIN
		SELECT * FROM invoice_sales where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT * FROM invoice_purchases where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT * FROM invoice_return_sales where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT * FROM invoice_return_purchases where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_sales  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_purchases  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_sales  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_purchases  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
	END




	

--------------------------------------------------------------
create PROC [dbo].[Get_Return_Purchase_Invoice_Data_Set]

@doc_type INT

AS

SELECT * FROM [dbo].invoice_return_purchases INNER JOIN [dbo].journals ON [dbo].invoice_return_purchases.id = [dbo].journals.doc_id;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;

---------------------------------------------------------------------------------
create PROC [dbo].[Create_Return_Purchase_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_purchases) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_purchases ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_purchases(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'مردود مشتريات' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردود مشتريات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		'3' );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_purchases  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_purchases.id = [dbo].journals.doc_id
			ORDER BY  [dbo].invoice_return_purchases.id DESC;
			
---------------------------------------------------------------------------------
 
 create proc [dbo].[Get_All_Return_Purchase_Invoices]
	 as
	 select * from [dbo].invoice_return_purchases

---------------------------------------------------------------------------------
create PROC [dbo].[Update_Return_Purchase_Invoice_Data_Set] 
	
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

----------------------------------------------------------------
 
create PROC [dbo].[Save_Updates_Invoice_Data_Return_Purchase]

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
	
	IF EXISTS ( SELECT * FROM invoice_return_purchases WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_return_purchases SET
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
		 
-------------------------------------------------------------------
