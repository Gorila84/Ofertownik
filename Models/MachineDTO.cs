using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MachineDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Nazwa maszyny jest wymagana.")]
        public string MachineName { get; set; }
        [Required(ErrorMessage = "Moc maszyny jest wymagana.")]
        public int MachinePower { get; set; }
    }
}
