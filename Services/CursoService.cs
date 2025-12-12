using CursosApi.Data;
using CursosApi.DTOs.Curso;
using Microsoft.EntityFrameworkCore;

namespace CursosApi.Services.Cursos
{
    public class CursoService : ICursoService
    {
        private readonly AppDbContext _context;

        public CursoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CursoResponseDto>> GetAll()
        {
            return await _context.Cursos
                .AsNoTracking()
                .Select(c => new CursoResponseDto
                {
                    Id = c.Id,
                    Titulo = c.Titulo,
                    Descricao = c.Descricao,
                    CargaHoraria = c.CargaHoraria,
                    Ativo = c.Ativo
                })
                .ToListAsync();
        }

        public async Task<CursoResponseDto> GetById(int id)
        {
            return await _context.Cursos
                .AsNoTracking()
                .Where(c => c.Id == id)
                .Select(c => new CursoResponseDto
                {
                    Id = c.Id,
                    Titulo = c.Titulo,
                    Descricao = c.Descricao,
                    CargaHoraria = c.CargaHoraria,
                    Ativo = c.Ativo
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CursoResponseDto> Create(CursoRequestDto dto)
        {
            var curso = new CursoModel(
                dto.Titulo,
                dto.Descricao,
                dto.CargaHoraria
            );

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return new CursoResponseDto
            {
                Id = curso.Id,
                Titulo = curso.Titulo,
                Descricao = curso.Descricao,
                CargaHoraria = curso.CargaHoraria,
                Ativo = curso.Ativo
            };
        }

        public async Task<bool> Update(int id, CursoUpdateDto dto)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return false;

            curso.Atualizar(dto.Titulo, dto.Descricao, dto.CargaHoraria, dto.Ativo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return false;

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}