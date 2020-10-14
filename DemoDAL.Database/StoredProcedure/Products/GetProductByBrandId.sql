CREATE PROCEDURE [dbo].[GetProductByBrandId]
	@Id INT
AS
BEGIN
SELECT * FROM Product WHERE BrandId = @Id
END