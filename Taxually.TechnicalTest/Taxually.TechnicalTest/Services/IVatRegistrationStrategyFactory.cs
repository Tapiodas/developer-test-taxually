using System;
using System.Threading.Tasks;

namespace Taxually.TechnicalTest.Services
{
  
    public interface IVatRegistrationStrategyFactory
    {
        IVatRegistrationStrategy GetStrategy(string countryCode);
    }


}