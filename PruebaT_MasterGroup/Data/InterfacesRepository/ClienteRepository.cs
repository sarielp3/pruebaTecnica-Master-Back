using Microsoft.EntityFrameworkCore;
using PruebaT_MasterGroup.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Data.InterfacesRepository
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly ApplicationDbContext _context;
        public ClienteRepository(ApplicationDbContext context) => _context = context;
        public async Task AddClienteAsync(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Clientes>> GetAllClientesASync()
        {
           return await _context.Clientes.Include(t => t.Compras).ToListAsync();
        }

        public async Task<Clientes> GetByIdClienteAsync(int id)
        {
            return await _context.Clientes.Include(t => t.Compras).FirstOrDefaultAsync(t => t.ClienteId == id);
        }
    }
}
