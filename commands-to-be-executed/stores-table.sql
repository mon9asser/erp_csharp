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
 
 
 
 entry_id_field
 entry_number_field
 
 datetime_field
 description_field
 
 
 
 
 
alter proc Get_Entries_Except_Fields

@not_in as dbo.documents_type ReadOnly

as

select * from journals where doc_type not in (select document_types from @not_in);

select * from journals, journal_details
inner join accounts on journal_details.account_number = accounts.account_number
where journals.id = journal_details.journal_id and journals.doc_type not in (select document_types from @not_in);











ALTER proc Update_DataSet_Of_Daily_Entries
	
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

		-- UPDATE ITEMS FIELD 
		IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN
			DELETE FROM journal_details WHERE journal_id = @journal_id;
			INSERT INTO journal_details( [description], account_number, journal_id, debit, credit, [date] ) SELECT [description], account_number, journal_id, debit, credit, [date] FROM @details_entry
		END
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
 
 