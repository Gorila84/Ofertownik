using Microsoft.AspNetCore.Mvc;
using Models;
using Ofertownik.Repositories.IRpositories;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
    public class CalcullationSettingController : ApiController
    {
        private readonly ICalcullationSettingsRepository _calcullationSettingRepository;

        public CalcullationSettingController(ICalcullationSettingsRepository calcullationSettingRepository)
        {
            _calcullationSettingRepository = calcullationSettingRepository;
        }

        [HttpPost("addCalcullationSetting")]
        public async Task<IActionResult> AddCalcullationSetting([FromBody] CalcullationSettingDTO calcullationSettingDTO)
        {
       

            var addCalcullationSetting = await _calcullationSettingRepository.AddCalcullationSettings(calcullationSettingDTO);
            return Ok(addCalcullationSetting);


        }

        [HttpGet("getCalcullationSetting/{id}")]
        public async Task<IActionResult> GetCalcullationSettingById( string userId)
        {
            var calcullationSetting = await _calcullationSettingRepository.GetCalcullationSettings( userId);
            return Ok(calcullationSetting);
        }

        [HttpGet("getCalcullationSettings")]
        public async Task<IActionResult> GetCalcullationSettings(string userId)
        {
            var calcullationSetting = await _calcullationSettingRepository.GetAllCalcullationSettings(userId);
            return Ok(calcullationSetting);
        }

        [HttpPut("editCalcullationSetting/{id}")]
        public async Task<IActionResult> EditCalcullationSetting(string userId, int id, CalcullationSettingDTO calcullationSettingDTO)
        {
            var calcullationSettingForUpdate = await _calcullationSettingRepository.UpdateCalcullationSettings(userId, id, calcullationSettingDTO);
            return Ok(calcullationSettingForUpdate);
        }

        [HttpDelete("deleteCalcullationSetting/{id}")]
        public async Task<IActionResult> DeleteCalcullationSetting(int id, string userId)
        {
            var calcullationSettingForRemove = await _calcullationSettingRepository.DeleteCalcullationSettings(id, userId);
            return Ok(calcullationSettingForRemove);
        }
    }
}
