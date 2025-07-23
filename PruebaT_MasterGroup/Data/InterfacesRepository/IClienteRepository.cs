using PruebaT_MasterGroup.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Data.InterfacesRepository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Clientes>> GetAllClientesASync();
        Task<Clientes> GetByIdClienteAsync(int id);

        Task AddClienteAsync(Clientes cliente);
        Task DeleteClienteAsync(int id);

        Task<Clientes> IniciarSesion(string correo,string contrasena);
    }
}
