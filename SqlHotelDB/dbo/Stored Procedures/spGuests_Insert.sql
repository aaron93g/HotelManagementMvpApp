CREATE PROCEDURE [dbo].[spGuests_Insert]
	@firstName nvarchar(20),
	@lastName nvarchar(20)	
AS
begin

	set nocount on;

	if not exists(select 1 from dbo.GuestsTable where FirstName = @firstName and LastName = @lastName)
	begin
		insert into dbo.GuestsTable (FirstName, LastName)
		values (@firstName, @lastName)
	end

	select top 1 [Id], [FirstName], [LastName]
	from dbo.GuestsTable
	where FirstName = @firstName and LastName = @lastName
end
