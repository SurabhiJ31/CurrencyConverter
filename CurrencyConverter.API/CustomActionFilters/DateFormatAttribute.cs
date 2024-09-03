using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CurrencyConverter.API.CustomActionFilters
{
    /// <summary>
    /// Returns success if the input value is in the specified date format
    /// </summary>
    public class DateFormatAttribute:ValidationAttribute
    {
        private readonly string _format;
        public DateFormatAttribute(string format)
        {
            _format = format;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime parsedDate;
                bool isValid = DateTime.TryParseExact(value.ToString(), _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
                return isValid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
