USE [OnlineShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Short_desc] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_name] [nvarchar](255) NOT NULL,
	[Phone_number] [nvarchar](255) NOT NULL,
	[Place_of_receipt] [nvarchar](255) NOT NULL,
	[Note] [nvarchar](255) NOT NULL,
	[Payment_method] [nvarchar](255) NOT NULL,
	[Total_Price] [decimal](18, 0) NOT NULL,
	[Status] [nvarchar](255) NOT NULL,
	[Ship_price] [decimal](18, 0) NOT NULL,
	[Created_date] [date] NOT NULL,
	[Promotion_id] [int] NULL,
	[User_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [int] NULL,
	[Product_id] [int] NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Created_at] [date] NOT NULL,
	[User_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Images] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Short_desc] [nvarchar](max) NOT NULL,
	[Created_at] [date] NOT NULL,
	[Updated_at] [date] NOT NULL,
	[Category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotion]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Short_desc] [nvarchar](255) NOT NULL,
	[Begin_date] [date] NOT NULL,
	[End_date] [date] NOT NULL,
	[Percent_discount] [int] NOT NULL,
	[Quantity_left] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spec]    Script Date: 10/27/2021 8:11:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spec](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CPU] [nvarchar](255) NOT NULL,
	[GPU] [nvarchar](255) NOT NULL,
	[Screen] [nvarchar](255) NOT NULL,
	[Ports] [nvarchar](255) NOT NULL,
	[RAM] [nvarchar](255) NOT NULL,
	[Storage] [nvarchar](255) NOT NULL,
	[Connectivity] [nvarchar](255) NOT NULL,
	[Size] [nvarchar](255) NOT NULL,
	[Weight] [nvarchar](255) NOT NULL,
	[Battery] [nvarchar](255) NOT NULL,
	[Manufacturer] [nvarchar](255) NOT NULL,
	[Product_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/27/2021 8:11:12 PM ******/
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
	[Gender] [varchar](100) NOT NULL,
	[Phone_number] [varchar](100) NOT NULL,
	[Role_id] [int] NULL,
	[Dob] [date] NOT NULL,
 CONSTRAINT [PK__User__3214EC0703317E3D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([Promotion_id])
REFERENCES [dbo].[Promotion] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD FOREIGN KEY([Order_id])
REFERENCES [dbo].[Order] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order_Product]  WITH CHECK ADD  CONSTRAINT [FK__Order_Pro__User___21B6055D] FOREIGN KEY([User_id])
REFERENCES [dbo].[User] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Order_Product] CHECK CONSTRAINT [FK__Order_Pro__User___21B6055D]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([Category_id])
REFERENCES [dbo].[Category] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Spec]  WITH CHECK ADD FOREIGN KEY([Product_id])
REFERENCES [dbo].[Product] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK__User__Role_id__0519C6AF] FOREIGN KEY([Role_id])
REFERENCES [dbo].[Role] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK__User__Role_id__0519C6AF]
GO
