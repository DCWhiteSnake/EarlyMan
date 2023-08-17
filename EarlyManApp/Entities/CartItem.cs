using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyMan.Entities
{
    //[EnsureTimeObject IsOrderedIsInThePresent]
    public class CartItem
    {
        [Key]
        public Guid CartItemId { get; set; }
        
        //[ForeignKey("CartId")]
        public Guid CartId { get; set; }

        //[ForeignKey("ProductId")]
        public Guid ProductId { get; set; } 

        public int PurchaseQuantity { get; set; } = 0;
        
        [Precision(18, 2)]
        public decimal PurchasePrice { get; set; } = 0M;
        
        [Precision(18, 2)]
        public decimal SubTotal{get;set;}

        public DateTimeOffset CreationDate { get; set; }

        public DateTimeOffset ModificationDate { get; set; } 

        public bool Valid { get; set; }
    }
}