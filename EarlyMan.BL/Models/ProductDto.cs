using System;

namespace EarlyMan.BL.Models
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; } 

        public string Description { get; set; } 

        public string ImageLocation { get; set; } 

        public decimal CurrentPrice { get; set; }
    }
}