CREATE PROC Inventory_Get_Quantities_Out_In_Products
AS
select DISTINCT product_id, product_name, is_out, SUM(CAST(total_quantity AS DECIMAL(10, 2))) OVER(PARTITION BY product_id, product_name) total_quantity from document_details where is_out = 0;
select DISTINCT product_id, product_name, is_out, SUM(CAST(total_quantity AS DECIMAL(10, 2))) OVER(PARTITION BY product_id, product_name) total_quantity from document_details where is_out = 1;

----------------------------------------
 
ALTER PROC [dbo].[Create_Return_Sales_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_sales(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'مردود فاتورة مبيعات' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردود مببعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		'2' );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id
			ORDER BY  [dbo].invoice_return_sales.id DESC;