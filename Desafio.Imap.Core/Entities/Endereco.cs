namespace Desafio.Imap.Core.Entities;

public class Endereco
{
    public Endereco()
    {
        Rua = default!;
        Complemento = default!;
        Cep = default!;
        Cidade = default!;
        Estado = default!;
    }

    public Endereco(int id, string rua, string complemento, int numero, string cep, string cidade, string estado, int candidatoId)
    {
        Id = id;
        Rua = rua;
        Complemento = complemento;
        Numero = numero;
        Cep = cep;
        Cidade = cidade;
        Estado = estado;
        CandidatoId = candidatoId;
    }

    public int Id { get; set; }
    public string Rua { get; set; }
    public string Complemento { get; set; }
    public int Numero { get; set; }
    public string Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public int CandidatoId {get; set;}
}
