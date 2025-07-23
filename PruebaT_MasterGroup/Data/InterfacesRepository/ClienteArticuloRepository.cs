using Microsoft.EntityFrameworkCore;
using PruebaT_MasterGroup.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Data.InterfacesRepository
{
    public class ClienteArticuloRepository : IClienteArticuloRepository
    {

        private readonly ApplicationDbContext _context;
        public ClienteArticuloRepository(ApplicationDbContext context) => _context = context;
        public async Task AddArticuloCarritoAsync(ClienteArticulo clienteArticulo)
        {
            _context.ClienteArticulo.Add(clienteArticulo);
            await _context.SaveChangesAsync();
        }

        public async Task<ClienteArticulo> BuscarArticuloEnCarritoAsync(int idCliente, int idArticulo)
        {
            return await _context.ClienteArticulo.Where(a => a.ClienteId.Equals(idCliente))
                .Where(b => b.ArticuloId.Equals(idArticulo))
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ClienteArticulo>> GetAllCarritosASync()
        {
            return await _context.ClienteArticulo.ToListAsync();
        }

        public async Task<IEnumerable<ClienteArticulo>> GetCarritoByIdClienteAsync(int idCliente)
        {
            return await _context.ClienteArticulo.Where(a => a.ClienteId.Equals(idCliente)).ToListAsync();
        }

        public async Task UpdateArticuloCarritoAsync(ClienteArticulo clienteArticulo)
        {
            _context.ClienteArticulo.Update(clienteArticulo);
            await _context.SaveChangesAsync();
        }

        public async Task VaciarCarritoClienteAsync(int id)
        {
            var registros = await _context.ClienteArticulo.Where(ca => ca.ClienteId == id).ToListAsync();

            if (registros.Any())
            {
                _context.ClienteArticulo.RemoveRange(registros);
                await _context.SaveChangesAsync();
            }
        }
    }
}
