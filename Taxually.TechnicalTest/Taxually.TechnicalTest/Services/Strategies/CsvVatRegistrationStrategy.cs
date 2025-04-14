using System.IO;
using System.Text;
using System.Threading.Tasks;
using Taxually.TechnicalTest.Models;


namespace Taxually.TechnicalTest.Services.Strategies
{
    
       public class CsvVatRegistrationStrategy : IVatRegistrationStrategy
    {
        private readonly TaxuallyQueueClient _queueClient;

        public CsvVatRegistrationStrategy(TaxuallyQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public async Task RegisterAsync(VatRegistrationRequest request)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("CompanyName,CompanyId");
            csvBuilder.AppendLine($"{request.CompanyName},{request.CompanyId}");
            var csv = Encoding.UTF8.GetBytes(csvBuilder.ToString());
            await _queueClient.EnqueueAsync("vat-registration-csv", csv);


        }
    }

   
}