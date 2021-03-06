USE [ORMS]
GO
/****** Object:  ForeignKey [FK_Events_EventStatuses]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_EventStatuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_EventStatuses]
GO
/****** Object:  ForeignKey [FK_Events_MyProductsServices]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_MyProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_MyProductsServices]
GO
/****** Object:  ForeignKey [FK_Events_NotifyBeforePeriodType]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_NotifyBeforePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_NotifyBeforePeriodType]
GO
/****** Object:  ForeignKey [FK_Events_ReoccurancePeriodType]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_ReoccurancePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_ReoccurancePeriodType]
GO
/****** Object:  ForeignKey [FK_Events_Users]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_Users]
GO
/****** Object:  ForeignKey [FK_Images_ImageTypes]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_ImageTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_ImageTypes]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_ParentProductsServices]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ParentProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_ParentProductsServices]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_ProductsServices]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_ProductsServices]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Receipts]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Receipts]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Sections]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Sections]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Sections]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Users]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Users]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_WarrantyCards]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_WarrantyCards]
GO
/****** Object:  ForeignKey [FK_ProductServiceImages_Images]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images] DROP CONSTRAINT [FK_ProductServiceImages_Images]
GO
/****** Object:  ForeignKey [FK_ProductServiceImages_ProductsServices]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images] DROP CONSTRAINT [FK_ProductServiceImages_ProductsServices]
GO
/****** Object:  ForeignKey [FK_Category_SubCategory]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Category_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_SubCategories]'))
ALTER TABLE [dbo].[Product_Service_SubCategories] DROP CONSTRAINT [FK_Category_SubCategory]
GO
/****** Object:  ForeignKey [FK_ProductsServices_Category]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_Category]
GO
/****** Object:  ForeignKey [FK_ProductsServices_SubCategory]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_SubCategory]
GO
/****** Object:  ForeignKey [FK_ProductsServices_Users]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_Users]
GO
/****** Object:  ForeignKey [FK_ReceiptImages_Images]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages] DROP CONSTRAINT [FK_ReceiptImages_Images]
GO
/****** Object:  ForeignKey [FK_ReceiptImages_Receipts]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages] DROP CONSTRAINT [FK_ReceiptImages_Receipts]
GO
/****** Object:  ForeignKey [FK_Receipts_Users]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Receipts_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Receipts]'))
ALTER TABLE [dbo].[Receipts] DROP CONSTRAINT [FK_Receipts_Users]
GO
/****** Object:  ForeignKey [FK_SocialUser_Association]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SocialUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation] DROP CONSTRAINT [FK_SocialUser_Association]
GO
/****** Object:  ForeignKey [FK_SystemUser_Association]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SystemUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation] DROP CONSTRAINT [FK_SystemUser_Association]
GO
/****** Object:  ForeignKey [FK_User_Role]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Role]
GO
/****** Object:  ForeignKey [FK_WarrantyCardImages_Images]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages] DROP CONSTRAINT [FK_WarrantyCardImages_Images]
GO
/****** Object:  ForeignKey [FK_WarrantyCardImages_WarrantyCards]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages] DROP CONSTRAINT [FK_WarrantyCardImages_WarrantyCards]
GO
/****** Object:  ForeignKey [FK_WarrantyCards_Users]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCards_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCards]'))
ALTER TABLE [dbo].[WarrantyCards] DROP CONSTRAINT [FK_WarrantyCards_Users]
GO
/****** Object:  Table [dbo].[EventsInfo]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_EventStatuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_EventStatuses]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_MyProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_MyProductsServices]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_NotifyBeforePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_NotifyBeforePeriodType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_ReoccurancePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_ReoccurancePeriodType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] DROP CONSTRAINT [FK_Events_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventsInfo]') AND type in (N'U'))
DROP TABLE [dbo].[EventsInfo]
GO
/****** Object:  Table [dbo].[Product_Service_Images]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images] DROP CONSTRAINT [FK_ProductServiceImages_Images]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images] DROP CONSTRAINT [FK_ProductServiceImages_ProductsServices]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]') AND type in (N'U'))
DROP TABLE [dbo].[Product_Service_Images]
GO
/****** Object:  Table [dbo].[My_Products_Services]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ParentProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_ParentProductsServices]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_ProductsServices]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Receipts]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Sections]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Sections]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Users]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_WarrantyCards]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[My_Products_Services]') AND type in (N'U'))
DROP TABLE [dbo].[My_Products_Services]
GO
/****** Object:  Table [dbo].[ReceiptImages]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages] DROP CONSTRAINT [FK_ReceiptImages_Images]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages] DROP CONSTRAINT [FK_ReceiptImages_Receipts]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiptImages]') AND type in (N'U'))
DROP TABLE [dbo].[ReceiptImages]
GO
/****** Object:  Table [dbo].[WarrantyCardImages]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages] DROP CONSTRAINT [FK_WarrantyCardImages_Images]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages] DROP CONSTRAINT [FK_WarrantyCardImages_WarrantyCards]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]') AND type in (N'U'))
DROP TABLE [dbo].[WarrantyCardImages]
GO
/****** Object:  Table [dbo].[WarrantyCards]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCards_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCards]'))
ALTER TABLE [dbo].[WarrantyCards] DROP CONSTRAINT [FK_WarrantyCards_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarrantyCards]') AND type in (N'U'))
DROP TABLE [dbo].[WarrantyCards]
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Receipts_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Receipts]'))
ALTER TABLE [dbo].[Receipts] DROP CONSTRAINT [FK_Receipts_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Receipts]') AND type in (N'U'))
DROP TABLE [dbo].[Receipts]
GO
/****** Object:  Table [dbo].[System_Social_UsersAssociation]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SocialUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation] DROP CONSTRAINT [FK_SocialUser_Association]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SystemUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation] DROP CONSTRAINT [FK_SystemUser_Association]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]') AND type in (N'U'))
DROP TABLE [dbo].[System_Social_UsersAssociation]
GO
/****** Object:  Table [dbo].[Products_Services]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_Category]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_SubCategory]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_Users]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products_Services]') AND type in (N'U'))
DROP TABLE [dbo].[Products_Services]
GO
/****** Object:  Table [dbo].[Product_Service_SubCategories]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Category_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_SubCategories]'))
ALTER TABLE [dbo].[Product_Service_SubCategories] DROP CONSTRAINT [FK_Category_SubCategory]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_SubCategories]') AND type in (N'U'))
DROP TABLE [dbo].[Product_Service_SubCategories]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_ImageTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_ImageTypes]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Images]') AND type in (N'U'))
DROP TABLE [dbo].[Images]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/09/2014 00:14:09 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Role]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[SocialUsers]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SocialUsers]') AND type in (N'U'))
DROP TABLE [dbo].[SocialUsers]
GO
/****** Object:  Table [dbo].[ImageTypes]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImageTypes]') AND type in (N'U'))
DROP TABLE [dbo].[ImageTypes]
GO
/****** Object:  Table [dbo].[PeriodTypes]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PeriodTypes]') AND type in (N'U'))
DROP TABLE [dbo].[PeriodTypes]
GO
/****** Object:  Table [dbo].[Product_Service_Categories]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_Categories]') AND type in (N'U'))
DROP TABLE [dbo].[Product_Service_Categories]
GO
/****** Object:  Table [dbo].[Product_Service_Sections]    Script Date: 05/09/2014 00:14:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_Sections]') AND type in (N'U'))
DROP TABLE [dbo].[Product_Service_Sections]
GO
/****** Object:  Table [dbo].[EventStatuses]    Script Date: 05/09/2014 00:14:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventStatuses]') AND type in (N'U'))
DROP TABLE [dbo].[EventStatuses]
GO
/****** Object:  Table [dbo].[EventStatuses]    Script Date: 05/09/2014 00:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventStatuses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventStatus] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product_Service_Sections]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_Sections]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product_Service_Sections](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Description] [nvarchar](100) NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Product_Service_Sections] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product_Service_Categories]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_Categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product_Service_Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTitle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Product_Services_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[PeriodTypes]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PeriodTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PeriodTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Value] [int] NULL,
 CONSTRAINT [PK_PeriodTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ImageTypes]    Script Date: 05/09/2014 00:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImageTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ImageTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageType] [nvarchar](10) NULL,
 CONSTRAINT [PK_ImageTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[SocialUsers]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SocialUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SocialUsers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[SocialNetworkName] [nvarchar](50) NULL,
	[Token] [nvarchar](100) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastLogin] [datetime] NULL,
 CONSTRAINT [PK_SocialUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05/09/2014 00:14:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[LastLogin] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Images]    Script Date: 05/09/2014 00:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Images]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Images](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ImageTypeId] [int] NULL,
	[Title] [nvarchar](50) NULL,
	[Path] [nvarchar](100) NOT NULL,
	[FileSize] [int] NULL,
	[FileFormat] [nvarchar](5) NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product_Service_SubCategories]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_SubCategories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product_Service_SubCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[SubCategoryTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product_Service_SubCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Products_Services]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products_Services]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Products_Services](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CategoryId] [int] NULL,
	[SubCategoryId] [int] NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Products_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[System_Social_UsersAssociation]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[System_Social_UsersAssociation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[SocialUserId] [bigint] NOT NULL,
 CONSTRAINT [PK_System_Social_UsersAssociation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Receipts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Receipts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptDate] [datetime] NULL,
	[SerialNumber] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[UserId] [bigint] NULL,
	[CreatedOn] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WarrantyCards]    Script Date: 05/09/2014 00:14:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarrantyCards]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WarrantyCards](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[WarrantyExpireOn] [datetime] NULL,
	[CreatedOn] [datetime] NULL,
	[UserId] [bigint] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_WarrantyCards] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[WarrantyCardImages]    Script Date: 05/09/2014 00:14:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WarrantyCardImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[WarrantyCardId] [bigint] NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_WarrantyCardImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReceiptImages]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReceiptImages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReceiptImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ReceiptId] [bigint] NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_ReceiptImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[My_Products_Services]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[My_Products_Services]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[My_Products_Services](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
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
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product_Service_Images]    Script Date: 05/09/2014 00:14:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product_Service_Images](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Product_Service_Id] [bigint] NULL,
	[ImageId] [bigint] NULL,
 CONSTRAINT [PK_Product_Service_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[EventsInfo]    Script Date: 05/09/2014 00:14:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EventsInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EventsInfo](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
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
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  ForeignKey [FK_Events_EventStatuses]    Script Date: 05/09/2014 00:14:07 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_EventStatuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventStatuses] FOREIGN KEY([EventStatusId])
REFERENCES [dbo].[EventStatuses] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_EventStatuses]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] CHECK CONSTRAINT [FK_Events_EventStatuses]
GO
/****** Object:  ForeignKey [FK_Events_MyProductsServices]    Script Date: 05/09/2014 00:14:07 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_MyProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo]  WITH CHECK ADD  CONSTRAINT [FK_Events_MyProductsServices] FOREIGN KEY([My_Product_Service_Id])
REFERENCES [dbo].[My_Products_Services] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_MyProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] CHECK CONSTRAINT [FK_Events_MyProductsServices]
GO
/****** Object:  ForeignKey [FK_Events_NotifyBeforePeriodType]    Script Date: 05/09/2014 00:14:07 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_NotifyBeforePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo]  WITH CHECK ADD  CONSTRAINT [FK_Events_NotifyBeforePeriodType] FOREIGN KEY([NotifyBefore_PeriodTypeId])
REFERENCES [dbo].[PeriodTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_NotifyBeforePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] CHECK CONSTRAINT [FK_Events_NotifyBeforePeriodType]
GO
/****** Object:  ForeignKey [FK_Events_ReoccurancePeriodType]    Script Date: 05/09/2014 00:14:07 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_ReoccurancePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo]  WITH CHECK ADD  CONSTRAINT [FK_Events_ReoccurancePeriodType] FOREIGN KEY([Reoccurance_PeriodTypeId])
REFERENCES [dbo].[PeriodTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_ReoccurancePeriodType]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] CHECK CONSTRAINT [FK_Events_ReoccurancePeriodType]
GO
/****** Object:  ForeignKey [FK_Events_Users]    Script Date: 05/09/2014 00:14:07 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Events_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[EventsInfo]'))
ALTER TABLE [dbo].[EventsInfo] CHECK CONSTRAINT [FK_Events_Users]
GO
/****** Object:  ForeignKey [FK_Images_ImageTypes]    Script Date: 05/09/2014 00:14:07 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_ImageTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_ImageTypes] FOREIGN KEY([ImageTypeId])
REFERENCES [dbo].[ImageTypes] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Images_ImageTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Images]'))
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_ImageTypes]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_ParentProductsServices]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ParentProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_ParentProductsServices] FOREIGN KEY([Parent_My_Product_Service_Id])
REFERENCES [dbo].[My_Products_Services] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ParentProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_ParentProductsServices]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_ProductsServices]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_ProductsServices] FOREIGN KEY([Product_Service_Id])
REFERENCES [dbo].[Products_Services] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_ProductsServices]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Receipts]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_Receipts] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipts] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_Receipts]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Sections]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Sections]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_Sections] FOREIGN KEY([SectionId])
REFERENCES [dbo].[Product_Service_Sections] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Sections]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_Sections]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_Users]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_Users]
GO
/****** Object:  ForeignKey [FK_MyProductsServices_WarrantyCards]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_MyProductsServices_WarrantyCards] FOREIGN KEY([WarrantyCardId])
REFERENCES [dbo].[WarrantyCards] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MyProductsServices_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[My_Products_Services]'))
ALTER TABLE [dbo].[My_Products_Services] CHECK CONSTRAINT [FK_MyProductsServices_WarrantyCards]
GO
/****** Object:  ForeignKey [FK_ProductServiceImages_Images]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images]  WITH CHECK ADD  CONSTRAINT [FK_ProductServiceImages_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images] CHECK CONSTRAINT [FK_ProductServiceImages_Images]
GO
/****** Object:  ForeignKey [FK_ProductServiceImages_ProductsServices]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images]  WITH CHECK ADD  CONSTRAINT [FK_ProductServiceImages_ProductsServices] FOREIGN KEY([Product_Service_Id])
REFERENCES [dbo].[Products_Services] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductServiceImages_ProductsServices]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_Images]'))
ALTER TABLE [dbo].[Product_Service_Images] CHECK CONSTRAINT [FK_ProductServiceImages_ProductsServices]
GO
/****** Object:  ForeignKey [FK_Category_SubCategory]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Category_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_SubCategories]'))
ALTER TABLE [dbo].[Product_Service_SubCategories]  WITH CHECK ADD  CONSTRAINT [FK_Category_SubCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Product_Service_Categories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Category_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Product_Service_SubCategories]'))
ALTER TABLE [dbo].[Product_Service_SubCategories] CHECK CONSTRAINT [FK_Category_SubCategory]
GO
/****** Object:  ForeignKey [FK_ProductsServices_Category]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_ProductsServices_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Product_Service_Categories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] CHECK CONSTRAINT [FK_ProductsServices_Category]
GO
/****** Object:  ForeignKey [FK_ProductsServices_SubCategory]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_ProductsServices_SubCategory] FOREIGN KEY([SubCategoryId])
REFERENCES [dbo].[Product_Service_SubCategories] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] CHECK CONSTRAINT [FK_ProductsServices_SubCategory]
GO
/****** Object:  ForeignKey [FK_ProductsServices_Users]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services]  WITH CHECK ADD  CONSTRAINT [FK_ProductsServices_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProductsServices_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Products_Services]'))
ALTER TABLE [dbo].[Products_Services] CHECK CONSTRAINT [FK_ProductsServices_Users]
GO
/****** Object:  ForeignKey [FK_ReceiptImages_Images]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptImages_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages] CHECK CONSTRAINT [FK_ReceiptImages_Images]
GO
/****** Object:  ForeignKey [FK_ReceiptImages_Receipts]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptImages_Receipts] FOREIGN KEY([ReceiptId])
REFERENCES [dbo].[Receipts] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReceiptImages_Receipts]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReceiptImages]'))
ALTER TABLE [dbo].[ReceiptImages] CHECK CONSTRAINT [FK_ReceiptImages_Receipts]
GO
/****** Object:  ForeignKey [FK_Receipts_Users]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Receipts_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Receipts]'))
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Receipts_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Receipts]'))
ALTER TABLE [dbo].[Receipts] CHECK CONSTRAINT [FK_Receipts_Users]
GO
/****** Object:  ForeignKey [FK_SocialUser_Association]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SocialUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation]  WITH CHECK ADD  CONSTRAINT [FK_SocialUser_Association] FOREIGN KEY([SocialUserId])
REFERENCES [dbo].[SocialUsers] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SocialUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation] CHECK CONSTRAINT [FK_SocialUser_Association]
GO
/****** Object:  ForeignKey [FK_SystemUser_Association]    Script Date: 05/09/2014 00:14:08 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SystemUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation]  WITH CHECK ADD  CONSTRAINT [FK_SystemUser_Association] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SystemUser_Association]') AND parent_object_id = OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]'))
ALTER TABLE [dbo].[System_Social_UsersAssociation] CHECK CONSTRAINT [FK_SystemUser_Association]
GO
/****** Object:  ForeignKey [FK_User_Role]    Script Date: 05/09/2014 00:14:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_Role]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_User_Role]
GO
/****** Object:  ForeignKey [FK_WarrantyCardImages_Images]    Script Date: 05/09/2014 00:14:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages]  WITH CHECK ADD  CONSTRAINT [FK_WarrantyCardImages_Images] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Images] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_Images]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages] CHECK CONSTRAINT [FK_WarrantyCardImages_Images]
GO
/****** Object:  ForeignKey [FK_WarrantyCardImages_WarrantyCards]    Script Date: 05/09/2014 00:14:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages]  WITH CHECK ADD  CONSTRAINT [FK_WarrantyCardImages_WarrantyCards] FOREIGN KEY([WarrantyCardId])
REFERENCES [dbo].[WarrantyCards] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_WarrantyCards]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCardImages]'))
ALTER TABLE [dbo].[WarrantyCardImages] CHECK CONSTRAINT [FK_WarrantyCardImages_WarrantyCards]
GO
/****** Object:  ForeignKey [FK_WarrantyCards_Users]    Script Date: 05/09/2014 00:14:09 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCards_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCards]'))
ALTER TABLE [dbo].[WarrantyCards]  WITH CHECK ADD  CONSTRAINT [FK_WarrantyCards_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_WarrantyCards_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[WarrantyCards]'))
ALTER TABLE [dbo].[WarrantyCards] CHECK CONSTRAINT [FK_WarrantyCards_Users]
GO
