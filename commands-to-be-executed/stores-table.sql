
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
/****** Object:  StoredProcedure [dbo].[Create_Resource_Id]    Script Date: 5/17/2022 11:12:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



ALTER PROC [dbo].[Create_Resource_Id] 

	@type INT 

AS

DECLARE @ClientId AS VARCHAR(50);
SET @ClientId = CASE WHEN @type = 0 THEN (SELECT suppliers_account FROM settings where suppliers_account != '') ELSE (SELECT customers_account FROM settings where customers_account != '') END; 
 

 

IF NOT EXISTS( SELECT * FROM [dbo].[resources] WHERE resource_name = '' ) 
	
	BEGIN

		
		INSERT INTO [dbo].[resources] ( resource_name ) VALUES( '' )

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
	 
SELECT TOP 1 * FROM  [dbo].[resources]  WHERE resource_name = ''  ORDER BY  [dbo].[resources].id DESC ; 



---------------------------------------------------
