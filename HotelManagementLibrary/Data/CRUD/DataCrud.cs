using HotelManagementLibrary.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Data.CRUD
{
    public class DataCrud
    {
        string connection = "Default";
        private readonly ISqlDataAccess _db;
        public DataCrud(ISqlDataAccess db)
        {
            _db = db;
        }
        
        private readonly SqlDataAccess db;
        public DataCrud(SqlDataAccess connectionString)
        {
            db = connectionString;
        }
    }
}
