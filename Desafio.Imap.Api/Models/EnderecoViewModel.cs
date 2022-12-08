using System.ComponentModel.DataAnnotations;

namespace Desafio.Imap.Api.Models;

public class EnderecoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public string Rua { get; set; } = default!;

    public string? Complemento { get; set; }

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int Numero { get; set; }

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public string Cep { get; set; } = default!;

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public string Cidade { get; set; } = default!;

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public string Estado { get; set; } = default!;
}
