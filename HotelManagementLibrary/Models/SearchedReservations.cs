using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Models
{
    public class SearchedReservations
    {
        public int BookingsId { get; set; }
        public string ReservationRoomNumber { get; set; }
        public string ReservationRoomTitle { get; set; }
        public string ReservationFirstName { get; set; }
        public string ReservationLastName { get; set; }
        public DateOnly ReservationStartDate { get; set; }
        public DateOnly ReservationEndDate { get; set;}
        public bool ReservationCheckedIn { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal ReservationTotalCost { get; set; }
    }
}
