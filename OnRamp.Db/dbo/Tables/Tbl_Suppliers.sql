CREATE TABLE [dbo].[Tbl_Suppliers](
	[Supplier_ID] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_Name] [varchar](100) NOT NULL,
	[Supplier_Email] [varchar](50) NULL,
	[Supplier_Telephone_Number] [varchar](15) NULL,
 CONSTRAINT [PK_Tbl_Suppliers] PRIMARY KEY CLUSTERED 
(
	[Supplier_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]