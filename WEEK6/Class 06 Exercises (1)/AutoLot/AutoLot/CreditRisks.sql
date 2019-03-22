CREATE TABLE [dbo].[CreditRisks]
(
	[CustId] INT NOT NULL IDENTITY,
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    CONSTRAINT [PK_CreditRisks] PRIMARY KEY ([CustId])
)
