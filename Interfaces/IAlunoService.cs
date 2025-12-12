using CursosApi.DTOs.Alunos;

namespace CursosApi.Services.Alunos
{
    public interface IAlunoService
    {
        Task<List<AlunoResponseDto>> GetAll();
        Task<AlunoResponseDto> GetById(int id);
        Task<AlunoResponseDto> Create(AlunoRequestDto dto);
        Task<bool> Update(int id, AlunoUpdateDto dto);
        Task<bool> Delete(int id);
    }
}
