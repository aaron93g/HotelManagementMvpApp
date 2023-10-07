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
    public class Read : IRead
    {
        private const string connection = "Default";
        private readonly ISqlDataAccess _db;
        public Read(ISqlDataAccess db)
        {
            _db = db;
        }


        //READ


        public (int roomType1, int roomType2) GetOptionsCount(DateTime startDate, DateTime endDate)
        {
            int roomType1;
            int roomType2;

            roomType1 = _db.LoadData<RoomModel, dynamic>("spRooms_GetRoomTypeCount",
                                                         new { roomOption = 1, startDate, endDate },
                                                         connection,
                                                         true).Count;

            roomType2 = _db.LoadData<RoomModel, dynamic>("spRooms_GetRoomTypeCount",
                                                         new { roomOption = 2, startDate, endDate },
                                                         connection,
                                                         true).Count;

            return (roomType1, roomType2);
        }

        public List<RoomTypeModel> GetRoomOptions(DateTime startDate, DateTime endDate)
        {
                    
            return _db.LoadData<RoomTypeModel, dynamic>("dbo.spRoomTypeTable_GetAvailableTypes",
                                                       new { startDate, endDate },
                                                       connection,
                                                       true);
        }


        public List<SearchedReservations> SearchBooking(string firstName, string lastName)
        {
            DateTime todaysDate = DateTime.Now.Date;

            List<SearchedReservations> listOfReservations = _db.LoadData<SearchedReservations, dynamic>("dbo.spBookings_FindReservation",
                                                                                                  new { firstName, lastName, todaysDate },
                                                                                                  connection,
                                                                                                  true);
            return listOfReservations;
        }
    }
}
