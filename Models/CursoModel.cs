using CursosApi.Models;

public class CursoModel
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public int CargaHoraria { get; private set; }
    public bool Ativo { get; private set; }
    public List<MatriculaModel> Matriculas { get; private set; }

    public CursoModel(string titulo, string descricao, int cargaHoraria)
    {
        Titulo = titulo;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        Ativo = true;
        Matriculas = new List<MatriculaModel>();
    }

    public void Atualizar(string titulo, string descricao, int cargaHoraria, bool ativo)
    {
        Titulo = titulo;
        Descricao = descricao;
        CargaHoraria = cargaHoraria;
        Ativo = ativo;
    }
}
