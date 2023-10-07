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
                            int roomTypeId)
        {
            GuestModel guest = _db.LoadData<GuestModel, dynamic>("spGuests_Insert",
                                                                 new { firstName, lastName },
                                                                 connection,
                                                                 true).First();

            RoomTypeModel roomType = _db.LoadData<RoomTypeModel, dynamic>("select * from dbo.RoomTypeTable where Id = @roomTypeId",
                                                                          new { roomTypeId },
                                                                          connection).First();

            TimeSpan stayDuration = endDate.Subtract(startDate);

            List<RoomModel> availableRooms = _db.LoadData<RoomModel, dynamic>("dbo.spRooms_GetAvailableRooms",
                                                                              new { startDate, endDate, roomTypeId },
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
