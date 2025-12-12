using CursosApi.DTOs.Curso;
using CursosApi.Services.Cursos;
using Microsoft.AspNetCore.Mvc;

namespace CursosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;

        public CursoController(ICursoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var cursos = await _service.GetAll();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var curso = await _service.GetById(id);
            if (curso == null) return NotFound();
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CursoRequestDto dto)
        {
            var curso = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = curso.Id }, curso);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CursoUpdateDto dto)
        {
            var atualizado = await _service.Update(id, dto);
            if (!atualizado) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var apagado = await _service.Delete(id);
            if (!apagado) return NotFound();
            return NoContent();
        }
    }
}
