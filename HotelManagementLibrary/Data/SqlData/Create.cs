using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.DataBases;
using HotelManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Data.SqlData
{
    public class Create : ICreate
    {
        string connection = "Default";
        private readonly ISqlDataAccess _db;
        public Create(ISqlDataAccess db)
        {
            _db = db;
        }

        public void Booking(string firstName, 
                            string lastName,
                            DateTime startDate,
                            DateTime endDate,
                            int roomType1Choice,
                            int roomType2Choice)
        {
             if(roomType1Choice > 0)
            {
                for (int i = 0; roomType1Choice > i; i++)
                {

                    GuestModel guest = _db.LoadData<GuestModel, dynamic>("spGuests_Insert",
                                                     new { firstName, lastName },
                                                     connection,
                                                     true).First();

                    RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypeTable where Id = @roomTypeId",
                                                                                  new { roomTypeId = 1 },
                                                                                  connection).First();

                    TimeSpan stayDuration = endDate.Subtract(startDate);

                    List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
                                                                                      new { startDate, endDate, roomTypeId = 1 },
                                                                                      connection,
                                                                                      true);

                    _db.SaveData("dbo.spBookings_Insert",
                                 new
                                 {
                                     roomId = availableRooms.First().Id,
                                     guestId = guest.GuestId,
                                     startDate = startDate,
                                     endDate = endDate,
                                     totalCost = stayDuration.Days * roomType.Price
                                 },
                                 connection,
                                 true);
                }
            }

            if (roomType2Choice > 0)
            {
                for (int i = 0; roomType2Choice > i; i++)
                {

                    GuestModel guest = _db.LoadData<GuestModel, dynamic>("spGuests_Insert",
                                                     new { firstName, lastName },
                                                     connection,
                                                     true).First();

                    RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypeTable where Id = @roomTypeId",
                                                                                  new { roomTypeId = 2 },
                                                                                  connection).First();

                    TimeSpan stayDuration = endDate.Subtract(startDate);

                    List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
                                                                                      new { startDate, endDate, roomTypeId = 2 },
                                                                                      connection,
                                                                                      true);

                    _db.SaveData("dbo.spBookings_Insert",
                                 new
                                 {
                                     roomId = availableRooms.First().Id,
                                     guestId = guest.GuestId,
                                     startDate = startDate,
                                     endDate = endDate,
                                     totalCost = stayDuration.Days * roomType.Price
                                 },
                                 connection,
                                 true);
                }
            }

        }


    }
}
