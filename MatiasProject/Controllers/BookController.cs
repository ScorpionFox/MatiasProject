﻿using MatiasProject.Models.Domain;
using MatiasProject.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MatiasProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService service;
        public BookController(IBookService service)
        {
            this.service = service;
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
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
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
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
            var result = service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return View(data);
        }
    }
}
