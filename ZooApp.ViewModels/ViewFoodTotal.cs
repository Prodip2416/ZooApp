using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models.Migrations;
using AnimalFood = ZooApp.Models.AnimalFood;

namespace ZooApp.ViewModels
{
    public class ViewFoodTotal
    {
        public ViewFoodTotal()
        {

        }
        public ViewFoodTotal(AnimalFood animal)
        {
            FoodName = animal.Food.Name;
            FoodPrice = animal.Food.Price;
            TotalQuentity = animal.Animal.Quantity* animal.Quantity;
        TotalPrice = FoodPrice* TotalQuentity;
            Id = animal.Id;
            FoodId = animal.FoodId;
        }
    public int Id { get; set; }
        public int FoodId { get; set; } 

        public double TotalPrice { get; set; }

        public double TotalQuentity  { get; set; }

        public double FoodPrice  { get; set; }

        public string FoodName   { get; set; }
    }
}
