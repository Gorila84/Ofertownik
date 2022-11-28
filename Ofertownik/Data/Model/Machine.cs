using System;

namespace Ofertownik.Data.Model
{
    public class Machine
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MachineName { get; set; }
        public int MachinePower { get; set; }
        public double WorkingHourPrice { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
