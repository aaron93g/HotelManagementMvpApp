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
        
        private readonly SqlDataAccess db;
        public DataCrud(SqlDataAccess connectionString)
        {
            db = connectionString;
        }
    }
}
