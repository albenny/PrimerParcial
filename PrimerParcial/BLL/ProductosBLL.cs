using Microsoft.EntityFrameworkCore;
using PrimerParcial.DAL;
using PrimerParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimerParcial.BLL
{
    public class ProductosBLL
    {
        private Contexto contexto { get; set; }
        public ProductosBLL(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<bool> Guardar(Prodctos Productos)
        {
            if (!await Exciste(Productos.ProductoId))
                return await Insertar(Productos);
            else
                return await Modificar(Productos);
        }

        private async Task<bool> Exciste(int id)
        {
            bool ok = false;
            try
            {
                ok = await contexto.Productos.AnyAsync(a => a.ProductosId == id);
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Insertar(Productos Productos)
        {
            bool ok = false;
            try
            {
                await contexto.Productos.AddAsync(Productos);
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        private async Task<bool> Modificar(Productos Productos)
        {
            bool ok = false;
            try
            {
                var aux = contexto.Set<Productos>()
                    .Local.SingleOrDefault(a => a.ProductosId == Productos.ProductosId);
                if (aux != null)
                {
                    contexto.Entry(aux).State = EntityState.Detached;
                }

                contexto.Entry(Productos).State = EntityState.Modified;
                ok = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<Productos> Buscar(int id)
        {
            Articulos Productos;
            try
            {
                Productos = await contexto.Productos
                    .Where(a => a.ProductosId == id)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return Productos;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool ok = false;

            try
            {
                var registro = await contexto.Productos.FindAsync(id);
                if (registro != null)
                {
                    contexto.Productos.Remove(registro);
                    ok = await contexto.SaveChangesAsync() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return ok;
        }

        public async Task<List<Productos>> GetProductos()
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = await contexto.Productos.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        public async Task<List<Productos>> GetProductos(Expression<Func<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                lista = await contexto.Productos.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
