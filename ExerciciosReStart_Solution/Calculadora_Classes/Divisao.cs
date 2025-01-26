using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_Classes
{
    internal class Divisao
    {
        public static void Dividir()
        {
            Console.Clear();
            Console.WriteLine("Escolheu opção divisão insira dois números");
            Console.Write("Insira o 1ºnúmero: ");
            if (!int.TryParse(Console.ReadLine(), out int num1))
            {
                Console.WriteLine("Insira um número válido");

            }
            Console.Write("Insira o 2ºnúmero: ");
            if (!int.TryParse(Console.ReadLine(), out int num2))
            {
                Console.WriteLine("Insira um número válido");

            }
            int soma = num1 / num2;
            Console.WriteLine($"A divisão dos números {num1} e {num2} é = {soma}");
            Console.WriteLine();
        }
    }
}

