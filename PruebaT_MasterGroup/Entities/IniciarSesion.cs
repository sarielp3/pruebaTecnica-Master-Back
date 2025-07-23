using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaT_MasterGroup.Entities
{
    public class IniciarSesion
    {
        
        public string Correo { get; set; }
        public string Contrasena { get; set; }

    }
}
