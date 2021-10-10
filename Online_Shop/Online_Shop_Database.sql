USE [Online_Shop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cart_id] [int] NOT NULL,
	[customer_name] [nvarchar](255) NOT NULL,
	[phone_number] [nvarchar](50) NOT NULL,
	[place_of_receipt] [nvarchar](255) NOT NULL,
	[note] [nvarchar](255) NOT NULL,
	[payment_method] [varchar](100) NOT NULL,
	[total_price] [decimal](18, 0) NOT NULL,
	[delivery_status] [varchar](50) NOT NULL,
	[is_paid] [int] NOT NULL,
	[ship_price] [decimal](18, 0) NOT NULL,
	[created_date] [date] NOT NULL,
	[creator_id] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[created_at] [date] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[short_desc] [varchar](max) NOT NULL,
	[images] [varchar](255) NOT NULL,
	[specs_id] [int] NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
	[promotion_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[cpu] [varchar](100) NOT NULL,
	[gpu] [varchar](100) NOT NULL,
	[screen] [varchar](100) NOT NULL,
	[storage] [varchar](100) NOT NULL,
	[ram] [varchar](100) NOT NULL,
	[os] [varchar](100) NOT NULL,
	[size] [varchar](100) NOT NULL,
	[weight] [varchar](100) NOT NULL,
	[ports] [varchar](100) NOT NULL,
	[connectivity] [varchar](100) NOT NULL,
	[battery] [varchar](100) NOT NULL,
	[extras] [varchar](100) NOT NULL,
	[manufacturer] [varchar](100) NOT NULL,
	[MFG] [date] NOT NULL,
	[quantity] [int] NOT NULL,
	[created_at] [date] NOT NULL,
	[updated_at] [date] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[short_desc] [nvarchar](max) NOT NULL,
	[begin_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[percent_discount] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/10/2021 7:25:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[address] [varchar](255) NOT NULL,
	[avatar] [varchar](255) NOT NULL,
	[gender] [int] NOT NULL,
	[phone_number] [varchar](50) NOT NULL,
	[role_id] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Cart] FOREIGN KEY([cart_id])
REFERENCES [dbo].[Order_Product] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Cart]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([creator_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Products] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Order_Product] CHECK CONSTRAINT [FK_Cart_Products]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([category_id])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Products_Promotions] FOREIGN KEY([promotion_id])
REFERENCES [dbo].[Promotion] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Products_Promotions]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Users_Roles]
GO
