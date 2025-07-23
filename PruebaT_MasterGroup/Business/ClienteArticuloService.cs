using PruebaT_MasterGroup.Data.InterfacesRepository;
using PruebaT_MasterGroup.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Business
{
    public class ClienteArticuloService : IClienteArticuloService
    {

        private readonly IClienteArticuloRepository _repo;

        private readonly IClienteRepository _clienteRepo;

        public ClienteArticuloService(IClienteArticuloRepository repo, IClienteRepository _clienteRepo) {
            this._repo = repo;
            this._clienteRepo = _clienteRepo;
        }
        public async Task ActualizarCarrito(ClienteArticulo articulo)
        {

            ClienteArticulo articuloExiste = await _repo.BuscarArticuloEnCarritoAsync(articulo.ClienteId,articulo.ArticuloId);
            if (articuloExiste == null)
            {
                throw new KeyNotFoundException("El Articulo no existe.");
            }

            articuloExiste.Fecha = articulo.Fecha;
            articuloExiste.quantity = articulo.quantity;

            await _repo.UpdateArticuloCarritoAsync(articuloExiste);
        }

        public async Task<ClienteArticulo> BuscarArticuloEnCarrito(int idCliente, int idArticulo)
        {
            Clientes clienteExiste = await _clienteRepo.GetByIdClienteAsync(idCliente);
            if (clienteExiste == null)
            {
                throw new KeyNotFoundException("El id del Cliente no existe.");
            }
            return await _repo.BuscarArticuloEnCarritoAsync(idCliente,idArticulo);
        }

        public async Task CrearArticuloAsync(ClienteArticulo articulo)
        {
            if (articulo.ClienteId == 0)
            {
                throw new ArgumentException("El id del cliente es obligatorio.");
            }
            if (articulo.ArticuloId == 0)
            {
                throw new ArgumentException("El id del articulo es obligatorio.");
            }
            if (articulo.Fecha == DateTime.MinValue || articulo.Fecha == null)
            {
                throw new ArgumentException("La fecha es obligatoria.");
            }
            if (articulo.quantity == 0)
            {
                throw new ArgumentException("El cantidad del articulo es obligatorio.");
            }
            await _repo.AddArticuloCarritoAsync(articulo);
        }

        public async Task<IEnumerable<ClienteArticulo>> ObtenerCarritoPorId(int idCliente)
        {
            Clientes clienteExiste = await _clienteRepo.GetByIdClienteAsync(idCliente);
            if (clienteExiste == null)
            {
                throw new KeyNotFoundException("El id del Cliente no existe.");
            }
            return await _repo.GetCarritoByIdClienteAsync(idCliente);
        }

        public async Task<IEnumerable<ClienteArticulo>> ObtenerTodosLosCarritos()
        {
            return await _repo.GetAllCarritosASync();
        }

        public async Task VaciarCarritoAsync(int id)
        {
            Clientes clienteExiste = await _clienteRepo.GetByIdClienteAsync(id);
            if (clienteExiste == null)
            {
                throw new KeyNotFoundException("El id del Cliente no existe.");
            }
            await _repo.VaciarCarritoClienteAsync(id);
        }
    }
}
