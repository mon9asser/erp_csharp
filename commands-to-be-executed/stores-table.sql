
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

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Create_Resource_Id]    Script Date: 5/17/2022 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[Create_Resource_Id] 

	@type INT 

AS

DECLARE @ClientId AS VARCHAR(50);
SET @ClientId = CASE WHEN @type = 0 THEN (SELECT suppliers_account FROM settings where suppliers_account != '') ELSE (SELECT customers_account FROM settings where customers_account != '') END; 
 

 

IF NOT EXISTS( SELECT * FROM [dbo].[resources] WHERE resource_name = '' and resource_type = @type ) 
	
	BEGIN

		
		INSERT INTO [dbo].[resources] ( resource_name, resource_type  ) VALUES( '', @type )

		UPDATE [dbo].[resources] SET 
			resource_code = CONCAT( @ClientId , '00', @@Identity ),
			resource_type = @type
		WHERE id = @@Identity;
		
		-- update the tree 
		IF NOT EXISTS ( SELECT * FROM accounts WHERE account_number = CONCAT( @ClientId , '00', @@Identity ) )
		BEGIN 
			INSERT INTO accounts( account_number, main_account, is_main_account ) VALUES(CONCAT( @ClientId , '00', @@Identity ),  @ClientId, 0 )
		END
			 
	END
	 
SELECT TOP 1 * FROM  [dbo].[resources]  WHERE resource_name = '' and  resource_type = @type  ORDER BY  [dbo].[resources].id DESC ; 



---------------------------------------------------

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_Resource_Data]    Script Date: 5/17/2022 4:37:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[Update_Resource_Data]

	@id INT,
	@type INT, 
	@resource_name VARCHAR(50),
	@resource_phone  VARCHAR(50),
	@resource_address  VARCHAR(50),
	@resource_email  VARCHAR(50),

	@date_update DATETIME, 
	@updated_by INT,


	@vat_number VARCHAR(50),
	@establishment_name VARCHAR(50)
AS 

DECLARE @ClientId AS VARCHAR(50);
SET @ClientId = CASE WHEN @type = 0 THEN (SELECT suppliers_account FROM settings where suppliers_account != '') ELSE (SELECT customers_account FROM settings where customers_account != '') END; 

 
IF EXISTS ( SELECT * FROM [dbo].[resources] WHERE id = @id )
	
	BEGIN
		
		UPDATE [dbo].[resources] SET  
			
			resource_name = @resource_name,
			resource_phone = @resource_phone, 
			resource_address = @resource_address, 
			resource_email = @resource_email,
			date_update = @date_update,
			updated_by = @updated_by,

			vat_number = @vat_number,
			establishment_name = @establishment_name

		WHERE id = @id

		IF EXISTS ( SELECT * FROM accounts WHERE account_number = ( SELECT resource_code FROM  [dbo].[resources] WHERE id=@id ) )
		BEGIN 
			UPDATE accounts SET 
				account_name = @resource_name
			WHERE account_number = ( SELECT resource_code FROM  [dbo].[resources] WHERE id=@id )
		END

	END

	SELECT * FROM  [dbo].[resources] WHERE resource_type = @type

