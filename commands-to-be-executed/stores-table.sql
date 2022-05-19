
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
 

create proc [dbo].[Get_All_Entries_By_Order]
	@date_from varchar(50),
	@date_to varchar(50)
as
SELECT * FROM journals, journal_details 
inner join accounts on journal_details.account_number = accounts.account_number 
where journal_details.journal_id = journals.id AND updated_date  BETWEEN @date_from AND @date_to
order by journal_details.id, journals.id

 