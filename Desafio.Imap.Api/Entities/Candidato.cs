namespace Desafio.Imap.Api.Entities;

public class Candidato
{
    public Candidato()
    {
        Nome = default!;
        Endereco = default!;
        Email = default!;
        Telefone = default!;
        Cpf = default!;
    }

    public Candidato(int id, string nome, Endereco endereco, int idade, string telefone, string cpf, string email)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Idade = idade;
        Telefone = telefone;
        Cpf = cpf;
        Email = email;
    }

    public int Id { get;  set; }
    public string Nome { get;  set; }
    public Endereco Endereco { get;  set; }
    public int Idade { get;  set; }
    public string Telefone { get; set; }
    public string Cpf { get;  set; }
    public string Email { get;  set; } 
}
