using PruebaT_MasterGroup.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Business
{
    public interface IArticuloService
    {
        Task<IEnumerable<Articulos>> ObtenerTodosArticulos();

        Task<Articulos> ObtenerPorId(int id);

        Task CrearArticuloAsync(Articulos articulo);

        Task ActualizarArticulo(Articulos articulo);

        Task EliminarAsync(int id);

        Task<IEnumerable<Articulos>> ObtenerPorDescArticulos(string descripcion);


    }
}
