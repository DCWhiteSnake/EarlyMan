using EarlyMan.DL.Entities;
namespace EarlyMan.BL.Models
{
    public class CartForUpdateDto
    {
        public ICollection<CartItem> CartItems { get; set; } = 
            new List<CartItem>();

        public DateTimeOffset ModificationDate { get; set; }


    }
}