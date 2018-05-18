using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public partial class Animal 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("IX_AnimalName",1,IsUnique = true)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Index("IX_AnimalOrigin")]
        public string Origin { get; set; }  
        public ICollection<AnimalFood> AnimalFoods { get; set; }
        [Required]
        public int Quantity { get; set; }

    }

    public partial class Animal:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
         //   var result = new List<ValidationResult>();

            ZooContext db = new ZooContext();
            Name = Name.ToLower();
            var nameAnimal = db.Animals.FirstOrDefault(x => x.Name.ToLower() == Name);

            if (nameAnimal != null)
            {
                ValidationResult error = new ValidationResult("Name already exists", new[] { "Name" });
               // result.Add(error);
               yield return error;
            }
          //  return result;
        }
    }
}
