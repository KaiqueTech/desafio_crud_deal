using CursosApi.DTOs.Matriculas;

namespace CursosApi.Services.Matriculas
{
    public interface IMatriculaService
    {
        Task<List<MatriculaResponseDto>> GetAll();
        Task<MatriculaResponseDto> GetById(int id);
        Task<MatriculaResponseDto> Create(MatriculaRequestDto dto);
        Task<bool> Delete(int id);
    }
}