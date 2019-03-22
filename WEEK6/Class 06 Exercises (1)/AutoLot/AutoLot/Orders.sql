CREATE TABLE [dbo].[Orders]
(
	[OrderId] INT NOT NULL IDENTITY, 
    [CustId] INT NOT NULL, 
    [CarId] INT NOT NULL, 
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]), 
    CONSTRAINT [FK_Orders_Customer] FOREIGN KEY ([CustId]) REFERENCES [Customers]([CustId]), 
    CONSTRAINT [FK_Orders_Inventory] FOREIGN KEY ([CarId]) REFERENCES [Inventory]([CarId]) 
)
