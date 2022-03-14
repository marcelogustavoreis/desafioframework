using DesafioFramework.Core;
using System;

namespace DesafioFramework.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroParaDecompor = 0;
            bool conversaoCorreta = false;

            Console.WriteLine($"Digite número que gostaria de decompor:");
            do
            {
                conversaoCorreta = int.TryParse(Console.ReadLine(), out numeroParaDecompor);
                if (!conversaoCorreta || numeroParaDecompor <= 1)
                    Console.WriteLine($"Digite um número maior que 1:");
            } while (!conversaoCorreta || numeroParaDecompor <= 1);

            Desafio desafio = new Desafio(numeroParaDecompor);
            Console.WriteLine($"Número de Entrada: {desafio.NumeroEntrada}");
            Console.WriteLine($"Todos Números Primos: {string.Join("-", desafio.NumerosPrimos)}");
            Console.WriteLine($"Números Divisores: {string.Join("-", desafio.NumerosDivisores)}");
            Console.WriteLine($"Divisores Primos: {string.Join("-", desafio.NumerosDivisoresPrimos)}");
        }
    }
}
