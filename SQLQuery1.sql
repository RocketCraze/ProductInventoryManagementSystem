USE [ProductInventory]

CREATE TABLE [dbo].[ProductInventory](
	[pkProductID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Make] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Description] [text] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [int] NOT NULL
)