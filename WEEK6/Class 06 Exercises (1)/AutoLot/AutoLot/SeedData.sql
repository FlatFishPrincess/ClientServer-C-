/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
/*
 * Delete all orders, the clear each table and insert new data
 * This runs post-build, assumes tables have been created.
 *
 */
delete from dbo.Orders
go
DBCC CHECKIDENT ('[Orders]', RESEED, 0)
go
DELETE FROM [dbo].Customers
go
DBCC CHECKIDENT ('[Customers]', RESEED, 0)
go
SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (1, N'Mike', N'Jones')
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (2, N'John', N'Smith')
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (3, N'Navdeep', N'Kaur')
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (4, N'Sapreet', N'Singh')
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (5, N'Paul', N'Wu')
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (6, N'Mary', N'Wong')
INSERT INTO [dbo].[Customers] ([CustId], [FirstName], [LastName]) VALUES (7, N'Susan', N'Landerson')
SET IDENTITY_INSERT [dbo].[Customers] OFF
go
delete from [dbo].Inventory
go
DBCC CHECKIDENT ('[Inventory]', RESEED, 0)
go
SET IDENTITY_INSERT [dbo].[Inventory] ON
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (1, N'Honda', N'White', N'Civic')
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (2, N'BMW', N'Blue', N'I3')
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (3, N'Ford', N'White', N'Focus')
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (4, N'Ford', N'Black', N'Fusion')
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (5, N'Chevy', N'Red', N'Malibu')
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (6, N'Lincoln', N'Silver', N'MK4')
INSERT INTO [dbo].[Inventory] ([CarId], [Make], [Color], [Name]) VALUES (7, N'Toyota', N'Green', N'Yaris')
SET IDENTITY_INSERT [dbo].[Inventory] OFF
go
set identity_insert [dbo].Orders on
insert into [dbo].Orders (OrderId, CarId, CustId) values (1, 1, 2)
insert into [dbo].Orders (OrderId, CarId, CustId) values (2, 2, 3)
insert into [dbo].Orders (OrderId, CarId, CustId) values (3, 3, 4)
insert into [dbo].Orders (OrderId, CarId, CustId) values (4, 3, 5)
set identity_insert dbo.Orders off
go
