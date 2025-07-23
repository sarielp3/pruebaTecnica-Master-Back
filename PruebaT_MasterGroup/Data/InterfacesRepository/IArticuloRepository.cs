using PruebaT_MasterGroup.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Data.InterfacesRepository
{
    public interface IArticuloRepository
    {
        Task<IEnumerable<Articulos>> GetAllArticulos();

        Task<Articulos> GetByIdArticulo(int id);

        Task AddArticuloAsync(Articulos articulo);

        Task UpdateArticuloAsync(Articulos articulo);

        Task DeleteArticuloAsync(int id);

        Task<IEnumerable<Articulos>> GetByDescArticulo(string descripcion);
    }
}
