using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CalcullationSettingDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage ="Cena prądu jest wymagana. Proszę uzupełnić cenę prądu.")]
        public double EnergyPrice { get; set; }
        [Required(ErrorMessage = "Marża produktu jest wymagana. Proszę uzupełnić marżę produktu.")]
        public int ProductMargin { get; set; }
        [Required(ErrorMessage = "Marża materiału jest wymagana. Proszę uzupełnić marżę materiału.")]
        public int MaterialMargin { get; set; }
        [Required(ErrorMessage = "Koszt godziny pracy pracownika jest wymagany. Proszę uzupełnić koszt godziny pracy pracownika.")]
        public double WorkerHourPrice { get; set; }
    }
}
