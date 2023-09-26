CREATE PROCEDURE [dbo].[spRooms_GetAvailableRooms]
	@startDate date,
	@endDate date,
	@roomTypeId int
AS

begin
	
	select r.*
	from dbo.RoomsTable r
	inner join dbo.RoomTypeTable rt on r.RoomTypeId = rt.Id
	where r.RoomTypeId = @roomTypeId and
	r.Id not in 
	(

		--selects the RoomId that is interefered by the new booking(dates)
		select b.RoomId
		from dbo.BookingsTable b
		where (@startDate >= b.StartDate and @endDate <= b.EndDate) or
				(@startDate <= b.StartDate and @endDate >= b.EndDate) or
				(@startDate <= b.StartDate and (@endDate >= b.StartDate and @endDate <= b.EndDate) or
				((@startDate >= b.StartDate and @startDate <= b.EndDate) and @endDate >= b.EndDate))

	)

end