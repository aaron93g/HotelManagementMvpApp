namespace HotelManagementLibrary.Data.DataInterfaces
{
    public interface ICreate
    {
        void Booking(string firstName,
                     string lastName,
                     DateTime startDate,
                     DateTime endDate,
                     int roomType1Choice,
                     int roomType2Choice);
    }
}