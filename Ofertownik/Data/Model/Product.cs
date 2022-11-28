using System;

namespace Ofertownik.Data.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ProductName { get; set; }
        public string MarkingName { get; set; }
        public double PurchasePrice { get; set; }
        public string Supplier { get; set; }
        public User User { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }

    }
}
