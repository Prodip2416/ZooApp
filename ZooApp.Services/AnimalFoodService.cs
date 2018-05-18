using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalFoodService
    {
        ZooContext db = new ZooContext();
        public List<ViewFoodTotal> ViewFoodTotalsDetails()
        {
           var animalFoodGroup =db.AnimalFoods.GroupBy(x => x.FoodId);
            IQueryable<ViewFoodTotal> foodTotals =
                from foodGroup in animalFoodGroup
                let totalQuentity = foodGroup.Sum(x => x.Animal.Quantity*x.Quantity)
                let food = foodGroup.FirstOrDefault()
                select new ViewFoodTotal()
                {
                    FoodPrice =food.Food.Price,
                    FoodName = food.Food.Name,
                    TotalQuentity = totalQuentity,
                    TotalPrice = totalQuentity*food.Food.Price,
                    Id = food.Id,
                    FoodId = food.FoodId
                };
            return foodTotals.ToList();
        }

        public List<ViewFoodTotal> ViewFoodTotalsDetailsByFoodId(int id)
        {
            var animalFoodGroup = db.AnimalFoods.Where(x=>x.FoodId==id).GroupBy(x => x.FoodId);
            IQueryable<ViewFoodTotal> foodTotals =
                from foodGroup in animalFoodGroup
                let totalQuentity = foodGroup.Sum(x => x.Animal.Quantity * x.Quantity)
                let food = foodGroup.FirstOrDefault()
                select new ViewFoodTotal()
                {
                    FoodPrice = food.Food.Price,
                    FoodName = food.Food.Name,
                    TotalQuentity = totalQuentity,
                    TotalPrice = totalQuentity * food.Food.Price,
                    Id = food.Id,
                    FoodId = food.FoodId
                };
            return foodTotals.ToList();
        }
    }
}
