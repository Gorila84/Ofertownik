using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Models;
using Ofertownik.Data;
using Ofertownik.Data.Model;
using Ofertownik.Repositories.IRpositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertownik.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MaterialRepository(ApplicationDbContext db,
                                  IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<MaterialDTO> AddMaterial(MaterialDTO materialDTO)
        {
            Material materialToAdd = _mapper.Map<MaterialDTO, Material>(materialDTO);
            materialToAdd.CreatedDate = DateTime.Now;
            materialDTO.MaterialName = materialDTO.MaterialName.ToLower();
            var material = await _db.Materials.AddAsync(materialToAdd);
            await _db.SaveChangesAsync();

            return _mapper.Map<Material, MaterialDTO>(material.Entity);

        }

        public async Task<bool> DeleteMaterial(int materialId, string userId)
        {
            var materialForDelete = await _db.Materials.FirstOrDefaultAsync(x=> x.Id == materialId
                                                                                && x.UserId == userId);
            if(materialForDelete != null)
            {
                _db.Materials.Remove(materialForDelete);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllMaterials(string userId)
        {
            IEnumerable<MaterialDTO> materials = _mapper.Map<IEnumerable<Material>, IEnumerable<MaterialDTO>>(
                                                       await _db.Materials.Where(x=> x.UserId == userId).ToListAsync());
            return materials;
         }

        public async Task<MaterialDTO> GetMaterial(int materialId, string userId)
        {
            MaterialDTO material = _mapper.Map<Material,MaterialDTO>(
                                                       await _db.Materials.FirstOrDefaultAsync(x => x.Id == materialId
                                                                                                    && x.UserId == userId));
            return material;
        }

        public async Task<MaterialDTO> UpdateMaterial(string userId, int materialId, MaterialDTO materialDTO)
        {
            try
            {
                if (materialId == materialDTO.Id)
                {
                    Material material = await _db.Materials.FirstOrDefaultAsync(x => x.Id == materialId && x.UserId == userId);
                    Material materialForUpdate = _mapper.Map<MaterialDTO, Material>(materialDTO, material);
                    materialForUpdate.UpadateDate = DateTime.Now;
                    materialForUpdate.MaterialName = materialForUpdate.MaterialName.ToLower();
                    var materialUpdate = _db.Materials.Update(materialForUpdate);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<Material, MaterialDTO>(materialUpdate.Entity);
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

        public async Task<bool> ValidateMaterial(string materialName, double materialPrice, string userId)
        {
            var material = await _db.Materials.Where(x=> x.MaterialName == materialName 
                                                      && x.PurchasePrice == materialPrice
                                                      && x.UserId == userId).FirstOrDefaultAsync();
            
            if(material != null)
            { 
                return true;
            }
            return false;
        }
    }
}
