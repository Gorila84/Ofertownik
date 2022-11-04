using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MaterialDTO
    {
        public string MaterialName { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double PurchasePrice { get; set; }
        public string SupplierName { get; set; }
    }
}
