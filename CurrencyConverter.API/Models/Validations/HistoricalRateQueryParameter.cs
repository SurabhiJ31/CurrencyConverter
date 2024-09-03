using CurrencyConverter.API.CustomActionFilters;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.API.Models.Validations
{
    public class HistoricalRateQueryParameter
    {
        [Required]
        [DateFormat("yyyy-MM-dd", ErrorMessage ="Date is not in correct format. Should be in yyyy-MM-dd")]
        public string StartDate { get; set; }

        [Required]
        [DateFormat("yyyy-MM-dd", ErrorMessage = "Date is not in correct format, Should be in yyyy-MM-dd")]
        public string EndDate { get; set; }

        [Required]
        public string ToCurrency { get; set; }
    }
}
