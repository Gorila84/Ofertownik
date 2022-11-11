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
        public async Task<IActionResult> CalculatePrice (CalcullationDTO calcullationDTO)
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
            return Ok(result);
        }

        [HttpPost("calculateMaterialPrice")]
        public async Task<IActionResult> CalculateMaterialPrice(CalcullationDTO calcullationDTO)
        {
            var calculateMaterialPrice = await _calcullationService.CalculateMaterialPrice(calcullationDTO.MaterialId,
                                                                                     calcullationDTO.UserId,
                                                                                     calcullationDTO.Height,
                                                                                     calcullationDTO.Width);
            return Ok(calculateMaterialPrice);

        }

        [HttpPost("userprice")]
        public async Task<IActionResult> CalculateWorkerPrice(CalcullationDTO calcullationDTO)
        {
            var workerPrice = await _calcullationService.CalcullateWorkerWorkPerMinutePrice(calcullationDTO.UserId, 
                                                                                             calcullationDTO.WorkerTimeInMinutes);
            return Ok(workerPrice);
        }

       
    }
}
