using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofertownik.Repositories.IRpositories
{
    public interface ICalcullationSettingsRepository
    {
        Task<CalcullationSettingDTO> AddCalcullationSettings(CalcullationSettingDTO calcullationSettingsDTO);
        Task<CalcullationSettingDTO> UpdateCalcullationSettings(string userId, int calcullationSettingsId, CalcullationSettingDTO calcullationSettingsDTO);
        Task<IEnumerable<CalcullationSettingDTO>> GetAllCalcullationSettings(string userId);
        Task<CalcullationSettingDTO> GetCalcullationSettings(int calcullationSettingsId, string userId);

        Task<bool> DeleteCalcullationSettings(int calcullationSettingsId, string userId);

        
    }
}
