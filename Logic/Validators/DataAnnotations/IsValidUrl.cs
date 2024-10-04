using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Validators.DataAnnotations
{
    /// <summary>
    /// Validates URL Field.
    /// </summary>
    public class IsValidUrl : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                UrlAttribute urlAttribute = new UrlAttribute();

                if (!urlAttribute.IsValid(value))
                {
                    return new ValidationResult($"Please enter a valid URL in the '{validationContext.MemberName}' field.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
