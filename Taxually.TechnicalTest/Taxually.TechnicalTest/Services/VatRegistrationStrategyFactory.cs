using System;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Services.Strategies;

namespace Taxually.TechnicalTest.Services
{

    public class VatRegistrationStrategyFactory : IVatRegistrationStrategyFactory
    {
        private readonly TaxuallyHttpClient _httpClient;
        private readonly TaxuallyQueueClient _queueClient;

        public VatRegistrationStrategyFactory(
            TaxuallyHttpClient httpClient,
            TaxuallyQueueClient queueClient)
        {
            _httpClient = httpClient;
            _queueClient = queueClient;
        }

        public IVatRegistrationStrategy GetStrategy(string countryCode)
        {
            return countryCode switch
            {
                "GB" => new ApiVatRegistrationStrategy(_httpClient),
                "FR" => new CsvVatRegistrationStrategy(_queueClient),
                "DE" => new XmlVatRegistrationStrategy(_queueClient),
                _ => throw new NotSupportedException($"Country {countryCode} is not supported")
            };
        }
    }
}