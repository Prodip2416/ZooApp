using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;

namespace ZooApp.Web.Mvc.Controllers
{
    public class FoodController : Controller
    {
       FoodService service= new FoodService();
        public ActionResult Index()
        {
            return View(service.GetAll().ToList());
        }

   
        public ActionResult Details(int id)
        {
            Food food = service.GetFoodById(id);
            return View(food);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                var save = service.Save(food);
                return RedirectToAction("Index");
            }        
             return View(food);
        }
        public ActionResult Edit(int id)
        {
            Food food = service.GetFoodById(id);
            return View(food);
        }

        [HttpPost]
        public ActionResult Edit(Food food )
        {
            try
            {
                var update = service.Update(food);
                if (update)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            Food food = service.GetFoodById(id);
            return View(food);
        }
        [HttpPost]
        public ActionResult Delete(Food food)
        {
            try
            {
                var delete = service.Delete(food);
                if (delete)
                {
                    return RedirectToAction("Index");
                }
                return View(food);
            }
            catch
            {
                return View();
            }
        }
    }
}
