USE [database-88]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  Table [dbo].[employees]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  Table [dbo].[settings]    Script Date: 1/10/2022 12:51:07 AM ******/
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
 CONSTRAINT [PK_settings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_permission_id]  DEFAULT ((0)) FOR [permission_id]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_current_language]  DEFAULT ('ar') FOR [current_language]
GO
/****** Object:  StoredProcedure [dbo].[Backup_Database]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Delete_Category]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Get_All_Categories]    Script Date: 1/10/2022 12:51:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Categories]

AS


SELECT * FROM [dbo].categories INNER JOIN  [dbo].employees ON [dbo].categories.updated_by = [dbo].employees.id 

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Settings]    Script Date: 1/10/2022 12:51:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_All_Settings]

AS

	SELECT * FROM [dbo].settings

GO
/****** Object:  StoredProcedure [dbo].[Installing]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Categories]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Settings_System_Logo]    Script Date: 1/10/2022 12:51:07 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Update_System_Settings]    Script Date: 1/10/2022 12:51:07 AM ******/
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
@date_made datetime

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
			date_made

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
			@date_made
		
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
			mod_date=@mod_date
			
		WHERE id = @id
		 
	END

GO
