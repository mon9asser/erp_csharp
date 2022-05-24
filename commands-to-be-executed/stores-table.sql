/**
Document Types
=====================
0 => Sales Invoices
1 => Purchase Invoices 
2 => Return Sales Invoices 
3 => Return Purchase Invoices 
4 => Direct Entry 
 
------ إذن الصرف 
----- 
--من ح / صاحب المؤسسة 
-- إلي ح / المخزون
-- صرف بضاعه بإذن
*/



declare @date_from as datetime
set @date_from = '2022-05-19 00:00:00.000';

declare @date_to as datetime
set @date_to = '2022-05-23 23:59:59.000';


declare @vat_value as decimal(18,2);
set @vat_value = (select CAST(vat_value as decimal(18,2)) from settings where vat_value != ''); 
 

SELECT 
	product_id, 
	name,
	shortcut,
	count(*) 'sale_number', 
	sum(CAST(total_quantity AS DECIMAL(18,2))) 'quantity', 
	sum(CAST(total_price  AS DECIMAL(18,2))) 'sale_price', 
	sum(CAST(total_cost  AS DECIMAL(18,2))) 'cost_price', 
	( sum(CAST(total_price  AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) 'net_profit' 
FROM products
	INNER JOIN document_details  
		ON document_details.product_id = products.id   
	INNER JOIN invoice_sales
		ON document_details.doc_id = invoice_sales.id
	INNER JOIN product_untis
		ON products.unit_id = product_untis.id 
	WHERE is_out = 1 AND doc_type = 0 AND invoice_sales.date BETWEEN @date_from AND @date_to  GROUP BY product_id, name, shortcut;

SELECT 
	count(*) 'sale_number', 
	sum(CAST(total_quantity AS DECIMAL(18,2))) 'quantity', 
	sum(CAST(total_price AS DECIMAL(18,2))) 'sale_price', 
	sum(CAST(total_cost AS DECIMAL(18,2))) 'cost_price', 
	( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) 'net_profit'  ,
	@date_from 'date_from',
	@date_to 'date_to',
	'تقرير المسحوبات عن الفترة' 'title',
	@vat_value 'vat_value'
FROM document_details 
	INNER JOIN invoice_sales
		ON document_details.doc_id = invoice_sales.id
	WHERE is_out = 1 AND doc_type = 0 AND invoice_sales.date BETWEEN @date_from AND @date_to;
	 











----=================================================
  CREATE PROC WithdraW_Summery_Report


@date_from varchar(50),
@date_to varchar(50)


AS
SELECT 
	product_id, 
	name,
	shortcut,
	count(*) 'sale_number', 
	sum(CAST(total_quantity AS DECIMAL(18,2))) 'quantity', 
	sum(CAST(total_price  AS DECIMAL(18,2))) 'sale_price', 
	sum(CAST(total_cost  AS DECIMAL(18,2))) 'cost_price', 
	( sum(CAST(total_price  AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) 'net_profit' 
FROM products
	INNER JOIN document_details  
		ON document_details.product_id = products.id   
	INNER JOIN invoice_sales
		ON document_details.doc_id = invoice_sales.id
	INNER JOIN product_untis
		ON products.unit_id = product_untis.id 
	WHERE is_out = 1 AND doc_type = 0 AND invoice_sales.date BETWEEN @date_from AND @date_to  GROUP BY product_id, name, shortcut;

SELECT 
	count(*) 'sale_number', 
	sum(CAST(total_quantity AS DECIMAL(18,2))) 'quantity', 
	sum(CAST(total_price AS DECIMAL(18,2))) 'sale_price', 
	sum(CAST(total_cost AS DECIMAL(18,2))) 'cost_price', 
	( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) 'net_profit'  ,
	@date_from 'date_from',
	@date_to 'date_to',
	'تقرير المسحوبات عن الفترة' 'title'
FROM document_details 
	INNER JOIN invoice_sales
		ON document_details.doc_id = invoice_sales.id
	WHERE is_out = 1 AND doc_type = 0 AND invoice_sales.date BETWEEN @date_from AND @date_to;
	 