namespace CurrencyConverter.API.Models
{
    public class LatestExchangeRatesResponseDto
    {
        public string Date { get; set; }
        public string BaseCurrency { get; set; }
        public List<RateDto> Rates { get; set; }
    }
}
