/*****************************************************************
IMPORTANT!!

This script only work after fresh db creation, other wise it will cause errors
*****************************************************************/

USE [ORMS]

/* Add lookup data in roles table  */
DELETE FROM [Roles];
DBCC CHECKIDENT ('[Roles]', RESEED)
INSERT INTO [Roles](Title) Values('User');
INSERT INTO [Roles](Title) Values('Admin');
GO

/* Add lookup data in [Product_Service_Categories] table  */
DELETE FROM [Product_Service_Categories];
DBCC CHECKIDENT ('[Product_Service_Categories]', RESEED)
INSERT INTO [Product_Service_Categories](CategoryTitle) Values('Computers - Hardware');
INSERT INTO [Product_Service_Categories](CategoryTitle) Values('Electronics');
INSERT INTO [Product_Service_Categories](CategoryTitle) Values('Home - Furniture - Garden Supplies');
GO

/* Add lookup data in [Product_Service_Categories] table  */
DELETE FROM [Product_Service_SubCategories];
DBCC CHECKIDENT ('[Product_Service_SubCategories]', RESEED)
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(1, 'Laptops');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(1, 'Printers');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(1, 'External Drives');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(1, 'Other');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(2, 'Refrigerators');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(2, 'Air Conditioners');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(2, 'Cell Phones');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(2, 'Other');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(3, 'Bedroom');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(3, 'Garden');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(3, 'Bathroom');
INSERT INTO [Product_Service_SubCategories](CategoryId, SubCategoryTitle) Values(3, 'Other');
GO
