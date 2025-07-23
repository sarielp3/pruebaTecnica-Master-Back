using Microsoft.AspNetCore.Mvc;
using PruebaT_MasterGroup.Business;
using PruebaT_MasterGroup.Entities;
using System;
using System.Threading.Tasks;

namespace PruebaT_MasterGroup.Controllers
{
    [ApiController]
    [Route("Articulos/")]
    public class ArticulosController :ControllerBase
    {
        private readonly IArticuloService _articuloService;

        public ArticulosController(IArticuloService articuloService) => _articuloService = articuloService;
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticuloPorId(int id)
        {
            return Ok(await _articuloService.ObtenerPorId(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            return Ok(await _articuloService.ObtenerTodosArticulos());
        }

        [HttpGet("filtrar/{descripcion}")]
        public async Task<IActionResult> GetArticuloPorDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                return BadRequest("Debes proporcionar una descripcion para buscar.");
            }
            return Ok(await _articuloService.ObtenerPorDescArticulos(descripcion));
        }

        [HttpPost]
        public async Task<IActionResult> AgregarArticulo([FromBody] Articulos articulo)
        {
            await _articuloService.CrearArticuloAsync(articulo);
            return Ok("Articulo creado con exito!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarArticulo(int id, [FromBody] Articulos articulo)
        {
            articulo.Id_Articulo = id;
            await _articuloService.ActualizarArticulo(articulo);
            return Ok("Articulo actualizado con exito!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            await _articuloService.EliminarAsync(id);
            return Ok("Articulo Eliminado con exito");
        }
    }
}
