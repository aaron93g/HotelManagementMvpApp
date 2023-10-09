using HotelManagementLibrary.Data.DataInterfaces;
using HotelManagementLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HotelWebApp.Pages
{
    public class WelcomeModel : PageModel
    {
        private IRead _read;

        //[DataType(DataType.Date)]
        [BindProperty (SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        //[DataType(DataType.Date)]
        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Now;

        [BindProperty (SupportsGet = true)]
        public int roomType1Choice { get; set; }

        [BindProperty (SupportsGet = true)]
        public int roomType2Choice { get; set; }

        [BindProperty (SupportsGet = true)]
        public bool SearchEnabled { get; set; } = false;

        public List<RoomTypeModel> RoomOptions { get; set; }

        public (int roomType1, int roomType2) TypeCount { get; set; }

        public WelcomeModel(IRead read)
        {
            _read = read;
        }

        public void OnGet()
        {
            if(SearchEnabled == true)
            {
                RoomOptions = _read.GetRoomOptions(StartDate, EndDate);
                TypeCount = _read.GetOptionsCount(StartDate, EndDate);
            }
        }

        public IActionResult OnPost()
        {

            return RedirectToPage(new { 
                                    SearchEnabled = true, 
                                    StartDate = StartDate.ToString(format: "yyyy-MM-dd"), 
                                    EndDate = EndDate.ToString(format: "yyyy-MM-dd"),
                                    roomType1Choice = roomType1Choice,
                                    roomType2Choice = roomType2Choice});
        }
    }
}
