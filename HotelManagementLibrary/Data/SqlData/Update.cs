using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Data.SqlData
{
    public class Update : IUpdate
    {
        string connection = "Default";
        private readonly ISqlDataAccess _db;
        public Update(ISqlDataAccess db)
        {
            _db = db;
        }

        public void CheckIn(int bookingId)
        {

            _db.SaveData("spBookings_CheckIn",
                        new { bookingId },
                        connection,
                        true);
        }
    }
}
