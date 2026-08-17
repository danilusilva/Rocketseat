namespace DesafioPratico;

public static class PlacaVeiculo
{
    public static void ValidaPlaca()
    {
        bool placaValida = ObterPlacaValida("Digite a placa do carro a ser consultado");
        Console.WriteLine(placaValida ? "A placa informada é válida!" : "A placa informada é inválida!");
    }

    private static bool ObterPlacaValida(string mensagem)
    {
        while (true)
        {
            Console.WriteLine(mensagem);
            string? placaVeiculo = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(placaVeiculo))
            {
                Console.WriteLine("Erro: O valor é obrigatório. Tente novamente.\n");
                continue;
            }

            if (placaVeiculo.Length != 7)
            {
                Console.WriteLine("Erro: A placa deve ter 7 caracteres alfanuméricos;\n");
                continue;
            }

            // Validar se os 3 primeiros caracteres são letras
            if (!char.IsLetter(placaVeiculo[0]) || !char.IsLetter(placaVeiculo[1]) || !char.IsLetter(placaVeiculo[2]))
            {
                Console.WriteLine("❌ Erro: Os 3 primeiros caracteres devem ser letras.\n");
                continue;
            }

            // Validar se os 4 últimos caracteres são números
            if (!char.IsDigit(placaVeiculo[3]) || !char.IsDigit(placaVeiculo[4]) || !char.IsDigit(placaVeiculo[5]) || !char.IsDigit(placaVeiculo[6]))
            {
                Console.WriteLine("❌ Erro: Os 4 últimos caracteres devem ser números.\n");
                continue;
            }

            // Se passou em todas as validações, retorna true
            return true;
        }
    }
}