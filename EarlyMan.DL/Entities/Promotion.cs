using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyMan.DL.Entities
{
    public class Promotion
    {
        [Key]
        public Guid PromotionId { get; set; }   
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string ImageLocation { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}