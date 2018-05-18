using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.ViewModels;

namespace ZooApp.Web.Mvc.Controllers
{
    public class AnimalController : Controller
    {
        AnimalService service = new AnimalService();
        public ActionResult Index()
        {
            var animalList = service.GetAll();
            return View(animalList);
        }

        public ActionResult Details(int id)
        {
            var animalList = service.Get(id);
            return View(animalList);
        }
        [HttpGet]
        public ActionResult Create()
        {  
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                bool saved = service.Save(animal);
                return RedirectToAction("Index");
            }

            return View(animal);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Animal animal = service.GetAnimalById(id);
            return View(animal);
        }
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            bool saved = service.Update(animal);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Animal animal = service.GetAnimalById(id);
            return View(animal);
        }
        [HttpPost]
        public ActionResult Delete(Animal animal)
        {
            bool saved = service.Delete(animal);
            return RedirectToAction("Index");

        }
    }
}