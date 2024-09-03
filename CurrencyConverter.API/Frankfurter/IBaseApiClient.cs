using CurrencyConverter.API.Models.Frankfurter;

namespace CurrencyConverter.API.Frankfurter
{
    public interface IBaseApiClient
    {
        Task<ExchangeApiResponse> GetLatestExchangeRatesAsync();
        Task<ExchangeApiResponse> ConvertAmountAsync(string fromCurrency, decimal fromAmount, string toCurrency);
        Task<ExchangeApiResponse> GetHistoricalExchangeRatesAsync(string fromDate, string endDate, string toCurrency);
    }
}
