namespace CursosApi.DTOs.Curso;
public class CursoResponseDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int CargaHoraria { get; set; }
    public bool Ativo { get; set; }
}
