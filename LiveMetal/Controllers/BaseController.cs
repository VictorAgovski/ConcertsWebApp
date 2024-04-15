using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiveMetal.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
