using Microsoft.AspNetCore.Mvc;
using Ofertownik.Services.IServices;

namespace Ofertownik.Controllers
{
    public class CalcullationController : ApiController
    {
        private readonly ICalcullationService _calcullationService;

        public CalcullationController(ICalcullationService calcullationService)
        {
            _calcullationService = calcullationService;
        }
    }
}
