using PruebaT_MasterGroup.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Business
{
    public interface IClienteService
    {
        Task<IEnumerable<Clientes>> ObtenerTodosAsync();
        Task<Clientes> ObtenerPorIdAsync(int id);
        Task CrearAsync(Clientes cliente);
        Task ActualizarAsync(Clientes cliente);
        Task EliminarAsync(int id);

        Task<Clientes> IniciarSesion(string correo, string contrasena);
    }
}
