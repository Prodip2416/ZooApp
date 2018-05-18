using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        ZooContext db = new ZooContext();
        // Return animal list............
        public List<ViewFood> GetAll()
        {
            var food = db.Foods.ToList();

            List<ViewFood> viewFoods = new List<ViewFood>();

            foreach (var l in food)
            {
                ViewFood viewFood = new ViewFood(l);
              
                viewFoods.Add(viewFood);
            }
            return viewFoods;
        }

        // Save animal to database.............
        public bool Save(Food food)
        {
            db.Foods.Add(food);
            db.SaveChanges();
            return true;

        }

        // Return animal details...........
        public object Get(int id)
        {
            Food food = db.Foods.Find(id);
            return new ViewFood(food)
            {
                Id = food.Id,
                Name = food.Name
            };
        }

        public bool Update(Food food)
        {
            db.Entry(food).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public Food GetFoodById(int id)
        {
            return db.Foods.Find(id);
        }

        public bool Delete(Food food)
        {
            Food f = db.Foods.Find(food.Id);
            db.Foods.Remove(f);
            db.SaveChanges();
            return true;
        }
    }
}
