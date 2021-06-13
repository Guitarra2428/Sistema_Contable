using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class Registros
    {
        [Key]
        public int OfrendaID { get; set; }

        [Required(ErrorMessage ="Este Campo Es Obligatorio")]
        [Display(Name ="Nombre")]
        public string PrimerNombre { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Apellido")]
        public string PrimerApellido { get; set; }


        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Por Concepto")]
        public string Concepto{ get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Cantidad A Diezmar")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Fecha")]
       [DataType(DataType.Date)]
        public DateTime FechaDePago { get; set; }




    }
}
