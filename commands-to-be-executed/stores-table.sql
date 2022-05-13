
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

WITH tempDebitCredit AS (
	SELECT a.id, a.debit, a.credit, a.date, COALESCE(a.Credit ,0) - COALESCE(a.Debit,0) 'diff'
	FROM journal_details a 
)
SELECT a.id, a.Debit, a.Credit, SUM(b.diff) 'Balance', a.Date
FROM   tempDebitCredit a,
       tempDebitCredit b
WHERE b.id <= a.id  and a.date >= '2020/06/01' AND a.date <= '2024/02/28'
GROUP BY a.id,a.Debit, a.Credit, a.date
