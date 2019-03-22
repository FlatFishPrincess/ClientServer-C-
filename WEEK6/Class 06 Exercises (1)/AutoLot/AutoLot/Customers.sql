CREATE TABLE [dbo].[Customers]
(
	[CustId] INT NOT NULL IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustId])
)
