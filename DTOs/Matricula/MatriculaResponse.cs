namespace CursosApi.DTOs.Matriculas
{
    public class MatriculaResponseDto
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}
