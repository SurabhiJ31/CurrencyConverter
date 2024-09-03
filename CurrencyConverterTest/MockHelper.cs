using CurrencyConverter.API.Models.Frankfurter;
using CurrencyConverter.API.Models.Validations;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CurrencyConverterTest
{
    internal static class MockHelper
    {
        internal static ExchangeApiResponse MockLatestRatesResponse()
        {
            return new ExchangeApiResponse()
            {
                Amount = 100,
                Base = "ABR",
                Date = "2020-10-01",
                Rates = MockLatestRates(@"{""AUD"":1.6322,""BGN"":1.9558,""BRL"":6.2185,""CAD"":1.4932}")
            };

        }

        internal static JsonObject MockLatestRates(string jsonString)
        {
            return JsonSerializer.Deserialize<JsonObject>(jsonString);
        }
        internal static ExchangeApiResponse MockConvertCurrencyResponse()
        {
            return new ExchangeApiResponse()
            {
                Amount = 100,
                Base = "AUD",
                Date = "2020-10-01",
                Rates = MockLatestRates(@"{""USD"":67.767}")

            };

        }

        internal static ConvertCurrencyQueryParameters MockConvertCurrencyQueryParameters(string fromCurrency, decimal amount, string toCurrency)
        {
            return new ConvertCurrencyQueryParameters
            {
                FromCurrency = fromCurrency,
                Amount = amount,
                ToCurrency = toCurrency
            };
        }
    }
}
