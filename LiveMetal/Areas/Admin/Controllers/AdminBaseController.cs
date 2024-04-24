using LiveMetal.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static LiveMetal.Core.Constants.AdministratorConstants;

namespace LiveMetal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    [CustomAuthorization]
    public class AdminBaseController : Controller
    {

    }
}
