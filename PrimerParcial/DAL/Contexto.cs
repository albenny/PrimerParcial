using Microsoft.EntityFrameworkCore;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;  

public class Contexto : DbContext
    {
       
        public DbSet <Productos> Productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\Producto.db");
        }
    }
}