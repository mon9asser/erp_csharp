
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

CREATE TYPE [dbo].[journal_details] AS TABLE(
	[journal_id] [int] NULL,
	[debit] decimal(18,2) NULL,
	[credit] decimal(18,2) NULL,
	[description] [text] NULL,
	[cost_center_number] [varchar](50) NULL,
	[date] [datetime] NULL,
	[account_number] [varchar](50) NULL
)
GO
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
-----------------------------------
CREATE TYPE [dbo].[journal_details] AS TABLE(
	[journal_id] [int] NULL,
	[debit] decimal(18,2) NULL,
	[credit] decimal(18,2) NULL,
	[description] [text] NULL,
	[cost_center_number] [varchar](50) NULL,
	[date] [datetime] NULL,
	[account_number] [varchar](50) NULL
)
GO

USE [zakat_invoices]
GO

/****** Object:  UserDefinedTableType [dbo].[entry_accounts_table]    Script Date: 5/13/2022 1:24:04 AM ******/
CREATE TYPE [dbo].[entry_accounts_table] AS TABLE(
	[journal_id] [int] NULL,
	[debit] [varchar](50) NULL,
	[credit] decimal(18,2) NULL,
	[description] decimal(18,2) NULL,
	[cost_center_number] [varchar](50) NULL,
	[account_number] [varchar](50) NULL
)
GO



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
