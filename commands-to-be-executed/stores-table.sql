create proc Get_This_Entry_By_Id
@id INT
AS
SELECT * FROM journals WHERE id=@id;
-----------------------------------------
create proc Delete_Entries_And_Record
@id INT
AS
delete from journals WHERE id=@id;