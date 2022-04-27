/****** Object:  UserDefinedTableType [dbo].[Accounting_Tree]    Script Date: 4/27/2022 5:01:10 PM ******/
CREATE TYPE [dbo].[Accounting_Tree] AS TABLE(
	[account_number] [varchar](50) NULL,
	[account_name] text NULL,
	[main_account] [varchar](50) NULL
)
GO

--===========================================================
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

ALTER TABLE [dbo].[accounts] ADD  CONSTRAINT [DF_accounts_is_main_account]  DEFAULT ((0)) FOR [is_main_account]
GO
