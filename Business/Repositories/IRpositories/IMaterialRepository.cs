using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repositories.IRpositories
{
    public interface IMaterialRepository
    {
        Task<MaterialDTO> AddConference(MaterialDTO materialDTO);
        Task<MaterialDTO> UpdateConference(int conferenceID, MaterialDTO materialDTO);
        Task<IEnumerable<MaterialDTO>> GetAllConferences();
        Task<MaterialDTO> GetConference(int materialId);

        Task<bool> DeleteConference(int materialId);

        Task<MaterialDTO> ValidateConference(string materialName, int materialId = 0);
    }
}
