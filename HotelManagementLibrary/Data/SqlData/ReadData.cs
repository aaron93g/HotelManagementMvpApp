﻿using HotelManagementLibrary.DataBases;
using HotelManagementLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Data.SqlData
{
    public class ReadData
    {
        string connection = "Default";
        private readonly ISqlDataAccess _db;
        public ReadData(ISqlDataAccess db)
        {
            _db = db;
        }


        //READ

        //Get RoomTypes
        public List<RoomTypeModel> GetRoomOptions(DateTime startDate, DateTime endDate)
        {
            RoomModel room = new RoomModel();
            string sqlStatement = "";

            sqlStatement = "dbo.spRoomTypeTable_GetAvailableTypes;";
            return _db.LoadData<RoomTypeModel, dynamic>(sqlStatement,
                                                       new { startDate, endDate },
                                                       connection,
                                                       true);
        }
    }
}