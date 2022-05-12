
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
USE [zakat_invoices]
GO
/****** Object:  StoredProcedure [dbo].[Get_Withdraw_Document]    Script Date: 5/12/2022 10:29:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Get_Withdraw_Document]
 
AS
  
SELECT * FROM [dbo].[withdraw_document] INNER JOIN [dbo].journals ON [dbo].[withdraw_document].id = [dbo].journals.doc_id ORDER BY  [dbo].withdraw_document.id ASC;;
SELECT * FROM [dbo].document_details WHERE doc_type = 6;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis; 

----------------------------------------------------------
create proc Delete_Export_Cart
@cid int,
@jid int
as

delete from withdraw_document where id = @cid;
delete from document_details where doc_id = @cid and doc_type = 6;
delete from journals where id=@jid;
delete from journal_details where journal_id = @jid;

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

