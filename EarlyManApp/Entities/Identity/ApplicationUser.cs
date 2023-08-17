using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string HomeAddress { get; set; } = "";
        public string ShippingAddress1 { get; set; } = "";
        public string ShippingAddress2 { get; set; } = "";
        public bool HasAddress { get; set; }
        public bool AccountActive { get; set; }
        
       
    }
}
