using PruebaT_MasterGroup.Data.InterfacesRepository;
using PruebaT_MasterGroup.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Business
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _repo;

        public ArticuloService(IArticuloRepository repo) => _repo = repo;
        public async Task ActualizarArticulo(Articulos articulo)
        {
           
            if(articulo.Id_Articulo <= 0)
            {
                throw new ArgumentException("Id inválido.");
            }

            Articulos articuloExiste = await _repo.GetByIdArticulo(articulo.Id_Articulo);
            if (articuloExiste == null)
            {
                throw new KeyNotFoundException("El Articulo no existe.");
            }

            articuloExiste.Codigo = articulo.Codigo;
            articuloExiste.Descripcion = articulo.Descripcion;
            articuloExiste.Precio = articulo.Precio;
            articuloExiste.Imagen = articulo.Imagen;
            articuloExiste.Stock = articulo.Stock;

            await _repo.UpdateArticuloAsync(articuloExiste);
        }

        public async Task CrearArticuloAsync(Articulos articulo)
        {
            if (string.IsNullOrEmpty(articulo.Codigo))
            {
                throw new ArgumentException("El codigo del articulo es obligatorio.");
            }
            if (string.IsNullOrEmpty(articulo.Descripcion))
            {
                throw new ArgumentException("La descripcion del articulo es obligatoria.");
            }

            if (string.IsNullOrEmpty((articulo.Precio).ToString()))
            {
                throw new ArgumentException("El precio del articulo es obligatorio.");
            }
            if (string.IsNullOrEmpty(articulo.Imagen))
            {
                throw new ArgumentException("La imagen del articulo es obligatoria.");
            }
            if (string.IsNullOrEmpty((articulo.Stock).ToString()))
            {
                throw new ArgumentException("El stock del articulo es obligatorio.");
            }
            await _repo.AddArticuloAsync(articulo);
        }

        public async Task EliminarAsync(int id)
        {
           var articuloExiste = await _repo.GetByIdArticulo(id);
            if(articuloExiste == null)
            {
                throw new KeyNotFoundException("El Articulo con el id ingresado no existe.");
            }
           await _repo.DeleteArticuloAsync(id);
        }

        public async Task<Articulos> ObtenerPorId(int id)
        {
            return await _repo.GetByIdArticulo(id);
        }

        public async Task<IEnumerable<Articulos>> ObtenerTodosArticulos()
        {
            return await _repo.GetAllArticulos();
        }

        public async Task<IEnumerable<Articulos>> ObtenerPorDescArticulos(string descripcion)
        {
            return await _repo.GetByDescArticulo(descripcion);
        }
    }
}
