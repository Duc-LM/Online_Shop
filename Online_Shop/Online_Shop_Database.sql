USE [Online_Shop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Short_desc] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cart_id] [int] NOT NULL,
	[Customer_name] [nvarchar](255) NOT NULL,
	[Phone_number] [nvarchar](50) NOT NULL,
	[Place_of_receipt] [nvarchar](255) NOT NULL,
	[Note] [nvarchar](255) NOT NULL,
	[Payment_method] [nvarchar](100) NOT NULL,
	[Total_price] [decimal](18, 0) NOT NULL,
	[Delivery_status] [varchar](255) NOT NULL,
	[Is_paid] [int] NOT NULL,
	[Ship_price] [decimal](18, 0) NOT NULL,
	[Created_date] [date] NOT NULL,
	[Creator_id] [int] NULL,
	[Promotion_id] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [int] NULL,
	[Product_id] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Created_at] [date] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Images] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Short_desc] [nvarchar](max) NOT NULL,
	[Created_at] [date] NOT NULL,
	[Updated_at] [date] NOT NULL,
	[Category_id] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Short_desc] [nvarchar](max) NOT NULL,
	[Begin_date] [date] NOT NULL,
	[End_date] [date] NOT NULL,
	[Percent_discount] [int] NOT NULL,
	[Quantity_left] [int] NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spec]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spec](
	[Id] [int] NULL,
	[CPU] [nvarchar](255) NOT NULL,
	[GPU] [nvarchar](255) NOT NULL,
	[Screen] [nvarchar](255) NOT NULL,
	[Ports] [nvarchar](255) NOT NULL,
	[RAM] [nvarchar](255) NOT NULL,
	[Storage] [nvarchar](255) NOT NULL,
	[Connectivity] [nvarchar](255) NOT NULL,
	[Size] [nvarchar](255) NOT NULL,
	[Weight] [nvarchar](100) NOT NULL,
	[Battery] [nvarchar](100) NOT NULL,
	[Manufacturer] [nvarchar](100) NOT NULL,
	[Product_id] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/12/2021 4:12:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_name] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](255) NOT NULL,
	[Avatar] [nvarchar](max) NOT NULL,
	[Gender] [int] NOT NULL,
	[Phone_number] [varchar](50) NOT NULL,
	[Role_id] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Promotion] FOREIGN KEY([Promotion_id])
REFERENCES [dbo].[Promotion] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Promotion]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Cart] FOREIGN KEY([Cart_id])
REFERENCES [dbo].[Order_Product] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Cart]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([Creator_id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product_Product] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Order_Product] CHECK CONSTRAINT [FK_Order_Product_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category_id])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Spec]  WITH CHECK ADD  CONSTRAINT [FK_Spec_Product] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Spec] CHECK CONSTRAINT [FK_Spec_Product]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([Role_id])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Users_Roles]
GO
