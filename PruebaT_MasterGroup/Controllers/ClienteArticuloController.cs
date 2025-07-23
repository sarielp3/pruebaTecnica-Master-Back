using Microsoft.AspNetCore.Mvc;
using PruebaT_MasterGroup.Business;
using PruebaT_MasterGroup.Entities;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Controllers
{
    [ApiController]
    [Route("Carrito/")]
    public class ClienteArticuloController : ControllerBase
    {
        private readonly IClienteArticuloService _service;
        public ClienteArticuloController(IClienteArticuloService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarritoPorId(int id)
        {
            return Ok(await _service.ObtenerCarritoPorId(id));
        }

        [HttpGet("{clienteId}/{articuloId}")]
        public async Task<IActionResult> BuscarArticuloEnCarrito(int clienteId,int articuloId)
        {
            return Ok(await _service.BuscarArticuloEnCarrito(clienteId,articuloId));
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarArticuloCarrito([FromBody] ClienteArticulo articulo)
        {
            await _service.ActualizarCarrito(articulo);
            return Ok("Articulo actualizado con exito!");
        }

        [HttpPost]
        public async Task<IActionResult> AgregarArticuloCarrito([FromBody] ClienteArticulo articulo)
        {
            await _service.CrearArticuloAsync(articulo);
            return Ok("Articulo agregar al carrito con exito!");
        }
    }
}
