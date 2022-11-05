using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MachineDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MachineName { get; set; }
        public int MachinePower { get; set; }
    }
}
