using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApp.Pages
{
    public class BookingModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomType1Choice { get; set; }

        [BindProperty(SupportsGet = true)]
        public int RoomType2Choice { get; set; }

        public void OnGet()
        {
        }
    }
}
