USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Create_Store_Id]    Script Date: 4/24/2022 11:47:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Create_Store_Id]

@created_by int,
@datemade datetime

AS

declare @StoreId AS VARCHAR(50);
SET @StoreId = (SELECT id FROM [dbo].stores); 

	IF NOT EXISTS( SELECT * FROM [dbo].stores WHERE store_name = '' ) 
		BEGIN
			
			INSERT INTO [dbo].stores ( store_name, created_by, datemade ) VALUES( '', @created_by, @datemade );

			UPDATE [dbo].stores SET 
				code = CONCAT( @StoreId , '00', @@Identity )
			WHERE id = @@Identity;
			 
		END

	SELECT TOP 1 * FROM  [dbo].stores  WHERE store_name = ''  ORDER BY  [dbo].stores.id DESC ; 
	
	
	
---------------------------------------
CREATE PROC Get_All_Stores
AS
SELECT * FROM [dbo].stores;

--------------------------------------
ALTER PROC Update_Data_Of_Stores 

@id INT,  
@store_name varchar(50),
@store_branch varchar(50),
@telephone varchar(50),
@address TEXT,
@fax varchar(50),
@cost_center_id varchar(50),
@updated_by INT

AS
UPDATE [dbo].stores SET
	 
	store_name = @store_name,
	store_branch = @store_branch,
	telephone=@telephone,
	[address]=@address,
	fax=@fax,
	cost_center_id=@cost_center_id,
	updated_by = @updated_by

WHERE id=@id;