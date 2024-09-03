namespace CurrencyConverter.API.Models
{
    public class CurrencyConversionResponseDto
    {
        public string Date { get; set; }
        public string FromCurrency { get; set; }
        public decimal BaseAmount { get; set; }
        public string ToCurrency { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
