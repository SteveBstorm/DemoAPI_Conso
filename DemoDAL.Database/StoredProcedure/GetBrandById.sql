CREATE PROCEDURE [dbo].[GetBrandById]
	@Id int
AS
BEGIN
	SELECT Id, Name FROM Brand WHERE Id = @Id
END