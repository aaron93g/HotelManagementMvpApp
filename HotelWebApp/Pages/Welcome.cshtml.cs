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
        public bool SearchEnabled { get; set; } = false;

        public List<RoomTypeModel> RoomOptions { get; set; }

        public WelcomeModel(IRead read)
        {
            _read = read;
        }

        public void OnGet()
        {
            if(SearchEnabled == true)
            {
                RoomOptions = _read.GetRoomOptions(StartDate, EndDate);
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage(new { SearchEnabled = true, StartDate, EndDate});
        }
    }
}
