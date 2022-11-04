using System;

namespace Ofertownik.Data.Model
{
    public class Material
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public double PurchasePrice { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpadateDate { get; set; }
        public string UpdateBy { get; set; }

    }
}
