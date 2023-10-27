using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApp.Pages
{
    public class BookingModel : PageModel
    {
        private IRead _read;
        private ICreate _create;

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int roomType1Choice { get; set; }

        [BindProperty(SupportsGet = true)] 
        public int roomType2Choice { get; set; } 

        [BindProperty] 
        public List<RoomTypeModel> RoomOptions { get ; set ; } 

        [BindProperty] 
        public decimal StayTotal1 { get; set; } 

        [BindProperty] 
        public decimal StayTotal2 { get; set; } 

        [BindProperty] 
        public string FirstName { get; set; } 

        [BindProperty] 
        public string LastName { get; set; } 

        public BookingModel(IRead read, ICreate create) 
        {
            _read = read;
            _create = create;
        }



        public void OnGet() 
        { 
            StartDate = StartDate; 
            EndDate = EndDate; 
            roomType1Choice = roomType1Choice; 
            roomType2Choice = roomType2Choice; 
            RoomOptions = _read.GetRoomOptions(StartDate, EndDate); 
        } 

        public IActionResult OnPost() 
        {
            _create.Booking(FirstName,
                            LastName,
                            StartDate,
                            EndDate,
                            roomType1Choice,
                            roomType2Choice);

            return RedirectToPage("/Index");
        }
    }
}
