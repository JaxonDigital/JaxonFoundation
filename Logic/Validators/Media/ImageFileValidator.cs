using EPiServer.Validation;
using JaxonFoundation.Logic.Models.Media;

namespace JaxonFoundation.Logic.Validators.Media
{
    public class ImageFileValidator : IValidate<ImageFile>
    {
        public IEnumerable<ValidationError> Validate(ImageFile file)
        {

            List<string> extensions = new List<string>();
            extensions.Add(".jpg");
            extensions.Add(".jpeg");
            extensions.Add(".jpe");
            extensions.Add(".ico");
            extensions.Add(".gif");
            extensions.Add(".bmp");
            extensions.Add(".png");

            string? fileExtension = Path.GetExtension(file.Name);

            if (!extensions.Contains(fileExtension) || fileExtension == null)
            {
                yield return new ValidationError
                {
                    ErrorMessage = "Name must include file extension of .jpg, .jpeg, .jpe, .ico, .gif, .bmp, or .png",
                    Severity = ValidationErrorSeverity.Error,
                    ValidationType = ValidationErrorType.PropertyValidation
                };
            }
        }
    }
}