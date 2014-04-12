USE [master]
GO
/****** Object:  Database [ORMS]    Script Date: 04/02/2014 01:17:29 ******/
CREATE DATABASE [ORMS] ON  PRIMARY 
( NAME = N'ORMS', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\ORMS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ORMS_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\ORMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ORMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ORMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ORMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ORMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ORMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ORMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ORMS] SET ARITHABORT OFF
GO
ALTER DATABASE [ORMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ORMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ORMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ORMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ORMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ORMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ORMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ORMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ORMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ORMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ORMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [ORMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ORMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ORMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ORMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ORMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ORMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [ORMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ORMS] SET  READ_WRITE
GO
ALTER DATABASE [ORMS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [ORMS] SET  MULTI_USER
GO
ALTER DATABASE [ORMS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ORMS] SET DB_CHAINING OFF
GO
USE [ORMS]
GO
/****** Object:  Table [dbo].[EventStatuses]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventStatuses](
	[EventStatusId] [int] IDENTITY(1,1) NOT NULL,
	[EventStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventStatuses] PRIMARY KEY CLUSTERED 
(
	[EventStatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EventStatuses] ON
INSERT [dbo].[EventStatuses] ([EventStatusId], [EventStatus]) VALUES (1, N'Opened')
INSERT [dbo].[EventStatuses] ([EventStatusId], [EventStatus]) VALUES (2, N'Delayed')
INSERT [dbo].[EventStatuses] ([EventStatusId], [EventStatus]) VALUES (3, N'Closed')
SET IDENTITY_INSERT [dbo].[EventStatuses] OFF
/****** Object:  Table [dbo].[Product_Service_Sections]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Service_Sections](
	[SectionId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Description] [nvarchar](100) NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_Service_Sections] PRIMARY KEY CLUSTERED 
(
	[SectionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Service_Categories]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Service_Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product_Services_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeriodTypes]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeriodTypes](
	[PeriodTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_PeriodTypes] PRIMARY KEY CLUSTERED 
(
	[PeriodTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PeriodTypes] ON
INSERT [dbo].[PeriodTypes] ([PeriodTypeId], [Title], [Value]) VALUES (1, N'Day', 1)
INSERT [dbo].[PeriodTypes] ([PeriodTypeId], [Title], [Value]) VALUES (2, N'Week', 7)
INSERT [dbo].[PeriodTypes] ([PeriodTypeId], [Title], [Value]) VALUES (3, N'Month', 30)
INSERT [dbo].[PeriodTypes] ([PeriodTypeId], [Title], [Value]) VALUES (4, N'Year', 365)
SET IDENTITY_INSERT [dbo].[PeriodTypes] OFF
/****** Object:  Table [dbo].[ImageTypes]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageTypes](
	[ImageTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ImageType] [nvarchar](10) NULL,
 CONSTRAINT [PK_ImageTypes] PRIMARY KEY CLUSTERED 
(
	[ImageTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialUsers]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialUsers](
	[SocialUserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SocialNetworkName] [nvarchar](50) NULL,
	[Token] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastLogin] [datetime] NULL,
 CONSTRAINT [PK_SocialUsers] PRIMARY KEY CLUSTERED 
(
	[SocialUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastLogin] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageId] [bigint] IDENTITY(1,1) NOT NULL,
	[ImageTypeId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Path] [nvarchar](100) NOT NULL,
	[FileSize] [int] NULL,
	[FileFormat] [nvarchar](5) NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Service_SubCategories]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Service_SubCategories](
	[SubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[SubCategoryTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product_Service_SubCategory] PRIMARY KEY CLUSTERED 
(
	[SubCategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products_Services]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_Services](
	[Product_Service_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Products_Services] PRIMARY KEY CLUSTERED 
(
	[Product_Service_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[System_Social_UsersAssociation]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[System_Social_UsersAssociation](
	[UserAssociationId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SocialUserId] [bigint] NOT NULL,
 CONSTRAINT [PK_System_Social_UsersAssociation] PRIMARY KEY CLUSTERED 
(
	[UserAssociationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipts](
	[ReceiptId] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptDate] [datetime] NULL,
	[SerialNumber] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[ReceiptId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarrantyCards]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarrantyCards](
	[WarrantyCardId] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[WarrantyExpireOn] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[UserId] [bigint] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_WarrantyCards] PRIMARY KEY CLUSTERED 
(
	[WarrantyCardId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarrantyCardImages]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarrantyCardImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[WarrantyCardId] [bigint] NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_WarrantyCardImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptImages]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptId] [bigint] NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_ReceiptImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[My_Products_Services]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[My_Products_Services](
	[My_Product_Service_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_Service_Id] [bigint] NULL,
	[Parent_My_Product_Service_Id] [bigint] NULL,
	[SectionId] [bigint] NULL,
	[ReceiptId] [bigint] NULL,
	[WarrantyCardId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [nchar](10) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_My_Products_Services] PRIMARY KEY CLUSTERED 
(
	[My_Product_Service_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Service_Images]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Service_Images](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_Service_Id] [bigint] NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_Product_Service_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 04/02/2014 01:17:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [bigint] IDENTITY(1,1) NOT NULL,
	[My_Product_Service_Id] [bigint] NULL,
	[EventDate] [datetime] NULL,
	[EventName] [nvarchar](50) NULL,
	[EventDescription] [nvarchar](100) NULL,
	[NotifyBefore_PeriodValue] [int] NULL,
	[NotifyBefore_PeriodTypeId] [int] NULL,
	[Reoccurance_PeriodValue] [int] NULL,
	[Reoccurance_PeriodTypeId] [int] NULL,
	[EventStatusId] [int] NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_User_Role]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  ForeignKey [FK_Images_ImageTypes]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_ImageTypes] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageTypes] ([ImageTypeId])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_ImageTypes]
GO
/****** Object:  ForeignKey [FK_Category_SubCategory]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Product_Service_SubCategories]  WITH CHECK ADD  CONSTRAINT [FK_Category_SubCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Product_Service_Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Product_Service_SubCategories] CHECK CONSTRAINT [FK_Category_SubCategory]
GO
/****** Object:  ForeignKey [FK_ProductsServices_Category]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_ProductsServices_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Product_Service_Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products_Services] CHECK CONSTRAINT [FK_ProductsServices_Category]
GO
/****** Object:  ForeignKey [FK_ProductsServices_SubCategory]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_ProductsServices_SubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[Product_Service_SubCategories] ([SubCategoryId])
GO
ALTER TABLE [dbo].[Products_Services] CHECK CONSTRAINT [FK_ProductsServices_SubCategory]
GO
/****** Object:  ForeignKey [FK_ProductsServices_Users]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_ProductsServices_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Products_Services] CHECK CONSTRAINT [FK_ProductsServices_Users]
GO
/****** Object:  ForeignKey [FK_SocialUser_Association]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[System_Social_UsersAssociation]  WITH CHECK ADD  CONSTRAINT [FK_SocialUser_Association] FOREIGN KEY([SocialUserId])
REFERENCES [dbo].[SocialUsers] ([SocialUserId])
GO
ALTER TABLE [dbo].[System_Social_UsersAssociation] CHECK CONSTRAINT [FK_SocialUser_Association]
GO
/****** Object:  ForeignKey [FK_SystemUser_Association]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[System_Social_UsersAssociation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUser_Association] FOREIGN KEY([UserAssociationId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[System_Social_UsersAssociation] CHECK CONSTRAINT [FK_SystemUser_Association]
GO
/****** Object:  ForeignKey [FK_Receipts_Users]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Receipts] CHECK CONSTRAINT [FK_Receipts_Users]
GO
/****** Object:  ForeignKey [FK_WarrantyCards_Users]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[WarrantyCards]  WITH CHECK ADD  CONSTRAINT [FK_WarrantyCards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[WarrantyCards] CHECK CONSTRAINT [FK_WarrantyCards_Users]
GO
/****** Object:  ForeignKey [FK_WarrantyCardImages_Images]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[WarrantyCardImages]  WITH CHECK ADD  CONSTRAINT [FK_WarrantyCardImages_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([ImageId])
GO
ALTER TABLE [dbo].[WarrantyCardImages] CHECK CONSTRAINT [FK_WarrantyCardImages_Images]
GO
/****** Object:  ForeignKey [FK_WarrantyCardImages_WarrantyCards]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[WarrantyCardImages]  WITH CHECK ADD  CONSTRAINT [FK_WarrantyCardImages_WarrantyCards] FOREIGN KEY([WarrantyCardId])
REFERENCES [dbo].[WarrantyCards] ([WarrantyCardId])
GO
ALTER TABLE [dbo].[WarrantyCardImages] CHECK CONSTRAINT [FK_WarrantyCardImages_WarrantyCards]
GO
/****** Object:  ForeignKey [FK_ReceiptImages_Images]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[ReceiptImages]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptImages_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([ImageId])
GO
ALTER TABLE [dbo].[ReceiptImages] CHECK CONSTRAINT [FK_ReceiptImages_Images]
GO
/****** Object:  ForeignKey [FK_ReceiptImages_Receipts]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[ReceiptImages]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptImages_Receipts] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipts] ([ReceiptId])
GO
ALTER TABLE [dbo].[ReceiptImages] CHECK CONSTRAINT [FK_ReceiptImages_Receipts]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_ParentProductsServices]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_ParentProductsServices] FOREIGN KEY([Parent_My_Product_Service_Id])
REFERENCES [dbo].[My_Products_Services] ([My_Product_Service_Id])
GO
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_ParentProductsServices]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_ProductsServices]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_ProductsServices] FOREIGN KEY([Product_Service_Id])
REFERENCES [dbo].[Products_Services] ([Product_Service_Id])
GO
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_ProductsServices]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Receipts]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_Receipts] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipts] ([ReceiptId])
GO
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_Receipts]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Sections]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Product_Service_Sections] ([SectionId])
GO
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_Sections]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Users]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_Users]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_WarrantyCards]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_WarrantyCards] FOREIGN KEY([WarrantyCardId])
REFERENCES [dbo].[WarrantyCards] ([WarrantyCardId])
GO
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_WarrantyCards]
GO
/****** Object:  ForeignKey [FK_ProductServiceImages_Images]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Product_Service_Images]  WITH CHECK ADD  CONSTRAINT [FK_ProductServiceImages_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([ImageId])
GO
ALTER TABLE [dbo].[Product_Service_Images] CHECK CONSTRAINT [FK_ProductServiceImages_Images]
GO
/****** Object:  ForeignKey [FK_ProductServiceImages_ProductsServices]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Product_Service_Images]  WITH CHECK ADD  CONSTRAINT [FK_ProductServiceImages_ProductsServices] FOREIGN KEY([Product_Service_Id])
REFERENCES [dbo].[Products_Services] ([Product_Service_Id])
GO
ALTER TABLE [dbo].[Product_Service_Images] CHECK CONSTRAINT [FK_ProductServiceImages_ProductsServices]
GO
/****** Object:  ForeignKey [FK_Events_EventStatuses]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventStatuses] FOREIGN KEY([EventStatusId])
REFERENCES [dbo].[EventStatuses] ([EventStatusId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventStatuses]
GO
/****** Object:  ForeignKey [FK_Events_MyProductsServices]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_MyProductsServices] FOREIGN KEY([My_Product_Service_Id])
REFERENCES [dbo].[My_Products_Services] ([My_Product_Service_Id])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_MyProductsServices]
GO
/****** Object:  ForeignKey [FK_Events_NotifyBeforePeriodType]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_NotifyBeforePeriodType] FOREIGN KEY([NotifyBefore_PeriodTypeId])
REFERENCES [dbo].[PeriodTypes] ([PeriodTypeId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_NotifyBeforePeriodType]
GO
/****** Object:  ForeignKey [FK_Events_ReoccurancePeriodType]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_ReoccurancePeriodType] FOREIGN KEY([Reoccurance_PeriodTypeId])
REFERENCES [dbo].[PeriodTypes] ([PeriodTypeId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_ReoccurancePeriodType]
GO
/****** Object:  ForeignKey [FK_Events_Users]    Script Date: 04/02/2014 01:17:31 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Users]
GO
