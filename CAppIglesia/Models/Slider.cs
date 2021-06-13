using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAppIglesia.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este Campo Es Obligatorio")]
        [Display(Name ="Titulo De Imagen")]
        [MaxLength(20, ErrorMessage ="{0} El Titulo Solo Puede Tener Un Maximo De {1} Caracter")]
        public string Nombre { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
    }
}
