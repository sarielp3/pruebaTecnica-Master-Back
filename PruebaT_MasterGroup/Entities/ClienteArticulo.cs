using System;
using System.Text.Json.Serialization;

namespace PruebaT_MasterGroup.Entities
{
    public class ClienteArticulo
    {
        public int ClienteId { get; set; }
        [JsonIgnore]
        public Clientes Cliente { get; set; }

        public int ArticuloId { get; set; }
        [JsonIgnore]
        public Articulos Articulo { get; set; }

        public DateTime Fecha { get; set; }

        public int quantity { get; set; }
    }
}
