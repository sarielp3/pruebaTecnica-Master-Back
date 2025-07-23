using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaT_MasterGroup.Entities
{
    public class Articulos
    {
        [Key]
        [ReadOnly(true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Articulo { get; set; } 
        public string Codigo { get; set; } 
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public short Stock { get; set; }

        public ICollection<ArticuloTienda> TiendasDisponibles { get; set; }
        public ICollection<ClienteArticulo> CompradoPorClientes { get; set; }
    }
}
