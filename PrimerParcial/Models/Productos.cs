using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Productos
    { 
        [Key]
        public int ProductoId { get; set; }
        [Required(ErrorMessage =" es obligatorio llenar este campo, increse una descripcion")]
        public string Descripcion { get; set;}
        [Range(minimum:1, maximum:99)]
        public float Existencia { get; set; }
        public float Costo { get; set;}
        public double ValorInventario { get; set;}

    }

}
