/**
Document Types
=====================
0 => Sales Invoices
1 => Purchase Invoices 
2 => Return Sales Invoices 
3 => Return Purchase Invoices 
4 => Direct Entry 
 
------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن
*/



In journals table 
----------------------------------------------
show_balances_in_period
(default value or bindings => (0))
 
 
 
 
 ----------------------------------------------
 
 USE [zakat_invoices]
GO

/****** Object:  UserDefinedTableType [dbo].[journal_header]    Script Date: 5/23/2022 2:30:08 PM ******/
CREATE TYPE [dbo].[journal_header] AS TABLE(
	[id] [int] NULL,
	[updated_by] [int] NULL,
	[doc_id] [int] NULL,
	[doc_type] [int] NULL,
	[description] [text] NULL,
	[is_forwarded] [bit] NULL,
	[entry_number] [varchar](50) NULL,
	[updated_date] [datetime] NULL,
	[show_balances_in_period] BIT
)
GO



 
 
 ---------------------------------------
 
 
 
 USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Update_DataSet_Of_Daily_Entries]    Script Date: 5/23/2022 2:27:41 PM ******/
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
				[updated_date] = header_entry.[updated_date],
				[show_balances_in_period] = header_entry.[show_balances_in_period]
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