using System;
using Taxually.TechnicalTest.Models;

using System.Threading.Tasks;

namespace Taxually.TechnicalTest.Services
{
    public interface IVatRegistrationStrategy
    {
        Task RegisterAsync(VatRegistrationRequest request);
    }

}