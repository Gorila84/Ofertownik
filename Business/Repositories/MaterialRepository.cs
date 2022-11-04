using AutoMapper;
using Business.Repositories.IRpositories;
using Models;
using Ofertownik.Data;
using Ofertownik.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
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

        public async Task<MaterialDTO> AddConference(MaterialDTO materialDTO)
        {
            Material materialToAdd = _mapper.Map<MaterialDTO, Material>(materialDTO);
            materialToAdd.CreatedDate = DateTime.Now;
            var material = await _db.Materials.AddAsync(materialToAdd);
            await _db.SaveChangesAsync();

            return _mapper.Map<Material, MaterialDTO>(material.Entity);

        }

        public Task<bool> DeleteConference(int materialId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MaterialDTO>> GetAllConferences()
        {
            throw new NotImplementedException();
        }

        public Task<MaterialDTO> GetConference(int materialId)
        {
            throw new NotImplementedException();
        }

        public Task<MaterialDTO> UpdateConference(int conferenceID, MaterialDTO materialDTO)
        {
            throw new NotImplementedException();
        }

        public Task<MaterialDTO> ValidateConference(string materialName, int materialId = 0)
        {
            throw new NotImplementedException();
        }
    }
}
