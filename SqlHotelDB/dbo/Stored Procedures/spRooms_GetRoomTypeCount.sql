CREATE PROCEDURE [dbo].[spRooms_GetRoomTypeCount]
@startDate date,
@endDate date,
@roomOption int

AS
BEGIN
	set nocount on;

select [r].[Id], [r].[RoomTypeId], [r].[RoomNumber]
from dbo.RoomsTable r
where r.RoomTypeId = @roomOption AND (r.Id not in(

--selects the RoomId that is interefered by the new booking(dates)
select b.RoomId
from dbo.BookingsTable b
where (@startDate >= b.StartDate and @endDate <= b.EndDate) or
		(@startDate <= b.StartDate and @endDate >= b.EndDate) or
		(@startDate <= b.StartDate and (@endDate >= b.StartDate and @endDate <= b.EndDate) or
		((@startDate >= b.StartDate and @startDate <= b.EndDate) and @endDate >= b.EndDate))

		))
END
