this.Text = title;
this.Repo.RegisterData(dataSource, dataSetName);
this.Repo.Load(Application.StartupPath + file_source );
this.Repo.Preview = this.previewControl1;
this.Repo.Show();
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
 
 
 
create type documents_type as table (
	document_types int
) 


create proc Get_Entries_Except_Fields

@not_in as dbo.documents_type ReadOnly

as

select * from journals, journal_details
inner join accounts on journal_details.account_number = accounts.account_number
where journals.id = journal_details.journal_id and journals.doc_type not in (select document_types from @not_in)

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
 
 