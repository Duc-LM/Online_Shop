USE [OnlineShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/4/2021 9:13:01 PM ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 11/4/2021 9:13:02 PM ******/
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
/****** Object:  Table [dbo].[Order_Product]    Script Date: 11/4/2021 9:13:02 PM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 11/4/2021 9:13:02 PM ******/
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
/****** Object:  Table [dbo].[Promotion]    Script Date: 11/4/2021 9:13:02 PM ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 11/4/2021 9:13:02 PM ******/
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
/****** Object:  Table [dbo].[Spec]    Script Date: 11/4/2021 9:13:02 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 11/4/2021 9:13:02 PM ******/
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
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Short_desc]) VALUES (1, N'Laptop', N'Laptop')
INSERT [dbo].[Category] ([Id], [Name], [Short_desc]) VALUES (2, N'PC', N'PC All in one')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Customer_name], [Phone_number], [Place_of_receipt], [Note], [Payment_method], [Total_Price], [Status], [Ship_price], [Created_date], [Promotion_id], [User_id]) VALUES (1, N'Le Quyet', N'0966396695', N'475 TL 417 Street, Thọ Xuân, Đan Phượng, Hà Nội', N'', N'Cash On Delivery', CAST(4080 AS Decimal(18, 0)), N'Pending', CAST(80 AS Decimal(18, 0)), CAST(N'2021-10-31' AS Date), 4, NULL)
INSERT [dbo].[Order] ([Id], [Customer_name], [Phone_number], [Place_of_receipt], [Note], [Payment_method], [Total_Price], [Status], [Ship_price], [Created_date], [Promotion_id], [User_id]) VALUES (2, N'Trung Thanh Vu', N'0915595489', N'63G Hẻm 29 / 70 / 2 Tổ 5 Cụm 4 Khương Hạ Khương Đình Thanh Xuân Hà Nội', N'', N'Cash On Delivery', CAST(6510 AS Decimal(18, 0)), N'Delivering', CAST(10 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4, 4)
INSERT [dbo].[Order] ([Id], [Customer_name], [Phone_number], [Place_of_receipt], [Note], [Payment_method], [Total_Price], [Status], [Ship_price], [Created_date], [Promotion_id], [User_id]) VALUES (3, N'Le Quyet', N'0966396695', N'475 TL 417 Street, Thọ Xuân, Đan Phượng, Hà Nội', N'', N'Cash On Delivery', CAST(4010 AS Decimal(18, 0)), N'Completed', CAST(10 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4, 1)
INSERT [dbo].[Order] ([Id], [Customer_name], [Phone_number], [Place_of_receipt], [Note], [Payment_method], [Total_Price], [Status], [Ship_price], [Created_date], [Promotion_id], [User_id]) VALUES (4, N'Trung Thanh Vu', N'0915595489', N'63G Hẻm 29 / 70 / 2 Tổ 5 Cụm 4 Khương Hạ Khương Đình Thanh Xuân Hà Nội', N'', N'Cash On Delivery', CAST(5010 AS Decimal(18, 0)), N'Pending', CAST(10 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4, 4)
INSERT [dbo].[Order] ([Id], [Customer_name], [Phone_number], [Place_of_receipt], [Note], [Payment_method], [Total_Price], [Status], [Ship_price], [Created_date], [Promotion_id], [User_id]) VALUES (5, N'Trung Thanh Vu', N'0915595489', N'63G Hẻm 29 / 70 / 2 Tổ 5 Cụm 4 Khương Hạ Khương Đình Thanh Xuân Hà Nội', N'', N'Cash On Delivery', CAST(4060 AS Decimal(18, 0)), N'Pending', CAST(10 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4, 4)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Order_Product] ON 

INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (1, 1, 1, 2, CAST(4000 AS Decimal(18, 0)), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (2, 2, 2, 1, CAST(4000 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (3, 2, 3, 1, CAST(1000 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (4, 2, 7, 1, CAST(800 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (5, 2, 5, 1, CAST(700 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (6, 3, 2, 1, CAST(4000 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 1)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (7, 4, 2, 1, CAST(4000 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (8, 4, 3, 1, CAST(1000 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (9, 5, 8, 1, CAST(750 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (10, 5, 7, 1, CAST(800 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
INSERT [dbo].[Order_Product] ([Id], [Order_id], [Product_id], [Quantity], [Price], [Created_at], [User_id]) VALUES (11, 5, 9, 1, CAST(2500 AS Decimal(18, 0)), CAST(N'2021-11-01' AS Date), 4)
SET IDENTITY_INSERT [dbo].[Order_Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (1, N'Laptop Asus ROG Strix G15 G513IC-HN002T', N'139084_38852_20439_laptop_asus_rog_strix_g15_g513ih_hn015t_4.jpg;139084_38852_20439_laptop_asus_rog_strix_g15_g513ih_hn015t_5.jpg;139084_38852_20439_laptop_asus_rog_strix_g15_g513ih_hn015t_6.jpg;', CAST(2000 AS Decimal(18, 0)), 98, N'Ryzen 7-4800H | 8GB | 512GB | RTX 3050 4GB | 15.6 inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (2, N'Laptop Asus ROG Zephyrus G14 GA401QM-K2041T', N'237168_37168_g14_grey_03_light_2021.png;237168_g14_grey_12_2021.png;237168_g14_grey_15_2021.png;', CAST(4000 AS Decimal(18, 0)), 97, N'AMD Ryzen™ 9-5900HS|32GB|1TB M2NVMe PCIe|RTX 3060 6GB GDDR6 ', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (3, N'Laptop Asus ZenBook 13 UX325EA-KG363T', N'338805_copy_of_zenbook_13_oled_ux325_product_photo_2g_pine_grey_07_numberpad__1_.jpg;338805_copy_of_zenbook_13_ux325_product_photo_2g_pine_grey_04_2000x2000.png;338805_copy_of_zenbook_13_ux325_product_photo_2g_pine_grey_11_2000x2000.png;', CAST(1000 AS Decimal(18, 0)), 998, N'Core™ i5-1135G7 | 8GB | 512GB | Intel Iris Xe | 13.3 inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (4, N'Laptop Asus TUF Gaming A15 FA506QR-AZ003T', N'438856_20446_laptop_asus_tuf_gaming_a15_fa506qr_az003t_1.jpg;438856_20446_laptop_asus_tuf_gaming_a15_fa506qr_az003t_6.jpg;438856_20446_laptop_asus_tuf_gaming_a15_fa506qr_az003t_7.jpg;', CAST(1800 AS Decimal(18, 0)), 100, N'Ryzen 7-5800H | 16GB | 512GB | RTX™ 3070 8GB | 15.6 inch FHD | Win 10 | Eclipse Gray', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (5, N'Laptop Asus ExpertBook P2451FA-EK1623T', N'539095_nbas1043__19_.jpg;539095_nbas1043__26_.jpg;539095_nbas1043__27_.jpg;', CAST(700 AS Decimal(18, 0)), 99, N'Core™ i3-10110U | 4GB | 512GB | Intel UHD | 14.0 inch FHD | Free Dos', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (6, N'Laptop Asus ROG Zephyrus G14 GA401QEC-K2064T', N'638880_3_108__1_.jpg;638880_4_108.jpg;638880_product_photos_g14.png;', CAST(2000 AS Decimal(18, 0)), 100, N'Ryzen 9-5900HS | 16GB | 1TB | RTX™ 3050 Ti 4GB | 14.0 inch QHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (7, N'Laptop Asus Vivobook X515EA-BQ1006T', N'738779_37081_36960_637502180353357853_asus_vivobook_x515_print_bac_2.jpg;738779_37081_36960_637502180353514102_asus_vivobook_x515_print_bac_3.jpg;738779_37081_36960_637502180353670464_asus_vivobook_x515_print_bac_1.jpg;', CAST(800 AS Decimal(18, 0)), 98, N'Core i3-1115G4 | 4GB | 512GB | Intel UHD | 15.6-inch FHD | Win 10 | Silver', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (8, N'Laptop Asus X415EA-EK560T Window 11', N'839408_20470_laptop_asus_vivobook_14_x415ea_ek560t_1.jpg;839408_20470_laptop_asus_vivobook_14_x415ea_ek560t_5.jpg;839408_20470_laptop_asus_vivobook_14_x415ea_ek560t_6.jpg;', CAST(750 AS Decimal(18, 0)), 99, N'Core™ i3-1115G4 | 4GB | 256GB | Intel® UHD | 14.0-inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (9, N'Laptop Asus ROG Strix SCAR 15 G533QR-HQ098T', N'937627_36517_02_scar_15_l.png;937627_36517_11_scar_15_l.png;937627_36517_12_scar_15_l.png;', CAST(2500 AS Decimal(18, 0)), 99, N'Ryzen 9-5900HX | 16GB | 1TB SSD | RTX 3070 8GB | 15.6 WQHD | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (10, N'Laptop Asus ROG Zephyrus G14 GA401QC-HZ100T', N'1038935_37956_h732__6_.png;1038935_37956_h732__7_.png;1038935_37956_h732__8_.png;', CAST(1800 AS Decimal(18, 0)), 100, N'Ryzen 9-5900HS | 16GB | 512GB | RTX 3050 4GB | 14.0 inch FHD | Win 10 | White', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (11, N'Laptop Dell Latitude 3420 L3420I5SSD', N'1138241_38188_screenshot_6.png;1138241_38188_screenshot_7.png;1138241_38188_screenshot_8.png;', CAST(1850 AS Decimal(18, 0)), 100, N'Core i5-1135G7 | 8GB | 256GB | Intel Iris Xe | 14.0 inch HD | Fedora | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (12, N'Laptop Dell Vostro 3405 V4R53500U003W', N'1234997_34994_vos_3405.png;1234997_34994_vos_3405_1.png;1234997_34994_vos_3405_2.png;', CAST(1700 AS Decimal(18, 0)), 100, N'Ryzen™ 5-3500U | 8GB | 512GB | AMD Radeon | 14.0 inch FHD | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (13, N'Laptop Dell Inspiron N5515A P106F003ASL', N'1339627_20777_laptop_dell_inspiron_5515_p106f003asl_0.jpg;1339627_20777_laptop_dell_inspiron_5515_p106f003asl_2.jpg;1339627_20777_laptop_dell_inspiron_5515_p106f003asl_3.jpg;', CAST(1800 AS Decimal(18, 0)), 100, N'Ryzen™ 5-5500U | 8GB | 256GB | AMD Redeon | 15.6 inch FHD | Win 10 | Office', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (14, N'Laptop Dell Mobile Precision 3561', N'1439341_dell_x2cnd_precision_3561_g11_i7_11800h_1652898.jpg;', CAST(1900 AS Decimal(18, 0)), 10, N'Core i7-11850H | 16GB | 256GB | T600 4GB | 15.6 inch FHD | Ubuntu Linux', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (15, N'Laptop Dell Vostro 3400 70253900', N'1539197_44234_vostro_3400_ha1.jpg;1539197_44234_vostro_3400_ha4.jpg;1539197_44234_vostro_3400_ha5.jpg;', CAST(950 AS Decimal(18, 0)), 15, N'Core™ i5-1135G7 | 8GB | 256GB | Intel Iris Xe | 14.0-inch FHD | Win 10 | Office', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (16, N'Laptop Dell Vostro 5510 70266006', N'1639413_39195_202195b_1.jpg;1639413_39195_202195c.jpg;1639413_39195_202195e.jpg;', CAST(1000 AS Decimal(18, 0)), 20, N'Core™ i5-11320H | 8GB | 512GB | Intel Iris Xe | 15.6-inch FHD | Win 10 | Office | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (17, N'Laptop Dell Inspiron N3511B P112F001BBL', N'1739309_20677_laptop_dell_inspiron_3511_p112f001abl_2.jpg;1739309_20677_laptop_dell_inspiron_3511_p112f001abl_5.jpg;', CAST(900 AS Decimal(18, 0)), 15, N'Core™ i5-1135G7 | 4GB | 512GB | Intel UHD | 15.6-inch FHD | Win 10 | Office | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (18, N'Laptop Dell Inspiron 5301 70232601', N'1835602_1.jpg;1835602_2.jpg;1835602_3.jpg;', CAST(1100 AS Decimal(18, 0)), 15, N'Intel Core i7-1165G7|8G|512GB|MX350 2GB| 13.1inch', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (19, N'Laptop Dell Latitude 7420 70251597', N'1938285_aeih_3.jpg;1938285_kfdfk_3.jpg;1938285_klhdkfh_3.jpg;', CAST(1700 AS Decimal(18, 0)), 25, N'Core i7-1185G7 | 16GB | 256GB | Intel Iris Xe | 14.0 inch FHD | Ubuntu | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (20, N'Laptop Dell XPS 13 9310 7026293', N'2039191_38908_37079_35575_56720_xps9310__1_.png;2039191_38908_37079_35575_56720_xps9310__3_.png;', CAST(1900 AS Decimal(18, 0)), 5, N'Core i5-1135G7 | 8GB | 256GB | Intel® Iris® Xe | 13.4-inch FHD | Cảm ứng | Win 10 | Silver', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (21, N'Laptop HP ZBook Firefly 14 G8 Mobile Workstation 1A2F1AV', N'2138915_left_rear_facing.png;2138915_right_facing.png;', CAST(1500 AS Decimal(18, 0)), 12, N'Core i5-1135G7 | 16GB | 512GB | Intel Iris Xe | 14 inch FHD | Win 10 Pro | Silver', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (22, N'Laptop HP 15s-du1105TU 2Z6L3PA', N'2239303_36277_18921_laptop_hp_15s_du1055tu_1w7p3pa_1.png;2239303_36277_18921_laptop_hp_15s_du1055tu_1w7p3pa_3.png;2239303_36277_18921_laptop_hp_15s_du1055tu_1w7p3pa_4.png;', CAST(550 AS Decimal(18, 0)), 10, N'Core™ i3-10110U | 4GB | 256GB | Intel® UHD | 15.6 inch HD | Win 10 | Bạc', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (23, N'Laptop HP 240 G8 519A7PA', N'2339544_laptop_hp_240_g8_518v6pa_bac_108172.jpg;2339544_laptop_hp_240_g8_518v6pa_bac_108173.jpg;', CAST(600 AS Decimal(18, 0)), 13, N'Core™ i3-1005G1 | 4GB | 256GB | Intel® UHD | 14 inch FHD | Win 10 | Silver', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (24, N'Laptop HP Pavilion 15-eg0542TU 4P5G9PA', N'2439541_38773_laptop_hp_pavilion_15_eg_sv_4_1.jpg;2439541_38773_laptop_hp_pavilion_15_eg_sv_5_1.jpg;2439541_screenshot_3.png;', CAST(700 AS Decimal(18, 0)), 15, N'Core i3-1125G4 | 4GB | 256GB | Intel® UHD | 15.6 inch FHD | Win 11 | Silver', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (25, N'Laptop HP VICTUS 16-e0175AX 4R0U8PA', N'2538974_hp_victus_16_e0177ax__4r0u9pa__0e86783a258e41158d56b1f7b51b030d_master.png;2538974_hp_victus_16_e0177ax__4r0u9pa__2_2108639a998646bf88b02a30608d851b_master.png;2538974_hp_victus_16_e0177ax__4r0u9pa__3_77258bdcda35478489d879efdf3c778a_master.png;', CAST(1000 AS Decimal(18, 0)), 20, N'Ryzen™ 5-5600H | 8GB | 512GB SSD | RTX 3050 4GB | 16.1 inch FHD | Win 10', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (26, N'Laptop HP OMEN 16-b0142TX 4Y0Z8PA ', N'2638971_38965_left_facing.png;2638971_38965_left_rear_facing.png;2638971_38965_right_facing.png;', CAST(1750 AS Decimal(18, 0)), 20, N'Core i5-11400H | 16GB | 1TB SSD + 32GB SSD | RTX 3050Ti 4GB | 16.1 inch FHD | Win 10 | Shadow Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (27, N'Laptop HP Pavilion 15-eg0504TU 46M00PA', N'2738360_37188_18784_laptop_hp_pavilion_15_eg0072tu_2p1n3pa_2.png;2738360_37188_18784_laptop_hp_pavilion_15_eg0072tu_2p1n3pa_3.png;2738360_37188_18784_laptop_hp_pavilion_15_eg0072tu_2p1n3pa_4.png;', CAST(1000 AS Decimal(18, 0)), 15, N'Core i7-1165G7 | 8GB | 512GB | Intel Iris Xe | 15.6 inch FHD | Win 10 | Gold', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (28, N'Laptop HP Pavilion 14-dv0534TU 4P5G3PA', N'2838863_laptop_hp_pavilion_14_dv0534tu_4p5g3pa.png;2838863_laptop_hp_pavilion_14_dv0534tu_4p5g3pa_core_i7_1165g7.png;2838863_laptop_hp_pavilion_14_dv0534tu_4p5g3pa_core_i7_1165g7_chinh_hang.png;', CAST(999 AS Decimal(18, 0)), 120, N'Core i7-1165G7 | 8GB | 512GB | Intel Iris Xe | 14 Inch FHD | Win 11 | Warm Gold', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (29, N'Laptop HP 340s G7 36A37PA', N'2937151_37060_34459_18191_hp_340s_g7_224l0pa_1.jpg;2937151_37060_34459_18191_hp_340s_g7_224l0pa_2.jpg;2937151_37060_34459_18191_hp_340s_g7_224l0pa_3.jpg;', CAST(950 AS Decimal(18, 0)), 12, N'Core i7-1065G7 | 8GB | 512GB | Intel Iris Plus | 14.0 inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (30, N'Laptop HP Probook 430 G8 2H0N9PA', N'3037549_37305_18780_018780_laptop_hp_probook_430_g8_348d6pa_3.jpg;3037549_37305_18780_018780_laptop_hp_probook_430_g8_348d6pa_4.jpg;', CAST(900 AS Decimal(18, 0)), 25, N'Core i5-1135G7 | 8GB | 512GB | Intel Iris Xe | 13.3 inch FHD | Win 10 | Silver', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (31, N'Laptop Acer Swift X SFX14-41G-R61A NX.AU3SV.001', N'3138742_1.jpg;3138742_5.jpg;3138742_8.jpg;', CAST(1200 AS Decimal(18, 0)), 10, N'Ryzen 5-5600U | 16GB | 1TB | RTX 3050Ti 4GB | 14.0 inch FHD | Win 10 | Safari Gold', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (32, N'Laptop Acer Nitro 5 Eagle AN515-57-54MV NH.QENSV.003', N'3239172_38371_3.jpg;3239172_38371_4.jpg;3239172_38371_5.jpg;', CAST(1100 AS Decimal(18, 0)), 15, N'Core i5-11400H | 8GB | 512GB | RTX™ 3050 4GB | 15.6 inch FHD | Win 11 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (33, N'Laptop Acer Nitro 5 AN515-57-77KU NH.QDGSV.001', N'3339172_38371_3.jpg;3339172_38371_4.jpg;3339172_38371_5.jpg;', CAST(1750 AS Decimal(18, 0)), 5, N'Core i7-11800H | 16GB | 512GB | RTX 3060 6GB | 15.6 inch QHD | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (34, N'Laptop Acer Gaming Aspire 7 A715-42G-R1SB NH.QAYSV.005', N'3439301_20703_laptop_acer_gaming_aspire_7_a715_42g_r6zr_3.jpg;3439301_20703_laptop_acer_gaming_aspire_7_a715_42g_r6zr_4.jpg;3439301_20703_laptop_acer_gaming_aspire_7_a715_42g_r6zr_5.jpg;', CAST(999 AS Decimal(18, 0)), 10, N'Ryzen R5-5500U | 8GB | 256GB | GTX 1650 4GB | GTX 1650 4GB | 15.6 inch FHD | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (35, N'Laptop Acer Aspire 3 A315-56-502X NX.HS5SV.00F', N'3535530_32141_acer_aspire_3_a315_56_black_gallery_03.png;3535530_32141_acer_aspire_3_a315_56_black_gallery_04.png;3535530_32141_acer_aspire_3_a315_56_black_gallery_06.png;3535530_laptop_acer_aspire_3_a315_56_502x_nx_hs5sv_00f_11.jpg;', CAST(600 AS Decimal(18, 0)), 15, N'Core™ i5-1035G1|4G|256Gb|Intel UHD| 15.6 Inch', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (36, N'Laptop Lenovo Ideapad 3 81WH', N'3639233_ideapad_3_14igl05_ct1_01.png;3639233_ideapad_3_14igl05_ct2_01.png;3639233_ideapad_3_14igl05_ct2_02.png;', CAST(450 AS Decimal(18, 0)), 10, N'Pentium® Silver N5030 | 4GB | 128GB | Intel UHD | 14 inch HD | Win 10 |', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (37, N'Laptop Lenovo Legion 5 Pro 16ACH6H 82JQ005YVN', N'3737173_lenovo_legion_5_pro_16ach6h_ct1_02.png;3737173_lenovo_legion_5_pro_16ach6h_ct2_02.png;3737173_lenovo_legion_5_pro_16ach6h_ct2_04.png;', CAST(2300 AS Decimal(18, 0)), 50, N'Ryzen 7-5800H | 16GB | 1TB SSD | RTX 3070 8GB | 16.0 inch WQXGA | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (38, N'Laptop Lenovo ThinkBook 15 G2 ITL 20VE0040VN', N'3837622_thinkbook_15_g2_itl_ct1_02.png;3837622_thinkbook_15_g2_itl_ct1_03.png;3837622_thinkbook_15_g2_itl_ct1_06.png;', CAST(1050 AS Decimal(18, 0)), 30, N'Core i7-1165G7 | 8GB | 512GB | MX450 2GB | 15.6 inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (39, N'Laptop Lenovo Yoga Slim 7 14ITL05 82A3004FVN', N'3935130_18487_lenovo_yoga_slim_7_14itl05_82a3002qvn_4.jpg;3935130_18487_lenovo_yoga_slim_7_14itl05_82a3002qvn_5.jpg;3935130_18487_lenovo_yoga_slim_7_14itl05_82a3002qvn_6.jpg;', CAST(1100 AS Decimal(18, 0)), 35, N'Intel® Core™ i7-1165G7|8GB|512GB|Intel Iris | 14.0 Inch', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (40, N'Laptop Lenovo Thinkpad X13 Gen 2 20WK00CUVA', N'4039088_thinkpad_x13_gen_2_intel_ct1_02.png;4039088_thinkpad_x13_gen_2_intel_ct2_04.png;4039088_thinkpad_x13_gen_2_intel_ct2_06.png;', CAST(1700 AS Decimal(18, 0)), 25, N'Core i7-1165G7 | 8GB | 512GB | Intel Iris Xe | 13.3 inch WQXGA | FreeDos | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (41, N'Laptop Lenovo ThinkPad L13 Gen 2 20VH0049VA', N'4139612_39523_thinkpad_l13_gen_2_intel_ct1_07.png;4139612_39523_thinkpad_l13_gen_2_intel_ct2_02.png;4139612_39523_thinkpad_l13_gen_2_intel_ct2_04.png;', CAST(1080 AS Decimal(18, 0)), 25, N'Core™ i5-1135G7 | 8GB | 512GB | Intel Iris Xe | 13.3 inch FHD | FreeDos | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (42, N'Laptop Lenovo V15 G2 ITL 82KB00CQVN', N'4239607_45100_lenovo_v15_g2_black_ha4.jpg;4239607_45100_lenovo_v15_g2_black_ha5.jpg;4239607_45100_lenovo_v15_g2_black_ha6.jpg;', CAST(950 AS Decimal(18, 0)), 40, N'Core™ i7-1165G7 | 8GB | 512GB | MX350 2GB | 15.6 inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (43, N'Laptop Lenovo ThinkBook 15 G2 ITL 20VE006WVN', N'4335943_thinkbook_15_g2_itl_ct1_01.png;4335943_thinkbook_15_g2_itl_ct1_05.png;4335943_thinkbook_15_g2_itl_ct2_03.png;', CAST(800 AS Decimal(18, 0)), 15, N'Intel® Core™ i5-1135G7 | 8G|512 GB | Intel Iris Xe| 15.6 Inch | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (44, N'Laptop Lenovo Thinkpad X1 Carbon Gen 9 20XW009UVN', N'4439090_thinkpad_x1_carbon_gen_9_ct1_08.png;4439090_thinkpad_x1_carbon_gen_9_ct2_04.png;', CAST(2200 AS Decimal(18, 0)), 25, N'Core™ i7-1165G7 | 8GB | 512GB | Intel Iris Xe | 14 inch WUXGA | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (45, N'Laptop Lenovo Yoga Slim 7 14ITL05 82A300A6VN', N'4539174_lenovo_yoga_slim_7_14itl05_82a300a6vn_i7_1165g7_3_c700c67b1c7f488999fdf8f07131c579_master.jpg;4539174_lenovo_yoga_slim_7_14itl05_82a300a6vn_i7_1165g7_4_2972fb031a374e9b86902af1688d8250_master.jpg;4539174_lenovo_yoga_slim_7_14itl05_82a300a6vn_i7_1165g7_1220b34e54ae48e380b720db090581a6_master.jpg;', CAST(1150 AS Decimal(18, 0)), 25, N'Core i7-1165G7 | 8GB | 512GB | Intel Iris Xe | 14 inch FHD | Win 10 | Orchid', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (46, N'Laptop MSI Modern 14 B10MW 646VN', N'4638836_9009_msi_modern_14_b10mw_427vn_2.jpg;4638836_9009_msi_modern_14_b10mw_427vn_4.jpg;4638836_9009_msi_modern_14_b10mw_427vn_5.jpg;', CAST(650 AS Decimal(18, 0)), 15, N'Core I5-10210U | 8GB | 512GB | Intel® UHD | 14 inch FHD | Win 10 | Grey', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (47, N'Laptop MSI Prestige 14 A11SCX 282VN', N'4735901_33778_17920_msi_prestige_14_a10ras_220vn_7.jpg;4735901_33778_17920_msi_prestige_14_a10ras_220vn_8.jpg;4735901_33778_17920_msi_prestige_14_a10ras_220vn_9.jpg;', CAST(1650 AS Decimal(18, 0)), 20, N'Intel® Core™ i7-1185G7 | 8GB | 512GB | GTX1650 4GB| 14 Inch', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (48, N'Laptop MSI Bravo 15 B5DD 265VN', N'4839516_20760_laptop_msi_bravo_15_b5dd_265vn_3.jpg;4839516_20760_laptop_msi_bravo_15_b5dd_265vn_4.jpg;4839516_20760_laptop_msi_bravo_15_b5dd_265vn_5.jpg;', CAST(930 AS Decimal(18, 0)), 15, N'Ryzen 5-5600H | 8GB | 512GB | RX 5500M 4GB | 15.6 inch FHD | Win 11 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (49, N'Laptop MSI Katana GF76 11UC 096VN', N'4937870_19632_laptop_msi_pulse_gl66_11udk_255vn_1.jpg;4937870_19632_laptop_msi_pulse_gl66_11udk_255vn_2.jpg;4937870_19632_laptop_msi_pulse_gl66_11udk_255vn_3.jpg;', CAST(1400 AS Decimal(18, 0)), 60, N'Core i7-11800H | 8GB | 512GB | RTX 3050 4GB | 17.3 inch FHD | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (50, N'Laptop MSI Summit E13 Flip Evo A11MT 211VN', N'5038289_laptop_msi_summit_e13_flip_evo_a11mt_211vn_111.jpg;5038289_laptop_msi_summit_e13_flip_evo_a11mt_211vn_333.jpg;5038289_laptop_msi_summit_e13_flip_evo_a11mt_211vn_444.jpg;', CAST(1800 AS Decimal(18, 0)), 15, N'Core i7-1185G7 | 16GB | 1TB SSD | Intel Iris Xe | 13.4 inch FHD+ | Win 10 | Black', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 1)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (51, N'PC Asus D500MA 5104001080', N'5139476_asus_d500ma_1.jpg;5139476_asus_d500ma_3_1.jpg;', CAST(500 AS Decimal(18, 0)), 20, N'i5-10400/8GB/256GB SSD/Đen/Dos', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 2)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (52, N'PC Mini Asus PN60-BB3046MV', N'5234571_46622_mini_pc_pn60_bb3097mv_04.png;5234571_46622_mini_pc_pn60_bb3097mv_07.png;', CAST(350 AS Decimal(18, 0)), 15, N'Intel Core i3-8130U', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 2)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (53, N'Dell Inspiron 3881 42IN380006', N'5338726_dell_inspiron_3881.jpg;5338726_may_tinh_yy_ban_dell_ins3881mt_d.jpg;', CAST(479 AS Decimal(18, 0)), 15, N'i3-10100/8GB/1TB/Office 2019/win10 Home', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 2)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (54, N'Dell OptiPlex 7080 SFF 42OC380003', N'5436179_2_c0b54986_ede6_49a1_8369_cb22e689012f.jpg;5436179_4_1f328ddc_ef0e_489a_8aae_7344908410ca.jpg;', CAST(900 AS Decimal(18, 0)), 15, N'Core i7-10700 / 8G/256GBSSD', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 2)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (55, N'Dell OptiPlex 5080 SFF 42OT580003', N'5539476_asus_d500ma_1.jpg;5539476_asus_d500ma_3_1.jpg;', CAST(850 AS Decimal(18, 0)), 20, N'i7-10700/8G/1TB/Dos', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 2)
INSERT [dbo].[Product] ([Id], [Name], [Images], [Price], [Quantity], [Short_desc], [Created_at], [Updated_at], [Category_id]) VALUES (56, N'Dell Optiplex 3080 Micro 42OC380003', N'5639361_dell_optiplex_3080_micro.jpg;5639361_dell_optiplex_3080_micro_3.jpg;', CAST(550 AS Decimal(18, 0)), 20, N'i5-10400T/4G/1TB/Fedora Linux', CAST(N'2021-10-31' AS Date), CAST(N'2021-10-31' AS Date), 2)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Promotion] ON 

INSERT [dbo].[Promotion] ([Id], [Name], [Short_desc], [Begin_date], [End_date], [Percent_discount], [Quantity_left]) VALUES (4, N'None', N'None', CAST(N'2021-10-21' AS Date), CAST(N'3000-11-01' AS Date), 0, 999999995)
INSERT [dbo].[Promotion] ([Id], [Name], [Short_desc], [Begin_date], [End_date], [Percent_discount], [Quantity_left]) VALUES (5, N'B2S', N'Back To School', CAST(N'2021-11-02' AS Date), CAST(N'2021-12-11' AS Date), 10, 50)
INSERT [dbo].[Promotion] ([Id], [Name], [Short_desc], [Begin_date], [End_date], [Percent_discount], [Quantity_left]) VALUES (6, N'VTD', N'Vietnamese Teachers'' Day', CAST(N'2021-11-20' AS Date), CAST(N'2021-11-22' AS Date), 15, 20)
SET IDENTITY_INSERT [dbo].[Promotion] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'Staff')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'User')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Spec] ON 

INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (1, N'Ryzen 7 -4800H', N'RTX 3050 4GB', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'512 GB', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'35.4 x 25.9 x 2.06 ~ 2.59 cm', N'2.10 Kg', N'4-cell, 56WHrs', N'Asus', 1)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (2, N'AMD Ryzen™ 9-5900HS', N'NVIDIA® GeForce RTX 3060 6GB GDDR6 65W', N'14-inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'32GB DDR4-3200Mhz SO-DIMM', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.4 x 22.0 x 1.79 ~ 1.79 cm', N'1.60 Kg', N'4-cell, 76WHrs', N'Asus', 2)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (3, N'Core™ i5-1135G7', N'Intel® Iris® Xe Graphics', N'13.3 inch', N'2 x Thunderbolt™ 4 USB-C® (up to 40Gbps) 1 x USB 3.2 Gen 1 Type-A (up to 5Gbps)  1 x Standard HDMI', N'8GB', N'512GB PCIe® NVMe™ 3.0 x2 M.2 SSD', N'Bluetooth 5.0', N'Height: 1.39cm  Width: 30.4cm Depth: 20.3cm ', N'1.07kg', N'4-cell, 67Wh', N'Asus', 3)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (4, N'Ryzen 7-5800H ', N'RTX™ 3070 8GB', N'15.6 Inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'16Gb', N'512GB PCIE SSD', N'1 x RJ45 LAN jack for LAN insert BT5.0', N'35.9(W) x 25.6(D) x 2.47 ~ 2.49(H) cm', N'2.3Kg', N'4-cell, 90 Wh', N'Asus', 4)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (5, N'Core™ i3-10110U', N'Intel UHD Graphics', N'14-inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'4GB', N'512 GB SSD', N'Integrated Wi-Fi 6 (802.11 ax (2x2)  Bluetooth 5.0', N'32.53 x 23.29 x 1.99 cm', N'1.6 Kg', N'3 -Cell, 48 Wh', N'Asus', 5)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (6, N'AMD Ryzen™ 9-5900HS', N'NVIDIA® GeForce RTX™ 3050 Ti 4GB GDDR6', N'14-inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'16Gb', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.4 x 22.2 x 1.99 ~ 1.99 cm', N'1.7 Kg', N'4-cell, 76WHrs', N'Asus', 6)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (7, N'Core i3-1115G4', N'Intel UHD Graphics', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'4GB', N'512GB PCIe® NVMe™ 3.0 x2 M.2 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'36.00 x 23.50 x 1.99 ~ 1.99 cm', N'1.8 Kg', N'2-cell, 37WHrs', N'Asus', 7)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (8, N'Core™ i3-1115G4', N'Intel UHD Graphics', N'14-inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'4GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.54 x 21.60 x 1.99 ~ 1.99 cm', N'1.55 Kg', N'2-cell, 37WHrs', N'Asus', 8)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (9, N'Ryzen 9-5900HX', N'NVIDIA® GeForce RTX™ 3070 8GB GDDR6', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'16Gb', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'35.4(W) x 25.9(D) x 2.26 ~ 2.72(H) cm', N'2.5 Kg', N'4-cell, 90 Wh', N'Asus', 9)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (10, N'Ryzen 9-5900HS', N'RTX 3050 4GB', N'14-inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'16Gb', N'512GB SSD M.2 NVMe PCIe', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.4(W) x 22.0(D) x 1.99 ~ 1.99(H) cm', N'1.7 Kg', N'4-cell, 76WHrs', N'Asus', 10)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (11, N'Core i5-1135G7', N'Intel® Iris® Xe graphics', N'14-inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'256GB M.2 PCIe NVMe Class 35 SSD ', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Height: 17.6mm x Width: 326mm x Depth: 226mm', N'1.52Kg', N'3 Cell 41Whr', N'Dell', 11)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (12, N'Ryzen™ 5-3500U', N'AMD Radeon™ Graphics', N'14-inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB PCIE SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Rear Height: 19.90 mm  Front Height: 18.10 mm Width: 328.70 mm Depth: 239.50 mm', N'1.60 Kg', N'3 -Cell, 45 Wh', N'Dell', 12)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (13, N'Ryzen™ 5-5500U', N'AMD Radeon™ Graphics', N'14-inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'8GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Height:  14.6mm – 17.99mm x Width: 356.06mm x Depth: 228.9mm ', N'1.64Kg', N'4-cell, 54WHrs', N'Dell', 13)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (14, N'Core i7-11850H', N'NVIDIA T600 4GB GDDR6', N'15.6 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'16Gb', N'256GB M.2 NVMe PCIe®', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'22.67 mm x 24.05 mm x 357.80 mm', N'1.79 Kg', N'4-cell, 64Wh', N'Dell', 14)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (15, N'Core™ i5-1135G7 ', N'Intel® Iris® Xe Graphics', N'14-inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.4 x 22.0 x 1.79 ~ 1.79 cm', N'1.64Kg', N'3 -Cell, 42 Wh', N'Dell', 15)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (16, N'Core™ i5-11320H', N'Intel® Iris® Xe Graphics', N'15.6 Inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB PCIE SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Height (front): 0.56 in. (14.16 mm) Height (rear): 0.71 in. (17.99 mm) Width: 14.02 in. (356.06 mm) Depth: 9.01 in. (228.9 mm)', N'1.63Kg', N'4-cell, 54WHrs', N'Dell', 16)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (17, N'Core™ i5-1135G7', N'Intel UHD Graphics', N'15.6 Inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'4GB', N'512GB PCIe® NVMe™ 3.0 x2 M.2 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Height: 18.0 mm – 19.9 mm (0.71" – 0.78") Width: 363.96 mm (14.33") Depth: 249 mm (9.80")', N'1.83 Kg', N'3 -Cell, 41 Wh', N'Dell', 17)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (18, N'Intel Core i7-1165G7', N'NVIDIA® GeForce® MX350 2GB GDDR5', N'13.3 inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'8GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Height : 15.85 mm (0.62") X Width: 305.96 mm (12.05") X Depth: 203.40 mm (8.01")', N'1.23Kg', N'3 -Cell, 40 Wh', N'Dell', 18)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (19, N'Core i7-1185G7', N'Intel® Iris® Xe Graphics', N'14-inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'16Gb', N'256GB M.2 NVMe PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'Height: 0.68" (17.27mm) x Width: 12.65" (321.35mm) x Depth: 8.22" (208.69mm)', N'1.22Kg', N'4-cell, 63Wh', N'Dell', 19)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (20, N'Core i5-1135G7', N'Intel® Iris® Xe Graphics', N'13.3 inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'256GB M.2 NVMe PCIe®', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'14.8mm x 296mm x 199mm', N'1.27Kg', N'4-cell, 51WHrs', N'Dell', 20)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (21, N'Core i5-1135G7', N'Intel® Iris® Xe Graphics', N'14-inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'16Gb', N'512GB SSD M.2 NVMe PCIe', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.3 x 21.46 x 1.79 cm', N'1.35Kg', N'3 -Cell, 53 Wh', N'HP', 21)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (22, N'Core™ i3-10110U', N'Intel UHD Graphics', N'15.6 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'4GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'35.85 x 24.2 x 1.79 cm', N'1.7 Kg', N'3 -Cell, 41 Wh', N'HP', 22)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (23, N'Core™ i3-1005G1', N'Intel UHD Graphics', N'14-inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'4GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.4 x 22.59 x 1.99 cm', N'1.47Kg', N'3 -Cell, 41 Wh', N'HP', 23)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (24, N'Core i3-1125G4', N'Intel UHD Graphics', N'15.6 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'4GB', N'256GB M.2 NVMe PCIe®', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'36.02 x 23.4 x 1.79 cm', N'1.75Kg', N'3 -Cell, 41 Wh', N'HP', 24)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (25, N'Ryzen™ 5-5600H', N'NVIDIA® GeForce RTX 3050 4GB GDDR6', N'16.1 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'512GB PCIe® NVMe™ 3.0 x2 M.2 SSD', N'Integrated Wi-Fi 6 (802.11 ax (2x2)  Bluetooth 5.0', N'37 x 26 x 2.35 cm', N'2.46 Kg', N'4-cell, 70WHrs', N'HP', 25)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (26, N'Core i5-11400H', N'NVIDIA® GeForce RTX™ 3050Ti 4GB GDDR6', N'16.1 Inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'16Gb', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'36.92 x 24.8 x 2.3 cm', N'2.3Kg', N'6-cell, 83 Wh Li-ion', N'HP', 26)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (27, N'Core i7-1165G7', N'Intel® Iris® Xe Graphics', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'256GB M.2 NVMe PCIe®', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'36.02 x 23.4 x 1.79 cm', N'1.75 Kg', N'3 -Cell, 41 Wh', N'HP', 27)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (28, N'Core i7-1165G7', N'Intel® Iris® Xe Graphics', N'14-inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB PCIe® NVMe™ 3.0 x2 M.2 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.5 x 21.66 x 1.7 cm', N'1.4 Kg', N'3 -Cell, 41 Wh', N'HP', 28)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (29, N'Core i7-1065G7', N'Intel® Iris® Plus Graphics', N'14.0 inch ', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'32.4 x 22.5 x 1.79 cm', N'1.47Kg', N'3 -Cell, 41 Wh', N'HP', 29)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (30, N'Core i5-1135G7', N'Intel® Iris® Xe Graphics', N'13.3 inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'30.69 x 20.84 x 1.59 cm', N'1.28 Kg', N'3 -Cell, 45 Wh', N'HP', 30)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (31, N'Ryzen™ 5-5600U', N'RTX 3050Ti 4GB', N'14.0 inch ', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'16Gb', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'322.8 (W) x 212.2 (D) x 17.9 (H) mm', N'1.39 Kg', N'59Wh', N'Acer', 31)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (32, N'Core i5-11400H', N'RTX 3050 4GB', N'15.6 Inch', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'363.4 (W) x 255 (D) x 23.9 (H) mm', N'2.2 Kg', N'4-cell, 57.6WHrs', N'Acer', 32)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (33, N'Core i7-11800H', N'RTX™ 3060 6GB', N'15.6 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'16Gb', N'512GB SSD M.2 NVMe PCIe', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'363.4 (W) x 255 (D) x 23.9 (H) mm', N'2.2 Kg', N'4-cell, 57.6WHrs', N'Acer', 33)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (34, N'Ryzen R5-5500U', N'GTX 1650 4GB', N'15.6 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'363.4 (W) x 255 (D) x 23.9 (H) mm', N'2.10 Kg', N'48 Wh ', N'Acer', 34)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (35, N'Core™ i5-1035G1', N'Intel UHD Graphics', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'4GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'363.4 (W) x 255 (D) x 23.9 (H) mm', N'1.7 Kg', N'2-cell, 37WHrs', N'Acer', 35)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (36, N'Pentium® Silver N5030', N'Intel UHD Graphics', N'14.0 inch ', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'4GB', N'128GB SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'327.1 x 241 x 19.9 mm', N'1.5Kg', N'35Wh', N'Lenovo', 36)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (37, N'Ryzen 7-5800H ', N'RTX™ 3070 8GB', N'16.0 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'16Gb', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'356 x 260.4-264.4 x 21.7-26.85 mm', N'2.45 Kg', N'4-cell, 80 Wh', N'Lenovo', 37)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (38, N'Core i7-1165G7', N'MX 450 2GB', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'357 x 235 x 18.9 mm', N'1.7 Kg', N'3 -Cell, 45 Wh', N'Lenovo', 38)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (39, N'Intel® Core™ i7-1165G7', N'Intel® Iris® Xe Graphics', N'14.0 inch ', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'321.6mm x 208mm x 15.4mm', N'1.5Kg', N'4-cell, 60,7 Wh', N'Lenovo', 39)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (40, N'Core i7-1165G7', N'Intel® Iris® Xe Graphics', N'13.3 inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'305.8 x 217.06 x 18.19 mm', N'1.29Kg', N'3 -Cell, 41 Wh', N'Lenovo', 40)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (41, N'Core™ i5-1135G7', N'Intel® Iris® Xe Graphics', N'13.3 inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'512GB SSD M.2 NVMe PCIe', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'311.5 x 219 x 17.6 mm', N'1.39 Kg', N'4-cell, 46 WHrs', N'Lenovo', 41)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (42, N'Core™ i7-1165G7', N'MX350 2GB', N'15.6 Inch', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB SSD M.2 NVMe PCIe', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'359.2 x 235.8 x 19.9 mm', N'1.7 Kg', N'2-cell, 38WHrs', N'Lenovo', 42)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (43, N'Intel® Core™ i5-1135G7', N'Intel® Iris® Xe Graphics', N'15.6 Inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'357mm x 235mm x 18.9mm', N'1.7 Kg', N'3 -Cell, 45 Wh', N'Lenovo', 43)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (44, N'Core™ i7-1165G7', N'Intel® Iris® Xe Graphics', N'14.0 inch ', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'315 x 221.6 x 14.9 mm', N'1.133Kg', N'4-cell, 57 WHrs', N'Lenovo', 44)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (45, N'Core i7-1165G7', N'Intel® Iris® Xe Graphics', N'14.0 inch ', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB PCIe® NVMe™ 3.0 x2 M.2 SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'320.6 x 208.18 x 14.9 mm', N'1.36Kg', N'4-cell, 60,7 Wh', N'Lenovo', 45)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (46, N'Core I5-10210U', N'Intel UHD Graphics', N'14.0 inch ', N'1x USB 3.2 Gen 2 Type-C 2x USB 3.2 Gen 1 Type-A 1x USB 3.2 Gen 2 Type-C support DisplayPort / power delivery / G-SYNC', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'319 x 219 x 16.9 mm', N'1.30 Kg', N'3 -Cell, 39 Wh', N'MSI', 46)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (47, N'Intel® Core™ i7-1185G7 ', N'GTX 1650 4GB', N'14.0 inch ', N'1x Type A USB 2.0 1x Type C USB 3.2 Gen 2 2x Type A USB 3.2 Gen 1 1x Kensington Lock 1x HDMI 2.0b', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'319 x 215 x 15.9 mm', N'1.29Kg', N'3 -Cell, 52 Wh', N'MSI', 47)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (48, N'Ryzen 5-5600H', N'RX 5500M 4GB', N'15.6 Inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'8GB', N'512GB PCIe® NVMe™ 3.0  SSD', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'397 x 260 x 22~23.1 mm', N'1.96 Kg', N'3 -Cell, 52 Wh', N'MSI', 48)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (49, N'Core i7-11800H', N'RTX 3050 4GB', N'17.3 inch', N'1 x Type-C USB 3.2 (Gen 2) with display and power delivery support 2 x Type-A USB 3.2 (Gen 1) 1 x Type-A USB2.0', N'8GB', N'512GB SSD M.2 NVMe PCIe', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'397 x 260 x 22~23.1 mm', N'2.3Kg', N'3 -Cell, 53.5 Wh', N'MSI', 49)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (50, N'Core i7-1185G7', N'Intel® Iris® Xe Graphics', N'13.4 inch', N'1x Type C USB 3.2 Gen 1 with Power Delivery and Display Port 3x USB 3.2 Gen 1 Type-A', N'16Gb', N'1TB M.2 NVMe™ PCIe® 3.0', N'Wi-Fi 6(802.11ax) Bluetooth 5.1 (Dual band) 2*2', N'300.2 x 222.25 x 14.9 mm', N'1.35 Kg', N'4-cell, 70WHrs', N'MSI', 50)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (51, N'Intel Core i5-10400', N'Intel UHD Graphics', N'None', N'1x Headphone 1x 3.5mm combo audio jack 4x USB 3.2 Gen 1 Type-A  Sau 1x RJ45 Gigabit Ethernet 1x HDMI 1.4 1x VGA Port 1x DisplayPort 2x PS2 3 x Audio jacks 4x USB 2.0 Type-A', N'8GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'LAN', N'16.20 x 29.13 x 35.50 cm', N'6.0 Kg', N'None', N'Asus', 51)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (52, N'Intel Core i3-8130U', N'Intel UHD Graphics 620', N'None', N'1 x USB 2.0 1x USB 3.1Gen 1 Type-C* 1x USB 3.1Gen 1 1 x Audio jack  Phía sau:  2 x USB 3.1 Gen 1 1 x USB 3.1 Gen 1 Type-C * 1 x HDMI 1 x RJ45 LAN 1 x DC-in 1 x Configurable port(options:COM, VGA, HDMI, DisplayPort, LAN)', N'4GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Wifi: 802.11 a/b/g/n/ac Lan: 10/100/1000/Gigabit Mbps Bluetooth® 5.0', N'115 x 115 x 49 mm', N'0.7 Kg', N'None', N'Asus', 52)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (53, N'Intel Core i3-10100', N'Intel UHD Graphics 630', N'None', N'3x USB 3.2 Gen 1m 1X USB 3.2 Gen 2(Type CX), 4XUSB 2.0, One headset, One Line-out, EJ45, SD Card', N'8GB', N'1 TB 7200 RPM 3,5''''(x1 slot M2 PCLe, NvMe)', N'LAN', N'324.3x154x293 mm', N'5.23 Kg', N'None', N'Dell', 53)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (54, N'Core i7-10700', N'Intel UHD Graphics 630', N'None', N'1 RJ-45 port 10/100/1000 Mbps (rear) 2 USB 2.0 Ports (1 with PowerShare) 1 USB 3.2 Gen 1 port (front) 1 USB 3.2 Gen 2 Type-C port (front) 2 USB 2.0 ports ', N'8GB', N'256GB M.2 NVMe PCIe® 3.0 SSD', N'Qualcomm QCA61x4a 802.11ac dual band 2x2 + Bluetooth 5', N'293 mm x W: 93 mm x D: 290 mm', N'3.85Kg', N'None', N'Dell', 54)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (55, N'Intel Core i7-10700', N'Intel® Integrated Graphics', N'None', N'1 Universal Audio Jack 4 USB 2.0 Ports (1 with Smart Power on) 5 USB 3.2 Gen 1 Type-A Ports 1 USB 3.2 Gen 2 Type-C Port 1 Line-out 2 Display Ports 1 RJ-45 Port 1 Optional Port: 2x DP1.4/ x1HDMI 2.0b/USB Type-C 1 Optional Serial/PS2 Port', N'8GB', N'1 TB 7200 RPM 3,5''''(x1 slot M2 PCLe, NvMe)', N'LAN', N'Width: 93mm x Depth: 290mm x Height: 293mm ', N'5.25Kg', N'None', N'Dell', 55)
INSERT [dbo].[Spec] ([Id], [CPU], [GPU], [Screen], [Ports], [RAM], [Storage], [Connectivity], [Size], [Weight], [Battery], [Manufacturer], [Product_id]) VALUES (56, N'Intel® Core™ i5-10500T', N'Intel® Integrated Graphics', N'None', N'4 USB 3.2 Gen 1 Type A, 2 USB 2.0 port, 1 Universal Audio Jack. 1 Line-out audio port VGA, Display Port, HDMI', N'4GB', N'1 TB 7200 RPM 3,5''''(x1 slot M2 PCLe, NvMe)', N'LAN, Bluetooth', N'183 x 36 x 178 mm', N'1.16 Kg', N'None', N'Dell', 56)
SET IDENTITY_INSERT [dbo].[Spec] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [User_name], [Password], [Name], [Email], [Address], [Avatar], [Gender], [Phone_number], [Role_id], [Dob]) VALUES (1, N'admin', N'$2a$11$ZO5PFilCJAimOCgzxRFnj.QVBAHnCgEyQo8ujF2KE7tpexJjJmzUu', N'Le Quyet', N'lequyet99@gmail.com', N'475 TL 417 Street, Thọ Xuân, Đan Phượng, Hà Nội', N'0241545749_4921786464501453_2914788704512001438_n.jpg', N'Male', N'0966396695', 1, CAST(N'1999-05-30' AS Date))
INSERT [dbo].[User] ([Id], [User_name], [Password], [Name], [Email], [Address], [Avatar], [Gender], [Phone_number], [Role_id], [Dob]) VALUES (2, N'admin1', N'$2a$11$YFxss50RFaIepCn9zFZKB.0IUoNgL2er.46NnE8QCtFh4RG77wAUu', N'Le Quyet 1', N'lequyet199@gmail.com', N'475 TL 417 Street, Thọ Xuân, Đan Phượng, Hà Nội', N'0241545749_4921786464501453_2914788704512001438_n.jpg', N'Male', N'0123456789', 1, CAST(N'1999-05-30' AS Date))
INSERT [dbo].[User] ([Id], [User_name], [Password], [Name], [Email], [Address], [Avatar], [Gender], [Phone_number], [Role_id], [Dob]) VALUES (3, N'Duccop99', N'$2a$11$A3nRxCUnAoKTnLMLlf3sHuhhfrJ3fzdwrUBeeJdbVclJqPEogHDOK', N'Duc Minh Lai', N'laiminhduc99@gmail.com', N'63G Hẻm 29 / 70 / 2 Tổ 5 Cụm 4 Khương Hạ Khương Đình Thanh Xuân Hà Nội', N'57110242243_2667384590216908_3355489037839726785_n.jpg', N'Male', N'0386751567', 2, CAST(N'1999-07-17' AS Date))
INSERT [dbo].[User] ([Id], [User_name], [Password], [Name], [Email], [Address], [Avatar], [Gender], [Phone_number], [Role_id], [Dob]) VALUES (4, N'trungvtt1999', N'$2a$11$PrYL27ouV/h7y74KOd0nQuE73HWRgTLl0GnsvzZvyxo6MPakQkP7i', N'Trung Thanh Vu', N'trungvtt@gmail.com', N'63G Hẻm 29 / 70 / 2 Tổ 5 Cụm 4 Khương Hạ Khương Đình Thanh Xuân Hà Nội', N'', N'Male', N'0915595489', 3, CAST(N'1999-04-27' AS Date))
SET IDENTITY_INSERT [dbo].[User] OFF
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
