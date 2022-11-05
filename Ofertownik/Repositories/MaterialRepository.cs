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
            var material = await _db.Materials.AddAsync(materialToAdd);
            await _db.SaveChangesAsync();

            return _mapper.Map<Material, MaterialDTO>(material.Entity);

        }

        public async Task<bool> DeleteMaterial(int materialId)
        {
            var materialForDelete = await _db.Materials.FindAsync(materialId);
            if(materialForDelete != null)
            {
                _db.Materials.Remove(materialForDelete);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<IEnumerable<MaterialDTO>> GetAllMaterials()
        {
            IEnumerable<MaterialDTO> materials = _mapper.Map<IEnumerable<Material>, IEnumerable<MaterialDTO>>(
                                                       await _db.Materials.ToListAsync());
            return materials;
         }

        public async Task<MaterialDTO> GetMaterial(int materialId)
        {
            MaterialDTO material = _mapper.Map<Material,MaterialDTO>(
                                                       await _db.Materials.FirstOrDefaultAsync(x => x.Id == materialId));
            return material;
        }

        public async Task<MaterialDTO> UpdateMaterial(int materialId, MaterialDTO materialDTO)
        {
            MaterialDTO materialForUpdate = _mapper.Map<Material, MaterialDTO>(
                                                       await _db.Materials.FirstOrDefaultAsync(x => x.Id == materialId));

            return materialForUpdate;
        }

        public async Task<bool> ValidateMaterial(string materialName, double materialPrice)
        {
            var material = await _db.Materials.Where(x=> x.MaterialName == materialName 
                                                && x.PurchasePrice == materialPrice).FirstOrDefaultAsync();
            
            if(material != null)
            { 
                return true;
            }
            return false;
        }
    }
}
