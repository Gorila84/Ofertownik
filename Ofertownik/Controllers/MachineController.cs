using Microsoft.AspNetCore.Mvc;
using Models;
using Ofertownik.Repositories.IRpositories;
using System.Threading.Tasks;

namespace Ofertownik.Controllers
{
    public class MachineController : ApiController
    {
        private readonly IMachineRepository _machineRepository;

        public MachineController(IMachineRepository MachineRepository)
        {
            _machineRepository = MachineRepository;
        }

        [HttpPost("addMachine")]
        public async Task<IActionResult> AddMachine([FromBody] MachineDTO machineDTO)
        {
           

            var addMachine = await _machineRepository.AddMachine(machineDTO);
            return Ok(addMachine);


        }

        [HttpGet("getMachine/{id}")]
        public async Task<IActionResult> GetMachineById(int id, string userId)
        {
            var Machine = await _machineRepository.GetMachine(id, userId);
            return Ok(Machine);
        }

        [HttpGet("getMachines/{id}")]
        public async Task<IActionResult> GetMachines(string id)
        {
            var Machine = await _machineRepository.GetAllMachines(id);
            return Ok(Machine);
        }

        [HttpPut("editMachine/{id}")]
        public async Task<IActionResult> EditMachine(string userId, int id, MachineDTO MachineDTO)
        {
            var MachineForUpdate = await _machineRepository.UpdateMachine(userId, id, MachineDTO);
            return Ok(MachineForUpdate);
        }

        [HttpDelete("deleteMachine/{id}")]
        public async Task<IActionResult> DeleteMachine(int id, string userId)
        {
            var MachineForRemove = await _machineRepository.DeleteMachine(id, userId);
            return Ok(MachineForRemove);
        }
    }
}
