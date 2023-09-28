CREATE PROCEDURE [dbo].[spBookings_CheckIn]

 @checkingId int

AS

BEGIN
	set nocount on;

	update dbo.BookingsTable set CheckedIn = 1
	where Id = @checkingId

END