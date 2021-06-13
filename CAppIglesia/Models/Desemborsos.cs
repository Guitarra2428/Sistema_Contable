using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class Desemborsos
    {
        [Key]
        public int DesemborsoID { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Consepto De:")]
        public string Concepoto { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Cantidad A Desemborsar:")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Fecha De Desemborso:")]
        public DateTime FechaDeSemborso{ get; set; }

        


    }
}
