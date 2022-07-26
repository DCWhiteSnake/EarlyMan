using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EarlyMan.DL.Entities
{
    public class Cart
    {
        public Guid CartId { get; set; }
   
        [Precision(18, 2)]
        public decimal Total { get; set; }

        public bool IsValid { get; set; }
        
        
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset ModificationDate { get; set; }

    }
}