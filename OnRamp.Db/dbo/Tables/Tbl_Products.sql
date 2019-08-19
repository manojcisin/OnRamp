CREATE TABLE [dbo].[Tbl_Products](
	[Product_Barcode] [int] IDENTITY(1,1) NOT NULL,
	[Product_Category_ID] [int] NOT NULL,
	[Product_Name] [varchar](150) NOT NULL,
	[Product_Date_Captured] [datetime] NOT NULL,
	[Supplier_ID] [int] NOT NULL,
	[Product_Location] [varchar](200) NULL,
	[Product_Warranty] [int] NULL,
	[Product_Status] [int] NULL,
 CONSTRAINT [PK_Tbl_Products] PRIMARY KEY CLUSTERED 
(
	[Product_Barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_Products]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Products_Tbl_Product_Category] FOREIGN KEY([Product_Category_ID])
REFERENCES [dbo].[Tbl_Product_Category] ([Category_ID])
GO

ALTER TABLE [dbo].[Tbl_Products] CHECK CONSTRAINT [FK_Tbl_Products_Tbl_Product_Category]
GO


GO
ALTER TABLE [dbo].[Tbl_Products]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Products_Tbl_Suppliers] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Tbl_Suppliers] ([Supplier_ID])
GO

ALTER TABLE [dbo].[Tbl_Products] CHECK CONSTRAINT [FK_Tbl_Products_Tbl_Suppliers]
GO

