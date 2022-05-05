CREATE PROC Get_All_Row_Entries_By_Id
@id INT 
AS 
SELECT * FROM journal_details INNER JOIN accounts ON journal_details.account_number = accounts.account_number
WHERE journal_details.id=@id;


------------------------------------------------------------
create proc Create_Entry_Id

as 

DECLARE @DayNumber AS VARCHAR(50)
SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) ); 


IF NOT EXISTS ( SELECT * FROM [dbo].journals WHERE doc_id = -1 AND doc_type = '4')
BEGIN
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
END

SELECT TOP 1 * FROM [dbo].journals ORDER BY  [dbo].journals.id DESC;
