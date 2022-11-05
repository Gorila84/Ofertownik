using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CalcullationSettingDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public double EnergyPrice { get; set; }
        public int ProductMargin { get; set; }
        public int MaterialMargin { get; set; }
        public double WorkerHourPrice { get; set; }
    }
}
