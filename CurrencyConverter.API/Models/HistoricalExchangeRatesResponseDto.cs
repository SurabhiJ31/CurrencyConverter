namespace CurrencyConverter.API.Models
{
    public class HistoricalExchangeRatesResponseDto
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string BaseCurrency { get; set; }
        public List<HistoricalRateDto> Rates { get; set; }
    }
}
