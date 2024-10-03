using System.ComponentModel.DataAnnotations;
using EPiServer.ServiceLocation;


namespace JaxonFoundation.Logic.Validators.DataAnnotations
{
    /// <summary>
    /// Validates whether a content reference with allowed type <see cref="GenericFile"/> is a file with an allowed type/extension.
    /// </summary>
    public class IsValidFileType : ValidationAttribute
    {
        private IContentLoader _contentLoader;
        private readonly string[] _allowedFileTypes;

        public IsValidFileType(IContentLoader contentLoader, params string[] allowedFileTypes)
        {
            _contentLoader = contentLoader;
            _allowedFileTypes = allowedFileTypes.Select(ext => ext.ToUpper()).ToArray();
        }

        public IsValidFileType(params string[] allowedFileTypes) : this(ServiceLocator.Current.GetInstance<IContentLoader>(), allowedFileTypes)
        {
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            // Empty value is okay.
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // If we can cast the value to a generic file, do so.
            var file = _contentLoader.Get<Models.Media.GenericFile>((ContentReference)value);
            if (file != null)
            {
                // Check if the given file has one of the allowed file types/extensions.
                if (!_allowedFileTypes.Contains(file.FileType.ToUpper()))
                {
                    return new ValidationResult($"The file uploaded to \"{validationContext.DisplayName}\" is not one of the allowed file types (has {file.FileType}). It must be of one of the following types: {string.Join(", ", _allowedFileTypes)}.");
                }
            }
            else
            {
                // If the file is not a GenericFile and it's not null, some invalid content has been added.
                return new ValidationResult($"The file uploaded to \"{validationContext.DisplayName}\" is invalid.");
            }

            return ValidationResult.Success;
        }
    }
}
