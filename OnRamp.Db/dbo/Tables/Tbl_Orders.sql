CREATE TABLE [dbo].[Tbl_Orders](
	[Order_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Product_Barcode] [int] NOT NULL,
	[Supplier_ID] [int] NOT NULL,
	[Date_Sold] [datetime] NOT NULL,
	[Payment_Received] [bit] NOT NULL CONSTRAINT [DF_Tbl_Orders_Payment_Received]  DEFAULT ((0)),
 CONSTRAINT [PK_Tbl_Orders] PRIMARY KEY CLUSTERED 
(
	[Order_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tbl_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Orders_Tbl_Customers] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Tbl_Customers] ([Customer_ID])
GO

ALTER TABLE [dbo].[Tbl_Orders] CHECK CONSTRAINT [FK_Tbl_Orders_Tbl_Customers]
GO


GO
ALTER TABLE [dbo].[Tbl_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Orders_Tbl_Product] FOREIGN KEY([Product_Barcode])
REFERENCES [dbo].[Tbl_Products] ([Product_Barcode])
GO

ALTER TABLE [dbo].[Tbl_Orders] CHECK CONSTRAINT [FK_Tbl_Orders_Tbl_Product]
GO
ALTER TABLE [dbo].[Tbl_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Orders_Tbl_Suppliers] FOREIGN KEY([Supplier_ID])
REFERENCES [dbo].[Tbl_Suppliers] ([Supplier_ID])
GO

ALTER TABLE [dbo].[Tbl_Orders] CHECK CONSTRAINT [FK_Tbl_Orders_Tbl_Suppliers]
