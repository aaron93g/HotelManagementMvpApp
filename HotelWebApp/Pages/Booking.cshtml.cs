using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApp.Pages
{
    public class BookingModel : PageModel
    {
        private IRead _read;

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int roomType1Choice { get; set; }

        [BindProperty(SupportsGet = true)]
        public int roomType2Choice { get; set; }

        [BindProperty] // ? use static session(cookies) ?use multiple named handler methods
        public List<RoomTypeModel> RoomOptions { get ; set ; }

        public BookingModel(IRead read)
        {
            _read = read;
        }

        public void OnGet()
        {
            StartDate = StartDate;
            EndDate = EndDate;
            roomType1Choice = roomType1Choice;
            roomType2Choice = roomType2Choice;
            RoomOptions = _read.GetRoomOptions(StartDate, EndDate);
        }
    }
}
