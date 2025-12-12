using System.Data;
using CursosApi.DTOs.Relatorios;
using Dapper;

namespace CursosApi.Services.Relatorios
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IDbConnection _connection;

        public RelatorioService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<RelatorioCursoMatriculasDto>> GetCursosComTotalMatriculas()
        {
            var sql = @"
                SELECT c.""Id"" AS CursoId,
                 c.""Titulo"" AS Titulo,
                 COUNT(m.""Id"") AS TotalMatriculas
                FROM ""tbl_Curso"" c
                LEFT JOIN ""tbl_Matricula"" m ON m.""CursoId"" = c.""Id""
                GROUP BY c.""Id"", c.""Titulo""
                ORDER BY c.""Titulo"";
            ";

            var result = await _connection.QueryAsync<RelatorioCursoMatriculasDto>(sql);
            return result.ToList();
        }

        public async Task<List<RelatorioAlunosPorCursoDto>> GetAlunosPorCurso(int cursoId)
        {
            var sql = @"
                SELECT a.""Id"" AS AlunoId,
                       a.""Nome"" AS NomeAluno,
                       a.""Email"" AS EmailAluno
                FROM ""tbl_Matricula"" m
                INNER JOIN ""tbl_Aluno"" a ON a.""Id"" = m.""AlunoId""
                WHERE m.""CursoId"" = @cursoId
                ORDER BY a.""Nome"";
            ";

            var result = await _connection.QueryAsync<RelatorioAlunosPorCursoDto>(sql, new { cursoId });
            return result.ToList();
        }

        public async Task<int> GetTotalMatriculas()
        {
            var sql = @"SELECT COUNT(*) FROM ""tbl_Matricula"";";

            return await _connection.ExecuteScalarAsync<int>(sql);
        }

        public async Task<RelatorioAlunosAtivosInativosDto> GetAlunosAtivosInativos()
        {
            var sql = @"
                SELECT 
                    SUM(CASE WHEN ""Ativo"" = TRUE THEN 1 ELSE 0 END) AS Ativos,
                    SUM(CASE WHEN ""Ativo"" = FALSE THEN 1 ELSE 0 END) AS Inativos
                FROM ""tbl_Aluno"";
            ";

            return await _connection.QuerySingleAsync<RelatorioAlunosAtivosInativosDto>(sql);
        }
    }
}
