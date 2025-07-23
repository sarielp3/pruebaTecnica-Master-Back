using PruebaT_MasterGroup.Data.InterfacesRepository;
using PruebaT_MasterGroup.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Business
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _repo;
        public ClienteService(IClienteRepository repo) => _repo = repo;
        public Task ActualizarAsync(Clientes cliente)
        {
            throw new System.NotImplementedException();
        }

        public async Task CrearAsync(Clientes cliente)
        {

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente es obligatorio.");
            }
            if (string.IsNullOrEmpty(cliente.Apellidos))
            {
                throw new ArgumentException("El apellido del cliente es obligatorio.");
            }

            if (string.IsNullOrEmpty(cliente.Correo))
            {
                throw new ArgumentException("El correo del cliente es obligatorio.");
            }
            if (string.IsNullOrEmpty(cliente.Contrasena))
            {
                throw new ArgumentException("La contraseña del cliente es obligatorio.");
            }
            await _repo.AddClienteAsync(cliente);
        }

        public async Task EliminarAsync(int id)
        {
            await _repo.DeleteClienteAsync(id);
        }

        public async Task<Clientes> IniciarSesion(string correo, string contrasena)
        {
            if (string.IsNullOrEmpty(correo))
            {
                throw new ArgumentException("El correo es obligatorio.");
            }
            if (string.IsNullOrEmpty(contrasena))
            {
                throw new ArgumentException("La contrasena es obligatoria.");
            }
            return await _repo.IniciarSesion(correo, contrasena);
        }

        public async Task<Clientes> ObtenerPorIdAsync(int id)
        {
            return await _repo.GetByIdClienteAsync(id);
        }

        public async Task<IEnumerable<Clientes>> ObtenerTodosAsync() => await _repo.GetAllClientesASync();

    }
}
