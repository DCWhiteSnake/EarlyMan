using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Models.ViewModels
{
    public interface ILoginModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression(".+\\@.+\\..+",
          ErrorMessage = "Please enter a valid email address")]
        [UIHint("email")]
        string Email { get; set; }

        [Required]
        [UIHint("password")]
        string Password { get; set; }
    }
}