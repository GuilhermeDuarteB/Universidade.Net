using Universidade.Models;

public class Instrutores
{
    public int InstrutoresID { get; set; }
    public string InstrutoresNome { get; set; }

    public string Sobrenome { get; set; }
    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}