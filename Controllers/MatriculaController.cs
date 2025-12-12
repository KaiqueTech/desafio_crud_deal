using CursosApi.DTOs.Matriculas;
using CursosApi.Services.Matriculas;
using Microsoft.AspNetCore.Mvc;

namespace CursosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _service;

        public MatriculaController(IMatriculaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var matriculas = await _service.GetAll();
            return Ok(matriculas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var matricula = await _service.GetById(id);
            if (matricula == null) return NotFound();
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<ActionResult> Create(MatriculaRequestDto dto)
        {
            var matricula = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = matricula.Id }, matricula);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removida = await _service.Delete(id);
            if (!removida) return NotFound();
            return NoContent();
        }
    }
}
