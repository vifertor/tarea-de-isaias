using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interface;
using WebApi.Model;
namespace WebApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VacunasController : ControllerBase
    {
        private readonly IVacunaService _vacunaService;

        public VacunasController(IVacunaService vacunaService)
        {
            _vacunaService = vacunaService;
        }

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarVacuna([FromBody] Vacuna vacuna)
        {
            if (vacuna == null)
            {
                return BadRequest("Vacuna is null.");
            }

            await _vacunaService.InsertarVacuna(vacuna);
            return Ok();
        }

        [HttpPut("modificar")]
        public async Task<IActionResult> ModificarVacuna([FromBody] Vacuna vacuna)
        {
            if (vacuna == null)
            {
                return BadRequest("Vacuna is null.");
            }

            await _vacunaService.ModificarVacuna(vacuna);
            return Ok();
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> BuscarVacunaPorId(int id)
        {
            var vacuna = await _vacunaService.BuscarVacunaPorId(id);
            return Ok(vacuna);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarVacunas()
        {
            var vacunas = await _vacunaService.ListarVacunas();
            return Ok(vacunas);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarVacuna(int id)
        {
            await _vacunaService.EliminarVacuna(id);
            return Ok();
        }
    }
}