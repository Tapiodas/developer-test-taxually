using System.Text;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Services;
using Taxually.TechnicalTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
         private readonly IVatRegistrationStrategyFactory _strategyFactory;

    public VatRegistrationController(IVatRegistrationStrategyFactory strategyFactory)
    {
        _strategyFactory = strategyFactory;
    }
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = _strategyFactory.GetStrategy(request.Country);
            await strategy.RegisterAsync(request);

            return Ok();
        }
    }

 
}
