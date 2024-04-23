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

        [HttpGet]
        public IActionResult Create()
        {
            return View(new VenueCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VenueCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _venueService.AddVenueAsync(model);
                return RedirectToAction("All");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while creating the venue");
                return View(model);
            }
        }
    }
}
