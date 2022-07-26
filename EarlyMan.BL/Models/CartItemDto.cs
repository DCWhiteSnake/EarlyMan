namespace EarlyMan.BL.Models
{
    public class CartItemDto
    {   
        public Guid ProductId { get; set; }
        
        public int PurchaseQuantity { get; set; }
        
        public decimal PurchasePrice { get; set; } 
    }
}
