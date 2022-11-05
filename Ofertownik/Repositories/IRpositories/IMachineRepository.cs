using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ofertownik.Repositories.IRpositories
{
    public interface IMachineRepository
    {
        Task<MachineDTO> AddMachine(MachineDTO machineDTO);
        Task<MachineDTO> UpdateMachine(string userId, int machineId, MachineDTO machineDTO);
        Task<IEnumerable<MachineDTO>> GetAllMachines(string userId);
        Task<MachineDTO> GetMachine(int machineId, string userId);

        Task<bool> DeleteMachine(int machineId, string userId);

        Task<bool> ValidateMachine(string machineName, double machinePrice, string userId);
    }
}
