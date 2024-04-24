using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Venue;
using LiveMetal.Core.Services;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Areas.Admin.Controllers
{
    public class VenueController : AdminBaseController
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

        [HttpGet]
        public IActionResult Create()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

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

            if (!User.IsAdmin())
            {
                return Unauthorized();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var model = _venueService.GetAllVenuesWithFeatures().Result.Where(v => v.Id == id).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }

            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            await _venueService.DeleteVenueAsync(model);
            return RedirectToAction("All");
        }
    }
}
