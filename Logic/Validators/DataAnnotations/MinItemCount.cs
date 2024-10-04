using EPiServer.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Validators.DataAnnotations
{
    /// <summary>
    /// IF added as an annotation to a Content Area, it is not possible
    /// to add less than the stated amount of items.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MinItemCount : ValidationAttribute
    {
        private readonly int minItemCount;

        public MinItemCount(int minItemCount)
        {
            this.minItemCount = minItemCount;
        }

        public override bool IsValid(object? value)
        {
            var contentArea = value as ContentArea;

            if (contentArea?.Items == null)
            {
                return true;
            }

            return contentArea.Count >= minItemCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);

            if (!string.IsNullOrWhiteSpace(result?.ErrorMessage))
            {
                result.ErrorMessage = $"Content Area '{validationContext.DisplayName}' can not contain less than {minItemCount} items.";
            }

            return result;
        }
    }
}
