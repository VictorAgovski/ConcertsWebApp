using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Member;
using LiveMetal.Core.Services;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Areas.Admin.Controllers
{
    public class BandController : AdminBaseController
    {
        private readonly IBandService _bandService;
        private readonly IMemberService _memberService;

        public BandController(IBandService bandService, IMemberService memberService)
        {
            _bandService = bandService;
            _memberService = memberService;
        }

        public async Task<IActionResult> All()
        {
            var allBands = await _bandService.GetAllBandsWithFeatures();
            return View(allBands);
        }

        public async Task<IActionResult> MemberDetails(int memberId)
        {
            var member = await _memberService.GetMemberDetailsById(memberId);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(BandMemberCreateViewModel model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var band = await _bandService.GetBandById(model.BandId);

            if (band == null)
            {
                return NotFound($"No band found with ID {model.BandId}");
            }

            await _memberService.CreateMemberAsync(model);

            return RedirectToAction("All");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMember(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var member = await _memberService.GetMemberDetailsById(id);

            if (member == null)
            {
                return NotFound();
            }

            await _memberService.DeleteMemberAsync(id);

            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var model = new BandCreateViewModel
            {
                Members = new List<BandMemberCreateViewModel> { new BandMemberCreateViewModel() }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BandCreateViewModel model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _bandService.CreateBandAsync(model);
            return RedirectToAction("All");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBand(Band model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            await _bandService.DeleteBandAsync(model);
            return RedirectToAction("All");
        }
    }
}
