CREATE TABLE [dbo].[RoomsTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomTypeId] INT NOT NULL, 
    [RoomNumber] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_RoomsTable_RoomTypeTable] FOREIGN KEY (RoomTypeId) REFERENCES RoomTypeTable(Id)
)
