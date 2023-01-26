using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatiasProject.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
