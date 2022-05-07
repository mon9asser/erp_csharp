datagride_id
IN >>>>>>>>> product_untis

--------------------------------------------------------------------------------
 CREATE TYPE [dbo].[Product_Units_DataSet] AS TABLE(
	[title] [varchar](50) NULL,
	[shortcut] [varchar](50) NULL,
	[datagride_id]  [varchar](50) NULL
)
GO

--------------------------------------------------------------------------------

ALTER PROC [dbo].[Update_Product_Units_DataSet]
	@product_units AS Product_Units_DataSet READONLY
AS
	
	IF EXISTS( SELECT 1 FROM @product_units )
	BEGIN
		IF EXISTS(SELECT COUNT(*) FROM product_untis )
		BEGIN
			
			-- UPDATE THE CURRENT DATATABLE 
			UPDATE [dbo].product_untis SET
					title = item_units_value.title, 
					shortcut = item_units_value.shortcut
			FROM [dbo].product_untis
				INNER JOIN @product_units AS item_units_value
				ON [dbo].product_untis.datagride_id = item_units_value.datagride_id

			-- INSERT UNFOUND DATATABLE ROWS
			INSERT INTO [dbo].product_untis( title, shortcut, datagride_id ) 
				SELECT title, shortcut, datagride_id FROM @product_units
				WHERE datagride_id NOT IN( SELECT datagride_id FROM [dbo].product_untis );

			-- DELETE UNNEEDED DATATABLE VALUES 
			DELETE FROM [dbo].product_untis WHERE datagride_id NOT IN( SELECT datagride_id FROM @product_units );

		END
			ELSE
		BEGIN
			-- INSERT UNFOUND DATATABLE ROWS
			INSERT INTO [dbo].product_untis( title, shortcut, datagride_id ) SELECT title, shortcut, datagride_id FROM @product_units;
		END
	END 
