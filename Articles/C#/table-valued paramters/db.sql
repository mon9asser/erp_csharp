USE [dbtest]
GO

/****** Object:  Table [dbo].[accounts]    Script Date: 6/4/2022 2:22:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[accounts](
	[id] [int] NULL,
	[account_name] [varchar](50) NULL,
	[account_number] [varchar](50) NULL,
	[parent_account] [varchar](50) NULL
) ON [PRIMARY]
GO



----------------------------------------------
USE [dbtest]
GO

/****** Object:  UserDefinedTableType [dbo].[Accounting_Tree]    Script Date: 6/4/2022 2:22:09 PM ******/
CREATE TYPE [dbo].[Accounting_Tree] AS TABLE(
	[account_name] [varchar](50) NULL,
	[account_number] [varchar](50) NULL,
	[parent_account] [varchar](50) NULL
)
GO



--------------------------------------------
create PROC table_valued_parameter 

@table_params AS [dbo].[Accounting_Tree] READONLY

 AS 

IF EXISTS( SELECT 1 FROM @table_params )
	BEGIN
		INSERT INTO accounts (account_name, account_number, parent_account ) SELECT account_name, account_number, parent_account FROM @table_params  
	END
