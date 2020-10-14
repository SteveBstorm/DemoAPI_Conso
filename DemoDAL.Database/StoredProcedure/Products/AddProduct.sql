CREATE PROCEDURE [dbo].[AddProduct]
	@Name VARCHAR(150),
	@BrandId INT,
	@EAN13 CHAR(13),
	@Price DECIMAL(10,2)
AS
BEGIN
	INSERT INTO Product (Name, BrandId, EAN13, Price) OUTPUT inserted.Id VALUES (@Name, @BrandId, @EAN13, @Price)
END