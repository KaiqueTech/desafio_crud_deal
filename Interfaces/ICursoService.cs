using CursosApi.DTOs.Curso;

namespace CursosApi.Services.Cursos
{
    public interface ICursoService
    {
        Task<List<CursoResponseDto>> GetAll();
        Task<CursoResponseDto> GetById(int id);
        Task<CursoResponseDto> Create(CursoRequestDto dto);
        Task<bool> Update(int id, CursoUpdateDto dto);
        Task<bool> Delete(int id);
    }
}
