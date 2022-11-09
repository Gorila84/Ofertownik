using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CalcullationDTO
    {
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int MaterialId { get; set; }
        public int MachineId { get; set; }
        public int WorkerTimeInMinutes { get; set; }
        public int MachineWorkingTimeInMinutes { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
     
    }
}
