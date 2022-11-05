using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofertownik.Repositories.IRpositories
{
    public interface IMaterialRepository
    {
        Task<MaterialDTO> AddMaterial(MaterialDTO materialDTO);
        Task<MaterialDTO> UpdateMaterial(string userId, int materialId, MaterialDTO materialDTO);
        Task<IEnumerable<MaterialDTO>> GetAllMaterials(string userId);
        Task<MaterialDTO> GetMaterial(int materialId, string userId);

        Task<bool> DeleteMaterial(int materialId, string userId);

        Task<bool> ValidateMaterial(string materialName, double materialPrice, string userId);
    }
}
