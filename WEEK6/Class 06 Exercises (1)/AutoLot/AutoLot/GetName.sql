CREATE PROCEDURE GetName
@carID int,
@name char(10) output
AS
SELECT @name = Name from Inventory where CarId = @carID