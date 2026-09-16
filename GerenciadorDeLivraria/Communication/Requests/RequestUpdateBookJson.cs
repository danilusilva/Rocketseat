using GerenciadorDeLivraria.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivraria.Communication.Requests;

public class RequestUpdateBookJson
{
    [StringLength(120, MinimumLength = 2, ErrorMessage = "Título do livro deve ter no mínimo 2 e no máximo 120 caracteres")]
    public string? Titulo { get; set; } = string.Empty;

    [StringLength(120, MinimumLength = 2, ErrorMessage = "O campo 'Autor' deve ter no mínimo 2 e no máximo 120 caracteres")]
    public string? Autor { get; set; } = string.Empty;

    [GeneroValido]
    public string? Genero { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "Preço não pode ser negativo!")]
    public decimal? Preco { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Estoque não pode ser negativo!")]
    public int? Estoque { get; set; }
}
