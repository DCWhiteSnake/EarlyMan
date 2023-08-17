using EarlyMan.Entities;
namespace EarlyMan.Models
{
    public class CartForUpdateDto
    {
        public ICollection<CartItem> CartItems { get; set; } = 
            new List<CartItem>();

        public DateTimeOffset ModificationDate { get; set; }


    }
}