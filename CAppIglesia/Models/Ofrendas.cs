using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class Ofrendas
    {
      
        [Key]
        public int OfrendaID { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Cantidad De Ofrenda")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime FechaOfrenda { get; set; }

    }
}
