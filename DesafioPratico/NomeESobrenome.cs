namespace DesafioPratico;

public static class NomeESobrenome
{
    public static void ExibeNomeESobrenome()
    {
        Console.WriteLine("Digite o seu nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o seu sobrenome:");
        string sobrenome = Console.ReadLine();
        Console.WriteLine($"Opa, {nome} {sobrenome}, que belo nome você tem!");
    }
}
