namespace DesafioPratico;

public static class QuantCaracteres
{
    public static void ContaCaracteres()
    {
        Console.WriteLine("Digite uma frase para contar os caracteres:");
        string frase = Console.ReadLine() ?? string.Empty;
        int quantidadeCaracteres = frase.Length;
        if (quantidadeCaracteres == 0 || string.IsNullOrWhiteSpace(frase))
        {
            Console.WriteLine("Você não digitou nenhuma frase.");
            return;
        }
        Console.WriteLine($"A frase digitada possui {quantidadeCaracteres} caracteres.");
    }
}
