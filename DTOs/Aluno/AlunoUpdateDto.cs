namespace CursosApi.DTOs.Alunos
{
    public class AlunoUpdateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}