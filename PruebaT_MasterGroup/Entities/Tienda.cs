using System.Collections.Generic;

namespace PruebaT_MasterGroup.Entities
{
    public class Tienda
    {
        public int TiendaId { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public ICollection<ArticuloTienda> ArticulosEnTienda { get; set; }
    }
}
