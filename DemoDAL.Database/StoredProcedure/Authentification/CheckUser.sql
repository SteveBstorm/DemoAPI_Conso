CREATE PROCEDURE [dbo].[CheckUser]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
Begin
	SELECT Id, LastName, FirstName, Email
	From Utilisateur
	Where Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
End
