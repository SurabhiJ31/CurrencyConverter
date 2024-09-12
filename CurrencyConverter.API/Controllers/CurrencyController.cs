using CurrencyConverter.API.CustomActionFilters;
using CurrencyConverter.API.Extensions;
using CurrencyConverter.API.Frankfurter;
using CurrencyConverter.API.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CurrencyConverter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private IBaseApiClient _baseApiClient;

        public CurrencyController(IBaseApiClient baseApiClient)
        {
            _baseApiClient = baseApiClient;
        }

        [HttpGet("latest-rates")]
        public async Task<IActionResult> GetLatestRates([FromQuery] [Required] string currency)
        {
            var response = await _baseApiClient.GetLatestExchangeRatesAsync();
            if(response!=null)
            {
                var a = response.ToLatestExchangeRates();
                return Ok(a);
            }

            //should have send NotFound();
            return NoContent();
        }

        [HttpGet("convert")]
        public async Task<IActionResult> ConvertCurrency([FromQuery] ConvertCurrencyQueryParameters queryParameters)
        {
            var response = await _baseApiClient.ConvertAmountAsync(queryParameters.FromCurrency, queryParameters.Amount, queryParameters.ToCurrency);
            if (response != null)
            {
                return Ok(response.ToCurrencyResponse());
            }
            return NoContent();
        }

        [HttpGet("historical-rates")]
        public async Task<IActionResult> GetHistoricalRates([FromQuery] HistoricalRateQueryParameter queryParameter, 
                                                            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var response = await _baseApiClient.GetHistoricalExchangeRatesAsync(queryParameter.StartDate, queryParameter.EndDate, queryParameter.ToCurrency);
            if (response != null)
            {
                return Ok(response.ToHistoricalExchangeRates((pageNumber - 1) * pageSize, pageSize));
            }
            return NoContent();
        }
    }
}
