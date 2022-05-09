
/*
id 
date_made
details
account_number
account_name
total_quantity
total_price 
*/


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
-----------------------------------


CREATE PROC Update_Withdraw_Document

	@id int,
	@date_made datetime,
	@details text,
	@account_number varchar(50),
	@account_name varchar(50),
	@total_quantity varchar(50),
	@total_price varchar(50),
	@journal_id int,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY
AS

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

-- DOCUMENT ITEMS AND HEADER
IF @id = -1
	BEGIN
		-- CREATE NEW DOCUMENT 
		INSERT INTO [withdraw_document](
			date_made,
			details,
			account_number,
			account_name,
			total_quantity,
			total_price
		) VALUES(
			@date_made,
			@details,
			@account_number,
			@account_name,
			@total_quantity,
			@total_price
		);

		SET @id = @@IDENTITY;

		-- STORE ITEMS WITH THE NEW ID 
		INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost )
			SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table
			WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 6 AND  doc_id = @@IDENTITY;
		
		
		INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'إذن صرف بضاعه', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @id, 
		'6' );

		UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

		IF EXISTS( SELECT 1 FROM @details_entry ) BEGIN
			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT @@IDENTITY, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END

	END
		ELSE
	BEGIN 
		IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN

			UPDATE  [withdraw_document] SET
				date_made=@date_made,
				details=@details,
				account_number=@account_number,
				account_name=@account_name,
				total_quantity=@total_quantity,
				total_price=@total_price
			WHERE id=@id;

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
						WHERE [dbo].document_details.doc_type = 6 AND  [dbo].document_details.doc_id = @id

			INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details );
			
			DELETE FROM [dbo].document_details WHERE doc_type = 6 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );

			IF EXISTS( SELECT 1 FROM @details_entry )
			BEGIN
				IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
				BEGIN
					DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
				END

				INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
			END

		END
	END

 
-----------------------------------------------------

CREATE PROC Get_Withdraw_Document
 
AS
  
SELECT * FROM [dbo].[withdraw_document] INNER JOIN [dbo].journals ON [dbo].[withdraw_document].id = [dbo].journals.doc_id;
SELECT * FROM [dbo].document_details WHERE doc_type = 6;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis; 
-------------------------------------------------------