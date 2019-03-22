CREATE VIEW [dbo].[CustomerOrders]
	AS SELECT [Customers].*, [Inventory].* 
	FROM [Orders] 
		inner join [Customers] on [Customers].CustId = [Orders].CustId
		inner join [Inventory] on [Inventory].CarId = [Orders].CarId
