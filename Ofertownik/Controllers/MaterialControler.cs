
using Microsoft.AspNetCore.Mvc;
using Models;
using Ofertownik.Repositories.IRpositories;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
    public class MaterialControler : ApiController
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialControler(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        [HttpPost("addMaterial")]
        public async Task<IActionResult> AddMaterial([FromBody] MaterialDTO materialDTO)
        {
            if( await _materialRepository.ValidateMaterial(materialDTO.MaterialName, materialDTO.PurchasePrice, materialDTO.userId))
            {
                BadRequest("Materiał o podanej nazwie i cenie już istnieje.");
            }

            var addMaterial = await _materialRepository.AddMaterial(materialDTO);
            return Ok(addMaterial);


        }

        [HttpGet("getMaterial/{id}")]
        public async Task<IActionResult> GetMaterialById(int id, string userId)
        {
            var material = await _materialRepository.GetMaterial(id, userId);
            return Ok(material);
        }

        [HttpGet("getMaterials")]
        public async Task<IActionResult> GetMaterials(string userId)
        {
            var material = await _materialRepository.GetAllMaterials(userId);
            return Ok(material);
        }

        [HttpPut("editMaterial/{id}")]
        public async Task<IActionResult> EditMaterial(string userId, int id, MaterialDTO materialDTO)
        {
            var materialForUpdate = await _materialRepository.UpdateMaterial(userId, id, materialDTO);
            return Ok(materialForUpdate);
        }

        [HttpDelete("deleteMaterial/{id}")]
        public async Task<IActionResult> DeleteMaterial( int id, string userId)
        {
            var materialForRemove = await _materialRepository.DeleteMaterial(id, userId);
            return Ok(materialForRemove);
        }
    }
}
