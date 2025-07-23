using System;
using System.Text.Json.Serialization;

namespace PruebaT_MasterGroup.Entities
{
    public class ArticuloTienda
    {
        public int ArticuloId { get; set; }
        [JsonIgnore]
        public Articulos Articulo { get; set; }

        public int TiendaId { get; set; }
        [JsonIgnore]
        public Tienda Tienda { get; set; }

        public DateTime Fecha { get; set; }
    }
}
