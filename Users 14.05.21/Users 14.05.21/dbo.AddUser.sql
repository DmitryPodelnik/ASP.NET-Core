CREATE PROCEDURE [dbo].[AddUser]
	@username nvarchar(50),
	@password nvarchar(50),
	@email nvarchar(320)
AS
	INSERT INTO Users(Username, Password, Email)
			VALUES(@username, @password, @email)
