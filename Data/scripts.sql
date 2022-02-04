USE [database-88]
GO
/****** Object:  Table [dbo].[accounts]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_number] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[account_name_en] [varchar](50) NULL,
	[main_account] [varchar](50) NULL,
	[debit_credit] [varchar](50) NULL,
	[balance] [varchar](50) NULL,
	[is_main_account] [bit] NULL,
 CONSTRAINT [PK_accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  Table [dbo].[employees]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  Table [dbo].[journals]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[journals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NULL,
	[account_name] [varchar](50) NULL,
	[account_number] [varchar](50) NULL,
	[entry_number] [varchar](50) NULL,
	[date] [date] NULL,
	[datetime] [datetime] NULL,
	[debit] [varchar](50) NULL,
	[credit] [varchar](50) NULL,
 CONSTRAINT [PK_journals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_untis]    Script Date: 2/4/2022 09:20:35 م ******/
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
	[mod_date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 2/4/2022 09:20:35 م ******/
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
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resources]    Script Date: 2/4/2022 09:20:35 م ******/
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
 CONSTRAINT [PK_resources] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[settings]    Script Date: 2/4/2022 09:20:35 م ******/
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
 CONSTRAINT [PK_settings] PRIMARY KEY CLUSTERED 
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
ALTER TABLE [dbo].[products] ADD  CONSTRAINT [DF_products_default_group]  DEFAULT ((0)) FOR [default_group]
GO
ALTER TABLE [dbo].[resources] ADD  CONSTRAINT [DF_resources_resource_type]  DEFAULT ((1)) FOR [resource_type]
GO
/****** Object:  StoredProcedure [dbo].[Backup_Database]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Create_Product_Code]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Create_Resource_Id]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[Create_Resource_Id] 

	@type INT 

AS


IF NOT EXISTS( SELECT * FROM [dbo].[resources] WHERE resource_name = '' ) 
	
	BEGIN

		INSERT INTO [dbo].[resources] ( resource_name ) VALUES( '' )

		UPDATE [dbo].[resources] SET 
			resource_code = ( '1000' + @@Identity  ),
			resource_type = @type
		WHERE id = @@Identity;
	
	END
	 
SELECT TOP 1 * FROM  [dbo].[resources]  WHERE resource_name = ''  ORDER BY  [dbo].[resources].id DESC ; 

GO
/****** Object:  StoredProcedure [dbo].[Create_Tree_Account]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Account_By_Number]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_All_Accounts]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_All_Accounts]

AS

DELETE FROM accounts

GO
/****** Object:  StoredProcedure [dbo].[Delete_Category]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Product_By_Id]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Product_Units]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Resources_Data]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
resource type 0 => Suppliers
resource type 1 => Customers 
*/
create PROC [dbo].[Delete_Resources_Data]
	
	@id INT,
	@type INT
AS

IF EXISTS ( SELECT * FROM [dbo].[resources] WHERE id = @id ) 
	BEGIN
		DELETE FROM [dbo].[resources] WHERE id = @id
	END

SELECT * FROM [dbo].[resources] where resource_type=@type

GO
/****** Object:  StoredProcedure [dbo].[Get_Accounting_Tree]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Accounting_Tree]

AS

SELECT * FROM [dbo].accounts

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Categories]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Categories]

AS


SELECT * FROM [dbo].categories INNER JOIN  [dbo].employees ON [dbo].categories.updated_by = [dbo].employees.id 

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Products]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[Get_All_Products] 


AS

select * from [dbo].products 
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Resources]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_All_Resources]

@type int

AS

SELECT * FROM [dbo].[resources] where resource_type = @type


GO
/****** Object:  StoredProcedure [dbo].[Get_All_Settings]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Settings]

AS

	SELECT * FROM [dbo].settings

GO
/****** Object:  StoredProcedure [dbo].[Get_Product_Units]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[Get_Product_Units]
AS
	SELECT * FROM [dbo].product_untis
GO
/****** Object:  StoredProcedure [dbo].[Get_Tree]    Script Date: 2/4/2022 09:20:35 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Get_Tree]
AS
SELECT * FROM [dbo].[accounting_tree]
GO
/****** Object:  StoredProcedure [dbo].[Installing]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Search_In_Products]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Categories]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Product_DB]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Product_Image]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Product_Units]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Resource_Data]    Script Date: 2/4/2022 09:20:35 م ******/
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
	@updated_by INT

AS 

IF EXISTS ( SELECT * FROM [dbo].[resources] WHERE id = @id )
	
	BEGIN
		
		UPDATE [dbo].[resources] SET  
			resource_name = @resource_name,
			resource_phone = @resource_phone, 
			resource_address = @resource_address, 
			resource_email = @resource_email,
			date_update = @date_update,
			updated_by = @updated_by
		WHERE id = @id

	END

	SELECT * FROM  [dbo].[resources] WHERE resource_type = @type

GO
/****** Object:  StoredProcedure [dbo].[Update_Settings_System_Logo]    Script Date: 2/4/2022 09:20:35 م ******/
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
/****** Object:  StoredProcedure [dbo].[Update_System_Settings]    Script Date: 2/4/2022 09:20:35 م ******/
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
@is_enabled_vat bit
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
			enabled_vat
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
			@is_enabled_vat
		
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
			enabled_vat=@is_enabled_vat

		WHERE id = @id
		 
	END

GO
/****** Object:  StoredProcedure [dbo].[Update_Tree]    Script Date: 2/4/2022 09:20:35 م ******/
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
