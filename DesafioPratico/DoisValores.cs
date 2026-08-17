namespace DesafioPratico;

public static class DoisValores
{
    public static void CalculaDoisValores()
    {
        double valor1 = ObterValorValido("Digite o primeiro valor:");
        double valor2 = ObterValorValido("Digite o segundo valor:");

        Console.WriteLine($"A soma do valor {valor1} e {valor2} é: {valor1 + valor2}");
        Console.WriteLine($"A subtração do valor {valor1} e {valor2} é: {valor1 - valor2}");
        Console.WriteLine($"A multiplicação do valor {valor1} e {valor2} é: {valor1 * valor2}");

        if (valor2 == 0)
        {
            Console.WriteLine("Não é possível realizar a divisão por zero.");
            return;
        }

        Console.WriteLine($"A divisão do valor {valor1} e {valor2} é: {valor1 / valor2}");
    }

    private static double ObterValorValido(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            string? entrada = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("❌ Erro: O valor é obrigatório. Tente novamente.\n");
                continue;
            }

            if (double.TryParse(entrada, out double valor))
            {
                return valor;
            }

            Console.WriteLine("❌ Erro: Digite um número válido. Tente novamente.\n");
        }
    }
}
