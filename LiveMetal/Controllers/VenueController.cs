using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Venue;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    public class VenueController : BaseController
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allVenues = await _venueService.GetAllVenuesWithFeatures();
            return View(allVenues);
        }
    }
}
