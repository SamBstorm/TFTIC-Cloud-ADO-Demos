CREATE PROCEDURE [dbo].[SP_Player_Insert]
	@pseudo NVARCHAR(32),
	@email VARCHAR(320)
AS
BEGIN
	SET @email = TRIM(@email)
	IF(@email NOT LIKE '% %' AND LEN(@email) >= 3)
	BEGIN
		INSERT INTO [dbo].[Player] ([Pseudo], [Email])
			OUTPUT inserted.PlayerId
			VALUES (@pseudo, @email)
	END
END
