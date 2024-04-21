using LiveMetal.Core.Contracts;
using LiveMetal.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    public class BandController : Controller
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
    }
}
