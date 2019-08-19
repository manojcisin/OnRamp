CREATE TABLE [dbo].[Tbl_Customers](
	[Customer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [varchar](100) NOT NULL,
	[Customer_Email] [varchar](100) NULL,
	[Customer_Telephone_Number] [varchar](15) NULL,
 CONSTRAINT [PK_Tbl_Customers] PRIMARY KEY CLUSTERED 
(
	[Customer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]