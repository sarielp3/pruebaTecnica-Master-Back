using PruebaT_MasterGroup.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Data.InterfacesRepository
{
    public interface IClienteArticuloRepository
    {
        Task<IEnumerable<ClienteArticulo>> GetAllCarritosASync();
        Task<IEnumerable<ClienteArticulo>> GetCarritoByIdClienteAsync(int idCliente);

        Task<ClienteArticulo> BuscarArticuloEnCarritoAsync(int idCliente, int idArticulo);

        Task AddArticuloCarritoAsync(ClienteArticulo clienteArticulo);

        Task UpdateArticuloCarritoAsync(ClienteArticulo clienteArticulo);
        Task VaciarCarritoClienteAsync(int id);
    }
}
