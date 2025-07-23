using Microsoft.EntityFrameworkCore;
using PruebaT_MasterGroup.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Data.InterfacesRepository
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;
        public ArticuloRepository(ApplicationDbContext context) => _context = context;

        public async Task AddArticuloAsync(Articulos articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticuloAsync(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Articulos>> GetAllArticulos()
        {
            return await _context.Articulos.Include(t => t.TiendasDisponibles)
                .Include(l => l.CompradoPorClientes)
                .ToListAsync();

        }

        public async Task<Articulos> GetByIdArticulo(int id)
        {
            return await _context.Articulos.Include(t => t.TiendasDisponibles).FirstOrDefaultAsync(t => t.Id_Articulo == id);
        }

        public async Task<IEnumerable<Articulos>> GetByDescArticulo(string descripcion)
        {
            return await _context.Articulos.Where(a => a.Descripcion.Contains(descripcion)).ToListAsync();
        }

        public async Task UpdateArticuloAsync(Articulos articulo)
        {
            _context.Articulos.Update(articulo);
            await _context.SaveChangesAsync();
        }
    }
}
