
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
WITH CTE AS

(
	SELECT 
	 
		   t2.[date], 
		   t2.[credit], 
		   t2.[debit], 
		   SUM(COALESCE(t1.credit, 0) - COALESCE(t1.debit, 0)) AS Balance
	FROM journal_details t1 
	INNER JOIN journal_details t2
		ON t1.[date] <= t2.[date] 
	GROUP BY t2.[date], t2.[credit], t2.[debit]
)

SELECT * FROM CTE WHERE ([date] >= '2014/01/11 00:00:00' AND [date] <= '2025/02/28 20:00:00' ) 

-----------------------------------
CREATE TABLE journal_details
(
	[id] INT IDENTITY(1,1) NOT NULL,
	[journal_id] INT,
	[description] TEXT,
	[cost_center_number] VARCHAR(50),
	[date] DATETIME,
	[account_number] VARCHAR(50),
	[credit] DECIMAL(18, 2),
	[debit] DECIMAL(18, 2)
);


WITH CTE AS
(
SELECT t2.[date], 
       t2.[credit], 
       t2.[debit], 
       SUM(COALESCE(t1.credit, 0) - COALESCE(t1.debit, 0)) AS Balance
FROM Test t1 
INNER JOIN Test t2
    ON t1.[date] <= t2.[date] 
GROUP BY t2.[date], t2.[credit], t2.[debit]
)
SELECT * 
FROM CTE
WHERE ([date] >= '2014/01/11' AND [date] <= '2014/02/28' ) 


-- >>>>>>> Add two field for credit and debit with decimal(18,2) as a data type;
-------------------------------------------------------------



---=========================================================

WITH CTE AS
(
SELECT t2.TransDate, 
       t2.Credit, 
       t2.Debit, 
       SUM(COALESCE(t1.credit, 0) - COALESCE(t1.debit, 0)) AS Balance
FROM Test t1 
INNER JOIN Test t2
    ON t1.TransDate <= t2.TransDate

GROUP BY t2.TransDate, t2.Credit, t2.Debit
)
SELECT * 
FROM CTE
WHERE (TransDate >= '2014/01/11' AND TransDate <= '2014/02/28' ) 

-------------------------------------------------

SELECT *, SUM(COALESCE(CAST(credit AS DECIMAL(10, 2)),0) - COALESCE(CAST(debit AS DECIMAL(10, 2)),0)) over (order by id) as Balance
FROM journal_details  
INNER JOIN journals ON journal_details.journal_id = journals.id
where journal_details.account_number = 2106;

-------------------------------------------------------
WITH CTE AS
(
	SELECT t2.TransDate, 
		   t2.Credit, 
		   t2.Debit, 
		   SUM(COALESCE(t1.credit, 0) - COALESCE(t1.debit, 0)) AS Balance
	FROM Test t1 
	INNER JOIN Test t2
		ON t1.TransDate <= t2.TransDate

	GROUP BY t2.TransDate, t2.Credit, t2.Debit
)
SELECT * 
FROM CTE
WHERE (TransDate >= '2014/01/11' AND TransDate <= '2014/02/28' )



Select 
    x.[date], 
    x.credit, 
    x.debit, 
    SUM(coalesce(cast(y.credit as decimal(10,2)), 0) - coalesce(cast(y.debit as decimal(10,2)), 0))  AS Balance
FROM journal_details x 
INNER JOIN journal_details y
    ON y.[date] <= x.[date] 
GROUP BY
    x.[date], 
    x.credit, 
    x.debit
