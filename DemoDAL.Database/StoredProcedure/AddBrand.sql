CREATE PROCEDURE [dbo].[AddBrand]
	@Name VARCHAR(50)
AS
BEGIN
	INSERT INTO Brand (Name) OUTPUT inserted.Id VALUES (@Name)
END
