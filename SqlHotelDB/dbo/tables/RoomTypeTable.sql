﻿CREATE TABLE [dbo].[RoomTypeTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(2000) NOT NULL, 
    [Price] MONEY NOT NULL
)
