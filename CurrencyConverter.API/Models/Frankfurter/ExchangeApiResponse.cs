using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace CurrencyConverter.API.Models.Frankfurter
{
    public class ExchangeApiResponse
    {
        public decimal Amount { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; }
        public JsonObject Rates { get; set; }
        
    }
}
