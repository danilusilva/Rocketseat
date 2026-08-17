using System.Globalization;
namespace Desafio06.Console;

public static class ValidaData
{
    private static readonly CultureInfo Culture = new("pt-BR");

    /// <summary>
    /// Solicita ao usuário 4 tipos de formatação de data/hora
    /// </summary>
    public static void RecebeUsuario()
    {
        System.Console.WriteLine("=== Bem-vindo ao Sistema de Validação de Data/Hora ===\n");

        // 1. Formato completo (dia da semana, dia do mês, mês, ano, hora, minutos, segundos)
        SolicitaEValida(
            "Digite a data no formato COMPLETO (ex: segunda-feira, 12 de agosto de 2026 15:30:45):",
            "F"
        );

        // 2. Apenas a data no formato "01/03/2024"
        SolicitaEValida(
            "Digite apenas a DATA no formato DD/MM/YYYY (ex: 12/08/2026):",
            "d"
        );

        // 3. Apenas a hora no formato de 24 horas
        SolicitaEValida(
            "Digite apenas a HORA em formato 24h (ex: 15:30:45):",
            "T"  // T = hora com segundos em formato 24h
        );

        // 4. A data com o mês por extenso
        SolicitaEValida(
            "Digite a data com o mês POR EXTENSO (ex:segunda-feira, 12 de agosto de 2026):",
            "D"
        );

        System.Console.WriteLine("\n✅ Parabéns! Você completou todas as validações com sucesso!");
    }

    /// <summary>
    /// Solicita entrada do usuário e valida contra um formato específico
    /// </summary>
    /// <param name="mensagem">Mensagem a exibir para o usuário</param>
    /// <param name="formato">Formato esperado (F, d, T, D)</param>
    private static void SolicitaEValida(string mensagem, string formato)
    {
        System.Console.WriteLine(mensagem);

        while (true)
        {
            string respostaUser = System.Console.ReadLine()?.ToLower().Trim() ?? "";

            if (string.IsNullOrEmpty(respostaUser))
            {
                System.Console.WriteLine("Entrada vazia! Digite algo.\n");
                continue;
            }

            if (ValidaInsercaoData(respostaUser, formato))
            {
                System.Console.WriteLine("Perfeito! Formato correto.\n");
                break;
            }
            else
            {
                System.Console.WriteLine("Formato ou data inserida inválido! Tente novamente.\n");
            }
        }
    }

    /// <summary>
    /// Valida se a entrada do usuário corresponde EXATAMENTE ao formato esperado
    /// </summary>
    /// <param name="data">Texto inserido pelo usuário</param>
    /// <param name="formato">Formato esperado</param>
    /// <returns>True se válido; False caso contrário</returns>
    public static bool ValidaInsercaoData(string data, string formato)
    {
        // Tenta fazer parse exato do formato especificado
        bool isValid = DateTime.TryParseExact(
            data,
            formato,
            Culture,
            DateTimeStyles.None,
            out DateTime resultado
        );

        return isValid;
    }
}
