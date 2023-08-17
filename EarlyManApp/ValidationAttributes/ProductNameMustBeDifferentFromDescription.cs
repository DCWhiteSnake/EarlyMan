
using EarlyMan.Models;
using EarlyMan.Entities;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.ValidationAttributes
{
    public class ProductNameMustBeDifferentFromDescription : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            if (product.Description == product.Name)
            {
                return new ValidationResult(ErrorMessage, new[] { nameof(ProductForManipulationDto) });
            }
            
            return ValidationResult.Success;
            
        }
    }
}