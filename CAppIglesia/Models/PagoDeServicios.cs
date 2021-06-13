using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class PagoDeServicios
    {
        [Key]
        public int PagoDeServicioID { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Nombre de Servicio")]
        public string NombreServicio { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Cantidad A Pagar")]
        public int  Cantidad { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [Display(Name = "Fecha De Pago")]
        [DataType(DataType.Date)]
        public DateTime FechaDePago { get; set; }
    }
}
