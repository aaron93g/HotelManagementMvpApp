CREATE TABLE [dbo].[BookingsTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoomId] INT NOT NULL, 
    [GuestId] INT NOT NULL, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [CheckedIn] BIT NOT NULL DEFAULT 0, 
    [TotalCost] MONEY NOT NULL, 
    CONSTRAINT [FK_BookingsTable_GuestsTable] FOREIGN KEY (GuestId) REFERENCES GuestsTable(Id), 
    CONSTRAINT [FK_BookingsTable_RoomsTable] FOREIGN KEY (RoomId) REFERENCES RoomsTable(Id)
)
