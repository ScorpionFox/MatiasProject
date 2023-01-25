using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatiasProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAutorService autorService;
        private readonly IGatunekService gatunekService;
        private readonly IWydawnictwoService wydawnictwoService;

        public BookController(IBookService bookService, IAutorService autorService, IGatunekService gatunekService, IWydawnictwoService wydawnictwoService)
        {
            this.bookService = bookService;
            this.autorService = autorService;
            this.gatunekService = gatunekService;
            this.wydawnictwoService = wydawnictwoService;
        }


        public IActionResult Add()
        {
            var model = new Book();
            model.AutorLista = autorService.GetAll().Select(a => new SelectListItem { Text = a.NameAutor, Value = a.Id.ToString() }).ToList();
            model.WydawnictwoLista = wydawnictwoService.GetAll().Select(a => new SelectListItem { Text = a.NameWydawnictwo, Value = a.Id.ToString() }).ToList();
            model.GatunekLista = gatunekService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AutorLista = autorService.GetAll().Select(a => new SelectListItem { Text = a.NameAutor, Value = a.Id.ToString(), Selected = a.Id == model.AutorId }).ToList();
            model.WydawnictwoLista = wydawnictwoService.GetAll().Select(a => new SelectListItem { Text = a.NameWydawnictwo, Value = a.Id.ToString(), Selected = a.Id == model.WydawnictwoId }).ToList();
            model.GatunekLista = gatunekService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GatunekId }).ToList(); 

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Add(model);
            if (result == true)
            {
                TempData["msg"] = "Dodano Pomyślnie";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Wystąpił błąd";
                return View(model);
            }
        }

        public IActionResult Update(int id)
        {
            var model = bookService.FindById(id);
            model.AutorLista = autorService.GetAll().Select(a => new SelectListItem { Text = a.NameAutor, Value = a.Id.ToString(), Selected = a.Id == model.AutorId }).ToList();
            model.WydawnictwoLista = wydawnictwoService.GetAll().Select(a => new SelectListItem { Text = a.NameWydawnictwo, Value = a.Id.ToString(), Selected = a.Id == model.WydawnictwoId }).ToList();
            model.GatunekLista = gatunekService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GatunekId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AutorLista = autorService.GetAll().Select(a => new SelectListItem { Text = a.NameAutor, Value = a.Id.ToString(), Selected = a.Id == model.AutorId }).ToList();
            model.WydawnictwoLista = wydawnictwoService.GetAll().Select(a => new SelectListItem { Text = a.NameWydawnictwo, Value = a.Id.ToString(), Selected = a.Id == model.WydawnictwoId }).ToList();
            model.GatunekLista = gatunekService.GetAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GatunekId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Update(model);
            if (result == true)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                TempData["msg"] = "Wystąpił błąd";
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var result = bookService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = bookService.GetAll();
            return View(data);
        }
    }
}
