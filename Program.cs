using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, double> cotacoes = new Dictionary<string, double>
    {
        {"REAL", 1},
        {"DOLAR", 5.42},
        {"EURO", 6.38}
    };

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE CÂMBIO ===");

            Console.WriteLine("1 - Alterar cotação");
            Console.WriteLine("2 - Converter");
            Console.WriteLine("0 - Sair");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AlterarCotacao();
                    break;
                case "2":
                    ConverterMoeda();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AlterarCotacao()
    {
        Console.Clear();
        Console.WriteLine("==== Alterar Cotação ====\n");

        foreach (var moeda in cotacoes.Keys)
        {
            if (moeda != "REAL")
            {
                Console.Write($"Digite a cotação de 1 {moeda} em REAL: ");
                if (double.TryParse(Console.ReadLine(), out double novaCotacao))
                {
                    cotacoes[moeda] = novaCotacao;
                    Console.WriteLine($"Cotação atualizada: 1 {moeda} = {novaCotacao:F2} REAL");
                }
                else
                {
                    Console.WriteLine("Valor inválido.");
                }
            }
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
    }

    static void ConverterMoeda()
    {
        Console.Clear();
        Console.WriteLine("=== Conversor de Moeda ===\n");

        Console.Write("Moeda de origem (REAL, DOLAR, EURO): ");
        string origem = Console.ReadLine().ToUpper();

        Console.Write("Moeda de destino (REAL, DOLAR, EURO): ");
        string destino = Console.ReadLine().ToUpper();

        if (!cotacoes.ContainsKey(origem) || !cotacoes.ContainsKey(destino))
        {
            Console.WriteLine("Moeda inválida.");
            Console.ReadKey();
            return;
        }

        Console.Write($"Valor em {origem}: ");
        if (!double.TryParse(Console.ReadLine(), out double valor))
        {
            Console.WriteLine("Valor inválido.");
            Console.ReadKey();
            return;
        }

        double valorREAL = valor * cotacoes[origem];
        double valorConvertido = valorREAL / cotacoes[destino];

        Console.WriteLine($"\n{valor} {origem} = {valorConvertido:F2} {destino}");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
