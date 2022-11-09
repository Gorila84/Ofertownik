using Microsoft.AspNetCore.Mvc;
using Models;
using Ofertownik.Services.IServices;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
    public class CalcullationController : ApiController
    {
        private readonly ICalcullationService _calcullationService;

        public CalcullationController(ICalcullationService calcullationService)
        {
            _calcullationService = calcullationService;
        }

        [HttpPost("calculate")]
        public async Task<double> CalculatePrice (CalcullationDTO calcullationDTO)
        {
            var result = await _calcullationService.CallculateMarkingPrice(calcullationDTO.UserId,
                                                        calcullationDTO.ProductId,
                                                        calcullationDTO.MaterialId,
                                                        calcullationDTO.MachineId,
                                                        calcullationDTO.WorkerTimeInMinutes,
                                                        calcullationDTO.MachineWorkingTimeInMinutes,
                                                        calcullationDTO.Height,
                                                        calcullationDTO.Width
                                                        );
            return result;
        }
    }
}
