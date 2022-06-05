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
USE [dbtest]
GO
/****** Object:  StoredProcedure [dbo].[table_valued_parameter]    Script Date: 6/5/2022 10:16:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[table_valued_parameter] 

@table_params AS [dbo].[Accounting_Tree] READONLY

 AS 

IF EXISTS( SELECT 1 FROM @table_params )
	BEGIN
		
		-- UPDATE TABLE VALUED PARAMTERS 
		UPDATE [dbo].accounts SET 
			account_name   = udtts.account_name ,
			parent_account = udtts.parent_account
			FROM [dbo].accounts
			INNER JOIN @table_params AS udtts
			ON [dbo].accounts.account_number = udtts.account_number 
		
		-- INSERT NEW RECOREDS TO DATABASE
		INSERT INTO [dbo].accounts(account_name,parent_account,account_number)
			SELECT account_name,parent_account,account_number FROM @table_params
			WHERE account_number NOT IN (SELECT account_number FROM [dbo].accounts )
		
		-- DELETE ROWS FROM DATABASE THAT DOES'NT EXISTS IN @table_params
		DELETE FROM [dbo].accounts 
		WHERE account_number NOT IN (SELECT account_number FROM @table_params )

	END
