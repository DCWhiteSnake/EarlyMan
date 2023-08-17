using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Models
{
    public class ProductForUpdateDto : ProductForManipulationDto
    {
        [Range((double)0.1M, (double)decimal.MaxValue,
            ErrorMessage = "You Product requires a price")]
        public decimal CurrentPrice { get; set; }

        public string ImageLocation { get; set; }
    }
}