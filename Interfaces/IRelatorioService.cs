using CursosApi.DTOs.Relatorios;

namespace CursosApi.Services.Relatorios
{
    public interface IRelatorioService
    {
        Task<List<RelatorioCursoMatriculasDto>> GetCursosComTotalMatriculas();
        Task<List<RelatorioAlunosPorCursoDto>> GetAlunosPorCurso(int cursoId);
        Task<int> GetTotalMatriculas();
        Task<RelatorioAlunosAtivosInativosDto> GetAlunosAtivosInativos();
    }
}
