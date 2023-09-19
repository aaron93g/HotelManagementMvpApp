/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists( select 1 from dbo.RoomTypeTable)
begin
    insert into dbo.RoomTypeTable(Title, Description, Price)
    values('Single Room', 'A room with 1 king size bed.', 25.45),
    ('Double Room', 'A room with 2 full size beds.', 40.49)
end

if not exists( select 1 from dbo.RoomsTable)
begin
    declare @roomId1 int;
    declare @roomId2 int;

    select @roomId1 = Id from dbo.RoomTypeTable where Title = 'Single Room';
    select @roomId2 = Id from dbo.RoomTypeTable where Title = 'Double Room';

    insert into dbo.RoomsTable(RoomNumber, RoomTypeId)
    values('101', @roomId1),
    ('102', @roomId2),
    ('201', @roomId1),
    ('202', @roomId2),
    ('301', @roomId1),
    ('302', @roomId2)
    
end