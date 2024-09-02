CREATE TABLE [dbo].[GameSession]
(
	[GameSessionId] INT NOT NULL IDENTITY,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [MaxPlayer] TINYINT NOT NULL DEFAULT 2, 
    CONSTRAINT PK_GameSession PRIMARY KEY ([GameSessionId])
)
