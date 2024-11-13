using System.ComponentModel.DataAnnotations;

namespace EventManageApp.Core.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;

        public MaxFileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    var maxFileSizeInMB = Math.Round((double)_maxFileSize / (1024 * 1024), 2);
                    return new ValidationResult($"File size must not exceed {maxFileSizeInMB} MB.");
                }
            }
            return ValidationResult.Success;
        }
    }
}