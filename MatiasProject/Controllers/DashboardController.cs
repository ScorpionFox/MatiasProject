using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatiasProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }
}
