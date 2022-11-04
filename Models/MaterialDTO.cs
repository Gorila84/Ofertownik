using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MaterialDTO
    {
        [Required(ErrorMessage ="Nazwa materiału jest wymagana")]
        public string MaterialName { get; set; }
        [Required(ErrorMessage = "Wysokość materiału jest wymagana")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Szerokość materiału jest wymagana")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Cena zakupu materiału jest wymagana")]
        public double PurchasePrice { get; set; }
        
        public string SupplierName { get; set; }
    }
}
