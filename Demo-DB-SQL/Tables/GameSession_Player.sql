CREATE TABLE [dbo].[GameSession_Player]
(
	[GameSessionId] INT NOT NULL , 
    [PlayerId] INT NOT NULL, 
    CONSTRAINT PK_GameSession_Player PRIMARY KEY ([GameSessionId], [PlayerId]), 
    CONSTRAINT [FK_GameSession_Player_Player] FOREIGN KEY (PlayerId) REFERENCES [Player]([PlayerId]), 
    CONSTRAINT [FK_GameSession_Player_GameSession] FOREIGN KEY (GameSessionId) REFERENCES [GameSession]([GameSessionId])
)
