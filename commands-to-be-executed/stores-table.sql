USE [zakat_invoices]
GO

/****** Object:  Table [dbo].[stores]    Script Date: 4/24/2022 5:19:47 PM ******/
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
	[cost_center_id] [int] NULL,
	
	[updated_by] [int] NULL,
	[created_by] [int] NULL,
	[datemade] [datetime] NULL,
 CONSTRAINT [PK_stores] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


-----------------------------------------------------------------------------------------------------
ALTER PROC Create_Store_Id

AS

DECLARE @StoreId AS VARCHAR(50);
SET @StoreId = (SELECT id FROM [dbo].stores); 

	IF NOT EXISTS( SELECT * FROM [dbo].stores WHERE store_name = '' ) 
		BEGIN
			
			INSERT INTO [dbo].stores ( store_name ) VALUES( '' );

			UPDATE [dbo].stores SET 
				code = CONCAT( @StoreId , '00', @@Identity )
			WHERE id = @@Identity;
			 
		END

	SELECT TOP 1 * FROM  [dbo].stores  WHERE store_name = ''  ORDER BY  [dbo].stores.id DESC ; 