USE [master]
GO
/****** Object:  Database [OnlineShop]    Script Date: 12/09/18 10:43:01 ******/
CREATE DATABASE [OnlineShop]
 CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'OnlineShop', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OnlineShop.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
-- LOG ON 
--( NAME = N'OnlineShop_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\OnlineShop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OnlineShop] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OnlineShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OnlineShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OnlineShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OnlineShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OnlineShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OnlineShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OnlineShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OnlineShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OnlineShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OnlineShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OnlineShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OnlineShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OnlineShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OnlineShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OnlineShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OnlineShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OnlineShop] SET  MULTI_USER 
GO
ALTER DATABASE [OnlineShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OnlineShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OnlineShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OnlineShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [OnlineShop] SET DELAYED_DURABILITY = DISABLED 
GO
USE [OnlineShop]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](250) NULL,
	[Password] [varchar](250) NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Phone] [nchar](10) NULL,
	[Birthday] [datetime] NULL,
	[Type] [int] NULL CONSTRAINT [DF_Account_Type]  DEFAULT ((2)),
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Account_CreateDate]  DEFAULT (getdate()),
	[Status] [bit] NULL CONSTRAINT [DF_Account_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CusID] [bigint] NULL,
	[CreateDate] [datetime] NULL,
	[TotalAmount] [decimal](18, 0) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[Quantity] [decimal](18, 0) NOT NULL,
	[BillID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[BillID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[ParentID] [bigint] NULL,
	[DisPlayOrder] [int] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Category_CreateDate]  DEFAULT (getdate()),
	[MetaDescriptions] [nvarchar](250) NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Category_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Color]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeedBack]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedBack](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Content] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_FeedBack] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[TopHot] [datetime] NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[Detail] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[MetaTile] [nchar](10) NULL,
	[Status] [bit] NULL,
	[SeoTitle] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[MetaDescriptions] [nvarchar](250) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producer]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producer](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Producer_CreateDate]  DEFAULT (getdate()),
	[Status] [bit] NULL CONSTRAINT [DF_Producer_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_Producer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Code] [varchar](50) NULL,
	[Description] [nvarchar](250) NULL,
	[Detail] [nvarchar](500) NULL,
	[Image] [nvarchar](250) NULL,
	[Price] [decimal](18, 0) NULL CONSTRAINT [DF_Product_Price]  DEFAULT ((0)),
	[Discount] [int] NULL CONSTRAINT [DF_Product_Discount]  DEFAULT ((0)),
	[Quantity] [int] NULL CONSTRAINT [DF_Product_Quantity]  DEFAULT ((0)),
	[CategoryID] [bigint] NULL,
	[MetaTile] [nchar](10) NULL,
	[ProducerID] [bigint] NULL,
	[Warranty] [int] NULL,
	[Status] [bit] NULL CONSTRAINT [DF_Product_Status]  DEFAULT ((1)),
	[SeoTitle] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL CONSTRAINT [DF_Product_CreateDate]  DEFAULT (getdate()),
	[MetaDescriptions] [nvarchar](250) NULL,
	[TopHot] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductColor]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColor](
	[ColorID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ProductColor] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductSizes]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSizes](
	[SizeID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[Status] [bit] NULL CONSTRAINT [DF_ProductSizes_Status]  DEFAULT ((1)),
 CONSTRAINT [PK_ProductSizes] PRIMARY KEY CLUSTERED 
(
	[SizeID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Size] [int] NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slide]    Script Date: 12/09/18 10:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[Link] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Slide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [Username], [Password], [Name], [Image], [Address], [Phone], [Birthday], [Type], [CreateDate], [Status]) VALUES (1, N'Admin', N'123', N'Lê Văn Đạt', N'/Data/files/ImageAdmin.jpg', N'Ninh Bình', N'9611087212', CAST(N'1997-04-01 00:00:00.000' AS DateTime), 1, CAST(N'2018-11-11 19:47:42.470' AS DateTime), 1)
INSERT [dbo].[Account] ([ID], [Username], [Password], [Name], [Image], [Address], [Phone], [Birthday], [Type], [CreateDate], [Status]) VALUES (45, N'Client', N'123', NULL, NULL, N'Ninh Bình', N'1234567890', CAST(N'2018-11-14 00:00:00.000' AS DateTime), 2, CAST(N'2018-11-30 23:10:02.233' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (1, N'Giày mọi, lười, oxford nam', 1, NULL, NULL, CAST(N'2018-11-11 13:09:21.790' AS DateTime), NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (4, N'Giày bốt nam', 1, NULL, NULL, CAST(N'2018-11-11 13:11:38.230' AS DateTime), NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (5, N'Giày casual, vải nam', 1, NULL, NULL, CAST(N'2018-11-11 13:11:55.360' AS DateTime), NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (6, N'Giày búp bê đế bệt', 2, NULL, NULL, CAST(N'2018-11-11 13:14:16.800' AS DateTime), NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (7, N'Giày cao gót', 2, NULL, NULL, CAST(N'2018-11-11 13:14:30.997' AS DateTime), NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (8, N'Giày đế xuồng', 2, NULL, NULL, CAST(N'2018-11-11 13:14:49.563' AS DateTime), NULL, 1)
INSERT [dbo].[Category] ([ID], [Name], [ParentID], [DisPlayOrder], [SeoTitle], [CreateDate], [MetaDescriptions], [Status]) VALUES (9, N'Giày mọi, lười, oxford nữ', 2, NULL, NULL, CAST(N'2018-11-11 13:15:05.867' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([ID], [Name]) VALUES (1, N'Xanh')
SET IDENTITY_INSERT [dbo].[Color] OFF
SET IDENTITY_INSERT [dbo].[Producer] ON 

INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (1, N'

Biti''s', CAST(N'2018-11-11 13:19:04.193' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (2, N'Me Girl', CAST(N'2018-11-11 13:19:36.180' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (3, N'Juno', CAST(N'2018-11-11 13:21:33.923' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (4, N'Y-3', CAST(N'2018-11-11 13:22:06.483' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (5, N'Alexander McQueen', CAST(N'2018-11-11 13:22:18.813' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (6, N'Balenciaga', CAST(N'2018-11-11 13:22:30.987' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (7, N'Common Projects', CAST(N'2018-11-11 13:23:03.810' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (8, N'Fendi', CAST(N'2018-11-11 13:23:10.660' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (9, N'Nike', CAST(N'2018-11-11 13:23:17.570' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (14, N'Valentino', CAST(N'2018-11-11 13:23:46.407' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (15, N'Lanvin', CAST(N'2018-11-11 13:23:51.813' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (16, N'Reebok', CAST(N'2018-11-11 13:23:57.840' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (17, N'Converse', CAST(N'2018-11-11 13:24:03.550' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (18, N'adidas', CAST(N'2018-11-11 13:24:08.213' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (19, N'Lacoste', CAST(N'2018-11-11 13:24:14.190' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (20, N'Filling Pieces', CAST(N'2018-11-11 13:24:20.320' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (21, N'Vans', CAST(N'2018-11-11 13:24:26.073' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (22, N'New Balance', CAST(N'2018-11-11 13:24:31.953' AS DateTime), 1)
INSERT [dbo].[Producer] ([ID], [Name], [CreateDate], [Status]) VALUES (23, N'ASICS', CAST(N'2018-11-11 13:24:39.417' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Producer] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Code], [Description], [Detail], [Image], [Price], [Discount], [Quantity], [CategoryID], [MetaTile], [ProducerID], [Warranty], [Status], [SeoTitle], [CreateDate], [MetaDescriptions], [TopHot]) VALUES (1, N'Giày Tây Nam Vina-Giầy', N'Shoe001ddddd', NULL, NULL, N'/Data/images/Data/GiayNam/GiayDa/giay-luoi-nam-duc-lo-qua-chuong-gnla88k68-cf-370x370.jpg', NULL, 10, 12, 1, NULL, 1, NULL, 1, NULL, CAST(N'2018-11-11 13:40:13.190' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
INSERT [dbo].[ProductSizes] ([SizeID], [ProductID], [Status]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([ID], [Size]) VALUES (1, 6)
SET IDENTITY_INSERT [dbo].[Sizes] OFF
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF_Bill_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[FeedBack] ADD  CONSTRAINT [DF_FeedBack_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[FeedBack] ADD  CONSTRAINT [DF_FeedBack_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ProductColor] ADD  CONSTRAINT [DF_ProductColor_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Slide] ADD  CONSTRAINT [DF_Slide_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Account] FOREIGN KEY([CusID])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Account]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY([BillID])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Producer] FOREIGN KEY([ProducerID])
REFERENCES [dbo].[Producer] ([ID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Producer]
GO
ALTER TABLE [dbo].[ProductColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductColor_Color] FOREIGN KEY([ColorID])
REFERENCES [dbo].[Color] ([ID])
GO
ALTER TABLE [dbo].[ProductColor] CHECK CONSTRAINT [FK_ProductColor_Color]
GO
ALTER TABLE [dbo].[ProductColor]  WITH CHECK ADD  CONSTRAINT [FK_ProductColor_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductColor] CHECK CONSTRAINT [FK_ProductColor_Product]
GO
ALTER TABLE [dbo].[ProductSizes]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizes_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO
ALTER TABLE [dbo].[ProductSizes] CHECK CONSTRAINT [FK_ProductSizes_Product]
GO
ALTER TABLE [dbo].[ProductSizes]  WITH CHECK ADD  CONSTRAINT [FK_ProductSizes_Sizes] FOREIGN KEY([SizeID])
REFERENCES [dbo].[Sizes] ([ID])
GO
ALTER TABLE [dbo].[ProductSizes] CHECK CONSTRAINT [FK_ProductSizes_Sizes]
GO
USE [master]
GO
ALTER DATABASE [OnlineShop] SET  READ_WRITE 
GO
