using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivraria.Attributes;

public class GeneroValidoAttribute : ValidationAttribute
{
    private static readonly List<string> _generosValidos =
    [
        "Ficção",
        "Romance",
        "Mistério",
        "Fantasia",
        "Biografia"
    ];

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string genero && !_generosValidos.Contains(genero, StringComparer.OrdinalIgnoreCase))
            return new ValidationResult($"Gênero inválido. Os valores aceitos são: {string.Join(", ", _generosValidos)}");

        return ValidationResult.Success;
    }
}