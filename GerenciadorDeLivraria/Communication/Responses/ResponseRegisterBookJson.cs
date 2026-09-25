using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeLivraria.Communication.Responses;

public class ResponseRegisterBookJson
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
