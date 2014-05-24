
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2014 01:04:49
-- Generated from EDMX file: C:\FAISAL\MS(CS)\Advance Web Technologies\Project\Github\OnlineReceiptManagementSystem\Source\ReceiptManagement.Core\Model\OrmsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ORMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Events_EventStatuses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventsInfoes] DROP CONSTRAINT [FK_Events_EventStatuses];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_MyProductsServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventsInfoes] DROP CONSTRAINT [FK_Events_MyProductsServices];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_NotifyBeforePeriodType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventsInfoes] DROP CONSTRAINT [FK_Events_NotifyBeforePeriodType];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_ReoccurancePeriodType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventsInfoes] DROP CONSTRAINT [FK_Events_ReoccurancePeriodType];
GO
IF OBJECT_ID(N'[dbo].[FK_Events_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventsInfoes] DROP CONSTRAINT [FK_Events_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Images_ImageTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Images] DROP CONSTRAINT [FK_Images_ImageTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductServiceImages_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Service_Images] DROP CONSTRAINT [FK_ProductServiceImages_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_ReceiptImages_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceiptImages] DROP CONSTRAINT [FK_ReceiptImages_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_Images]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantyCardImages] DROP CONSTRAINT [FK_WarrantyCardImages_Images];
GO
IF OBJECT_ID(N'[dbo].[FK_MyProductsServices_ParentProductsServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_ParentProductsServices];
GO
IF OBJECT_ID(N'[dbo].[FK_MyProductsServices_ProductsServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_ProductsServices];
GO
IF OBJECT_ID(N'[dbo].[FK_MyProductsServices_Receipts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Receipts];
GO
IF OBJECT_ID(N'[dbo].[FK_MyProductsServices_Sections]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Sections];
GO
IF OBJECT_ID(N'[dbo].[FK_MyProductsServices_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_MyProductsServices_WarrantyCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[My_Products_Services] DROP CONSTRAINT [FK_MyProductsServices_WarrantyCards];
GO
IF OBJECT_ID(N'[dbo].[FK_Category_SubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Service_SubCategories] DROP CONSTRAINT [FK_Category_SubCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductsServices_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductServiceImages_ProductsServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Product_Service_Images] DROP CONSTRAINT [FK_ProductServiceImages_ProductsServices];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductsServices_SubCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_SubCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductsServices_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products_Services] DROP CONSTRAINT [FK_ProductsServices_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_ReceiptImages_Receipts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReceiptImages] DROP CONSTRAINT [FK_ReceiptImages_Receipts];
GO
IF OBJECT_ID(N'[dbo].[FK_Receipts_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Receipts] DROP CONSTRAINT [FK_Receipts_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_SocialUser_Association]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[System_Social_UsersAssociation] DROP CONSTRAINT [FK_SocialUser_Association];
GO
IF OBJECT_ID(N'[dbo].[FK_SystemUser_Association]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[System_Social_UsersAssociation] DROP CONSTRAINT [FK_SystemUser_Association];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantyCards_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantyCards] DROP CONSTRAINT [FK_WarrantyCards_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_WarrantyCardImages_WarrantyCards]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WarrantyCardImages] DROP CONSTRAINT [FK_WarrantyCardImages_WarrantyCards];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EventsInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventsInfoes];
GO
IF OBJECT_ID(N'[dbo].[EventStatuses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventStatuses];
GO
IF OBJECT_ID(N'[dbo].[Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Images];
GO
IF OBJECT_ID(N'[dbo].[ImageTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImageTypes];
GO
IF OBJECT_ID(N'[dbo].[My_Products_Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[My_Products_Services];
GO
IF OBJECT_ID(N'[dbo].[PeriodTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodTypes];
GO
IF OBJECT_ID(N'[dbo].[Product_Service_Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Service_Categories];
GO
IF OBJECT_ID(N'[dbo].[Product_Service_Images]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Service_Images];
GO
IF OBJECT_ID(N'[dbo].[Product_Service_Sections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Service_Sections];
GO
IF OBJECT_ID(N'[dbo].[Product_Service_SubCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product_Service_SubCategories];
GO
IF OBJECT_ID(N'[dbo].[Products_Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products_Services];
GO
IF OBJECT_ID(N'[dbo].[ReceiptImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReceiptImages];
GO
IF OBJECT_ID(N'[dbo].[Receipts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Receipts];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[SocialUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SocialUsers];
GO
IF OBJECT_ID(N'[dbo].[System_Social_UsersAssociation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[System_Social_UsersAssociation];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[WarrantyCardImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WarrantyCardImages];
GO
IF OBJECT_ID(N'[dbo].[WarrantyCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WarrantyCards];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EventsInfoes'
CREATE TABLE [dbo].[EventsInfoes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [My_Product_Service_Id] bigint  NULL,
    [EventDate] datetime  NULL,
    [EventName] nvarchar(50)  NULL,
    [EventDescription] nvarchar(100)  NULL,
    [NotifyBefore_PeriodValue] int  NULL,
    [NotifyBefore_PeriodTypeId] int  NULL,
    [Reoccurance_PeriodValue] int  NULL,
    [Reoccurance_PeriodTypeId] int  NULL,
    [EventStatusId] int  NULL,
    [UserId] bigint  NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'EventStatuses'
CREATE TABLE [dbo].[EventStatuses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EventStatus1] nvarchar(50)  NULL
);
GO

-- Creating table 'Images'
CREATE TABLE [dbo].[Images] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ImageTypeId] int  NULL,
    [Title] nvarchar(50)  NULL,
    [Path] nvarchar(100)  NOT NULL,
    [FileSize] int  NULL,
    [FileFormat] nvarchar(5)  NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL,
    [IsTrackable] bit  NOT NULL
);
GO

-- Creating table 'ImageTypes'
CREATE TABLE [dbo].[ImageTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ImageType1] nvarchar(10)  NULL
);
GO

-- Creating table 'My_Products_Services'
CREATE TABLE [dbo].[My_Products_Services] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Product_Service_Id] bigint  NULL,
    [Parent_My_Product_Service_Id] bigint  NULL,
    [SectionId] bigint  NULL,
    [ReceiptId] bigint  NULL,
    [WarrantyCardId] bigint  NULL,
    [UserId] bigint  NULL,
    [IsDeleted] bit  NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'PeriodTypes'
CREATE TABLE [dbo].[PeriodTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Value] int  NULL
);
GO

-- Creating table 'Product_Service_Categories'
CREATE TABLE [dbo].[Product_Service_Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryTitle] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Product_Service_Images'
CREATE TABLE [dbo].[Product_Service_Images] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Product_Service_Id] bigint  NULL,
    [ImageId] bigint  NULL
);
GO

-- Creating table 'Product_Service_Sections'
CREATE TABLE [dbo].[Product_Service_Sections] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nchar(10)  NULL,
    [Description] nvarchar(100)  NULL,
    [UserId] bigint  NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Product_Service_SubCategories'
CREATE TABLE [dbo].[Product_Service_SubCategories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryId] int  NULL,
    [SubCategoryTitle] nvarchar(50)  NULL
);
GO

-- Creating table 'Products_Services'
CREATE TABLE [dbo].[Products_Services] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(100)  NULL,
    [CategoryId] int  NULL,
    [SubCategoryId] int  NULL,
    [UserId] bigint  NULL,
    [Tags] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'ReceiptImages'
CREATE TABLE [dbo].[ReceiptImages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ReceiptId] bigint  NULL,
    [ImageId] bigint  NULL
);
GO

-- Creating table 'Receipts'
CREATE TABLE [dbo].[Receipts] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ReceiptDate] datetime  NULL,
    [SerialNumber] nvarchar(50)  NULL,
    [Title] nvarchar(50)  NULL,
    [Description] nvarchar(100)  NULL,
    [UserId] bigint  NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL
);
GO

-- Creating table 'SocialUsers'
CREATE TABLE [dbo].[SocialUsers] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [SocialNetworkName] nvarchar(50)  NULL,
    [Token] nvarchar(100)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [LastLogin] datetime  NULL
);
GO

-- Creating table 'System_Social_UsersAssociation'
CREATE TABLE [dbo].[System_Social_UsersAssociation] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL,
    [SocialUserId] bigint  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] nvarchar(50)  NOT NULL,
    [RoleId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [LastLogin] datetime  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'WarrantyCardImages'
CREATE TABLE [dbo].[WarrantyCardImages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [WarrantyCardId] bigint  NULL,
    [ImageId] bigint  NULL
);
GO

-- Creating table 'WarrantyCards'
CREATE TABLE [dbo].[WarrantyCards] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Description] nvarchar(100)  NULL,
    [WarrantyExpireOn] datetime  NULL,
    [CreatedOn] datetime  NULL,
    [UserId] bigint  NULL,
    [IsDeleted] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EventsInfoes'
ALTER TABLE [dbo].[EventsInfoes]
ADD CONSTRAINT [PK_EventsInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventStatuses'
ALTER TABLE [dbo].[EventStatuses]
ADD CONSTRAINT [PK_EventStatuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [PK_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImageTypes'
ALTER TABLE [dbo].[ImageTypes]
ADD CONSTRAINT [PK_ImageTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [PK_My_Products_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PeriodTypes'
ALTER TABLE [dbo].[PeriodTypes]
ADD CONSTRAINT [PK_PeriodTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product_Service_Categories'
ALTER TABLE [dbo].[Product_Service_Categories]
ADD CONSTRAINT [PK_Product_Service_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product_Service_Images'
ALTER TABLE [dbo].[Product_Service_Images]
ADD CONSTRAINT [PK_Product_Service_Images]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product_Service_Sections'
ALTER TABLE [dbo].[Product_Service_Sections]
ADD CONSTRAINT [PK_Product_Service_Sections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product_Service_SubCategories'
ALTER TABLE [dbo].[Product_Service_SubCategories]
ADD CONSTRAINT [PK_Product_Service_SubCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products_Services'
ALTER TABLE [dbo].[Products_Services]
ADD CONSTRAINT [PK_Products_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReceiptImages'
ALTER TABLE [dbo].[ReceiptImages]
ADD CONSTRAINT [PK_ReceiptImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Receipts'
ALTER TABLE [dbo].[Receipts]
ADD CONSTRAINT [PK_Receipts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SocialUsers'
ALTER TABLE [dbo].[SocialUsers]
ADD CONSTRAINT [PK_SocialUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'System_Social_UsersAssociation'
ALTER TABLE [dbo].[System_Social_UsersAssociation]
ADD CONSTRAINT [PK_System_Social_UsersAssociation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WarrantyCardImages'
ALTER TABLE [dbo].[WarrantyCardImages]
ADD CONSTRAINT [PK_WarrantyCardImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WarrantyCards'
ALTER TABLE [dbo].[WarrantyCards]
ADD CONSTRAINT [PK_WarrantyCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EventStatusId] in table 'EventsInfoes'
ALTER TABLE [dbo].[EventsInfoes]
ADD CONSTRAINT [FK_Events_EventStatuses]
    FOREIGN KEY ([EventStatusId])
    REFERENCES [dbo].[EventStatuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_EventStatuses'
CREATE INDEX [IX_FK_Events_EventStatuses]
ON [dbo].[EventsInfoes]
    ([EventStatusId]);
GO

-- Creating foreign key on [My_Product_Service_Id] in table 'EventsInfoes'
ALTER TABLE [dbo].[EventsInfoes]
ADD CONSTRAINT [FK_Events_MyProductsServices]
    FOREIGN KEY ([My_Product_Service_Id])
    REFERENCES [dbo].[My_Products_Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_MyProductsServices'
CREATE INDEX [IX_FK_Events_MyProductsServices]
ON [dbo].[EventsInfoes]
    ([My_Product_Service_Id]);
GO

-- Creating foreign key on [NotifyBefore_PeriodTypeId] in table 'EventsInfoes'
ALTER TABLE [dbo].[EventsInfoes]
ADD CONSTRAINT [FK_Events_NotifyBeforePeriodType]
    FOREIGN KEY ([NotifyBefore_PeriodTypeId])
    REFERENCES [dbo].[PeriodTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_NotifyBeforePeriodType'
CREATE INDEX [IX_FK_Events_NotifyBeforePeriodType]
ON [dbo].[EventsInfoes]
    ([NotifyBefore_PeriodTypeId]);
GO

-- Creating foreign key on [Reoccurance_PeriodTypeId] in table 'EventsInfoes'
ALTER TABLE [dbo].[EventsInfoes]
ADD CONSTRAINT [FK_Events_ReoccurancePeriodType]
    FOREIGN KEY ([Reoccurance_PeriodTypeId])
    REFERENCES [dbo].[PeriodTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_ReoccurancePeriodType'
CREATE INDEX [IX_FK_Events_ReoccurancePeriodType]
ON [dbo].[EventsInfoes]
    ([Reoccurance_PeriodTypeId]);
GO

-- Creating foreign key on [UserId] in table 'EventsInfoes'
ALTER TABLE [dbo].[EventsInfoes]
ADD CONSTRAINT [FK_Events_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Events_Users'
CREATE INDEX [IX_FK_Events_Users]
ON [dbo].[EventsInfoes]
    ([UserId]);
GO

-- Creating foreign key on [ImageTypeId] in table 'Images'
ALTER TABLE [dbo].[Images]
ADD CONSTRAINT [FK_Images_ImageTypes]
    FOREIGN KEY ([ImageTypeId])
    REFERENCES [dbo].[ImageTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Images_ImageTypes'
CREATE INDEX [IX_FK_Images_ImageTypes]
ON [dbo].[Images]
    ([ImageTypeId]);
GO

-- Creating foreign key on [ImageId] in table 'Product_Service_Images'
ALTER TABLE [dbo].[Product_Service_Images]
ADD CONSTRAINT [FK_ProductServiceImages_Images]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductServiceImages_Images'
CREATE INDEX [IX_FK_ProductServiceImages_Images]
ON [dbo].[Product_Service_Images]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'ReceiptImages'
ALTER TABLE [dbo].[ReceiptImages]
ADD CONSTRAINT [FK_ReceiptImages_Images]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReceiptImages_Images'
CREATE INDEX [IX_FK_ReceiptImages_Images]
ON [dbo].[ReceiptImages]
    ([ImageId]);
GO

-- Creating foreign key on [ImageId] in table 'WarrantyCardImages'
ALTER TABLE [dbo].[WarrantyCardImages]
ADD CONSTRAINT [FK_WarrantyCardImages_Images]
    FOREIGN KEY ([ImageId])
    REFERENCES [dbo].[Images]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WarrantyCardImages_Images'
CREATE INDEX [IX_FK_WarrantyCardImages_Images]
ON [dbo].[WarrantyCardImages]
    ([ImageId]);
GO

-- Creating foreign key on [Parent_My_Product_Service_Id] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [FK_MyProductsServices_ParentProductsServices]
    FOREIGN KEY ([Parent_My_Product_Service_Id])
    REFERENCES [dbo].[My_Products_Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MyProductsServices_ParentProductsServices'
CREATE INDEX [IX_FK_MyProductsServices_ParentProductsServices]
ON [dbo].[My_Products_Services]
    ([Parent_My_Product_Service_Id]);
GO

-- Creating foreign key on [Product_Service_Id] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [FK_MyProductsServices_ProductsServices]
    FOREIGN KEY ([Product_Service_Id])
    REFERENCES [dbo].[Products_Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MyProductsServices_ProductsServices'
CREATE INDEX [IX_FK_MyProductsServices_ProductsServices]
ON [dbo].[My_Products_Services]
    ([Product_Service_Id]);
GO

-- Creating foreign key on [ReceiptId] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [FK_MyProductsServices_Receipts]
    FOREIGN KEY ([ReceiptId])
    REFERENCES [dbo].[Receipts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MyProductsServices_Receipts'
CREATE INDEX [IX_FK_MyProductsServices_Receipts]
ON [dbo].[My_Products_Services]
    ([ReceiptId]);
GO

-- Creating foreign key on [SectionId] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [FK_MyProductsServices_Sections]
    FOREIGN KEY ([SectionId])
    REFERENCES [dbo].[Product_Service_Sections]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MyProductsServices_Sections'
CREATE INDEX [IX_FK_MyProductsServices_Sections]
ON [dbo].[My_Products_Services]
    ([SectionId]);
GO

-- Creating foreign key on [UserId] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [FK_MyProductsServices_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MyProductsServices_Users'
CREATE INDEX [IX_FK_MyProductsServices_Users]
ON [dbo].[My_Products_Services]
    ([UserId]);
GO

-- Creating foreign key on [WarrantyCardId] in table 'My_Products_Services'
ALTER TABLE [dbo].[My_Products_Services]
ADD CONSTRAINT [FK_MyProductsServices_WarrantyCards]
    FOREIGN KEY ([WarrantyCardId])
    REFERENCES [dbo].[WarrantyCards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MyProductsServices_WarrantyCards'
CREATE INDEX [IX_FK_MyProductsServices_WarrantyCards]
ON [dbo].[My_Products_Services]
    ([WarrantyCardId]);
GO

-- Creating foreign key on [CategoryId] in table 'Product_Service_SubCategories'
ALTER TABLE [dbo].[Product_Service_SubCategories]
ADD CONSTRAINT [FK_Category_SubCategory]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Product_Service_Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Category_SubCategory'
CREATE INDEX [IX_FK_Category_SubCategory]
ON [dbo].[Product_Service_SubCategories]
    ([CategoryId]);
GO

-- Creating foreign key on [CategoryId] in table 'Products_Services'
ALTER TABLE [dbo].[Products_Services]
ADD CONSTRAINT [FK_ProductsServices_Category]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Product_Service_Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductsServices_Category'
CREATE INDEX [IX_FK_ProductsServices_Category]
ON [dbo].[Products_Services]
    ([CategoryId]);
GO

-- Creating foreign key on [Product_Service_Id] in table 'Product_Service_Images'
ALTER TABLE [dbo].[Product_Service_Images]
ADD CONSTRAINT [FK_ProductServiceImages_ProductsServices]
    FOREIGN KEY ([Product_Service_Id])
    REFERENCES [dbo].[Products_Services]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductServiceImages_ProductsServices'
CREATE INDEX [IX_FK_ProductServiceImages_ProductsServices]
ON [dbo].[Product_Service_Images]
    ([Product_Service_Id]);
GO

-- Creating foreign key on [SubCategoryId] in table 'Products_Services'
ALTER TABLE [dbo].[Products_Services]
ADD CONSTRAINT [FK_ProductsServices_SubCategory]
    FOREIGN KEY ([SubCategoryId])
    REFERENCES [dbo].[Product_Service_SubCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductsServices_SubCategory'
CREATE INDEX [IX_FK_ProductsServices_SubCategory]
ON [dbo].[Products_Services]
    ([SubCategoryId]);
GO

-- Creating foreign key on [UserId] in table 'Products_Services'
ALTER TABLE [dbo].[Products_Services]
ADD CONSTRAINT [FK_ProductsServices_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductsServices_Users'
CREATE INDEX [IX_FK_ProductsServices_Users]
ON [dbo].[Products_Services]
    ([UserId]);
GO

-- Creating foreign key on [ReceiptId] in table 'ReceiptImages'
ALTER TABLE [dbo].[ReceiptImages]
ADD CONSTRAINT [FK_ReceiptImages_Receipts]
    FOREIGN KEY ([ReceiptId])
    REFERENCES [dbo].[Receipts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ReceiptImages_Receipts'
CREATE INDEX [IX_FK_ReceiptImages_Receipts]
ON [dbo].[ReceiptImages]
    ([ReceiptId]);
GO

-- Creating foreign key on [UserId] in table 'Receipts'
ALTER TABLE [dbo].[Receipts]
ADD CONSTRAINT [FK_Receipts_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Receipts_Users'
CREATE INDEX [IX_FK_Receipts_Users]
ON [dbo].[Receipts]
    ([UserId]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Role]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role'
CREATE INDEX [IX_FK_User_Role]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [SocialUserId] in table 'System_Social_UsersAssociation'
ALTER TABLE [dbo].[System_Social_UsersAssociation]
ADD CONSTRAINT [FK_SocialUser_Association]
    FOREIGN KEY ([SocialUserId])
    REFERENCES [dbo].[SocialUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SocialUser_Association'
CREATE INDEX [IX_FK_SocialUser_Association]
ON [dbo].[System_Social_UsersAssociation]
    ([SocialUserId]);
GO

-- Creating foreign key on [Id] in table 'System_Social_UsersAssociation'
ALTER TABLE [dbo].[System_Social_UsersAssociation]
ADD CONSTRAINT [FK_SystemUser_Association]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'WarrantyCards'
ALTER TABLE [dbo].[WarrantyCards]
ADD CONSTRAINT [FK_WarrantyCards_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WarrantyCards_Users'
CREATE INDEX [IX_FK_WarrantyCards_Users]
ON [dbo].[WarrantyCards]
    ([UserId]);
GO

-- Creating foreign key on [WarrantyCardId] in table 'WarrantyCardImages'
ALTER TABLE [dbo].[WarrantyCardImages]
ADD CONSTRAINT [FK_WarrantyCardImages_WarrantyCards]
    FOREIGN KEY ([WarrantyCardId])
    REFERENCES [dbo].[WarrantyCards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WarrantyCardImages_WarrantyCards'
CREATE INDEX [IX_FK_WarrantyCardImages_WarrantyCards]
ON [dbo].[WarrantyCardImages]
    ([WarrantyCardId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------