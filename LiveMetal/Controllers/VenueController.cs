using LiveMetal.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        public async Task<IActionResult> All()
        {
            var allVenues = await _venueService.GetAllVenuesWithFeatures();
            return View(allVenues);
        }
    }
}
