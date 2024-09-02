CREATE TABLE [dbo].[Player]
(
	[PlayerId] INT NOT NULL IDENTITY,
	[Pseudo] NVARCHAR(32) NOT NULL,
	[Email] VARCHAR(320) NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [UpdatedAt] DATETIME2 NULL, 
    CONSTRAINT PK_Player PRIMARY KEY ([PlayerId]), 
    CONSTRAINT [CK_Player_Email] CHECK ([Email] LIKE '_%@_%' AND [Email] NOT LIKE '%@%@%')
)

GO

CREATE UNIQUE INDEX [IX_Player_Pseudo] ON [dbo].[Player] ([Pseudo])

GO

CREATE UNIQUE INDEX [IX_Player_Email] ON [dbo].[Player] ([Email])

GO

/*CREATE TRIGGER [dbo].[TR_Player_UpdatedAt]
    ON [dbo].[Player]
    INSTEAD OF UPDATE
    AS
    BEGIN
        SET NoCount ON
        UPDATE [dbo].[Player]
            SET Email = inserted.Email,
                UpdatedAt = GETDATE()
            WHERE PlayerId = inserted.PlayerId
                
    END
    */