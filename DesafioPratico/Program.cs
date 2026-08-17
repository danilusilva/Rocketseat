using DesafioPratico;

// Menu de desafios
Console.WriteLine("Olá, seja muito bem vindo à minha resolução dos desafios propostos pela Rocketseat!");
Console.WriteLine("Digite o seu nome para que possamos continuar:");
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
Console.WriteLine($"Muito bem, {nome}, escolha um dos desafios solucionados no menu abaixo:");
Console.WriteLine("1 - Mensagem de boas vindas");
Console.WriteLine("2 - Nome e sobrenome");
Console.WriteLine("3 - Dois valores");
Console.WriteLine("4 - Quantidade de caracteres");
Console.WriteLine("5 - Validação de Placa Veículo");
Console.WriteLine("0 - Sair");

int? opcao = Console.ReadLine() switch
{
    "1" => 1,
    "2" => 2,
    "3" => 3,
    "4" => 4,
    "5" => 5,
    "0" => 0,
    _ => null
};

if (opcao is null || opcao < 0)
{
    Console.WriteLine("Opção inválida ou não informada, favor tente novamente...");
}
switch (opcao)
{
    case 1: BoasVindas.ExibirMensagem(); break;
    case 2: NomeESobrenome.ExibeNomeESobrenome(); break;
    case 3: DoisValores.CalculaDoisValores(); break;
    case 4: QuantCaracteres.ContaCaracteres(); break;
    case 5: PlacaVeiculo.ValidaPlaca(); break;


    case 0: Console.WriteLine("Encerrando programa..."); return;
}