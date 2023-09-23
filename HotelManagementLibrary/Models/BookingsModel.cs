using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementLibrary.Models
{
    public class BookingsModel
    {
        public int BookingId { get; set; }
        public RoomModel RoomConnection { get; set; } = new RoomModel();
        public GuestModel GuestConnection { get; set; } = new GuestModel();
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();
        public bool CheckedIn { get; set; }
        public decimal TotalCost { get; set; }
    }
}
