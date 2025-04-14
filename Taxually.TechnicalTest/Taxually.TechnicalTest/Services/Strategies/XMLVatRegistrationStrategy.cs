using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Taxually.TechnicalTest.Models;


namespace Taxually.TechnicalTest.Services.Strategies
{

    public class XmlVatRegistrationStrategy : IVatRegistrationStrategy
    {
        private readonly TaxuallyQueueClient _queueClient;

        public XmlVatRegistrationStrategy(TaxuallyQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        public async Task RegisterAsync(VatRegistrationRequest request)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(VatRegistrationRequest));
                serializer.Serialize(stringWriter, request);
                var xml = stringWriter.ToString();
                await _queueClient.EnqueueAsync("vat-registration-xml", xml);
            }
        }
    }
}