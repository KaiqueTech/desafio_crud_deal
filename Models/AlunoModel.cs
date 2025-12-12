namespace CursosApi.Models;
public class AlunoModel
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public bool Ativo { get; private set; } = true;

    public List<MatriculaModel> Matriculas { get; private set; }

    public AlunoModel(string nome, string email, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
        Matriculas = new List<MatriculaModel>();
    }

        public void Atualizar(string nome, string email, DateTime dataNascimento, bool ativo)
    {
        Nome = nome;
        Email = email;
        DataNascimento = dataNascimento;
        Ativo = ativo;
    }
    
}