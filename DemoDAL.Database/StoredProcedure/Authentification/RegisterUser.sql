CREATE PROCEDURE [dbo].[RegisterUser]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
Begin
	INSERT INTO Utilisateur (LastName, FirstName, Email, Passwd)
	VALUES (@LastName, @FirstName, @Email, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()));
End
