CREATE PROCEDURE [dbo].[spBookings_FindReservation]

@todaysDate date,
@firstName nvarchar(20),
@lastName nvarchar(20)

AS
BEGIN
	
	select b.Id, r.RoomNumber, rt.Title, g.FirstName, g.LastName, b.StartDate, b.EndDate, b.CheckedIn, rt.Price, b.TotalCost
from dbo.BookingsTable b
inner join dbo.GuestsTable g on g.Id = b.GuestId
inner join dbo.RoomsTable r on r.Id = b.RoomId
inner join dbo.RoomTypeTable rt on rt.Id = r.RoomTypeId
where b.StartDate = @todaysDate and g.FirstName = @firstName and g.LastName = @lastName

END
