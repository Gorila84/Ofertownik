using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofertownik.Repositories.IRpositories
{
    public interface IMaterialRepository
    {
        Task<MaterialDTO> AddMaterial(MaterialDTO materialDTO);
        Task<MaterialDTO> UpdateMaterial(int materialId, MaterialDTO materialDTO);
        Task<IEnumerable<MaterialDTO>> GetAllMaterials();
        Task<MaterialDTO> GetMaterial(int materialId);

        Task<bool> DeleteMaterial(int materialId);

        Task<bool> ValidateMaterial(string materialName, double materialPrice);
    }
}
