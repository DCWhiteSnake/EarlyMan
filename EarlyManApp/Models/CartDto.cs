using EarlyMan.Entities;

namespace EarlyMan.Models
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public List<CartItem> CartItems { get; set; } 
            = new List<CartItem>();

        public decimal Total { get; set; }


        public bool IsValid { get; set; }
    }
}