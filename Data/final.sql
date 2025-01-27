USE [zakat_invoices]
GO
/****** Object:  UserDefinedTableType [dbo].[Accounting_Table_Tree]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[Accounting_Table_Tree] AS TABLE(
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[main_account] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Accounting_Tree]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[Accounting_Tree] AS TABLE(
	[account_number] [varchar](50) NULL,
	[account_name] [text] NULL,
	[main_account] [varchar](50) NULL,
	[parent_account] [varchar](50) NULL,
	[account_name_en] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Accounting_Tree____]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[Accounting_Tree____] AS TABLE(
	[account_number] [varchar](50) NULL,
	[account_name] [text] NULL,
	[main_account] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[doc_details]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[doc_details] AS TABLE(
	[doc_id] [int] NULL,
	[doc_type] [int] NULL,
	[product_id] [int] NULL,
	[unit_id] [int] NULL,
	[is_out] [bit] NULL,
	[product_name] [varchar](50) NULL,
	[unit_name] [varchar](50) NULL,
	[unit_price] [varchar](50) NULL,
	[factor] [varchar](50) NULL,
	[quantity] [varchar](50) NULL,
	[total_quantity] [varchar](50) NULL,
	[datagrid_id] [varchar](50) NULL,
	[product_code] [varchar](50) NULL,
	[total_price] [varchar](50) NULL,
	[unit_cost] [varchar](50) NULL,
	[total_cost] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[documents_type]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[documents_type] AS TABLE(
	[document_types] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[entry_accounts_table]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[entry_accounts_table] AS TABLE(
	[journal_id] [int] NULL,
	[debit] [decimal](18, 0) NULL,
	[credit] [decimal](18, 0) NULL,
	[description] [text] NULL,
	[cost_center_number] [varchar](50) NULL,
	[account_number] [varchar](50) NULL,
	[date] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Inventory_Exp_Imp]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[Inventory_Exp_Imp] AS TABLE(
	[datagrid_id] [varchar](50) NULL,
	[qty] [varchar](50) NULL,
	[unit_cost] [varchar](50) NULL,
	[total_cost] [varchar](50) NULL,
	[product_id] [int] NULL,
	[doc_type] [int] NULL,
	[doc_id] [int] NULL,
	[is_out] [bit] NULL,
	[date] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[journal_details]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[journal_details] AS TABLE(
	[journal_id] [int] NULL,
	[debit] [decimal](18, 2) NULL,
	[credit] [decimal](18, 2) NULL,
	[description] [text] NULL,
	[cost_center_number] [varchar](50) NULL,
	[date] [datetime] NULL,
	[account_number] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[journal_header]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[journal_header] AS TABLE(
	[id] [int] NULL,
	[updated_by] [int] NULL,
	[doc_id] [int] NULL,
	[doc_type] [int] NULL,
	[description] [text] NULL,
	[is_forwarded] [bit] NULL,
	[entry_number] [varchar](50) NULL,
	[updated_date] [datetime] NULL,
	[show_balances_in_period] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Product_Units_DataSet]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[Product_Units_DataSet] AS TABLE(
	[title] [varchar](50) NULL,
	[shortcut] [varchar](50) NULL,
	[datagride_id] [varchar](50) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Trial_Balance]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[Trial_Balance] AS TABLE(
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[opening_debit] [decimal](18, 2) NULL,
	[opening_credit] [decimal](18, 2) NULL,
	[transaction_debit] [decimal](18, 2) NULL,
	[transaction_credit] [decimal](18, 2) NULL,
	[ending_debit] [decimal](18, 2) NULL,
	[ending_credit] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[valnew]    Script Date: 6/13/2022 8:18:19 PM ******/
CREATE TYPE [dbo].[valnew] AS TABLE(
	[id] [int] NOT NULL,
	[customer_name] [varchar](50) NULL,
	PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[accounting]    Script Date: 6/13/2022 8:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounting](
	[id] [int] NULL,
	[debit] [decimal](18, 2) NULL,
	[credit] [decimal](18, 2) NULL,
	[date] [date] NULL,
	[description] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [text] NULL,
	[account_name_en] [varchar](50) NULL,
	[main_account] [varchar](50) NULL,
	[debit_credit] [varchar](50) NULL,
	[balance] [varchar](50) NULL,
	[is_main_account] [bit] NULL,
	[parent_account] [varchar](50) NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](50) NULL,
	[updated_by] [int] NULL,
	[created_by] [int] NULL,
	[mod_date] [datetime] NULL,
	[created_date] [datetime] NULL,
 CONSTRAINT [PK_categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cost_centers]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cost_centers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_number] [int] NULL,
	[account_name_ar] [varchar](50) NULL,
	[account_name_en] [varchar](50) NULL,
	[date] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
 CONSTRAINT [PK_cost_centers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationDate] [date] NULL,
	[CustomerName] [varchar](45) NULL,
	[OpeningBalance] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[document_details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[document_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[doc_id] [int] NULL,
	[doc_type] [int] NULL,
	[product_id] [int] NULL,
	[product_name] [varchar](50) NULL,
	[unit_id] [int] NULL,
	[unit_name] [varchar](50) NULL,
	[unit_price] [varchar](50) NULL,
	[factor] [varchar](50) NULL,
	[quantity] [varchar](50) NULL,
	[total_quantity] [varchar](50) NULL,
	[datagrid_id] [varchar](50) NULL,
	[is_out] [bit] NULL,
	[product_code] [varchar](50) NULL,
	[total_price] [varchar](50) NULL,
	[unit_cost] [varchar](50) NULL,
	[total_cost] [varchar](50) NULL,
 CONSTRAINT [PK_document_details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[job_title] [varchar](50) NULL,
	[username] [varchar](50) NULL,
	[permission_id] [int] NULL,
	[password] [varchar](50) NULL,
	[added_by_id] [int] NULL,
	[started_date] [datetime] NULL,
	[mod_date] [datetime] NULL,
	[note] [varchar](50) NULL,
	[is_logged_in] [int] NULL,
	[current_language] [varchar](50) NULL,
	[basic_salary] [varchar](50) NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[inventory]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[datagrid_id] [varchar](50) NULL,
	[qty] [varchar](50) NULL,
	[unit_cost] [varchar](50) NULL,
	[total_cost] [varchar](50) NULL,
	[doc_type] [int] NULL,
	[doc_id] [int] NULL,
	[is_out] [bit] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_inventory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [date] NULL,
	[CustomerId] [int] NULL,
	[InvoiceTotal] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_purchases]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_purchases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_method] [int] NULL,
	[date] [datetime] NULL,
	[details] [text] NULL,
	[payment_condition_id] [int] NULL,
	[customer_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[account_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[cost_center_id] [int] NULL,
	[cost_center_number] [varchar](50) NULL,
	[cost_center_name] [varchar](50) NULL,
	[price_include_vat] [bit] NULL,
	[net_total] [varchar](50) NULL,
	[discount_name] [varchar](50) NULL,
	[discount_percentage] [varchar](50) NULL,
	[discount_not_more] [varchar](50) NULL,
	[total_without_vat] [varchar](50) NULL,
	[total_with_vat] [varchar](50) NULL,
	[vat_amount] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[serial] [varchar](50) NULL,
	[enabled_zakat_vat] [bit] NULL,
 CONSTRAINT [PK_invoice_purchases] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_return_purchases]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_return_purchases](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_method] [int] NULL,
	[date] [datetime] NULL,
	[details] [text] NULL,
	[payment_condition_id] [int] NULL,
	[customer_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[account_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[cost_center_id] [int] NULL,
	[cost_center_number] [varchar](50) NULL,
	[cost_center_name] [varchar](50) NULL,
	[price_include_vat] [bit] NULL,
	[net_total] [varchar](50) NULL,
	[discount_name] [varchar](50) NULL,
	[discount_percentage] [varchar](50) NULL,
	[discount_not_more] [varchar](50) NULL,
	[total_without_vat] [varchar](50) NULL,
	[total_with_vat] [varchar](50) NULL,
	[vat_amount] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[serial] [varchar](50) NULL,
	[enabled_zakat_vat] [bit] NULL,
	[qrcode] [image] NULL,
 CONSTRAINT [PK_invoice_return_purchases] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_return_sales]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_return_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_method] [int] NULL,
	[date] [datetime] NULL,
	[details] [text] NULL,
	[payment_condition_id] [int] NULL,
	[customer_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[account_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[cost_center_id] [int] NULL,
	[cost_center_number] [varchar](50) NULL,
	[cost_center_name] [varchar](50) NULL,
	[price_include_vat] [bit] NULL,
	[net_total] [varchar](50) NULL,
	[discount_name] [varchar](50) NULL,
	[discount_percentage] [varchar](50) NULL,
	[discount_not_more] [varchar](50) NULL,
	[total_without_vat] [varchar](50) NULL,
	[total_with_vat] [varchar](50) NULL,
	[vat_amount] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[serial] [varchar](50) NULL,
	[enabled_zakat_vat] [bit] NULL,
	[qrcode] [image] NULL,
 CONSTRAINT [PK_invoice_return_sales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_sales]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_sales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[payment_method] [int] NULL,
	[date] [datetime] NULL,
	[details] [text] NULL,
	[payment_condition_id] [int] NULL,
	[customer_id] [int] NULL,
	[customer_name] [varchar](50) NULL,
	[account_id] [int] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[cost_center_id] [int] NULL,
	[cost_center_number] [varchar](50) NULL,
	[cost_center_name] [varchar](50) NULL,
	[price_include_vat] [bit] NULL,
	[net_total] [varchar](50) NULL,
	[discount_name] [varchar](50) NULL,
	[discount_percentage] [varchar](50) NULL,
	[discount_not_more] [varchar](50) NULL,
	[total_without_vat] [varchar](50) NULL,
	[total_with_vat] [varchar](50) NULL,
	[vat_amount] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[serial] [varchar](50) NULL,
	[enabled_zakat_vat] [bit] NULL,
	[qrcode] [image] NULL,
 CONSTRAINT [PK_invoice_sales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[journal_details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[journal_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[journal_id] [int] NULL,
	[description] [text] NULL,
	[cost_center_number] [varchar](50) NULL,
	[date] [datetime] NULL,
	[account_number] [varchar](50) NULL,
	[credit] [decimal](18, 2) NULL,
	[debit] [decimal](18, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[journals]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[journals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [text] NULL,
	[is_forwarded] [bit] NULL,
	[entry_number] [varchar](50) NULL,
	[updated_date] [datetime] NULL,
	[updated_by] [int] NULL,
	[doc_id] [int] NULL,
	[doc_type] [int] NULL,
	[show_balances_in_period] [bit] NOT NULL,
 CONSTRAINT [PK_journals_] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [date] NULL,
	[CustomerId] [int] NULL,
	[PaymentTotal] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[privileges]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[privileges](
	[id] [int] NOT NULL,
	[responsability_id] [int] NULL,
	[privilege_name] [varchar](50) NULL,
	[is_enabled] [bit] NULL,
 CONSTRAINT [PK_privileges] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_untis]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_untis](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NULL,
	[shortcut] [varchar](50) NULL,
	[unit_counts] [varchar](50) NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[date_made] [datetime] NULL,
	[mod_date] [datetime] NULL,
	[datagride_id] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code]  AS ([id]+(100000)),
	[min_limit] [varchar](50) NULL,
	[max_limit] [varchar](50) NULL,
	[request_limit] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[invetory_value] [varchar](50) NULL,
	[purchase_price] [varchar](50) NULL,
	[less_sale_price] [varchar](50) NULL,
	[wholesale_sale] [varchar](50) NULL,
	[request_limit_notify] [bit] NULL,
	[minmax_limit_notify] [bit] NULL,
	[allowed_discount] [varchar](50) NULL,
	[discount_percentage_val] [varchar](50) NULL,
	[image] [image] NULL,
	[gr1_unit_id] [int] NULL,
	[gr1_purchase_price] [varchar](50) NULL,
	[gr1_sale_price] [varchar](50) NULL,
	[gr1_less_sale_price] [varchar](50) NULL,
	[gr1_wholesale_sale] [varchar](50) NULL,
	[gr1_transform] [varchar](50) NULL,
	[gr1_barcode]  AS ([id]+(110000)),
	[gr2_unit_id] [int] NULL,
	[gr2_purchase_price] [varchar](50) NULL,
	[gr2_sale_price] [varchar](50) NULL,
	[gr2_less_sale_price] [varchar](50) NULL,
	[gr2_wholesale_sale] [varchar](50) NULL,
	[gr2_transform] [varchar](50) NULL,
	[gr2_barcode]  AS ([id]+(120000)),
	[gr3_unit_id] [int] NULL,
	[gr3_purchase_price] [varchar](50) NULL,
	[gr3_sale_price] [varchar](50) NULL,
	[gr3_less_sale_price] [varchar](50) NULL,
	[gr3_wholesale_sale] [varchar](50) NULL,
	[gr3_transform] [varchar](50) NULL,
	[gr3_barcode]  AS ([id]+(130000)),
	[gr4_unit_id] [int] NULL,
	[gr4_purchase_price] [varchar](50) NULL,
	[gr4_sale_price] [varchar](50) NULL,
	[gr4_less_sale_price] [varchar](50) NULL,
	[gr4_wholesale_sale] [varchar](50) NULL,
	[gr4_transform] [varchar](50) NULL,
	[gr4_barcode]  AS ([id]+(140000)),
	[gr5_unit_id] [int] NULL,
	[gr5_purchase_price] [varchar](50) NULL,
	[gr5_sale_price] [varchar](50) NULL,
	[gr5_less_sale_price] [varchar](50) NULL,
	[gr5_wholesale_sale] [varchar](50) NULL,
	[gr5_transform] [varchar](50) NULL,
	[gr5_barcode]  AS ([id]+(150000)),
	[gr6_unit_id] [int] NULL,
	[gr6_purchase_price] [varchar](50) NULL,
	[gr6_sale_price] [varchar](50) NULL,
	[gr6_less_sale_price] [varchar](50) NULL,
	[gr6_wholesale_sale] [varchar](50) NULL,
	[gr6_transform] [varchar](50) NULL,
	[gr6_barcode]  AS ([id]+(160000)),
	[unit_id] [int] NULL,
	[category_id] [int] NULL,
	[expiration_date] [datetime] NULL,
	[enable_expiration_notification] [bit] NULL,
	[date_made] [datetime] NULL,
	[date_mod] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_by] [int] NULL,
	[default_sale_price] [varchar](50) NULL,
	[default_group] [int] NULL,
	[account_number] [varchar](50) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resources]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resources](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[resource_code] [varchar](50) NULL,
	[resource_type] [int] NULL,
	[resource_name] [varchar](50) NULL,
	[resource_phone] [varchar](50) NULL,
	[resource_address] [varchar](50) NULL,
	[resource_email] [varchar](50) NULL,
	[date_update] [datetime] NULL,
	[updated_by] [int] NULL,
	[vat_number] [varchar](50) NULL,
	[establishment_name] [varchar](50) NULL,
 CONSTRAINT [PK_resources] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[responsabilities]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[responsabilities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[responsability_name] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnInvoice]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnInvoice](
	[ReturnInvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[ReturnInvoiceDate] [date] NULL,
	[CustomerId] [int] NULL,
	[ReturnInvoiceTotal] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReturnInvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnPayment]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnPayment](
	[ReturnPaymentId] [int] IDENTITY(1,1) NOT NULL,
	[ReturnPaymentDate] [date] NULL,
	[CustomerId] [int] NULL,
	[ReturnPaymentTotal] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReturnPaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[settings]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[settings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[establishment_name] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[vat_number] [varchar](50) NULL,
	[vat_percentage] [int] NULL,
	[product_barcode_type] [int] NULL,
	[enable_delete_invoices] [bit] NULL,
	[enable_edit_invoices] [bit] NULL,
	[show_address_in_invoice] [bit] NULL,
	[created_by_id] [int] NULL,
	[update_by_id] [int] NULL,
	[mod_date] [datetime] NULL,
	[date_made] [datetime] NULL,
	[logo] [image] NULL,
	[vat_value] [varchar](50) NULL,
	[enabled_vat] [bit] NULL,
	[vat_acc_number] [varchar](50) NULL,
	[sales_account] [varchar](50) NULL,
	[sales_vat_account] [varchar](50) NULL,
	[purchases_vat_account] [varchar](50) NULL,
	[cost_of_goods_account] [varchar](50) NULL,
	[inventory_account] [varchar](50) NULL,
	[customers_account] [varchar](50) NULL,
	[suppliers_account] [varchar](50) NULL,
	[return_sales_account] [varchar](50) NULL,
	[asset_account] [varchar](50) NULL,
	[debits_account] [varchar](50) NULL,
	[profits_account] [varchar](50) NULL,
	[owners_account] [varchar](50) NULL,
	[expenses_account] [varchar](50) NULL,
	[cash_account] [varchar](50) NULL,
	[bank_account] [varchar](50) NULL,
 CONSTRAINT [PK_settings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stores]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[store_name] [varchar](50) NULL,
	[store_branch] [varchar](50) NULL,
	[telephone] [varchar](50) NULL,
	[address] [text] NULL,
	[fax] [varchar](50) NULL,
	[updated_by] [int] NULL,
	[created_by] [int] NULL,
	[datemade] [datetime] NULL,
	[cost_center_id] [varchar](50) NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[password] [varchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[fullname] [varchar](50) NULL,
	[is_manager] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[withdraw_document]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[withdraw_document](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date_made] [datetime] NULL,
	[details] [text] NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[total_quantity] [varchar](50) NULL,
	[total_price] [varchar](50) NULL,
 CONSTRAINT [PK_withdraw_document] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[accounts] ADD  CONSTRAINT [DF_accounts_is_main_account]  DEFAULT ((0)) FOR [is_main_account]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_permission_id]  DEFAULT ((0)) FOR [permission_id]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_current_language]  DEFAULT ('ar') FOR [current_language]
GO
ALTER TABLE [dbo].[journals] ADD  CONSTRAINT [DF_journals_show_balances_in_period]  DEFAULT ((0)) FOR [show_balances_in_period]
GO
ALTER TABLE [dbo].[products] ADD  CONSTRAINT [DF_products_default_group]  DEFAULT ((0)) FOR [default_group]
GO
ALTER TABLE [dbo].[resources] ADD  CONSTRAINT [DF_resources_resource_type]  DEFAULT ((1)) FOR [resource_type]
GO
/****** Object:  StoredProcedure [dbo].[amddata]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[amddata]
as
select * from accounts as accs;
select * from products as prod;
GO
/****** Object:  StoredProcedure [dbo].[Backup_Database]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Backup_Database]

@file_location Varchar(50),
@database_name Varchar(50)

AS
 
BACKUP DATABASE @database_name TO DISK = @file_location;
GO
/****** Object:  StoredProcedure [dbo].[Create_Entry_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Create_Entry_Id]

as 

DECLARE @DayNumber AS VARCHAR(50)
SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) ); 


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
GO
/****** Object:  StoredProcedure [dbo].[Create_Exp_Doucment_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE PROC [dbo].[Create_Exp_Doucment_Id]

AS

 
DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].withdraw_document(details) VALUES( 'إذن صرف بضاعه' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'إذن صرف بضاعه', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		'6' );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].withdraw_document  
			INNER JOIN 	[dbo].journals ON [dbo].withdraw_document.id = [dbo].journals.doc_id
			ORDER BY  [dbo].withdraw_document.id DESC;
			
			
			
GO
/****** Object:  StoredProcedure [dbo].[Create_Product_Code]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Create_Product_Code]

@user_id int,
@current_date datetime

AS

IF NOT EXISTS ( SELECT * FROM [dbo].[products] WHERE name = '' )
	
	BEGIN
		INSERT INTO [dbo].[products](
			name,
			invetory_value,
			min_limit,
			max_limit,
			request_limit,
			purchase_price,
			less_sale_price,
			wholesale_sale,
			request_limit_notify,
			minmax_limit_notify,
			allowed_discount,
			discount_percentage_val,

			gr1_purchase_price,
			gr1_sale_price,
			gr1_less_sale_price,
			gr1_wholesale_sale,
			gr1_transform,

			gr2_purchase_price,
			gr2_sale_price,
			gr2_less_sale_price,
			gr2_wholesale_sale,
			gr2_transform,

			gr3_purchase_price,
			gr3_sale_price,
			gr3_less_sale_price,
			gr3_wholesale_sale,
			gr3_transform,

			gr4_purchase_price,
			gr4_sale_price,
			gr4_less_sale_price,
			gr4_wholesale_sale,
			gr4_transform,

			gr5_purchase_price,
			gr5_sale_price,
			gr5_less_sale_price,
			gr5_wholesale_sale,
			gr5_transform,

			gr6_purchase_price,
			gr6_sale_price,
			gr6_less_sale_price,
			gr6_wholesale_sale,
			gr6_transform,
			 
			enable_expiration_notification,
			date_made,
			date_mod,
			created_by,
			updated_by,

			default_sale_price
		)

		VALUES (
			'',
			'0',
			'0',
			'0',
			'0',
			'0',
			'0',
			'0',
			1,
			1,
			'0',
			'0',

			'0',
			'0',
			'0',
			'0',
			'1',

			'0',
			'0',
			'0',
			'0',
			'1',

			'0',
			'0',
			'0',
			'0',
			'1',

			'0',
			'0',
			'0',
			'0',
			'1',

			'0',
			'0',
			'0',
			'0',
			'1', 

			'0',
			'0',
			'0',
			'0',
			'1',

			
			0,
			@current_date,
			@current_date,
			@user_id,
			@user_id,

			'0'

		)
 

		SELECT TOP 1 * FROM  [dbo].[products]   ORDER BY  [dbo].[products].id DESC;


	END
ELSE
	BEGIN
		SELECT * FROM [dbo].[products] WHERE [dbo].[products].name = '' 
	END


GO
/****** Object:  StoredProcedure [dbo].[Create_Purchase_Invoice_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROC [dbo].[Create_Purchase_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_purchases) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_purchases ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_purchases(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'شراء بضاعه نقدا' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مشتريات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		1 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_purchases  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_purchases.id = [dbo].journals.doc_id AND [dbo].journals.doc_type = 1
			ORDER BY  [dbo].invoice_purchases.id DESC;
GO
/****** Object:  StoredProcedure [dbo].[Create_Resource_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[Create_Resource_Id] 

	@type INT 

AS

DECLARE @ClientId AS VARCHAR(50);
SET @ClientId = CASE WHEN @type = 0 THEN (SELECT suppliers_account FROM settings where suppliers_account != '') ELSE (SELECT customers_account FROM settings where customers_account != '') END; 
 

 

IF NOT EXISTS( SELECT * FROM [dbo].[resources] WHERE resource_name = '' and resource_type = @type ) 
	
	BEGIN

		
		INSERT INTO [dbo].[resources] ( resource_name, resource_type  ) VALUES( '', @type )

		UPDATE [dbo].[resources] SET 
			resource_code = CONCAT( @ClientId , '00', @@Identity ),
			resource_type = @type
		WHERE id = @@Identity;
		
		-- update the tree 
		IF NOT EXISTS ( SELECT * FROM accounts WHERE account_number = CONCAT( @ClientId , '00', @@Identity ) )
		BEGIN 
			INSERT INTO accounts( account_number, main_account, is_main_account ) VALUES(CONCAT( @ClientId , '00', @@Identity ),  @ClientId, 0 )
		END
			 
	END
	 
SELECT TOP 1 * FROM  [dbo].[resources]  WHERE resource_name = '' and  resource_type = @type  ORDER BY  [dbo].[resources].id DESC ; 

GO
/****** Object:  StoredProcedure [dbo].[Create_Return_Purchase_Invoice_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROC [dbo].[Create_Return_Purchase_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_purchases) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_purchases ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_purchases(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'مردود مشتريات' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردود مشتريات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		3 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_purchases  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_purchases.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 3
			ORDER BY  [dbo].invoice_return_purchases.id DESC;
GO
/****** Object:  StoredProcedure [dbo].[Create_Return_Sales_Invoice_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Create_Return_Sales_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_return_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_return_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_return_sales(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'مردود فاتورة مبيعات' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مردود مببعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		2 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_return_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id AND [dbo].journals.doc_type = 2
			ORDER BY  [dbo].invoice_return_sales.id DESC;
GO
/****** Object:  StoredProcedure [dbo].[Create_Sale_Invoice_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
CREATE PROC [dbo].[Create_Sale_Invoice_Id]

AS

DECLARE @MyCounter AS INT;
	SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

DECLARE @DayNumber AS VARCHAR(50)
	SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) );

	-- Open New Invoice
	INSERT INTO  [dbo].invoice_sales(payment_method, total_with_vat, serial, price_include_vat, details) VALUES(0, '00', @MyCounter, 1, 'بيع بضاعه نقدا' );

	-- Open New Entry 
	INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مبيعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		0 );

	-- Update Entry Number 
	--UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;

	-- Return New Data 
	SELECT TOP 1 * FROM  [dbo].invoice_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_sales.id = [dbo].journals.doc_id AND [dbo].journals.doc_type = 0
			ORDER BY  [dbo].invoice_sales.id DESC;
GO
/****** Object:  StoredProcedure [dbo].[Create_Sales_Invoice_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROC [dbo].[Create_Sales_Invoice_Id]

@id INT 

AS 

DECLARE @MyCounter AS INT;
SET @MyCounter = CASE WHEN EXISTS(SELECT * FROM  [dbo].invoice_sales) THEN ( SELECT TOP 1 serial FROM  [dbo].invoice_sales ORDER BY id DESC ) + 1 ELSE 1 END; 

  
DECLARE @DayNumber AS VARCHAR(50)
SET @DayNumber =  CONVERT( VARCHAR , DATEPART( DAY, GETDATE() ) ); 


IF NOT EXISTS ( SELECT * FROM [dbo].invoice_sales WHERE id = @id )
	BEGIN 
		

		INSERT INTO  [dbo].invoice_sales(payment_method, total_with_vat, serial, price_include_vat) VALUES(0, '00', @MyCounter, 1 );
		 
		-- Journal Entry SELECT SCOPE_IDENTITY()
		INSERT INTO [dbo].journals( 
			[updated_date],
			[description], 
			entry_number, 
			doc_id, 
			doc_type
		) VALUES( 
		(SELECT GETDATE()), 
		'مبيعات', 
		( SELECT CONCAT(CAST( @DayNumber AS varchar ), CAST( '/' AS VARCHAR) , '00000' ) ) 
		, @@IDENTITY, 
		'0' )
		
		-- Change Entry Number to be proper with month day 
		UPDATE [dbo].journals SET entry_number = CONCAT( CAST( @DayNumber AS VARCHAR ), '/',  CAST( @@IDENTITY AS VARCHAR ) ) WHERE id= @@IDENTITY;


		-- Select Last Invoice 
		 SELECT TOP 1 * FROM  [dbo].invoice_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_sales.id = [dbo].journals.doc_id
			WHERE total_with_vat ='00' ORDER BY  [dbo].[invoice_sales].id DESC ;

	END

	SELECT TOP 1 * FROM  [dbo].invoice_sales  
			INNER JOIN 	[dbo].journals ON [dbo].invoice_sales.id = [dbo].journals.doc_id
			WHERE total_with_vat ='00' ORDER BY  [dbo].[invoice_sales].id DESC ;  
GO
/****** Object:  StoredProcedure [dbo].[Create_Store_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Create_Store_Id]

@created_by int,
@datemade datetime

AS

declare @StoreId AS VARCHAR(50);
SET @StoreId = (SELECT id FROM [dbo].stores); 

	IF NOT EXISTS( SELECT * FROM [dbo].stores WHERE store_name = '' ) 
		BEGIN
			
			INSERT INTO [dbo].stores ( store_name, created_by, datemade ) VALUES( '', @created_by, @datemade );

			UPDATE [dbo].stores SET 
				code = CONCAT( @StoreId , '00', @@Identity )
			WHERE id = @@Identity;
			 
		END

	SELECT TOP 1 * FROM  [dbo].stores  WHERE store_name = ''  ORDER BY  [dbo].stores.id DESC ; 
GO
/****** Object:  StoredProcedure [dbo].[Create_Tree_Account]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Create_Tree_Account]
	
	@id int,
	@account_number varchar(50),
	@account_name varchar(50),
	@account_name_en varchar(50),
	@main_account varchar(50),
	@debit_credit varchar(50),
	@balance varchar(50),
	@is_main_account bit
AS
	IF NOT EXISTS ( SELECT * FROM [dbo].accounts WHERE id = @id OR account_number = @account_number )
	BEGIN
		INSERT INTO [dbo].accounts( 
			account_number,
			account_name,
			account_name_en,
			main_account,
			debit_credit,
			balance,
			is_main_account
		) VALUES( 
			@account_number,
			@account_name,
			@account_name_en,
			@main_account,
			@debit_credit,
			@balance,
			@is_main_account
		)
	END
	ELSE
	BEGIN 
		UPDATE [dbo].accounts SET  
			account_number = @account_number,
			account_name = @account_name,
			account_name_en = @account_name_en,
			main_account = @main_account,
			debit_credit = @debit_credit,
			balance = @balance,
			is_main_account = @is_main_account
		WHERE id = @id OR account_number = @account_number
	END 
GO
/****** Object:  StoredProcedure [dbo].[Delete_Account_By_Number]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_Account_By_Number]

	@account_number VARCHAR(50)
AS
	IF EXISTS ( SELECT * FROM accounts WHERE account_number= @account_number)
		begin
			DELETE FROM accounts WHERE account_number= @account_number
			DELETE FROM accounts WHERE main_account= @account_number
		end
GO
/****** Object:  StoredProcedure [dbo].[Delete_All_Accounts]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_All_Accounts]

AS

DELETE FROM accounts

GO
/****** Object:  StoredProcedure [dbo].[Delete_Category]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_Category]

@id INT 

AS 


IF EXISTS ( SELECT * FROM [dbo].categories WHERE id = @id )
	
	BEGIN 
		DELETE FROM [dbo].categories WHERE id = @id 
	END

GO
/****** Object:  StoredProcedure [dbo].[Delete_Document_Item]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_Document_Item]

@doc_type INT,
@doc_id INT,
@grid_id VARCHAR(50)

AS 

IF EXISTS ( SELECT * FROM document_details WHERE datagrid_id=@grid_id AND doc_type=@doc_type AND doc_id=@doc_id )
BEGIN
	DELETE FROM document_details WHERE datagrid_id=@grid_id AND doc_type=@doc_type AND doc_id=@doc_id
END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Entries_And_Record]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Delete_Entries_And_Record]
@id INT
AS
	delete from journals WHERE id=@id;
	delete from journal_details where journal_id = @id;
GO
/****** Object:  StoredProcedure [dbo].[Delete_Export_Cart]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Delete_Export_Cart]
@cid int,
@jid int
as

delete from withdraw_document where id = @cid;
delete from document_details where doc_id = @cid and doc_type = 6;
delete from journals where id=@jid;
delete from journal_details where journal_id = @jid;
GO
/****** Object:  StoredProcedure [dbo].[Delete_Product_By_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_Product_By_Id]

@id INT 

AS

IF EXISTS ( SELECT * FROM [dbo].products WHERE id = @id )
	BEGIN 
		DELETE FROM [dbo].products WHERE id = @id
	END

GO
/****** Object:  StoredProcedure [dbo].[Delete_Product_Units]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Delete_Product_Units]

@id int

AS
	IF EXISTS ( SELECT * FROM [dbo].product_untis WHERE id = @id )

		BEGIN
			DELETE FROM [dbo].product_untis WHERE id=@id 
		END
	
	
	SELECT * FROM [dbo].product_untis

GO
/****** Object:  StoredProcedure [dbo].[Delete_Purchase_Invoice_Item]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Delete_Purchase_Invoice_Item]
	
	@id VARCHAR(50), 
	@invoice_id INT,
	@document_type INT

AS 
	
	IF EXISTS ( SELECT * FROM [invoice_details] WHERE [invoice_id] = @invoice_id)
		BEGIN
			DELETE FROM [purchase_invoice] WHERE id = @invoice_id
			DELETE FROM [invoice_details] WHERE [invoice_id] = @invoice_id AND [document_type] = @document_type
		END
	ELSE
		BEGIN

			IF EXISTS ( SELECT * FROM [invoice_details] WHERE datagride_id = @id  )
			 BEGIN 
				DELETE FROM [invoice_details] WHERE [datagride_id] = @id
			 END

		END
GO
/****** Object:  StoredProcedure [dbo].[Delete_Resources_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
resource type 0 => Suppliers
resource type 1 => Customers 
*/
CREATE PROC [dbo].[Delete_Resources_Data]
	
	@id INT,
	@type INT
AS

IF EXISTS ( SELECT * FROM [dbo].[resources] WHERE id = @id ) 
	BEGIN
		

		IF EXISTS ( SELECT * FROM accounts WHERE account_number = ( SELECT resource_code FROM  [dbo].[resources] WHERE id=@id ) )
		BEGIN 
			DELETE FROM accounts  
			WHERE account_number = ( SELECT resource_code FROM  [dbo].[resources] WHERE id=@id )

			DELETE FROM [dbo].[resources] WHERE id = @id
		END

		
	END

SELECT * FROM [dbo].[resources] where resource_type=@type

GO
/****** Object:  StoredProcedure [dbo].[Delete_User_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_User_Data]
	@id INT 
AS
	DELETE FROM users WHERE id = @id;
GO
/****** Object:  StoredProcedure [dbo].[Get_Accounting_Tree]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Accounting_Tree]

AS

SELECT * FROM [dbo].accounts

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Categories]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Categories]

AS


SELECT * FROM [dbo].categories INNER JOIN  [dbo].employees ON [dbo].categories.updated_by = [dbo].employees.id 

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Entries]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Get_All_Entries]
as
select * from journals;
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Entries_By_Order]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Get_All_Entries_By_Order]
	@date_from varchar(50),
	@date_to varchar(50)
as
SELECT * FROM journals, journal_details 
inner join accounts on journal_details.account_number = accounts.account_number 
where journal_details.journal_id = journals.id AND updated_date  BETWEEN @date_from AND @date_to
order by journal_details.id, journals.id

 
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Product_By_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_All_Product_By_Id]
	@id INT 
AS

	SELECT * FROM [dbo].products WHERE id=@id
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Products]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Get_All_Products] 


AS

select * from [dbo].products 
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Purchase_Invoices]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[Get_All_Purchase_Invoices]
	 as
	 select * from [dbo].invoice_purchases
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Resources]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_All_Resources]

@type int

AS

SELECT * FROM [dbo].[resources] where resource_type = @type


GO
/****** Object:  StoredProcedure [dbo].[Get_All_Return_Purchase_Invoices]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 create proc [dbo].[Get_All_Return_Purchase_Invoices]
	 as
	 select * from [dbo].invoice_return_purchases
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Return_Sales_Invoices]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Get_All_Return_Sales_Invoices]
	 as
	 select * from [dbo].invoice_return_sales
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Row_Entries]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Get_All_Row_Entries]
as
select * from journal_details
	inner join accounts on journal_details.account_number = accounts.account_number order by journal_details.id; 
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Row_Entries_By_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Row_Entries_By_Id]
@id INT 
AS 
SELECT * FROM journal_details INNER JOIN accounts ON journal_details.account_number = accounts.account_number
WHERE journal_details.journal_id=@id;
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Sale_Invoices]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[Get_All_Sale_Invoices]
	 as
	 select * from [dbo].invoice_purchases
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Sales_Invoice_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Get_All_Sales_Invoice_Details]

@doc_type INT 

AS

SELECT * FROM document_details WHERE doc_type = @doc_type;
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Sales_Invoices]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[Get_All_Sales_Invoices]
	 as
	 select * from [dbo].invoice_sales
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Settings]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Settings]

AS

	SELECT * FROM [dbo].settings

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Stores]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Stores]
AS
SELECT * FROM [dbo].stores;
GO
/****** Object:  StoredProcedure [dbo].[Get_All_User_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_User_Data]
AS
SELECT * FROM users;
GO
/****** Object:  StoredProcedure [dbo].[Get_Current_Cash_Bank_Balance]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Current_Cash_Bank_Balance]

AS


select accounts.account_number, 0 'type', (SUM(debit) - SUM(credit)) 'balance' from accounts, journal_details 
where accounts.account_number = journal_details.account_number and accounts.account_number LIKE '11010%'
group by accounts.account_number

UNION ALL

SELECT '1101' 'account_number', 0 'type', (SUM(debit) - SUM(credit)) 'balance' FROM journal_details WHERE account_number LIKE '1101%' 

UNION ALL

select accounts.account_number, 1 'type', (SUM(debit) - SUM(credit)) 'balance' from accounts, journal_details 
where accounts.account_number = journal_details.account_number and accounts.account_number LIKE '11020%'
group by accounts.account_number
	
UNION ALL

SELECT '1102' 'account_number', 1 'type', (SUM(debit) - SUM(credit)) 'balance' FROM journal_details WHERE account_number LIKE '1102%';

GO
/****** Object:  StoredProcedure [dbo].[Get_Document_Invoice_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROC [dbo].[Get_Document_Invoice_Details]

@doc_type INT 

AS

SELECT * FROM document_details WHERE doc_type = @doc_type;
GO
/****** Object:  StoredProcedure [dbo].[Get_document_Invoice_Items]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Get_document_Invoice_Items]

	@invoice_id INT,
	@doc_type INT
AS
SELECT * FROM [dbo].document_details WHERE doc_id = @invoice_id AND doc_type=@doc_type;
 
GO
/****** Object:  StoredProcedure [dbo].[Get_Entries_Except_Fields]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 
CREATE proc [dbo].[Get_Entries_Except_Fields]

@not_in as dbo.documents_type ReadOnly

as

select * from journals where doc_type not in (select document_types from @not_in);

select * from journals, journal_details
inner join accounts on journal_details.account_number = accounts.account_number
where journal_details.journal_id = journals.id and journals.doc_type not in (select document_types from @not_in) order by journal_details.id;







GO
/****** Object:  StoredProcedure [dbo].[Get_Inventory_Counts]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Inventory_Counts] 

As 
-- Purchases ( In )
SELECT product_id 'product_id', SUM(CAST(total_quantity AS DECIMAL(18,2))) 'total_quantity' FROM document_details where is_out = 0 GROUP BY product_id ;


-- Sales ( OUT )
SELECT product_id 'product_id', SUM(CAST(total_quantity AS DECIMAL(18,2))) 'total_quantity' FROM document_details where is_out = 1 GROUP BY product_id ;
GO
/****** Object:  StoredProcedure [dbo].[Get_Invoice_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Invoice_Details]

@invoice_id INT

AS 

SELECT * FROM [dbo].invoice_details IDETAILS
	INNER JOIN [dbo].products PROD ON IDETAILS.product_id = PROD.id 
	INNER JOIN [dbo].product_untis UNITS ON IDETAILS.unit_id = UNITS.id  

WHERE IDETAILS.invoice_id =@invoice_id

GO
/****** Object:  StoredProcedure [dbo].[Get_Product_Units]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Product_Units]
AS
	SELECT * FROM [dbo].product_untis
GO
/****** Object:  StoredProcedure [dbo].[Get_Purchase_Invoice_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Purchase_Invoice_Data]

AS

SELECT * FROM [dbo].purchase_invoice 
GO
/****** Object:  StoredProcedure [dbo].[Get_Purchase_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Get_Purchase_Invoice_Data_Set]

@doc_type INT

AS

SELECT * FROM [dbo].invoice_purchases INNER JOIN [dbo].journals ON [dbo].invoice_purchases.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 1;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;

GO
/****** Object:  StoredProcedure [dbo].[Get_Purchase_Invoice_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Purchase_Invoice_Details]
 
@invoice_id INT,
@type INT 

AS

SELECT * FROM [dbo].invoice_details IDETAILS
	INNER JOIN [dbo].products PROD ON IDETAILS.product_id = PROD.id 
	INNER JOIN [dbo].product_untis UNITS ON IDETAILS.unit_id = UNITS.id
WHERE IDETAILS.invoice_id = @invoice_id AND invoice_type = @type
GO
/****** Object:  StoredProcedure [dbo].[Get_Purchase_Invoice_Items]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Purchase_Invoice_Items]

@doc_type INT 

AS

SELECT * FROM document_details WHERE doc_type = @doc_type;
GO
/****** Object:  StoredProcedure [dbo].[Get_Return_Purchase_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Get_Return_Purchase_Invoice_Data_Set]

@doc_type INT

AS

SELECT * FROM [dbo].invoice_return_purchases INNER JOIN [dbo].journals ON [dbo].invoice_return_purchases.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 3;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;

GO
/****** Object:  StoredProcedure [dbo].[Get_Return_Sales_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Return_Sales_Invoice_Data_Set]


@doc_type INT

AS

SELECT * FROM [dbo].invoice_return_sales INNER JOIN [dbo].journals ON [dbo].invoice_return_sales.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 2;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;
GO
/****** Object:  StoredProcedure [dbo].[Get_Sale_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Sale_Invoice_Data_Set]


@doc_type INT

AS

SELECT * FROM [dbo].invoice_sales INNER JOIN [dbo].journals ON [dbo].invoice_sales.id = [dbo].journals.doc_id and [dbo].journals.doc_type = 0;
SELECT * FROM [dbo].document_details WHERE doc_type = @doc_type;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis;
SELECT * FROM [dbo].resources;
GO
/****** Object:  StoredProcedure [dbo].[Get_Sales_Invoice_Items]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Sales_Invoice_Items]
	@invoice_id INT,
	@doc_type INT
AS
SELECT * FROM [dbo].document_details WHERE doc_id = @invoice_id AND doc_type=@doc_type;
 
GO
/****** Object:  StoredProcedure [dbo].[Get_This_Entry_By_Id]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Get_This_Entry_By_Id]
@id INT
AS
SELECT * FROM journals WHERE id=@id;
GO
/****** Object:  StoredProcedure [dbo].[Get_Tree]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Get_Tree]
AS
SELECT * FROM [dbo].[accounting_tree]
GO
/****** Object:  StoredProcedure [dbo].[Get_Trial_Balance]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROC [dbo].[Get_Trial_Balance]

@date_from varchar(50),
@date_to varchar(50)
  

  

AS
declare @trial_blce AS [dbo].Trial_Balance;


-- OPENING BALANCE 
insert @trial_blce
select 
	accounts.account_number 'account_number' , 
	accounts.account_name 'account_name',
	0 'opening_debit',
	0 'opening_credit', 
	COALESCE(x.debit,0) 'transaction_debit',  
	COALESCE(x.credit,0)  'transaction_credit',
	
	-- CALCULATE ENDING BALANCE   
	(CASE WHEN (( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0)) > 0) 
		THEN ( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0))
		ELSE 0 END) 'ending_debit', 
	(CASE WHEN (( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0)) < 0) 
		THEN ABS( ( COALESCE(x.debit,0)) - ( COALESCE(x.credit,0)) )
		ELSE 0 END) 'ending_credit'   
	from accounts
 

FULL OUTER JOIN (
	SELECT 
	journal_details.account_number,  
	CAST(accounts.account_name AS VARCHAR(50)) 'name', 
	SUM(COALESCE(debit, 0)) 'debit', 
	SUM(COALESCE(credit, 0 )) 'credit' FROM accounts  
	INNER JOIN journal_details ON journal_details.account_number =  accounts.account_number
	INNER JOIN journals ON journal_details.journal_id =  journals.id 
	WHERE journal_details.account_number LIKE '%' AND
	journals.updated_date BETWEEN @date_from AND @date_to 
	GROUP BY 
		journal_details.account_number, 
		CAST(accounts.account_name AS VARCHAR(50))  
) x ON x.account_number = accounts.account_number WHERE 
	accounts.account_number NOT IN (100,200,300,400,500,110,120) 
	ORDER BY accounts.account_number;

	select 
			*
		from @trial_blce where (ending_debit !=0 and ending_credit =0) OR ( ending_credit!=0 and ending_debit =0);

	select 
			CAST(@date_from AS DATETIME) 'date_from',
			CAST(@date_to AS DATETIME) 'date_to',
			'ميزان المراجعه عن الفترة' 'titel',
			sum(transaction_debit) 'tran_debit', 
			sum(transaction_credit) 'tran_credit',
			sum(ending_debit) 'end_debit',
			ABS(sum(ending_credit )) 'end_credit'
		from @trial_blce where (ending_debit !=0 and ending_credit =0) OR ( ending_credit!=0 and ending_debit =0);



GO
/****** Object:  StoredProcedure [dbo].[Get_Useful_Accounts]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Useful_Accounts]
AS
select * from accounts where account_number NOT IN(100,110,120,200,210,220,300,400,410,420,500,510,520) 
GO
/****** Object:  StoredProcedure [dbo].[Get_Withdraw_Document]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Withdraw_Document]
 
AS
  
SELECT * FROM [dbo].[withdraw_document] INNER JOIN [dbo].journals ON [dbo].[withdraw_document].id = [dbo].journals.doc_id ORDER BY  [dbo].withdraw_document.id ASC;;
SELECT * FROM [dbo].document_details WHERE doc_type = 6;
SELECT * FROM [dbo].accounts;
SELECT * FROM [dbo].settings;
SELECT * FROM [dbo].products;
SELECT * FROM [dbo].product_untis; 
GO
/****** Object:  StoredProcedure [dbo].[Income_Statement_List]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Income_Statement_List]

@date_from DATETIME,
@date_to DATETIME
 
 AS
--==========================================================
--			SALES NET TOTAL
--========================================================== 

-- total sales
DECLARE @net_total_sales AS DECIMAL(18,2);
SET @net_total_sales = (SELECT SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT sales_account FROM settings WHERE sales_account != '' ) AND journals.updated_date BETWEEN @date_from AND @date_to);

IF @net_total_sales IS NULL 
	SET @net_total_sales = 0;

-- total return sales
DECLARE @net_return_sales AS DECIMAL(18,2);
SET @net_return_sales = (SELECT SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT return_sales_account FROM settings WHERE return_sales_account != '' ) AND journals.updated_date BETWEEN @date_from AND @date_to);
	 
IF @net_return_sales IS NULL 
	SET @net_return_sales = 0;

-- allowed discount 
DECLARE @sales_allowed_discounts AS DECIMAL(18,2);
SET @sales_allowed_discounts = (select SUM(COALESCE(debit, 0)) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '5104' AND journals.updated_date between @date_from and @date_to);

IF @sales_allowed_discounts IS NULL
	SET @sales_allowed_discounts = 0;

 
-- Net Sales Calculations 
DECLARE @net_sales AS DECIMAL(18,2);
SET @net_sales = ( SELECT @net_total_sales ) - ( ( SELECT @net_return_sales ) + ( SELECT @sales_allowed_discounts ) );

IF @net_sales IS NULL
SET @net_sales = 0;
 

--==========================================================
--			COST OF GOOD SOLD 
--========================================================== 

-- cost of sold goods 
DECLARE @cost_of_good_sold AS DECIMAL(18,2);
SET @cost_of_good_sold = (SELECT   SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) - SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT cost_of_goods_account FROM settings WHERE cost_of_goods_account != '' ) AND journals.updated_date BETWEEN @date_from AND @date_to);
 
IF @cost_of_good_sold IS NULL
SET @cost_of_good_sold = 0; 

-- allowed discount 
DECLARE @cost_allowed_discounts AS DECIMAL(18,2);
SET @cost_allowed_discounts = (select SUM(CAST(COALESCE(credit, 0) AS decimal(18,2))) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '4103' AND journals.updated_date between @date_from and @date_to);

IF @cost_allowed_discounts IS NULL
SET @cost_allowed_discounts = 0;

-- Net Cost Of Goods Calculations 
DECLARE @net_cost_of_goods AS DECIMAL(18,2);
SET @net_cost_of_goods = ((SELECT @cost_of_good_sold) - (SELECT @cost_allowed_discounts));

IF @net_cost_of_goods IS NULL
SET @net_cost_of_goods = 0;
 
 
--==========================================================
--			Total Profit
--========================================================== 

DECLARE @total_profits AS DECIMAL(18,2);
SET @total_profits = (( SELECT @net_sales ) - (SELECT @net_cost_of_goods));

IF @total_profits IS NULL 
SET @total_profits = 0;

--==========================================================
--			Other Revenues 
--========================================================== 
DECLARE @other_revenuse AS DECIMAL(18,2);
SET @other_revenuse = (SELECT SUM( CAST(COALESCE(credit, 0) AS decimal(18,2)) - CAST(COALESCE(debit, 0) AS decimal(18,2)) ) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '420%'); 

IF @other_revenuse IS NULL 
SET @other_revenuse = 0;


--==========================================================
--			Sell Expenses and distributions  
--========================================================== 
DECLARE @market_publish AS DECIMAL(18,2);
SET @market_publish = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '520%'); 

IF @market_publish IS NULL 
SET @market_publish = 0; 

--==========================================================
--			Management And General Expenses  
--========================================================== 
DECLARE @management_ingeneral_exp AS DECIMAL(18,2);
SET @management_ingeneral_exp = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '530%'); 

IF @management_ingeneral_exp IS NULL 
SET @management_ingeneral_exp = 0;

--==========================================================
--			Other Expenses  
--========================================================== 
DECLARE @other_expenses AS DECIMAL(18,2);
SET @other_expenses = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE journals.updated_date BETWEEN @date_from AND @date_to AND account_number LIKE '540%'); 

IF @other_expenses IS NULL 
SET @other_expenses = 0;



--==========================================================
--			Calculations   
--==========================================================
DECLARE @total_expenses AS DECIMAL(18,2);
SET @total_expenses =  ( SELECT @management_ingeneral_exp ) + (SELECT @market_publish) + (SELECT @other_expenses);

DECLARE @total_income AS DECIMAL(18,2);
SET @total_income = ( (  ( SELECT @total_profits ) + ( SELECT @other_revenuse )  ) - ( SELECT @total_expenses ) );



SELECT 
	CAST(@net_sales AS DECIMAL(18,2)) 'net_sales',
	CAST(@net_cost_of_goods AS DECIMAL(18,2)) 'sales_cost',
	CAST(@total_profits AS DECIMAL(18,2)) 'net_profit',
	-----------------------------
	CAST(@other_revenuse AS DECIMAL(18,2)) 'other_revenues',
	CAST(@market_publish AS DECIMAL(18,2)) 'sells_marketing_expenses',
	-----------------------------
	CAST(@management_ingeneral_exp AS DECIMAL(18,2)) 'management_expenses',
	CAST(@other_expenses AS DECIMAL(18,2)) 'other_expenses',
	CAST(@total_expenses AS DECIMAL(18,2)) 'total_expenses',
	--------------------------------
	CAST(@total_income AS DECIMAL(18,2)) 'total_income',
	@date_from 'date_from',
	@date_to 'date_to',
	'قائمة الدخل عن الفترة' 'title'



GO
/****** Object:  StoredProcedure [dbo].[Insert_Journal_Account_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Insert_Journal_Account_Details]
	
	@account_number VARCHAR(50),
	@debit VARCHAR(50),
	@credit VARCHAR(50),
	@description TEXT,
	@doc_id INT,
	@doc_type INT

AS

	IF EXISTS ( SELECT * FROM journals WHERE  doc_id= @doc_id AND doc_type = @doc_type )
	BEGIN
		INSERT INTO journal_details (
			journal_id,
			debit,
			credit,
			[description],
			[date],
			account_number
		) VALUES(
			( SELECT id FROM journals WHERE  doc_id= @doc_id AND doc_type = @doc_type ),
			@debit,
			@credit,
			@description,
			SYSDATETIME(),
			@account_number
		)
	END
	
GO
/****** Object:  StoredProcedure [dbo].[Installing]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Installing]

AS

/*Default User*/
IF NOT EXISTS( SELECT * FROM employees WHERE username = 'montasser' )
	BEGIN
		INSERT INTO employees 
			(
				name, 
				job_title, 
				username, 
				permission_id, 
				password, 
				added_by_id, 
				started_date, 
				mod_date, 
				note, 
				is_logged_in, 
				current_language, 
				basic_salary
			)

		VALUES
			(
				'Montasser Mossallem', 
				'System Administrator', 
				'montasser', 
				0, 
				'mon666666', 
				-1,
				convert(datetime,'18-06-12 10:34:09 PM',5),
				convert(datetime,'18-06-12 10:34:09 PM',5), 
				'',
				0,
				'en', 
				'0'
			);
	END
GO
/****** Object:  StoredProcedure [dbo].[Inventory_Get_Quantities_Out_In_Products]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Inventory_Get_Quantities_Out_In_Products]
AS
select DISTINCT product_id, product_name, is_out, SUM(CAST(total_quantity AS DECIMAL(10, 2))) OVER(PARTITION BY product_id, product_name) total_quantity from document_details where is_out = 0;
select DISTINCT product_id, product_name, is_out, SUM(CAST(total_quantity AS DECIMAL(10, 2))) OVER(PARTITION BY product_id, product_name) total_quantity from document_details where is_out = 1;
select * from products;
select * from product_untis;
GO
/****** Object:  StoredProcedure [dbo].[montasser_tests]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[montasser_tests]

@id int

as

select * from invoice_sales where id = @id;

  
GO
/****** Object:  StoredProcedure [dbo].[Prepare_Balance_Sheet]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Prepare_Balance_Sheet]

AS

--==========================================================
--			INCOME STATEMENT 
--========================================================== 

-- total sales
DECLARE @net_total_sales AS DECIMAL(18,2);
SET @net_total_sales = (SELECT SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT sales_account FROM settings WHERE sales_account != '' ));

IF @net_total_sales IS NULL 
	SET @net_total_sales = 0;

-- total return sales
DECLARE @net_return_sales AS DECIMAL(18,2);
SET @net_return_sales = (SELECT SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT return_sales_account FROM settings WHERE return_sales_account != '' ));
	 
IF @net_return_sales IS NULL 
	SET @net_return_sales = 0;

-- allowed discount 
DECLARE @sales_allowed_discounts AS DECIMAL(18,2);
SET @sales_allowed_discounts = (select SUM(COALESCE(debit, 0)) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '5104' );

IF @sales_allowed_discounts IS NULL
	SET @sales_allowed_discounts = 0;

 
-- Net Sales Calculations 
DECLARE @net_sales AS DECIMAL(18,2);
SET @net_sales = ( SELECT @net_total_sales ) - ( ( SELECT @net_return_sales ) + ( SELECT @sales_allowed_discounts ) );

IF @net_sales IS NULL
SET @net_sales = 0;
 

 
-- cost of sold goods 
DECLARE @cost_of_good_sold AS DECIMAL(18,2);
SET @cost_of_good_sold = (SELECT   SUM(COALESCE(CAST(debit AS DECIMAL(18,2)), 0 )) - SUM(COALESCE(CAST(credit AS DECIMAL(18,2)), 0 )) FROM journal_details 
	INNER JOIN journals ON journal_details.journal_id = journals.id 
	WHERE journal_details.account_number IN ( SELECT cost_of_goods_account FROM settings WHERE cost_of_goods_account != '' ));
 
IF @cost_of_good_sold IS NULL
SET @cost_of_good_sold = 0; 

-- allowed discount 
DECLARE @cost_allowed_discounts AS DECIMAL(18,2);
SET @cost_allowed_discounts = (select SUM(CAST(COALESCE(credit, 0) AS decimal(18,2))) from journal_details INNER JOIN journals ON journal_details.journal_id = journals.id where account_number = '4103');

IF @cost_allowed_discounts IS NULL
SET @cost_allowed_discounts = 0;

-- Net Cost Of Goods Calculations 
DECLARE @net_cost_of_goods AS DECIMAL(18,2);
SET @net_cost_of_goods = ((SELECT @cost_of_good_sold) - (SELECT @cost_allowed_discounts));

IF @net_cost_of_goods IS NULL
SET @net_cost_of_goods = 0;
 
 
DECLARE @total_profits AS DECIMAL(18,2);
SET @total_profits = (( SELECT @net_sales ) - (SELECT @net_cost_of_goods));

IF @total_profits IS NULL 
SET @total_profits = 0;

DECLARE @other_revenuse AS DECIMAL(18,2);
SET @other_revenuse = (SELECT SUM( CAST(COALESCE(credit, 0) AS decimal(18,2)) - CAST(COALESCE(debit, 0) AS decimal(18,2)) ) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE account_number LIKE '420%'); 

IF @other_revenuse IS NULL 
SET @other_revenuse = 0;

 
DECLARE @market_publish AS DECIMAL(18,2);
SET @market_publish = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE account_number LIKE '520%'); 

IF @market_publish IS NULL 
SET @market_publish = 0; 
 
DECLARE @management_ingeneral_exp AS DECIMAL(18,2);
SET @management_ingeneral_exp = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE  account_number LIKE '530%'); 

IF @management_ingeneral_exp IS NULL 
SET @management_ingeneral_exp = 0;

DECLARE @other_expenses AS DECIMAL(18,2);
SET @other_expenses = (SELECT SUM(CAST(COALESCE(debit, 0) AS decimal(18,2))) FROM journal_details 
INNER JOIN journals ON journal_details.journal_id = journals.id 
WHERE  account_number LIKE '540%'); 

IF @other_expenses IS NULL 
SET @other_expenses = 0;
 
DECLARE @total_expenses AS DECIMAL(18,2);
SET @total_expenses =  ( SELECT @management_ingeneral_exp ) + (SELECT @market_publish) + (SELECT @other_expenses);

DECLARE @total_income AS DECIMAL(18,2);
SET @total_income = ( (  ( SELECT @total_profits ) + ( SELECT @other_revenuse )  ) - ( SELECT @total_expenses ) );



--==========================================================
--			BALANCE SHEET   
--========================================================== 

------------------------------------------------
-- ASSETS 
------------------------------------------------
----------------------
-- CURRENT ASSETS 
---------------------
IF EXISTS ( SELECT * FROM journal_details WHERE account_number like '11%' )
		BEGIN
			SELECT journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '11%' group by journal_details.account_number, cast(accounts.account_name as varchar(50));
		END
	ELSE 
		BEGIN
			SELECT 
				'' 'account_number',
				'' 'account_name',
				0 'total'
		END
----------------------
-- FIXED ASSETS 
---------------------
IF EXISTS ( SELECT * FROM journal_details WHERE account_number like '12%' )
	BEGIN
		select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(debit,0) - COALESCE(credit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '12%' group by journal_details.account_number, cast(accounts.account_name as varchar(50));
	END
		ELSE
	BEGIN
		SELECT 
				'' 'account_number',
				'' 'account_name',
				0 'total'
	END

------------------------------------------------
-- LIABILITIES AND EQUTY 
------------------------------------------------
----------------------
-- CURRENT LIABILITIES 
---------------------
IF EXISTS ( SELECT * FROM journal_details WHERE account_number like '21%' )
	BEGIN
		select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '21%' group by journal_details.account_number, cast(accounts.account_name as varchar(50));
	END
		ELSE
	BEGIN
		SELECT 
				'' 'account_number',
				'' 'account_name',
				0 'total'
	END
----------------------
-- LONG EQUTY 
---------------------
IF EXISTS ( SELECT * FROM journal_details WHERE account_number like '22%' )
BEGIN
	select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name'
	, sum(COALESCE(credit,0) - COALESCE(debit,0)) 'all_total'  
	from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '22%' group by journal_details.account_number, cast(accounts.account_name as varchar(50));
END
	ELSE
BEGIN
	SELECT 
				'' 'account_number',
				'' 'account_name'
				,0 'all_total'
END

----------------------
-- OWNERS EQUTY 
---------------------
DECLARE @balance_year_profits AS DECIMAL(18,2);
SET @balance_year_profits = (SELECT sum(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number = '350' group by journal_details.account_number, cast(accounts.account_name as varchar(50)));

IF @balance_year_profits IS NULL
SET @balance_year_profits = 0;

select journal_details.account_number 'account_number', cast(accounts.account_name as varchar(50)) 'account_name', sum(COALESCE(credit,0) - COALESCE(debit,0)) 'total'  from journal_details, accounts where accounts.account_number = journal_details.account_number and journal_details.account_number like '3%' AND journal_details.account_number != '350' group by journal_details.account_number, cast(accounts.account_name as varchar(50))

			UNION ALL

			SELECT '350' 'account_number', 'الأرباح المحتجزة' 'account_name', (( SELECT @total_income ) + ( SELECT @balance_year_profits ) ) 'total' ;
			


-----------------------------------
-- TOTAL ASSETS AND LIABILITIES
-----------------------------------
DECLARE @total_assets AS DECIMAL(18,2);
DECLARE @total_liabilities AS DECIMAL(18,2);
DECLARE @current_assets AS DECIMAL(18,2);
DECLARE @none_current_assets AS DECIMAL(18,2);
DECLARE @current_liabilities AS DECIMAL(18,2);
DECLARE @none_current_liabilities AS DECIMAL(18,2);
DECLARE @owner_equity AS DECIMAL(18,2);

SET @current_assets = (SELECT sum(COALESCE(debit,0) - COALESCE(credit,0)) FROM journal_details WHERE account_number like '11%' );
 
SET @none_current_assets = (SELECT sum(COALESCE(debit,0) - COALESCE(credit,0))  from journal_details where account_number like '12%');
SET @current_liabilities = (SELECT sum(COALESCE(credit,0) - COALESCE(debit,0))  from journal_details where account_number like '21%');
SET @none_current_liabilities = (SELECT sum(COALESCE(credit,0) - COALESCE(debit,0))  from journal_details where account_number like '22%');
SET @owner_equity =  ( SELECT sum(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) FROM journal_details WHERE account_number like '3%');
SET @total_assets = (
	
	( CASE WHEN ( ( SELECT  SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '11%' ) ) IS NULL THEN 0 ELSE ( SELECT  SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '11%' ) END )
	+
	( CASE WHEN ( ( SELECT SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '12%' ) ) IS NULL THEN 0 ELSE ( SELECT SUM(COALESCE(debit,0) - COALESCE(credit,0)) from journal_details where journal_details.account_number like '12%' ) END )

);
SET @total_liabilities = (
	( CASE WHEN ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '21%') IS NULL THEN 0 ELSE ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '21%' ) END )
	+
	( CASE WHEN ( SELECT  SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '22%' ) IS NULL THEN 0 ELSE ( SELECT  SUM(COALESCE(credit,0) - COALESCE(debit,0)) from journal_details where journal_details.account_number like '22%' ) END )
	+
	( CASE WHEN ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) from journal_details where journal_details.account_number like '3%' ) IS NULL THEN 0 ELSE ( SELECT SUM(COALESCE(credit,0) - COALESCE(debit,0)) + ( SELECT @total_income ) from journal_details where journal_details.account_number like '3%' ) END )
);



SELECT 
	@total_assets 'total_assets',
	@total_liabilities 'total_liabilities',
	@current_assets 'current_assets',
	@none_current_assets 'fixed_assets',
	@current_liabilities 'current_liabilities',
	@none_current_liabilities 'long_liabilities',
	@owner_equity 'owner_equity',
	'قائمة المركز المالي في تاريخه' 'balance_title',
	GETDATE() 'date_time'
GO
/****** Object:  StoredProcedure [dbo].[Report_Statement_Document]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Report_Statement_Document]

	@account_1 varchar(50),
	@account_2 varchar(50),
	@date_from varchar(50),
	@date_to varchar(50)
	 
AS 
	
-- BUILDING OPENING BALANCE WITH AUTOMAIC ROW 
DECLARE @id AS INT 
SET @id = NULL;

DECLARE @jid AS INT 
SET @jid = NULL;

DECLARE @description AS VARCHAR(50) 
SET @description = 'رصيد أول المدة';

DECLARE @ccid AS VARCHAR(50) 
SET @ccid = NULL;

DECLARE @cdate AS DATETIME
SET @cdate = @date_from;

DECLARE @accnumber AS VARCHAR(50)
SET @accnumber = NULL;

DECLARE @credit AS DECIMAL(18,2)
SET @credit = NULL;

DECLARE @debit AS DECIMAL(18,2)
SET @debit = NULL;

DECLARE @paid_balance AS DECIMAL(18,2)
SET @paid_balance = (SELECT  SUM( COALESCE(debit ,0) + COALESCE(credit ,0) ) from journal_details inner join journals on journal_details.journal_id = journals.id where journals.show_balances_in_period = 1 AND account_number = @account_1);

DECLARE @balance AS DECIMAL(18,2) 
SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND account_number = @account_1 ); 

IF @account_2 != '-1'
	SET @balance = ( SELECT SUM(COALESCE(credit ,0)) - SUM(COALESCE(debit ,0)) FROM journal_details where [date] < @date_from AND ( account_number = @account_1 OR account_number = @account_2 ) );

IF @account_2 != '-1'
	SET @paid_balance = (SELECT  SUM( COALESCE(debit ,0) + COALESCE(credit ,0) ) from journal_details inner join journals on journal_details.journal_id = journals.id where journals.show_balances_in_period = 1 and (account_number = @account_1 OR account_number = @account_2));

IF @paid_balance IS NULL 
	SET @paid_balance = 0;
	
IF @balance IS NULL 
	SET @balance= 0.00;

 
-- BUILDING MAIN QUERY ( COLLECT IT WITH THE OPENING BALANCE )
SELECT @id AS 'id', 
	   @jid AS 'journal_id',
	   @description AS 'description',
	   @ccid AS 'cost_center_number',
	   @cdate AS 'date',
	   @accnumber AS 'account_number',
	   @credit AS 'credit',
	   @debit AS 'debit',
	   @balance AS 'balance' 
	
	   UNION ALL   

	   SELECT 
			id,
			journal_id,
			[description],
			cost_center_number,
			[date], 
			[account_number],
			credit,
			debit,
			( SELECT @balance ) + SUM( COALESCE(credit ,0) - COALESCE(debit,0) )  OVER(ORDER BY id)  balance
			FROM journal_details WHERE [date] BETWEEN @date_from AND @date_to AND ( account_number = @account_1 OR account_number = @account_2  )

-- CLOSING BALANCE 

/*
SELECT 
	SUM( COALESCE(credit ,0)) AS 'credit', 
	SUM( COALESCE(debit ,0)) AS 'debit',
	( SUM( COALESCE(credit ,0)) - SUM( COALESCE(debit ,0) ) ) AS 'balance',
	'الإجمالي' As 'title'
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 ) 
	
	UNION ALL
	*/
SELECT 
	( SUM( COALESCE(credit ,0) ) - ( SELECT @paid_balance ))  AS 'credit', 
	( SUM( COALESCE(debit ,0) ) - ( SELECT @paid_balance ))  AS 'debit', 
	( SUM( COALESCE(credit ,0)) - SUM( COALESCE(debit ,0) ) ) AS 'balance',
	'إجمالي الأرصدة المستحقة' As 'title'
	FROM journal_details 
	WHERE (account_number = @account_1 OR account_number = @account_2 );
GO
/****** Object:  StoredProcedure [dbo].[Retrieve_Purchase_Invoice_All_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Retrieve_Purchase_Invoice_All_Data]

AS

SELECT * FROM purchase_invoice




GO
/****** Object:  StoredProcedure [dbo].[Retrieve_Purchase_Invoice_All_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[Retrieve_Purchase_Invoice_All_Details]

@invoice_type INT

AS

SELECT * FROM [dbo].invoice_details IDETAILS
	INNER JOIN [dbo].products PROD ON IDETAILS.product_id = PROD.id 
	INNER JOIN [dbo].product_untis UNITS ON IDETAILS.unit_id = UNITS.id
WHERE IDETAILS.document_type= @invoice_type
GO
/****** Object:  StoredProcedure [dbo].[Save_Updates_Invoice_Data_Purchase]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Save_Updates_Invoice_Data_Purchase]

@id	INT,
@payment_method	INT,
@date DATETIME,
@details TEXT,
@payment_condition_id INT,
@customer_id INT,
@customer_name VARCHAR(50),
@account_id INT,
@account_number VARCHAR(50),
@account_name VARCHAR(50),
@cost_center_id INT,
@cost_center_number INT,
@cost_center_name VARCHAR(50),
@price_include_vat BIT,
@net_total  VARCHAR(50),
@discount_name  VARCHAR(50),
@discount_percentage  VARCHAR(50),
@discount_not_more  VARCHAR(50),
@total_without_vat  VARCHAR(50),
@total_with_vat  VARCHAR(50),
@vat_amount  VARCHAR(50),
@updated_by INT

AS
	
	IF EXISTS ( SELECT * FROM invoice_purchases WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_purchases SET
			payment_method = @payment_method,
			[date] = @date,
			details = @details,
			payment_condition_id= @payment_condition_id,
			customer_id = @customer_id,
			customer_name=@customer_name,
			account_id=@account_id,
			account_number=@account_number,
			account_name=@account_name,
			cost_center_id=@cost_center_id,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by
		WHERE id = @id 

		/* DAILY ENTRY */


	END
		 
GO
/****** Object:  StoredProcedure [dbo].[Save_Updates_Invoice_Data_Return_Purchase]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
create PROC [dbo].[Save_Updates_Invoice_Data_Return_Purchase]

@id	INT,
@payment_method	INT,
@date DATETIME,
@details TEXT,
@payment_condition_id INT,
@customer_id INT,
@customer_name VARCHAR(50),
@account_id INT,
@account_number VARCHAR(50),
@account_name VARCHAR(50),
@cost_center_id INT,
@cost_center_number INT,
@cost_center_name VARCHAR(50),
@price_include_vat BIT,
@net_total  VARCHAR(50),
@discount_name  VARCHAR(50),
@discount_percentage  VARCHAR(50),
@discount_not_more  VARCHAR(50),
@total_without_vat  VARCHAR(50),
@total_with_vat  VARCHAR(50),
@vat_amount  VARCHAR(50),
@updated_by INT

AS
	
	IF EXISTS ( SELECT * FROM invoice_return_purchases WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_return_purchases SET
			payment_method = @payment_method,
			[date] = @date,
			details = @details,
			payment_condition_id= @payment_condition_id,
			customer_id = @customer_id,
			customer_name=@customer_name,
			account_id=@account_id,
			account_number=@account_number,
			account_name=@account_name,
			cost_center_id=@cost_center_id,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by
		WHERE id = @id 

		/* DAILY ENTRY */


	END
		 
GO
/****** Object:  StoredProcedure [dbo].[Save_Updates_Invoice_Data_Return_Sale]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Save_Updates_Invoice_Data_Return_Sale]

@id	INT,
@payment_method	INT,
@date DATETIME,
@details TEXT,
@payment_condition_id INT,
@customer_id INT,
@customer_name VARCHAR(50),
@account_id INT,
@account_number VARCHAR(50),
@account_name VARCHAR(50),
@cost_center_id INT,
@cost_center_number INT,
@cost_center_name VARCHAR(50),
@price_include_vat BIT,
@net_total  VARCHAR(50),
@discount_name  VARCHAR(50),
@discount_percentage  VARCHAR(50),
@discount_not_more  VARCHAR(50),
@total_without_vat  VARCHAR(50),
@total_with_vat  VARCHAR(50),
@vat_amount  VARCHAR(50),
@updated_by INT

AS
	
	IF EXISTS ( SELECT * FROM invoice_return_sales WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_return_sales SET
			payment_method = @payment_method,
			[date] = @date,
			details = @details,
			payment_condition_id= @payment_condition_id,
			customer_id = @customer_id,
			customer_name=@customer_name,
			account_id=@account_id,
			account_number=@account_number,
			account_name=@account_name,
			cost_center_id=@cost_center_id,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by
		WHERE id = @id 

		/* DAILY ENTRY */


	END
GO
/****** Object:  StoredProcedure [dbo].[Save_Updates_Invoice_Data_Sale]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
create PROC [dbo].[Save_Updates_Invoice_Data_Sale]

@id	INT,
@payment_method	INT,
@date DATETIME,
@details TEXT,
@payment_condition_id INT,
@customer_id INT,
@customer_name VARCHAR(50),
@account_id INT,
@account_number VARCHAR(50),
@account_name VARCHAR(50),
@cost_center_id INT,
@cost_center_number INT,
@cost_center_name VARCHAR(50),
@price_include_vat BIT,
@net_total  VARCHAR(50),
@discount_name  VARCHAR(50),
@discount_percentage  VARCHAR(50),
@discount_not_more  VARCHAR(50),
@total_without_vat  VARCHAR(50),
@total_with_vat  VARCHAR(50),
@vat_amount  VARCHAR(50),
@updated_by INT

AS
	
	IF EXISTS ( SELECT * FROM invoice_sales WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_sales SET
			payment_method = @payment_method,
			[date] = @date,
			details = @details,
			payment_condition_id= @payment_condition_id,
			customer_id = @customer_id,
			customer_name=@customer_name,
			account_id=@account_id,
			account_number=@account_number,
			account_name=@account_name,
			cost_center_id=@cost_center_id,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by
		WHERE id = @id 

		/* DAILY ENTRY */


	END
		 
GO
/****** Object:  StoredProcedure [dbo].[Save_Updates_Invoice_Data_Sales]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Save_Updates_Invoice_Data_Sales]

@id	INT,
@payment_method	INT,
@date DATETIME,
@details TEXT,
@payment_condition_id INT,
@customer_id INT,
@customer_name VARCHAR(50),
@account_id INT,
@account_number VARCHAR(50),
@account_name VARCHAR(50),
@cost_center_id INT,
@cost_center_number INT,
@cost_center_name VARCHAR(50),
@price_include_vat BIT,
@net_total  VARCHAR(50),
@discount_name  VARCHAR(50),
@discount_percentage  VARCHAR(50),
@discount_not_more  VARCHAR(50),
@total_without_vat  VARCHAR(50),
@total_with_vat  VARCHAR(50),
@vat_amount  VARCHAR(50),
@updated_by INT

AS
	
	IF EXISTS ( SELECT * FROM invoice_sales WHERE id = @id )
	BEGIN

		/*INVOICE DATA*/
		UPDATE invoice_sales SET
			payment_method = @payment_method,
			[date] = @date,
			details = @details,
			payment_condition_id= @payment_condition_id,
			customer_id = @customer_id,
			customer_name=@customer_name,
			account_id=@account_id,
			account_number=@account_number,
			account_name=@account_name,
			cost_center_id=@cost_center_id,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by
		WHERE id = @id 

		/* DAILY ENTRY */


	END
		 
GO
/****** Object:  StoredProcedure [dbo].[Save_Updates_Purchase_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Save_Updates_Purchase_Invoice_Data_Set]

	@items_table AS dbo.valnew READONLY 

AS
	
	select * from document_details;
GO
/****** Object:  StoredProcedure [dbo].[Search_In_Products]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Search_In_Products] 

@search_value varchar(50)

AS

SELECT * FROM [dbo].products WHERE 
	(
		[name] LIKE @search_value
		
		OR 
		[code] LIKE @search_value
		
		OR 
		[gr1_barcode] LIKE @search_value

		OR 
		[gr2_barcode] LIKE @search_value

		OR 
		[gr3_barcode] LIKE @search_value

		OR 
		[gr5_barcode] LIKE @search_value

		OR 
		[gr4_barcode] LIKE @search_value

		OR 
		[gr5_barcode] LIKE @search_value

		OR 
		[gr6_barcode] LIKE @search_value

	)

GO
/****** Object:  StoredProcedure [dbo].[Search_On_Process_Reports]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Search_On_Process_Reports]

@date_from varchar(50),
@date_to varchar(50),
@filter_with int -- SHOULD CONTAIN A VALUE WITH 0 OR 1 OR 2

AS

IF @filter_with = 2 
	BEGIN
		
		SELECT * FROM invoice_sales where [date] >= @date_from and [date] <= @date_to;
		SELECT * FROM invoice_purchases where [date] >= @date_from and [date] <= @date_to;
		SELECT * FROM invoice_return_sales where [date] >= @date_from and [date] <= @date_to;
		SELECT * FROM invoice_return_purchases where [date] >= @date_from and [date] <= @date_to;

		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_sales  where [date] >= @date_from and [date] <= @date_to;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_purchases  where [date] >= @date_from and [date] <= @date_to;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_sales  where [date] >= @date_from and [date] <= @date_to;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_purchases  where [date] >= @date_from and [date] <= @date_to;

	END
		ELSE
	BEGIN
		SELECT * FROM invoice_sales where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT * FROM invoice_purchases where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT * FROM invoice_return_sales where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT * FROM invoice_return_purchases where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_sales  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_purchases  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_sales  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
		SELECT SUM(CAST(total_with_vat AS DECIMAL(10, 2))) AS total, SUM(CAST(vat_amount AS DECIMAL(10, 2))) as vat_amount, sum(cast( discount_name as decimal(10, 2))) AS dicount_amount FROM invoice_return_purchases  where [date] >= @date_from and [date] <= @date_to AND enabled_zakat_vat = @filter_with;
	END




	
GO
/****** Object:  StoredProcedure [dbo].[Update_Categories]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Categories]

@id int,
@category VARCHAR(50),
@created_by INT,
@mod_date DATETIME,
@created_date DATETIME, 
@updated_by INT 


AS

IF NOT EXISTS ( SELECT * FROM [dbo].categories WHERE id = @id )
	BEGIN
		INSERT INTO [dbo].categories
		(
			category,
			created_by,
			mod_date,
			created_date,
			updated_by
		) 
		VALUES( 
			@category,
			@created_by,
			@mod_date,
			@created_date, 
			@updated_by 
		)
	END

ELSE
	BEGIN 
		UPDATE [dbo].categories SET
			category = @category,
			mod_date = @mod_date,
			updated_by = @updated_by 
		WHERE id = @id
	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Data_Of_Stores]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Data_Of_Stores] 

@id INT,  
@store_name varchar(50),
@store_branch varchar(50),
@telephone varchar(50),
@address TEXT,
@fax varchar(50),
@cost_center_id varchar(50),
@updated_by INT

AS
UPDATE [dbo].stores SET
	 
	store_name = @store_name,
	store_branch = @store_branch,
	telephone=@telephone,
	[address]=@address,
	fax=@fax,
	cost_center_id=@cost_center_id,
	updated_by = @updated_by

WHERE id=@id;
GO
/****** Object:  StoredProcedure [dbo].[Update_DataSet_Of_Daily_Entries]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Update_DataSet_Of_Daily_Entries]
	
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
				[updated_date] = header_entry.[updated_date],
				[show_balances_in_period] = header_entry.[show_balances_in_period]
			FROM [dbo].journals
				INNER JOIN @header_entry AS header_entry 
				ON [dbo].journals.id = header_entry.id
				WHERE [dbo].journals.id = @journal_id
		END

		
	END



	-- UPDATE ITEMS FIELD 
	IF EXISTS( SELECT 1 FROM @details_entry )
	BEGIN

		delete from [dbo].journal_details where journal_details.journal_id = @journal_id;
		INSERT INTO [dbo].journal_details( journal_id, debit, credit, [description], cost_center_number, account_number, [date] ) 
			SELECT journal_id, debit, credit, [description], cost_center_number, account_number, [date] FROM @details_entry
			
			 
	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Document_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Document_Details]
 
@doc_id INT,
@doc_type INT,
@product_id INT,
@unit_id INT,
@is_out  BIT,

@product_name VARCHAR(50),
@unit_name VARCHAR(50),
@unit_price VARCHAR(50),
@factor VARCHAR(50),
@quantity VARCHAR(50),
@total_quantity VARCHAR(50),
@datagrid_id VARCHAR(50),
@product_code VARCHAR(50),
@total_price VARCHAR(50)

AS

IF NOT EXISTS ( SELECT * FROM document_details WHERE datagrid_id = @datagrid_id AND doc_id = @doc_id AND doc_type=0)
	BEGIN
		INSERT INTO document_details( 
					doc_id,
					doc_type,
					product_id,
					product_name,
					unit_id,
					unit_name,
					unit_price,
					factor,
					quantity,
					total_quantity,
					datagrid_id,
					is_out,
					product_code,
					total_price
				) VALUES(
					@doc_id,
					@doc_type,
					@product_id,
					@product_name,
					@unit_id,
					@unit_name,
					@unit_price,
					@factor,
					@quantity,
					@total_quantity,
					@datagrid_id,
					@is_out,
					@product_code,
					@total_price
				)
	END
		ELSE

	BEGIN
		UPDATE document_details SET  
			product_id=@product_id,
			product_name=@product_name,
			unit_id=@unit_id,
			unit_name=@unit_name,
			unit_price=@unit_price,
			factor=@factor,
			quantity=@quantity,
			total_quantity=@total_quantity,
			total_price=@total_price	
		WHERE datagrid_id = @datagrid_id AND doc_id = @doc_id AND doc_type=0 

	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Entries_DataSet]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Entries_DataSet]
	@entries AS entry_accounts_table READONLY,
	@date_time DATETIME,
	@detail VARCHAR(50),
	@id INT
AS

UPDATE journals SET
	[description] = @detail,
	updated_date = @date_time
WHERE id = @id;

DELETE FROM [dbo].journal_details;

	IF EXISTS( SELECT 1 FROM @entries )
	BEGIN
		
		INSERT INTO [dbo].journal_details( journal_id, debit, credit, [description], cost_center_number, account_number ) 
			SELECT journal_id, debit, credit, [description], cost_center_number, account_number FROM @entries
			
			
	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Journal_Document]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Journal_Document]
	@doc_id INT,
	@doc_type INT,
	@description TEXT, 
	@daynumber INT,
	@datemade DateTime,
	@allow_update_date BIT
AS

	IF EXISTS ( SELECT * FROM journals WHERE doc_id = @doc_id AND doc_type = @doc_type )
	BEGIN
		

		-- UPDATE JOURNAL ENTRY 
		UPDATE journals SET
			entry_number  = ( CASE WHEN ( @allow_update_date = 1 ) THEN CONCAT(@daynumber, '/', ( SELECT id FROM journals WHERE doc_id = @doc_id AND doc_type = @doc_type ) ) ELSE ( SELECT [entry_number] FROM journals WHERE doc_id = @doc_id AND doc_type = @doc_type ) END ),
			[description] =@description,
			updated_date = ( CASE WHEN ( @allow_update_date = 1 ) THEN @datemade ELSE ( SELECT updated_date FROM journals WHERE doc_id = @doc_id AND doc_type = @doc_type ) END )
		WHERE doc_id = @doc_id AND doc_type = @doc_type
		
		-- Delete all journal items 
		DELETE FROM journal_details WHERE id = @@IDENTITY

	END
	
GO
/****** Object:  StoredProcedure [dbo].[Update_Product_DB]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_Product_DB] 


@id INT, 
@min_limit varchar(50), 
@max_limit varchar(50), 
@request_limit varchar(50), 
@name varchar(50), 
@purchase_price varchar(50), 
@less_sale_price varchar(50), 
@wholesale_sale varchar(50), 
@request_limit_notify bit, 
@minmax_limit_notify bit, 
@allowed_discount varchar(50), 
@discount_percentage_val varchar(50), 
@unit_id int ,
@default_sale_price varchar(50),
@gr1_unit_id int, 
@gr1_purchase_price varchar(50), 
@gr1_sale_price varchar(50), 
@gr1_less_sale_price varchar(50), 
@gr1_wholesale_sale varchar(50), 
@gr1_transform varchar(50), 

@gr2_unit_id int, 
@gr2_purchase_price varchar(50), 
@gr2_sale_price varchar(50), 
@gr2_less_sale_price varchar(50), 
@gr2_wholesale_sale varchar(50), 
@gr2_transform varchar(50),

@gr3_unit_id int,
@gr3_purchase_price varchar(50),
@gr3_sale_price varchar(50),
@gr3_less_sale_price varchar(50),
@gr3_wholesale_sale varchar(50),
@gr3_transform varchar(50), 

@gr4_unit_id int,
@gr4_purchase_price varchar(50),
@gr4_sale_price varchar(50),
@gr4_less_sale_price varchar(50),
@gr4_wholesale_sale varchar(50),
@gr4_transform varchar(50),

@gr5_unit_id int ,
@gr5_purchase_price varchar(50),
@gr5_sale_price varchar(50),
@gr5_less_sale_price varchar(50 ),
@gr5_wholesale_sale varchar(50),
@gr5_transform varchar(50),

@gr6_unit_id int,
@gr6_purchase_price varchar(50),
@gr6_sale_price varchar(50),
@gr6_less_sale_price varchar(50),
@gr6_wholesale_sale varchar(50),
@gr6_transform varchar(50),


@category_id int,
@expiration_date datetime,
@enable_expiration_notification bit,
@date_mod datetime, 
@updated_by int,
@default_group int

AS

UPDATE [dbo].products SET

	min_limit = @min_limit, 
	max_limit = @max_limit, 
	request_limit  = @request_limit, 
	name = @name, 
	purchase_price =@purchase_price, 
	default_sale_price = @default_sale_price,
	less_sale_price = @less_sale_price, 
	wholesale_sale=@wholesale_sale, 
	request_limit_notify=@request_limit_notify, 
	minmax_limit_notify=@minmax_limit_notify, 
	allowed_discount = @allowed_discount, 
	discount_percentage_val = @discount_percentage_val, 
            
	gr1_unit_id = @gr1_unit_id, 
	gr1_purchase_price = @gr1_purchase_price, 
	gr1_sale_price = @gr1_sale_price, 
	gr1_less_sale_price = @gr1_less_sale_price, 
	gr1_wholesale_sale = @gr1_wholesale_sale, 
	gr1_transform = @gr1_transform, 

	gr2_unit_id = @gr2_unit_id, 
	gr2_purchase_price = @gr2_purchase_price, 
	gr2_sale_price = @gr2_sale_price, 
	gr2_less_sale_price = @gr2_less_sale_price, 
	gr2_wholesale_sale = @gr2_wholesale_sale, 
	gr2_transform = @gr2_transform ,

	gr3_unit_id = @gr3_unit_id,
	gr3_purchase_price = @gr3_purchase_price,
	gr3_sale_price = @gr3_sale_price,
	gr3_less_sale_price = @gr3_less_sale_price,
	gr3_wholesale_sale = @gr3_wholesale_sale,
	gr3_transform = @gr3_transform, 

	gr4_unit_id = @gr4_unit_id,
	gr4_purchase_price = @gr4_purchase_price,
	gr4_sale_price = @gr4_sale_price,
	gr4_less_sale_price = @gr4_less_sale_price,
	gr4_wholesale_sale = @gr4_wholesale_sale,
	gr4_transform = @gr4_transform,

	gr5_unit_id = @gr5_unit_id,
	gr5_purchase_price = @gr5_purchase_price,
	gr5_sale_price = @gr5_sale_price,
	gr5_less_sale_price = @gr5_less_sale_price,
	gr5_wholesale_sale=@gr5_wholesale_sale,
	gr5_transform = @gr5_transform ,

	gr6_unit_id  = @gr6_unit_id,
	gr6_purchase_price  = @gr6_purchase_price,
	gr6_sale_price =@gr6_sale_price,
	gr6_less_sale_price  =@gr6_less_sale_price,
	gr6_wholesale_sale = @gr6_wholesale_sale,
	gr6_transform = @gr5_transform,

	unit_id = @unit_id,
	category_id = @category_id,
	expiration_date = @expiration_date,
	enable_expiration_notification = @enable_expiration_notification,
	date_mod = @date_mod, 
	updated_by = @updated_by,
	default_group = @default_group

WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[Update_Product_Image]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_Product_Image] 

@id INT, 
@image IMAGE

AS

UPDATE [dbo].products SET

	[image] = @image

WHERE id = @id
GO
/****** Object:  StoredProcedure [dbo].[Update_Product_Units]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_Product_Units]

	@id int,
	
	@title varchar(50),  
	@shortcut varchar(50),
	
	@unit_counts varchar(50),
	@created_by int,
	@updated_by int,

	@date_made datetime,
	@mod_date datetime

AS

	IF NOT EXISTS ( SELECT * FROM [dbo].product_untis WHERE id = @id )

			BEGIN
				INSERT INTO [dbo].product_untis
					( 
						title,
						shortcut,
						unit_counts,
						created_by,
						updated_by,
						date_made,
						mod_date

					)
					VALUES
					( 
						@title,
						@shortcut,
						@unit_counts,
						@created_by,
						@updated_by,
						@date_made,
						@mod_date
					)
			END
	
		ELSE
	
			BEGIN
			UPDATE [dbo].product_untis SET 
				
				shortcut = @shortcut,
				title= @title,
				unit_counts=@unit_counts, 
				updated_by=@updated_by, 
				mod_date=@mod_date

			WHERE id = @id

		END

	SELECT * FROM [dbo].product_untis

GO
/****** Object:  StoredProcedure [dbo].[Update_Product_Units_DataSet]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Product_Units_DataSet]
	@product_units AS Product_Units_DataSet READONLY
AS
	
	IF EXISTS( SELECT 1 FROM @product_units )
	BEGIN
		IF EXISTS(SELECT COUNT(*) FROM product_untis )
		BEGIN
			
			-- UPDATE THE CURRENT DATATABLE 
			UPDATE [dbo].product_untis SET
					title = item_units_value.title, 
					shortcut = item_units_value.shortcut
			FROM [dbo].product_untis
				INNER JOIN @product_units AS item_units_value
				ON [dbo].product_untis.datagride_id = item_units_value.datagride_id

			-- INSERT UNFOUND DATATABLE ROWS
			INSERT INTO [dbo].product_untis( title, shortcut, datagride_id ) 
				SELECT title, shortcut, datagride_id FROM @product_units
				WHERE datagride_id NOT IN( SELECT datagride_id FROM [dbo].product_untis );

			-- DELETE UNNEEDED DATATABLE VALUES 
			DELETE FROM [dbo].product_untis WHERE datagride_id NOT IN( SELECT datagride_id FROM @product_units );

		END
			ELSE
		BEGIN
			-- INSERT UNFOUND DATATABLE ROWS
			INSERT INTO [dbo].product_untis( title, shortcut, datagride_id ) SELECT title, shortcut, datagride_id FROM @product_units;
		END
	END 
GO
/****** Object:  StoredProcedure [dbo].[Update_Purchase_Invoice_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Purchase_Invoice_Data]
	
	@id INT,
	@serial VARCHAR(50),
	@payment_method INT,
	@date DATETIME,
	@details TEXT, 
	@total_with_vat VARCHAR(50),
	@total_without_vat VARCHAR(50),
	@discount VARCHAR(50),
	@vat_value VARCHAR(50),
	@is_include_vat BIT,   
	@net_total VARCHAR(50),
	@discount_perc VARCHAR(50),
	@discount_not_more VARCHAR(50)


AS
	IF NOT EXISTS ( SELECT * FROM purchase_invoice WHERE id = @id )
		BEGIN
			INSERT INTO purchase_invoice( 
				serial,
				payment_method,
				[date],
				details, 
				total_with_vat,
				total_without_vat,
				discount,
				vat_value,
				is_include_vat,  
				net_total,
				discount_perc,
				discount_not_more
			) VALUES(
				@serial,
				@payment_method,
				@date,
				@details, 
				@total_with_vat,
				@total_without_vat,
				@discount,
				@vat_value,
				@is_include_vat,  
				@net_total,
				@discount_perc,
				@discount_not_more
			)
		END
	ELSE 
		BEGIN 
			UPDATE purchase_invoice SET  
				payment_method = @payment_method, 
				details=@details, 
				total_with_vat=@total_with_vat,
				total_without_vat=@total_without_vat,
				discount=@discount,
				vat_value=@vat_value,
				is_include_vat=@is_include_vat,
				net_total=@net_total,
				discount_perc=@discount_perc,
				discount_not_more=@discount_not_more
			WHERE id = @id 
		END
		 
GO
/****** Object:  StoredProcedure [dbo].[Update_Purchase_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Purchase_Invoice_Data_Set] 
	
	@id INT,
	@payment_method INT, 
	@date DATETIME,
	@details VARCHAR(50),
	@payment_condition_id INT, 
	@customer_id INT, 
	@customer_name VARCHAR(50),
	@account_id INT, 
	@account_number VARCHAR(50),
	@account_name VARCHAR(50),
	@cost_center_number INT,
	@cost_center_id INT,
	@cost_center_name VARCHAR(50),
	@price_include_vat BIT,
	@net_total VARCHAR(50),
	@discount_name VARCHAR(50),
	@discount_percentage VARCHAR(50),
	@discount_not_more VARCHAR(50),
	@total_without_vat VARCHAR(50),
	@total_with_vat VARCHAR(50),
	@vat_amount VARCHAR(50),
	@updated_by INT,
	@enabled_zakat_vat BIT,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_purchases WHERE id = @id )
	BEGIN 
		UPDATE invoice_purchases SET 
			payment_method=@payment_method, 
			[date]=@date,
			details=@details,
			payment_condition_id=@payment_condition_id, 
			customer_id=@customer_id, 
			customer_name=@customer_name,
			account_id=@account_id, 
			account_number=@account_number,
			account_name=@account_name,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by,
			cost_center_id = @cost_center_id,
			enabled_zakat_vat=@enabled_zakat_vat
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 1 AND  doc_id = @id )
				
				BEGIN
					
					-- UPDATE NEEDED DATA
					UPDATE [dbo].document_details SET
						product_code = items_table_value.product_code, 
						product_name = items_table_value.product_name, 
						unit_price = items_table_value.unit_price, 
						unit_name = items_table_value.unit_name, 
						quantity = items_table_value.quantity, 
						total_price = items_table_value.total_price, 
						doc_id = items_table_value.doc_id, 
						doc_type = items_table_value.doc_type, 
						product_id = items_table_value.product_id, 
						unit_id = items_table_value.unit_id, 
						factor = items_table_value.factor, 
						total_quantity = items_table_value.total_quantity,  
						is_out = items_table_value.is_out, 
						unit_cost = items_table_value.unit_cost, 
						total_cost  = items_table_value.total_cost
					FROM [dbo].document_details
						INNER JOIN @items_table AS items_table_value 
						ON [dbo].document_details.datagrid_id = items_table_value.datagrid_id
						WHERE [dbo].document_details.doc_type = 1 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 1 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 1 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
				END

					ELSE
				-- INSERT NEW
				BEGIN
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table;
				END

		END

	-- Update Journal Details
	IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN
			
			UPDATE [dbo].journals SET
				
				updated_by = table_value.updated_by,
				[description]  = table_value.[description],
				is_forwarded  = table_value.is_forwarded,
				entry_number = table_value.entry_number,
				updated_date = table_value.updated_date
			FROM [dbo].journals

			INNER JOIN @header_entry AS table_value ON table_value.id = [dbo].journals.id

		END
	
	-- Update Journal Account 
	IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN  
			
			IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
			BEGIN
				DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
			END

			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END

	

GO
/****** Object:  StoredProcedure [dbo].[Update_Purchase_Invoice_Details]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_Purchase_Invoice_Details]

	@datagride_id VARCHAR(50),
	@invoice_id INT,
	@invoice_type INT, 
	@product_id INT, 
	@unit_price VARCHAR(50),
	@unit_id INT,
	@quantity VARCHAR(50),
	@total_price VARCHAR(50),
	@total_quantity VARCHAR(50),
	@product_name VARCHAR(50),
	@factor VARCHAR(50),
	@document_type INT,
	@is_out INT 

AS

	IF NOT EXISTS ( SELECT * FROM invoice_details WHERE datagride_id = @datagride_id )
		BEGIN
			INSERT INTO invoice_details(
				datagride_id,
				invoice_id,
				invoice_type,
				product_id,
				unit_price,
				unit_id,
				quantity,
				total_price,
				total_quantity,
				product_name,
				factor,
				document_type,
				is_out
			) VALUES(
				@datagride_id,
				@invoice_id,
				@invoice_type, 
				@product_id, 
				@unit_price,
				@unit_id,
				@quantity,
				@total_price,
				@total_quantity,
				@product_name,
				@factor,
				@document_type,
				@is_out
			)
		END
	ELSE
		BEGIN
			UPDATE invoice_details SET  
				product_id=@product_id,
				unit_price=@unit_price,
				unit_id=@unit_id,
				quantity=@quantity,
				total_price=@total_price,
				total_quantity=@total_quantity,
				product_name=@product_name,
				factor=@factor,
				document_type=@document_type,
				is_out=@is_out
			WHERE datagride_id=@datagride_id
		END



GO
/****** Object:  StoredProcedure [dbo].[Update_Resource_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Resource_Data]

	@id INT,
	@type INT, 
	@resource_name VARCHAR(50),
	@resource_phone  VARCHAR(50),
	@resource_address  VARCHAR(50),
	@resource_email  VARCHAR(50),

	@date_update DATETIME, 
	@updated_by INT,


	@vat_number VARCHAR(50),
	@establishment_name VARCHAR(50)
AS 

DECLARE @ClientId AS VARCHAR(50);
SET @ClientId = CASE WHEN @type = 0 THEN (SELECT suppliers_account FROM settings where suppliers_account != '') ELSE (SELECT customers_account FROM settings where customers_account != '') END; 

 
IF EXISTS ( SELECT * FROM [dbo].[resources] WHERE id = @id  )
	
	BEGIN
		
		UPDATE [dbo].[resources] SET  
			
			resource_name = @resource_name,
			resource_phone = @resource_phone, 
			resource_address = @resource_address, 
			resource_email = @resource_email,
			date_update = @date_update,
			updated_by = @updated_by,

			vat_number = @vat_number,
			establishment_name = @establishment_name

		WHERE id = @id

		IF EXISTS ( SELECT * FROM accounts WHERE account_number = ( SELECT resource_code FROM  [dbo].[resources] WHERE id=@id ) )
		BEGIN 
			UPDATE accounts SET 
				account_name = @resource_name
			WHERE account_number = ( SELECT resource_code FROM  [dbo].[resources] WHERE id=@id )
		END

	END

	SELECT * FROM  [dbo].[resources] WHERE resource_type = @type
GO
/****** Object:  StoredProcedure [dbo].[Update_Return_Purchase_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Return_Purchase_Invoice_Data_Set] 
	
	@id INT,
	@payment_method INT, 
	@date DATETIME,
	@details VARCHAR(50),
	@payment_condition_id INT, 
	@customer_id INT, 
	@customer_name VARCHAR(50),
	@account_id INT, 
	@account_number VARCHAR(50),
	@account_name VARCHAR(50),
	@cost_center_number INT,
	@cost_center_id INT,
	@cost_center_name VARCHAR(50),
	@price_include_vat BIT,
	@net_total VARCHAR(50),
	@discount_name VARCHAR(50),
	@discount_percentage VARCHAR(50),
	@discount_not_more VARCHAR(50),
	@total_without_vat VARCHAR(50),
	@total_with_vat VARCHAR(50),
	@vat_amount VARCHAR(50),
	@updated_by INT,
	@enabled_zakat_vat BIT,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_return_purchases WHERE id = @id )
	BEGIN 
		UPDATE invoice_return_purchases SET 
			payment_method=@payment_method, 
			[date]=@date,
			details=@details,
			payment_condition_id=@payment_condition_id, 
			customer_id=@customer_id, 
			customer_name=@customer_name,
			account_id=@account_id, 
			account_number=@account_number,
			account_name=@account_name,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by,
			cost_center_id = @cost_center_id,
			enabled_zakat_vat=@enabled_zakat_vat
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 3 AND  doc_id = @id )
				
				BEGIN
					
					-- UPDATE NEEDED DATA
					UPDATE [dbo].document_details SET
						product_code = items_table_value.product_code, 
						product_name = items_table_value.product_name, 
						unit_price = items_table_value.unit_price, 
						unit_name = items_table_value.unit_name, 
						quantity = items_table_value.quantity, 
						total_price = items_table_value.total_price, 
						doc_id = items_table_value.doc_id, 
						doc_type = items_table_value.doc_type, 
						product_id = items_table_value.product_id, 
						unit_id = items_table_value.unit_id, 
						factor = items_table_value.factor, 
						total_quantity = items_table_value.total_quantity,  
						is_out = items_table_value.is_out, 
						unit_cost = items_table_value.unit_cost, 
						total_cost  = items_table_value.total_cost
					FROM [dbo].document_details
						INNER JOIN @items_table AS items_table_value 
						ON [dbo].document_details.datagrid_id = items_table_value.datagrid_id
						WHERE [dbo].document_details.doc_type = 3 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 3 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 3 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
				END

					ELSE
				-- INSERT NEW
				BEGIN
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table;
				END

		END

	-- Update Journal Details
	IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN
			
			UPDATE [dbo].journals SET
				
				updated_by = table_value.updated_by,
				[description]  = table_value.[description],
				is_forwarded  = table_value.is_forwarded,
				entry_number = table_value.entry_number,
				updated_date = table_value.updated_date

			FROM [dbo].journals

			INNER JOIN @header_entry AS table_value ON table_value.id = [dbo].journals.id

		END
	
	-- Update Journal Account 
	IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN  
			
			IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
			BEGIN
				DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
			END

			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END



GO
/****** Object:  StoredProcedure [dbo].[Update_Return_Sales_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Return_Sales_Invoice_Data_Set] 
	
	@id INT,
	@payment_method INT, 
	@date DATETIME,
	@details VARCHAR(50),
	@payment_condition_id INT, 
	@customer_id INT, 
	@customer_name VARCHAR(50),
	@account_id INT, 
	@account_number VARCHAR(50),
	@account_name VARCHAR(50),
	@cost_center_number INT,
	@cost_center_id INT,
	@cost_center_name VARCHAR(50),
	@price_include_vat BIT,
	@net_total VARCHAR(50),
	@discount_name VARCHAR(50),
	@discount_percentage VARCHAR(50),
	@discount_not_more VARCHAR(50),
	@total_without_vat VARCHAR(50),
	@total_with_vat VARCHAR(50),
	@vat_amount VARCHAR(50),
	@updated_by INT,
	@enabled_zakat_vat BIT,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY,
	@qrcode IMAGE
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_return_sales WHERE id = @id )
	BEGIN 
		UPDATE invoice_return_sales SET 
			payment_method=@payment_method, 
			[date]=@date,
			details=@details,
			payment_condition_id=@payment_condition_id, 
			customer_id=@customer_id, 
			customer_name=@customer_name,
			account_id=@account_id, 
			account_number=@account_number,
			account_name=@account_name,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by,
			cost_center_id = @cost_center_id,
			enabled_zakat_vat=@enabled_zakat_vat,
			qrcode=@qrcode
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 2 AND  doc_id = @id )
				
				BEGIN
					
					-- UPDATE NEEDED DATA
					UPDATE [dbo].document_details SET
						product_code = items_table_value.product_code, 
						product_name = items_table_value.product_name, 
						unit_price = items_table_value.unit_price, 
						unit_name = items_table_value.unit_name, 
						quantity = items_table_value.quantity, 
						total_price = items_table_value.total_price, 
						doc_id = items_table_value.doc_id, 
						doc_type = items_table_value.doc_type, 
						product_id = items_table_value.product_id, 
						unit_id = items_table_value.unit_id, 
						factor = items_table_value.factor, 
						total_quantity = items_table_value.total_quantity,  
						is_out = items_table_value.is_out, 
						unit_cost = items_table_value.unit_cost, 
						total_cost  = items_table_value.total_cost
					FROM [dbo].document_details
						INNER JOIN @items_table AS items_table_value 
						ON [dbo].document_details.datagrid_id = items_table_value.datagrid_id
						WHERE [dbo].document_details.doc_type = 2 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 2 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type =2 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
				END

					ELSE
				-- INSERT NEW
				BEGIN
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table;
				END

		END

	-- Update Journal Details
	IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN
			
			UPDATE [dbo].journals SET
				
				updated_by = table_value.updated_by,
				[description]  = table_value.[description],
				is_forwarded  = table_value.is_forwarded,
				entry_number = table_value.entry_number,
				updated_date = table_value.updated_date
			FROM [dbo].journals

			INNER JOIN @header_entry AS table_value ON table_value.id = [dbo].journals.id

		END
	
	-- Update Journal Account 
	IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN  
			
			IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
			BEGIN
				DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
			END

			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END

	
	
	
	
	
GO
/****** Object:  StoredProcedure [dbo].[Update_Sale_Invoice_Data_Set]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_Sale_Invoice_Data_Set] 
	
	@id INT,
	@payment_method INT, 
	@date DATETIME,
	@details VARCHAR(50),
	@payment_condition_id INT, 
	@customer_id INT, 
	@customer_name VARCHAR(50),
	@account_id INT, 
	@account_number VARCHAR(50),
	@account_name VARCHAR(50),
	@cost_center_number INT,
	@cost_center_id INT,
	@cost_center_name VARCHAR(50),
	@price_include_vat BIT,
	@net_total VARCHAR(50),
	@discount_name VARCHAR(50),
	@discount_percentage VARCHAR(50),
	@discount_not_more VARCHAR(50),
	@total_without_vat VARCHAR(50),
	@total_with_vat VARCHAR(50),
	@vat_amount VARCHAR(50),
	@updated_by INT,
	@enabled_zakat_vat BIT,
	@qrcode Image,
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY 
AS

	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM invoice_sales WHERE id = @id )
	BEGIN 
		UPDATE invoice_sales SET 
			payment_method=@payment_method, 
			[date]=@date,
			details=@details,
			payment_condition_id=@payment_condition_id, 
			customer_id=@customer_id, 
			customer_name=@customer_name,
			account_id=@account_id, 
			account_number=@account_number,
			account_name=@account_name,
			cost_center_number=@cost_center_number,
			cost_center_name=@cost_center_name,
			price_include_vat=@price_include_vat,
			net_total=@net_total,
			discount_name=@discount_name,
			discount_percentage=@discount_percentage,
			discount_not_more=@discount_not_more,
			total_without_vat=@total_without_vat,
			total_with_vat=@total_with_vat,
			vat_amount=@vat_amount,
			updated_by=@updated_by,
			cost_center_id = @cost_center_id,
			enabled_zakat_vat=@enabled_zakat_vat,
			qrcode = @qrcode
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 0 AND  doc_id = @id )
				
				BEGIN
					
					-- UPDATE NEEDED DATA
					UPDATE [dbo].document_details SET
						product_code = items_table_value.product_code, 
						product_name = items_table_value.product_name, 
						unit_price = items_table_value.unit_price, 
						unit_name = items_table_value.unit_name, 
						quantity = items_table_value.quantity, 
						total_price = items_table_value.total_price, 
						doc_id = items_table_value.doc_id, 
						doc_type = items_table_value.doc_type, 
						product_id = items_table_value.product_id, 
						unit_id = items_table_value.unit_id, 
						factor = items_table_value.factor, 
						total_quantity = items_table_value.total_quantity,  
						is_out = items_table_value.is_out, 
						unit_cost = items_table_value.unit_cost, 
						total_cost  = items_table_value.total_cost
					FROM [dbo].document_details
						INNER JOIN @items_table AS items_table_value 
						ON [dbo].document_details.datagrid_id = items_table_value.datagrid_id
						WHERE [dbo].document_details.doc_type = 0 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 0 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 0 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
				END

					ELSE
				-- INSERT NEW
				BEGIN
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table;
				END

		END

	-- Update Journal Details
	IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN
			
			UPDATE [dbo].journals SET
				
				updated_by = table_value.updated_by,
				[description]  = table_value.[description],
				is_forwarded  = table_value.is_forwarded,
				entry_number = table_value.entry_number,
				updated_date  = table_value.updated_date
			FROM [dbo].journals

			INNER JOIN @header_entry AS table_value ON table_value.id = [dbo].journals.id

		END
	
	-- Update Journal Account 
	IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN  
			
			IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
			BEGIN
				DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
			END

			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END

	













GO
/****** Object:  StoredProcedure [dbo].[Update_Sales_Invoice_Item]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Sales_Invoice_Item]
 
@doc_id INT,
@doc_type INT,
@product_id INT,
@unit_id INT,
@is_out  BIT,
@product_name VARCHAR(50),
@unit_name VARCHAR(50),
@unit_price VARCHAR(50),
@factor VARCHAR(50),
@quantity VARCHAR(50),
@total_quantity VARCHAR(50),
@datagrid_id VARCHAR(50),
@product_code VARCHAR(50),
@total_price VARCHAR(50)

AS

IF NOT EXISTS ( SELECT * FROM document_details WHERE datagrid_id = @datagrid_id AND doc_id = @doc_id AND doc_type=0)
	BEGIN
		INSERT INTO document_details( 
					doc_id,
					doc_type,
					product_id,
					product_name,
					unit_id,
					unit_name,
					unit_price,
					factor,
					quantity,
					total_quantity,
					datagrid_id,
					is_out,
					product_code,
					total_price
				) VALUES(
					@doc_id,
					@doc_type,
					@product_id,
					@product_name,
					@unit_id,
					@unit_name,
					@unit_price,
					@factor,
					@quantity,
					@total_quantity,
					@datagrid_id,
					@is_out,
					@product_code,
					@total_price
				)
	END
		ELSE

	BEGIN
		UPDATE document_details SET  
			product_id=@product_id,
			product_name=@product_name,
			unit_id=@unit_id,
			unit_name=@unit_name,
			unit_price=@unit_price,
			factor=@factor,
			quantity=@quantity,
			total_quantity=@total_quantity,
			total_price=@total_price	
		WHERE datagrid_id = @datagrid_id AND doc_id = @doc_id AND doc_type=0 

	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Settings_System_Logo]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Settings_System_Logo]

@id int, 
@image image

AS 

	IF EXISTS (SELECT * FROM [dbo].settings WHERE id = @id)

		BEGIN
			UPDATE [dbo].settings SET logo=@image WHERE id=@id
		END
GO
/****** Object:  StoredProcedure [dbo].[Update_System_Settings]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_System_Settings] 

@id int,
@establishment_name varchar(50),
@vat_number varchar(50),
@address varchar(50),
@vat_percentage int,
@vat_percentage_value varchar(50),
@product_barcode_type  int,
@enable_delete_invoices bit,
@enable_edit_invoices bit,
@show_address_in_invoice bit,
@created_by_id int, 
@update_by_id int,
@mod_date datetime,
@date_made datetime,
@is_enabled_vat bit,


@cash_account varchar(50),
@bank_account varchar(50),
@sales_account varchar(50),
@sales_vat_account varchar(50),
@purchases_vat_account varchar(50),
@cost_of_goods_account varchar(50),
@inventory_account varchar(50),
@customers_account varchar(50),
@suppliers_account varchar(50),
@return_sales_account varchar(50),
@asset_account varchar(50),
@debits_account varchar(50),
@profits_account varchar(50),
@owners_account varchar(50),
@expenses_account varchar(50)

AS

IF NOT EXISTS ( SELECT * FROM [dbo].settings WHERE id = @id)

	BEGIN
		INSERT INTO [dbo].[settings](

			establishment_name,
			address,
			vat_number,
			vat_percentage,
			vat_value,
			product_barcode_type,
			enable_delete_invoices,
			enable_edit_invoices,
			show_address_in_invoice, 
			created_by_id,
			update_by_id,
			mod_date,
			date_made,
			enabled_vat,


			cash_account,
			bank_account,
			sales_account,
			sales_vat_account,
			purchases_vat_account,
			cost_of_goods_account,
			inventory_account,
			customers_account,
			suppliers_account,
			return_sales_account,
			asset_account,
			debits_account,
			profits_account,
			owners_account,
			expenses_account
		) VALUES(

			@establishment_name,
			@address,
			@vat_number,
			@vat_percentage,
			@vat_percentage_value,
			@product_barcode_type,
			@enable_delete_invoices,
			@enable_edit_invoices,
			@show_address_in_invoice, 
			@created_by_id, 
			@update_by_id,
			@mod_date,
			@date_made,
			@is_enabled_vat,

			@cash_account,
			@bank_account,
			@sales_account,
			@sales_vat_account,
			@purchases_vat_account,
			@cost_of_goods_account,
			@inventory_account,
			@customers_account,
			@suppliers_account,
			@return_sales_account,
			@asset_account,
			@debits_account,
			@profits_account,
			@owners_account,
			@expenses_account
		)
	END

ELSE 
	
	BEGIN
		
		UPDATE [dbo].settings SET
			
			establishment_name = @establishment_name ,
			address = @address,
			vat_number = @vat_number,
			vat_value = @vat_percentage_value,
			vat_percentage = @vat_percentage ,
			product_barcode_type= @product_barcode_type,
			enable_delete_invoices = @enable_delete_invoices,
			enable_edit_invoices = @enable_edit_invoices,
			show_address_in_invoice = @show_address_in_invoice,
			update_by_id=@update_by_id,
			mod_date=@mod_date,
			enabled_vat=@is_enabled_vat,

			cash_account=@cash_account,
			bank_account=@bank_account,
			sales_account=@sales_account,
			sales_vat_account=@sales_vat_account,
			purchases_vat_account=@purchases_vat_account,
			cost_of_goods_account=@cost_of_goods_account,
			inventory_account=@inventory_account,
			customers_account=@customers_account,
			suppliers_account=@suppliers_account,
			return_sales_account=@return_sales_account,
			asset_account=@asset_account,
			debits_account=@debits_account,
			profits_account=@profits_account,
			owners_account=@owners_account,
			expenses_account=@expenses_account
		WHERE id = @id
		 
	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Tree]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Update_Tree]
	@id INT, 
	@parent_id INT,
	@clause_name VARCHAR(50),
	@date_made DATETIME,
	@allowed_control BIT,
	@created_by INT

AS
	
	IF NOT EXISTS ( SELECT * FROM [dbo].[accounting_tree] WHERE id = @id ) 
		BEGIN
			IF EXISTS ( SELECT * FROM [dbo].[accounting_tree] WHERE id = @parent_id ) 

				BEGIN
					INSERT INTO [dbo].[accounting_tree](parent_id, clause_name, date_made, allowed_control, created_by) VALUES(@parent_id, @clause_name, @date_made, @allowed_control, @created_by)
				END
			 
		END
	
	ELSE 
		
		BEGIN 
			UPDATE [dbo].[accounting_tree] SET 
				parent_id = @parent_id,
				clause_name = @clause_name,
				date_made = @date_made,
				allowed_control = @allowed_control,
				created_by = @created_by
			WHERE id = @id 
		END

	SELECT * FROM [dbo].[accounting_tree]

GO
/****** Object:  StoredProcedure [dbo].[Update_Tree_Of_Accounts_TableSet]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_Tree_Of_Accounts_TableSet]

@accounting_tree AS [dbo].Accounting_Tree READONLY

AS

DELETE FROM [dbo].accounts;

IF EXISTS( SELECT 1 FROM @accounting_tree )
	BEGIN 
		INSERT INTO [dbo].accounts(account_number, account_name, main_account, parent_account, account_name_en)
			SELECT account_number, account_name, main_account, parent_account, account_name_en FROM @accounting_tree

	END
GO
/****** Object:  StoredProcedure [dbo].[Update_User_Data]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_User_Data]
	@id INT,
	@username VARCHAR(50),
	@fullname VARCHAR(50),
	@password VARCHAR(50),
	@is_manager BIT
AS 
	IF @id != -1
	BEGIN
		
		UPDATE users SET
			is_manager = @is_manager,
			[password] = @password,
			username   = @username,
			fullname   = @fullname
		WHERE id=@id

	END
		ELSE
	BEGIN
	   
	   INSERT INTO users( is_manager, [password], username, fullname ) VALUES(@is_manager, @password, @username, @fullname);

	END
GO
/****** Object:  StoredProcedure [dbo].[Update_Withdraw_Document]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Update_Withdraw_Document]

	@id int,
	@date_made datetime,
	@details text,
	@account_number varchar(50),
	@account_name varchar(50),
	@total_quantity varchar(50),
	@total_price varchar(50),
	@journal_id int, 
	@items_table AS [dbo].doc_details READONLY,
	@header_entry AS [dbo].journal_header READONLY,
	@details_entry AS [dbo].journal_details READONLY
	

AS
	
	-- Update Invoice Data 
	IF EXISTS ( SELECT * FROM withdraw_document WHERE id = @id )
	BEGIN 
		UPDATE withdraw_document SET 
			date_made = @date_made,
			details = @details,
			account_number = @account_number,
			account_name=@account_name,
			total_quantity=@total_quantity,
			total_price=@total_price
		WHERE id = @id
	END 
		

	-- Update Invoice items WITH Export and Import Data
	IF EXISTS( SELECT 1 FROM @items_table )
		BEGIN 
		
			IF EXISTS( SELECT COUNT(*) FROM [dbo].document_details WHERE doc_type = 6 AND  doc_id = @id )
				
				BEGIN
					
					-- UPDATE NEEDED DATA
					UPDATE [dbo].document_details SET
						product_code = items_table_value.product_code, 
						product_name = items_table_value.product_name, 
						unit_price = items_table_value.unit_price, 
						unit_name = items_table_value.unit_name, 
						quantity = items_table_value.quantity, 
						total_price = items_table_value.total_price, 
						doc_id = items_table_value.doc_id, 
						doc_type = items_table_value.doc_type, 
						product_id = items_table_value.product_id, 
						unit_id = items_table_value.unit_id, 
						factor = items_table_value.factor, 
						total_quantity = items_table_value.total_quantity,  
						is_out = items_table_value.is_out, 
						unit_cost = items_table_value.unit_cost, 
						total_cost  = items_table_value.total_cost
					FROM [dbo].document_details
						INNER JOIN @items_table AS items_table_value 
						ON [dbo].document_details.datagrid_id = items_table_value.datagrid_id
						WHERE [dbo].document_details.doc_type = 6 AND  [dbo].document_details.doc_id = @id
					
					-- INSERT NEW RECORDS
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) 
						SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table 
						WHERE datagrid_id NOT IN ( SELECT datagrid_id FROM [dbo].document_details ) AND doc_type = 6 AND  doc_id = @id;
					
					-- DELETE UNEEDED ROWS
					DELETE FROM [dbo].document_details WHERE doc_type = 6 AND  doc_id = @id AND datagrid_id NOT IN ( SELECT datagrid_id FROM @items_table );
				END

					ELSE
				-- INSERT NEW
				BEGIN
					INSERT INTO [dbo].document_details( product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out, unit_cost, total_cost ) SELECT product_code, product_name, unit_price, unit_name, quantity, total_price, doc_id, doc_type, product_id, unit_id, factor, total_quantity, datagrid_id, is_out,unit_cost, total_cost FROM @items_table;
				END

		END

	-- Update Journal Details
	IF EXISTS( SELECT 1 FROM @header_entry )
		BEGIN
			
			UPDATE [dbo].journals SET
				
				updated_by = table_value.updated_by,
				[description]  = table_value.[description],
				is_forwarded  = table_value.is_forwarded,
				entry_number = table_value.entry_number

			FROM [dbo].journals

			INNER JOIN @header_entry AS table_value ON table_value.id = [dbo].journals.id

		END
	
	-- Update Journal Account 
	IF EXISTS( SELECT 1 FROM @details_entry )
		BEGIN  
			
			IF EXISTS( SELECT COUNT(*) FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry ) )
			BEGIN
				DELETE FROM [dbo].journal_details WHERE journal_id = ( SELECT id FROM @header_entry )
			END

			INSERT INTO [dbo].journal_details(journal_id, debit, credit, [description], cost_center_number, [date], account_number) SELECT journal_id, debit, credit, [description], cost_center_number, [date], account_number FROM @details_entry
		END

	
GO
/****** Object:  StoredProcedure [dbo].[WithdraW_Summery_Report]    Script Date: 6/13/2022 8:18:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[WithdraW_Summery_Report]


@date_from varchar(50),
@date_to varchar(50)


AS

declare @vat_value as decimal(18,2);
set @vat_value = (select CAST(vat_value as decimal(18,2)) from settings where vat_value != ''); 
 

SELECT 
	product_id, 
	name,
	shortcut,
	count(*) 'sale_number', 
	CAST( sum(CAST(total_quantity AS DECIMAL(18,2))) as decimal(18,2)) 'quantity', 
	CAST(sum(CAST(total_price  AS DECIMAL(18,2))) as DECIMAL(18,2)) 'sale_price', 
	CAST(sum(CAST(total_cost  AS DECIMAL(18,2))) as decimal(18,2)) 'cost_price', 
	CAST(( sum(CAST(total_price  AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) as decimal(18,2)) 'net_profit_with_vat',
	CAST(( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) - (( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) / @vat_value) as decimal(18,2)) 'vat_amount',
	CAST(( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) / @vat_value as decimal(18,2)) 'net_profit_without_vat'
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
	CAST(sum(CAST(total_quantity AS DECIMAL(18,2))) as decimal(18,2)) 'quantity', 
	CAST(sum(CAST(total_price AS DECIMAL(18,2))) as decimal(18,2)) 'sale_price', 
	CAST(sum(CAST(total_cost AS DECIMAL(18,2))) as decimal(18,2)) 'cost_price', 
	CAST(( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) as decimal(18,2)) 'net_profit_with_vat',
	CAST(( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) - (( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) / @vat_value) as decimal(8,2)) 'vat_amount',
	CAST( ( sum(CAST(total_price AS DECIMAL(18,2))) - sum(CAST(total_cost AS DECIMAL(18,2)))) / @vat_value  as decimal(18,2))'net_profit_without_vat',
	CAST(@date_from as datetime) 'date_from',
	CAST(@date_to as datetime) 'date_to',
	'تقرير المسحوبات عن الفترة' 'title'
	
FROM document_details 
	INNER JOIN invoice_sales
		ON document_details.doc_id = invoice_sales.id
	WHERE is_out = 1 AND doc_type = 0 AND invoice_sales.date BETWEEN @date_from AND @date_to;
GO
