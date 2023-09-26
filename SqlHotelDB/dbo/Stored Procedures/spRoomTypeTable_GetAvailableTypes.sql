CREATE PROCEDURE [dbo].[spRoomTypeTable_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
Begin
	set nocount on;

	select rt.Id, rt.Title, rt.Description, rt.Price
from dbo.RoomsTable r
inner join dbo.RoomTypeTable rt on r.RoomTypeId = rt.Id
where r.Id not in (

--selects the RoomId that is interefered by the new booking(dates)
select b.RoomId
from dbo.BookingsTable b
where (@startDate >= b.StartDate and @endDate <= b.EndDate) or
		(@startDate <= b.StartDate and @endDate >= b.EndDate) or
		(@startDate <= b.StartDate and (@endDate >= b.StartDate and @endDate <= b.EndDate) or
		((@startDate >= b.StartDate and @startDate <= b.EndDate) and @endDate >= b.EndDate))

		)

group by rt.Id, rt.Title, rt.Description, rt.Price
End