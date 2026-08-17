namespace DesafioPratico;

public static class BoasVindas
{
    public static void ExibirMensagem()
    {
        Console.WriteLine("Bem-vindo ao Desafio Prático!");
        Console.WriteLine("Por favor, digite seu nome:");
        string nome = Console.ReadLine();
        int tentativas = 0;
        while (nome is null || nome.Trim().Length == 0)
        {
            Console.WriteLine("Nome inválido. Por favor, digite seu nome novamente:");
            nome = Console.ReadLine();
            tentativas++;

            if (tentativas >= 3)
            {
                Console.WriteLine("Número máximo de tentativas atingido. Encerrando o programa.");
                return;
            }
        }
        Console.WriteLine($"Olá {nome}, seja muito bem-vindo ao primeiro exercício prático!");
    }
}
