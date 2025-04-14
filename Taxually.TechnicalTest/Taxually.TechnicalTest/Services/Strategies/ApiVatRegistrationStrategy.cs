using System.IO;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Models;


namespace Taxually.TechnicalTest.Services.Strategies
{
    public class ApiVatRegistrationStrategy : IVatRegistrationStrategy
    {
        private readonly TaxuallyHttpClient _httpClient;

        public ApiVatRegistrationStrategy(TaxuallyHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task RegisterAsync(VatRegistrationRequest request)
        {
            await _httpClient.PostAsync("https://api.uktax.gov.uk", request);
        }
    }



}