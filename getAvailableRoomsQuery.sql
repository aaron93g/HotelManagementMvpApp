
declare @startDate date = '12/05/2023';
declare @endDate date = '12/12/2023';
declare @roomOption int = '1';


select count(r.Id)
from dbo.RoomsTable r
inner join dbo.RoomTypeTable rt on rt.Id = r.RoomTypeId
where rt.Id = @roomOption AND (r.Id not in(

--selects the RoomId that is interefered by the new booking(dates)
select b.RoomId
from dbo.BookingsTable b
where (@startDate >= b.StartDate and @endDate <= b.EndDate) or
		(@startDate <= b.StartDate and @endDate >= b.EndDate) or
		(@startDate <= b.StartDate and (@endDate >= b.StartDate and @endDate <= b.EndDate) or
		((@startDate >= b.StartDate and @startDate <= b.EndDate) and @endDate >= b.EndDate))

		))