using System.ComponentModel.DataAnnotations;

namespace JaxonFoundation.Logic.Validators.DataAnnotations
{
    /// <summary>
	/// IF added as an annotation to a Content Area, it is not possible
	/// to add more than the stated amount of items.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MaxItemCount : ValidationAttribute
    {
        private readonly int maxItemCount;

        public MaxItemCount(int maxItemCount)
        {
            this.maxItemCount = maxItemCount;
        }

        public override bool IsValid(object? value)
        {
            if (value is ContentArea contentArea)
            {
                if (contentArea?.Items == null)
                {
                    return true;
                }

                return contentArea.Count <= maxItemCount;
            }
            else
            {
                IEnumerable<object>? list = value as IEnumerable<object>;

                if (list == null)
                {
                    return true;
                }

                return list.Count() <= maxItemCount;
            }
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var result = base.IsValid(value, validationContext);

            if (!string.IsNullOrWhiteSpace(result?.ErrorMessage))
            {
                if (value is ContentArea)
                {
                    result.ErrorMessage = $"Content Area '{validationContext.DisplayName}' can not contain more than {maxItemCount} items.";
                }
                else
                {
                    result.ErrorMessage = $"List '{validationContext.DisplayName}' can not contain more than {maxItemCount} items.";
                }
            }

            return result;
        }
    }
}
