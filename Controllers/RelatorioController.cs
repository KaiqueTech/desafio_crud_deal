using CursosApi.Services.Relatorios;
using Microsoft.AspNetCore.Mvc;

namespace CursosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioService _service;

        public RelatoriosController(IRelatorioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna a lista de cursos com o total de matrículas.
        /// </summary>
        /// <returns>Lista de cursos com total de matrículas</returns>
        [HttpGet("cursos-matriculas")]
        public async Task<IActionResult> GetCursosComTotalMatriculas()
        {
            var result = await _service.GetCursosComTotalMatriculas();
            return Ok(result);
        }

        /// <summary>
        /// Retorna a lista de alunos de um curso específico.
        /// </summary>
        /// <param name="cursoId">ID do curso</param>
        /// <returns>Lista de alunos matriculados</returns>
        [HttpGet("alunos-curso/{cursoId}")]
        public async Task<ActionResult> GetAlunosPorCurso(int cursoId)
        {
            var alunos = await _service.GetAlunosPorCurso(cursoId);
            return Ok(alunos);
        }

        /// <summary>
        /// Retorna o total de matrículas na plataforma.
        /// </summary>
        /// <returns>Total de matrículas</returns>
        [HttpGet("total-matriculas")]
        public async Task<IActionResult> GetTotalMatriculas()
        {
            var total = await _service.GetTotalMatriculas();
            return Ok(new { total });
        }

        /// <summary>
        /// Retorna a quantidade de alunos ativos e inativos.
        /// </summary>
        /// <returns>Quantidade de alunos ativos e inativos</returns>
        [HttpGet("alunos-ativos-inativos")]
        public async Task<IActionResult> GetAlunosAtivosInativos()
        {
            var result = await _service.GetAlunosAtivosInativos();
            return Ok(result);
        }
    }
}
