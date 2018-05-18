using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public partial class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("IX_Food",1,IsUnique = true)]
        public string Name { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
        [Required]
        public double Price { get; set; }     
    }

    public partial class Food : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            ZooContext db = new ZooContext();
            Name = Name.ToUpper();
            var nameAnimal = db.Foods.FirstOrDefault(x => x.Name.ToUpper() == Name);

            if (nameAnimal != null)
            {
                ValidationResult error = new ValidationResult("Name already exists", new[] {"Name"});
                result.Add(error);
            }

            return result;
        }
    }
}
