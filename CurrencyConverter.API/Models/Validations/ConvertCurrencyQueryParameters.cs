using CurrencyConverter.API.CustomActionFilters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CurrencyConverter.API.Models.Validations
{
    public class ConvertCurrencyQueryParameters
    {
        [JsonPropertyName("fromCurrency")]
        [Required]
        [DisallowedValues(["TRY", "PLN", "MXN", "THB"],ErrorMessage ="Not Allowed")]
        public string FromCurrency { get; set; }

        [JsonPropertyName("toCurrency")]
        [Required]
        public string ToCurrency { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public decimal Amount { get; set; }
    }
}
