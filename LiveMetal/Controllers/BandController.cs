using LiveMetal.Core.Contracts;
using LiveMetal.Core.Models.Band;
using LiveMetal.Core.Models.Member;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    public class BandController : BaseController
    {
        private readonly IBandService _bandService;
        private readonly IMemberService _memberService;

        public BandController(IBandService bandService, IMemberService memberService)
        {
            _bandService = bandService;
            _memberService = memberService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var allBands = await _bandService.GetAllBandsWithFeatures();
            return View(allBands);
        }

        [HttpGet]
        [AllowAnonymous]
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
    }
}
