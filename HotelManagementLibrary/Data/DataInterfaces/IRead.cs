using HotelManagementLibrary.Models;

namespace HotelManagementLibrary.Data.DataInterfaces
{
    public interface IRead
    {
        List<RoomTypeModel> GetRoomOptions(DateTime startDate, DateTime endDate);
        List<SearchedReservations> SearchBooking(string firstName, string lastName);
    }
}