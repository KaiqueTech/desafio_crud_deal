using CursosApi.Data;
using CursosApi.DTOs.Alunos;
using CursosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosApi.Services.Alunos
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlunoResponseDto>> GetAll()
        {
            return await _context.Alunos
                .AsNoTracking()
                .Select(a => new AlunoResponseDto
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Email = a.Email,
                    DataNascimento = a.DataNascimento,
                    Ativo = a.Ativo
                })
                .ToListAsync();
        }

        public async Task<AlunoResponseDto> GetById(int id)
        {
            return await _context.Alunos
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Select(a => new AlunoResponseDto
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Email = a.Email,
                    DataNascimento = a.DataNascimento,
                    Ativo = a.Ativo
                })
                .FirstOrDefaultAsync();
        }

        public async Task<AlunoResponseDto> Create(AlunoRequestDto dto)
        {
            var aluno = new AlunoModel(dto.Nome, dto.Email, dto.DataNascimento);

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return new AlunoResponseDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Email = aluno.Email,
                DataNascimento = aluno.DataNascimento,
                Ativo = aluno.Ativo
            };
        }

        public async Task<bool> Update(int id, AlunoUpdateDto dto)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return false;

            aluno.Atualizar(dto.Nome, dto.Email, dto.DataNascimento, dto.Ativo);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                return false;

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}