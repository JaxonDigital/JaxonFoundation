using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Validators.DataAnnotations
{
    /// <summary>
    /// Validates email field.
    /// </summary>
    public class IsValidEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                EmailAddressAttribute emailAddressAttribute = new EmailAddressAttribute();

                if (!emailAddressAttribute.IsValid(value))
                {
                    return new ValidationResult($"Please enter a valid email in the '{validationContext.MemberName}' field.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
