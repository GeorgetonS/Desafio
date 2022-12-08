using System.ComponentModel.DataAnnotations;

namespace Desafio.Imap.Api.Models;

public class CandidatoViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public string Nome { get; set; } = default!;

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public EnderecoViewModel Endereco { get; set; } = default!;
    
    [Required(ErrorMessage = "{0} deve ser preenchido")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(11, ErrorMessage = "{0} deve conter 11 caracteres")]
    public string Telefone { get; set; } = default!;

    [Required(ErrorMessage = "{0} deve ser preenchido")]
    [MinLength(11,ErrorMessage = "{0} deve conter 11 caracteres")]
    public string Cpf { get; set; } = default!;

    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "{0} deve ser preenchido")]
    public string Email { get; set; } = default!;
}
