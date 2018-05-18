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
    public class AnimalService
    {
        ZooContext db = new ZooContext();
        // Return animal list............
        public List<ViewAnimals> GetAll()
        {
            List<Animal> animals = db.Animals.ToList();

            List<ViewAnimals> viewAnimalses= new List<ViewAnimals>();

            foreach (Animal animal in animals)
            {
                ViewAnimals viewAnimal = new ViewAnimals(animal);
                
                viewAnimalses.Add(viewAnimal);
            }
            return viewAnimalses;
        }

        // Save animal to database.............
        public bool Save(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
            return true;

        }

        // Return animal details...........
        public ViewAnimals Get(int id)
        {
            Animal animal = db.Animals.Find(id);
            return new ViewAnimals(animal);
        }

        public bool Update(Animal animal)
        {
            db.Entry(animal).State=EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public Animal GetAnimalById(int id)
        {
            return db.Animals.Find(id);
        }

        public bool Delete(Animal animal)
        {
            Animal animals = db.Animals.Find(animal.Id);
            db.Animals.Remove(animals);
            db.SaveChanges();
            return true;
        }
    }
}
