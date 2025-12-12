
namespace CursosApi.Models;
public class MatriculaModel
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public int CursoId { get; set; }
    public DateTime DataMatricula { get; set; }

    public AlunoModel Aluno { get; set; }
    public CursoModel Curso { get; set; }
    
    public MatriculaModel(int alunoId, int cursoId)
    {
        AlunoId = alunoId;
        CursoId = cursoId;
        DataMatricula = DateTime.UtcNow;
    }

}
