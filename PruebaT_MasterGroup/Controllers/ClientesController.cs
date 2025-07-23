using Microsoft.AspNetCore.Mvc;
using PruebaT_MasterGroup.Business;
using PruebaT_MasterGroup.Entities;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Controllers
{
    [ApiController]
    [Route("Clientes/")]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteService _service;
        public ClientesController(IClienteService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioPorId(int id)
        {
            return Ok(await _service.ObtenerPorIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            return Ok(await _service.ObtenerTodosAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCliente([FromBody] Clientes cliente)
        {
            await _service.CrearAsync(cliente);
            //return CreatedAtAction(nameof(Get), new { id = cliente.ClienteId }, cliente);
            return Ok("Cliente :" + cliente.Nombre + " " + cliente.Apellidos + " creado con exito");
        }
    }
}
