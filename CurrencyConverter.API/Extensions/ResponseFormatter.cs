using CurrencyConverter.API.Models;
using CurrencyConverter.API.Models.Frankfurter;
using System.Text.Json.Nodes;

namespace CurrencyConverter.API.Extensions
{
    public static class ResponseFormatter
    {
        public static List<RateDto> ToLatestRates(this JsonObject ratesObject)
        {
            return ratesObject.ToArray().Select(x => new RateDto
            {
                Name = x.Key,
                Amount = (decimal)x.Value
            }).ToList();
        }

        public static List<HistoricalRateDto> ToHistoricalRates(this JsonObject ratesObject, int recordsToSkip, int recordsToTake)
        {
            List<HistoricalRateDto> rates = new List<HistoricalRateDto>();
            foreach (var dateEntry in ratesObject.ToArray().Skip(recordsToSkip).Take(recordsToTake))
            {
                string date = dateEntry.Key;
                JsonObject currencyRates = dateEntry.Value.AsObject();
                List<RateDto> rate = new List<RateDto>();
                foreach (var currencyRate in currencyRates)
                {
                    rate.Add(new RateDto
                    {
                        Name = currencyRate.Key,
                        Amount = currencyRate.Value.GetValue<decimal>()
                    });
                }
                rates.Add(new HistoricalRateDto { Date = date, Rates = rate });

            }
            return rates;
        }

        public static LatestExchangeRatesResponseDto ToLatestExchangeRates(this ExchangeApiResponse exchangeApiResponse)
        {
            return new LatestExchangeRatesResponseDto
            {
                Date = exchangeApiResponse.Date,
                BaseCurrency = exchangeApiResponse.Base,
                Rates = exchangeApiResponse.Rates.ToLatestRates()
            };
        }

        public static CurrencyConversionResponseDto ToCurrencyResponse(this ExchangeApiResponse exchangeApiResponse)
        {
            return new CurrencyConversionResponseDto
            {
                Date = exchangeApiResponse.Date,
                FromCurrency = exchangeApiResponse.Base,
                BaseAmount = exchangeApiResponse.Amount,
                ToCurrency = exchangeApiResponse.Rates.ToArray()[0].Key,
                ConvertedAmount = (decimal)exchangeApiResponse.Rates.ToArray()[0].Value
            };
        }

        public static HistoricalExchangeRatesResponseDto ToHistoricalExchangeRates(this ExchangeApiResponse exchangeApiResponse, int recordsToSkip, int recordsToTake)
        {
            return new HistoricalExchangeRatesResponseDto
            {
                StartDate = exchangeApiResponse.StartDate,
                EndDate = exchangeApiResponse.EndDate,
                BaseCurrency = exchangeApiResponse.Base,
                Rates=exchangeApiResponse.Rates.ToHistoricalRates(recordsToSkip, recordsToTake)
            };
        }
    }
}
