using Desafio06.Console;
using System.Globalization;

var culture = new CultureInfo("pt-BR");

System.Console.WriteLine("=== Formatos de Saída Esperados ===\n");
System.Console.WriteLine($"Formato completo (F)      : {DateTime.Now.ToString("F", culture)}");
System.Console.WriteLine($"Apenas data (d)           : {DateTime.Now.ToString("d", culture)}");
System.Console.WriteLine($"Apenas hora 24h (T)       : {DateTime.Now.ToString("T", culture)}");
System.Console.WriteLine($"Data com mês extenso (D)  : {DateTime.Now.ToString("D", culture)}");
System.Console.WriteLine("\n" + new string('=', 50) + "\n");

ValidaData.RecebeUsuario();
