CREATE TABLE [dbo].[Inventory]
(
	[CarId] INT NOT NULL IDENTITY, 
    [Make] NVARCHAR(50) NULL, 
    [Color] NVARCHAR(50) NULL, 
    [Name] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_Inventory] PRIMARY KEY ([CarId])
)
