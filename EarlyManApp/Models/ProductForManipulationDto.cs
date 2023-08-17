using EarlyMan.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Models
{
    [ProductNameMustBeDifferentFromDescription]
    public abstract class ProductForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a Name")]
        [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 characters")]
        public string Name { get; set; }

        [MaxLength(1500, ErrorMessage = "The description shouldn't have more than 1500 characters.")]
        public virtual string Description { get; set; }
    }
}