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


ALTER proc [dbo].[Delete_Entries_And_Record]
@id INT
AS
	delete from journals WHERE id=@id;
	delete from journal_details where journal_id = @id;
	
	
	
CREATE PROC Get_Useful_Accounts
	AS
select * from accounts where account_number NOT IN(100,110,120,200,210,220,300,400,410,420,500,510,520) 

CREATE TYPE [dbo].[entry_accounts_table] AS TABLE(
	[journal_id] [int] NULL,
	[debit] [decimal](18, 0) NULL,
	[credit] [decimal](18, 0) NULL,
	[description] TExt NULL,
	[cost_center_number] [varchar](50) NULL,
	[account_number] [varchar](50) NULL,
	[date] [datetime] NULL
)
GO

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_DataSet_Of_Daily_Entries]    Script Date: 5/21/2022 5:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_DataSet_Of_Daily_Entries]    Script Date: 5/21/2022 5:12:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER proc [dbo].[Update_DataSet_Of_Daily_Entries]
	
	@journal_id int, 
	@header_entry as dbo.journal_header ReadOnly,
	@details_entry as dbo.journal_details ReadOnly

AS 

	
	IF EXISTS ( SELECT * FROM journals WHERE id = @journal_id ) 
	BEGIN

	    -- DATE TIME AND DESCRIPTION  
		IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN

			UPDATE journals SET
				[description] = header_entry.[description],
				[updated_date] = header_entry.[updated_date]

			FROM [dbo].journals
				INNER JOIN @header_entry AS header_entry 
				ON [dbo].journals.id = header_entry.id
				WHERE [dbo].journals.id = @journal_id
		END

		
	END
	


-- UPDATE ITEMS FIELD 
	IF EXISTS( SELECT 1 FROM @details_entry )
	BEGIN

		delete from [dbo].journal_details where journal_details.journal_id = @journal_id;
		INSERT INTO [dbo].journal_details( journal_id, debit, credit, [description], cost_center_number, account_number, [date] ) 
			SELECT journal_id, debit, credit, [description], cost_center_number, account_number, [date] FROM @details_entry
			
			 
	END
	
	
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
 
 