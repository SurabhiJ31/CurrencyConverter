namespace CurrencyConverter.API.Models
{
    public class HistoricalRateDto
    {
        public string Date { get; set; }
        public List<RateDto> Rates { get; set; }
    }
}
