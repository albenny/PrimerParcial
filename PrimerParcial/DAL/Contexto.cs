using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;  

namespace PrimerParcial.DAL { 

   public class Contexto : DbContext
    {
       
        public DbSet<Productos> productos { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Producto.db");
        }
    }
}

