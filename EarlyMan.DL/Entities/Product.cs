using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.DL.Entities
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Precision(18, 2)]
        public decimal CurrentPrice { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public string ImageLocation { get; set; }
        
       
        public double DiscountPercentage { get; set; } = 0.0D;

        public int AvailableUnits { get; set; }

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset ModificationDate { get; set; }
        public bool IsAvailable { get; set; }


        /*
        // public bool UpdateProductQuantity(int purchaseAmount, IProductRepository) 
        // {
        //     AvailableUnits -= purchaseAmount; 
        // }
        */
    }
}