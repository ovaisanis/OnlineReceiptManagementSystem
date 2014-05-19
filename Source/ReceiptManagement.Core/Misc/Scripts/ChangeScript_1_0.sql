USE [ORMS]

/* Add lookup data in roles table  */

DELETE FROM [Roles];
DBCC CHECKIDENT ('[Roles]', RESEED)
INSERT INTO [Roles](Title) Values('User');
INSERT INTO [Roles](Title) Values('Admin');
GO
