using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.API.CustomActionFilters
{
    /// <summary>
    /// Returns success if the input value is not equal to any of the blacklisted values
    /// </summary>
    public class DisallowedValuesAttribute:ValidationAttribute
    {
        private readonly string[] _disallowedValues;
        public DisallowedValuesAttribute(string[] disaalowedValues)
        {
            _disallowedValues = disaalowedValues;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (_disallowedValues.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
