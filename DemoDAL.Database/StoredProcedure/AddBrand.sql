CREATE PROCEDURE [dbo].[AddBrand]
	@Name VARCHAR(50)
AS
BEGIN
	INSERT INTO Brand (Name) OUTPUT inserted.id VALUES (@Name)
END
