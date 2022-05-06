CREATE TYPE entry_accounts_table AS TABLE(
	[journal_id] INT,
	[debit] VARCHAR(50),
	[credit] VARCHAR(50),
	[description] VARCHAR(50),
	[cost_center_number] VARCHAR(50),
	[account_number] VARCHAR(50)
)

-------------------------------------------
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Row_Entries_By_Id]    Script Date: 5/6/2022 5:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Get_All_Row_Entries_By_Id]
@id INT 
AS 
SELECT * FROM journal_details INNER JOIN accounts ON journal_details.account_number = accounts.account_number
WHERE journal_details.journal_id=@id;
-------------------------------------------

CREATE PROC Update_Entries_DataSet
	@entries AS entry_accounts_table READONLY,
	@date_time DATETIME,
	@detail VARCHAR(50),
	@id INT
AS

UPDATE journals SET
	[description] = @detail,
	updated_date = @date_time
WHERE id = @id;

DELETE FROM [dbo].journal_details;

	IF EXISTS( SELECT 1 FROM @entries )
	BEGIN
		
		INSERT INTO [dbo].journal_details( journal_id, debit, credit, [description], cost_center_number, account_number ) 
			SELECT journal_id, debit, credit, [description], cost_center_number, account_number FROM @entries
			
			
	END
		 
--------------------------------------------------------------------------

ALTER proc [dbo].[Create_Entry_Id]

as 

DECLARE @DayNumber AS VARCHAR(50)
SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) ); 


INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, -1, 
		'4' )
		
		-- Change Entry Number to be proper with month day 
		UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;


SELECT TOP 1 * FROM [dbo].journals ORDER BY  [dbo].journals.id DESC;
