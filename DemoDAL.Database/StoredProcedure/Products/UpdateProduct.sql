CREATE PROCEDURE [dbo].[UpdateProduct]
	@Name VARCHAR(150),
	@EAN13 CHAR(13),
	@BrandId INT,
	@Price DECIMAL(10,2),
	@Id INT
AS
BEGIN
	UPDATE Product SET Name = @Name, EAN13 = @EAN13, BrandId = @BrandId, Price = @Price
	WHERE Id = @Id
END