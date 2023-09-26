CREATE PROCEDURE [dbo].[spBookings_Insert]
	@roomId int,
	@guestId int,
	@startDate date,
	@endDate date,
	@totalCost money

AS
begin
	set nocount on;

	insert into dbo.BookingsTable (RoomId, GuestId, StartDate, EndDate, TotalCost)
	values (@roomId, @guestId, @startDate, @endDate, @totalCost)
end
