using CursosApi.Data;
using CursosApi.DTOs.Matriculas;
using CursosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosApi.Services.Matriculas
{
    public class MatriculaService : IMatriculaService
    {
        private readonly AppDbContext _context;

        public MatriculaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MatriculaResponseDto>> GetAll()
        {
            return await _context.Matriculas
                .AsNoTracking()
                .Select(m => new MatriculaResponseDto
                {
                    Id = m.Id,
                    AlunoId = m.AlunoId,
                    CursoId = m.CursoId,
                    DataMatricula = m.DataMatricula
                })
                .ToListAsync();
        }

        public async Task<MatriculaResponseDto> GetById(int id)
        {
            return await _context.Matriculas
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new MatriculaResponseDto
                {
                    Id = m.Id,
                    AlunoId = m.AlunoId,
                    CursoId = m.CursoId,
                    DataMatricula = m.DataMatricula
                })
                .FirstOrDefaultAsync();
        }

        public async Task<MatriculaResponseDto> Create(MatriculaRequestDto dto)
        {
            var matricula = new MatriculaModel(dto.AlunoId, dto.CursoId);

            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();

            return new MatriculaResponseDto
            {
                Id = matricula.Id,
                AlunoId = matricula.AlunoId,
                CursoId = matricula.CursoId,
                DataMatricula = matricula.DataMatricula
            };
        }

        public async Task<bool> Delete(int id)
        {
            var matricula = await _context.Matriculas.FindAsync(id);
            if (matricula == null) return false;

            _context.Matriculas.Remove(matricula);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}