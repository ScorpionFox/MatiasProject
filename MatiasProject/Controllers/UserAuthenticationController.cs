using Microsoft.AspNetCore.Mvc;

namespace MatiasProject.Controllers
{
    public class UserAuthentication : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
