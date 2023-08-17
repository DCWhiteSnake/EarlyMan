using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Models
{
    public class ProductForCreationDto : ProductForManipulationDto
    {
        public decimal CurrentPrice { get; set; }

        [Required(ErrorMessage = "Every product requires an image, please provide the name of the product\'s image resource")]
        public string ImageLocation { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You need to provide product quantity you currently have, minimum of 1")]
        public int AvailableUnits { get; set; }
    }
}