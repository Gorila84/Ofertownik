using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Nazwa produktu jest obowiązkowa")]
        public string ProductName { get; set; }
        [Required(ErrorMessage ="Nazwa znakowania jest obowiązkowa")]
        public string MarkingName { get; set; }
        [Required(ErrorMessage = "Cena zakupu jest obowiązkowa")]
        public double PurchasePrice { get; set; }
        public string Supplier { get; set; }
    }
}
