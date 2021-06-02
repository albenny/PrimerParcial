﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcial.Models
{
    public class Productos
    { 
        
        public int ProductoId { get; set; }
        public string Descripcion { get; set;}
        public int Existencia { get; set; }
        public double Costo { get; set;}
        public double ValorInventario { get; set;}

    }

}
