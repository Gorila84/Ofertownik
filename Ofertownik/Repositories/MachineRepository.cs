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
    public class MachineRepository : IMachineRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public MachineRepository(ApplicationDbContext db,
                                  IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<MachineDTO> AddMachine(MachineDTO machineDTO)
        {
            Machine machineToAdd = _mapper.Map<MachineDTO, Machine>(machineDTO);
            machineToAdd.CreateDate = DateTime.Now;
            machineDTO.MachineName = machineDTO.MachineName.ToLower();
            var Machine = await _db.Machines.AddAsync(machineToAdd);
            await _db.SaveChangesAsync();

            return _mapper.Map<Machine, MachineDTO>(Machine.Entity);

        }

        public async Task<bool> DeleteMachine(int machineId, string userId)
        {
            var machineForDelete = await _db.Machines.FirstOrDefaultAsync(x => x.Id == machineId
                                                                                && x.UserId == userId);
            if (machineForDelete != null)
            {
                _db.Machines.Remove(machineForDelete);
                await _db.SaveChangesAsync();
                return true;

            }
            return false;
        }

        public async Task<IEnumerable<MachineDTO>> GetAllMachines(string userId)
        {
            IEnumerable<MachineDTO> machines = _mapper.Map<IEnumerable<Machine>, IEnumerable<MachineDTO>>(
                                                       await _db.Machines.Where(x => x.UserId == userId).ToListAsync());
            return machines;
        }

        public async Task<MachineDTO> GetMachine(int machineId, string userId)
        {
            MachineDTO machine = _mapper.Map<Machine, MachineDTO>(
                                                       await _db.Machines.FirstOrDefaultAsync(x => x.Id == machineId
                                                                                                    && x.UserId == userId));
            return machine;
        }

        public async Task<MachineDTO> UpdateMachine(string userId, int machineId, MachineDTO machineDTO)
        {
            try
            {
                if (machineId == machineDTO.Id)
                {
                    Machine machine = await _db.Machines.FirstOrDefaultAsync(x => x.Id == machineId && x.UserId == userId);
                    Machine machineForUpdate = _mapper.Map<MachineDTO, Machine>(machineDTO, machine);
                    machineForUpdate.UpdateDate = DateTime.Now;
                    machineForUpdate.MachineName = machineForUpdate.MachineName.ToLower();
                    var MachineUpdate = _db.Machines.Update(machineForUpdate);
                    await _db.SaveChangesAsync();

                    return _mapper.Map<Machine, MachineDTO>(MachineUpdate.Entity);
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

        public async Task<bool> ValidateMachine(string machineName, double machinePower, string userId)
        {
            var machine = await _db.Machines.Where(x => x.MachineName == machineName
                                                     && x.MachinePower == machinePower 
                                                     && x.UserId == userId).FirstOrDefaultAsync();

            if (machine != null)
            {
                return true;
            }
            return false;
        }
    }
}

