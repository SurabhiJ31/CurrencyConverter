using CurrencyConverter.API.Controllers;
using CurrencyConverter.API.Frankfurter;
using CurrencyConverter.API.Models.Frankfurter;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CurrencyConverterTest
{
    public class CurrencyControllerTest
    {
        private readonly CurrencyController _currencyController;
        private readonly Mock<IBaseApiClient> _baseApiClient;

        public CurrencyControllerTest()
        {
            _baseApiClient = new Mock<IBaseApiClient>();
            _currencyController = new CurrencyController(_baseApiClient.Object);
        }

        [Fact]
        public async void Verify_GetLatestRates_ReturnsOKResult()
        {
            _baseApiClient.Setup(_ => _.GetLatestExchangeRatesAsync()).ReturnsAsync(MockHelper.MockLatestRatesResponse());
            var actualLatestRates = await _currencyController.GetLatestRates();
            Assert.IsType<OkObjectResult>(actualLatestRates);
        }

        [Fact]
        public async void Verify_GetLatestRates_ReturnsNull()
        {
            _baseApiClient.Setup(_ => _.GetLatestExchangeRatesAsync()).ReturnsAsync((ExchangeApiResponse)null);
            var actualLatestRates = await _currencyController.GetLatestRates();
            Assert.IsType<NoContentResult>(actualLatestRates);
        }

        [InlineData("AUD", 100, "USD")]
        [Theory]
        public async void Verify_ConvertCurrency_ReturnsOk(string fromCurrency, decimal amount, string toCurrency)
        {
            var mockResponse = MockHelper.MockConvertCurrencyResponse();
            _baseApiClient.Setup(_ => _.ConvertAmountAsync(fromCurrency, amount, toCurrency)).ReturnsAsync(mockResponse);
            var convertedCurrency = await _currencyController.ConvertCurrency(MockHelper.MockConvertCurrencyQueryParameters(fromCurrency, amount, toCurrency));
            Assert.IsType<OkObjectResult>(convertedCurrency);
        }

    }
}