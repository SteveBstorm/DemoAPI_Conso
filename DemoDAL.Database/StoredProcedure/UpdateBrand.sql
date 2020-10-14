CREATE PROCEDURE [dbo].[UpdateBrand]
	@Id INT,
	@Name VARCHAR(50)
AS
BEGIN
	UPDATE Brand SET Name = @Name WHERE Id = @Id
END 
