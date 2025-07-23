using PruebaT_MasterGroup.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Business
{
    public interface IClienteArticuloService
    {
        Task<IEnumerable<ClienteArticulo>> ObtenerTodosLosCarritos();

        Task<IEnumerable<ClienteArticulo>> ObtenerCarritoPorId(int idCliente);

        Task<ClienteArticulo> BuscarArticuloEnCarrito(int idCliente,int idArticulo);

        Task CrearArticuloAsync(ClienteArticulo articulo);

        Task ActualizarCarrito(ClienteArticulo articulo);

        Task VaciarCarritoAsync(int id);
    }
}
