CREATE VIEW [dbo].[V_PlayerUpdated]
	AS SELECT * FROM [Player]
		WHERE UpdatedAt IS NOT NULL
