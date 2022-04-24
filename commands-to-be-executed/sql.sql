CREATE TYPE Product_Units_DataSet AS TABLE(
	title varchar(50),
	shortcut varchar(50)
)

ALTER PROC Update_Product_Units_DataSet
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
				ON [dbo].product_untis.title = item_units_value.title

			-- INSERT UNFOUND DATATABLE ROWS
			INSERT INTO [dbo].product_untis( title, shortcut ) 
				SELECT title, shortcut FROM @product_units
				WHERE title NOT IN( SELECT title FROM [dbo].product_untis );

			-- DELETE UNNEEDED DATATABLE VALUES 
			DELETE FROM [dbo].product_untis WHERE title NOT IN( SELECT title FROM @product_units );

		END
			ELSE
		BEGIN
			-- INSERT UNFOUND DATATABLE ROWS
			INSERT INTO [dbo].product_untis( title, shortcut ) SELECT title, shortcut FROM @product_units;
		END
	END 