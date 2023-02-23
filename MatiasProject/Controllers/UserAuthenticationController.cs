using MatiasProject.Models.DTO;
using MatiasProject.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MatiasProject.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService service;
        public UserAuthenticationController(IUserAuthenticationService service)
        {
            this.service = service;
        }


        public IActionResult Registration()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.Role = "user";
            var result = await service.RegistrationAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await service.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("GetAll", "Book");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await service.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

        //stworzenie admina
        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel
        //    {
        //        UserName = "admin",
        //        Name = "Matias",
        //        Email = "matias@gmail.com",
        //        Password = "Admin@12345#",
        //    };
        //    model.Role = "admin";
        //    var result = await service.RegistrationAsync(model);
        //    return Ok(result);
        //}
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }
            var result = await service.ChangePasswordAsync(model, User.Identity.Name);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(ChangePassword));
        }
    }
}
