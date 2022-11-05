using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Ofertownik.Data;
using Ofertownik.Data.Model;
using Ofertownik.Repositories.IRpositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ofertownik.Repositories
{
    public class CalcullationSettingsRepository : ICalcullationSettingsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CalcullationSettingsRepository(ApplicationDbContext db,
                                  IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CalcullationSettingDTO> AddCalcullationSettings(CalcullationSettingDTO calcullationSettingsDTO)
        {
            CalcullationSetting calcullationSettingsToAdd = _mapper.Map<CalcullationSettingDTO, CalcullationSetting>(calcullationSettingsDTO);
            
            
            var calcullationSettings = await _db.CalcullationSettings.AddAsync(calcullationSettingsToAdd);
            await _db.SaveChangesAsync();

            return _mapper.Map<CalcullationSetting, CalcullationSettingDTO>(calcullationSettings.Entity);

        }

        public async Task<bool> DeleteCalcullationSettings(int calcullationSettingsId, string userId)
        {
            var calcullationSettingsForDelete = await _db.CalcullationSettings.FirstOrDefaultAsync(x => x.Id == calcullationSettingsId
                                                                                && x.UserId == userId);
            if (calcullationSettingsForDelete != null)
            {
                _db.CalcullationSettings.Remove(calcullationSettingsForDelete);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<IEnumerable<CalcullationSettingDTO>> GetAllCalcullationSettings(string userId)
        {
            IEnumerable<CalcullationSettingDTO> calcullationSettings = _mapper.Map<IEnumerable<CalcullationSetting>, IEnumerable<CalcullationSettingDTO>>(
                                                       await _db.CalcullationSettings.Where(x => x.UserId == userId).ToListAsync());
            return calcullationSettings;
        }

        public async Task<CalcullationSettingDTO> GetCalcullationSettings(int calcullationSettingsId, string userId)
        {
            CalcullationSettingDTO calcullationSettings = _mapper.Map<CalcullationSetting, CalcullationSettingDTO>(
                                                       await _db.CalcullationSettings.FirstOrDefaultAsync(x => x.Id == calcullationSettingsId
                                                                                                    && x.UserId == userId));
            return calcullationSettings;
        }

        public async Task<CalcullationSettingDTO> UpdateCalcullationSettings(string userId, int calcullationSettingsId, CalcullationSettingDTO calcullationSettingsDTO)
        {
            try
            {
                if (calcullationSettingsId == calcullationSettingsDTO.Id)
                {
                    CalcullationSetting calcullationSettings = await _db.CalcullationSettings.FirstOrDefaultAsync(x => x.Id == calcullationSettingsId && x.UserId == userId);
                    CalcullationSetting calcullationSettingsForUpdate = _mapper.Map<CalcullationSettingDTO, CalcullationSetting>(calcullationSettingsDTO, calcullationSettings);
                    //calcullationSettingsForUpdate.UpdateDate = DateTime.Now;
                    //calcullationSettingsForUpdate.CalcullationSettingsName = CalcullationSettingsForUpdate.CalcullationSettingsName.ToLower();
                    var calcullationSettingsUpdate = _db.CalcullationSettings.Update(calcullationSettingsForUpdate);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<CalcullationSetting, CalcullationSettingDTO>(calcullationSettingsUpdate.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;

            }




        }

       
    }
}
