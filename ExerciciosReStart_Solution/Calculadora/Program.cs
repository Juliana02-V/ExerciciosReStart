class Program
{
    static void Main()
    {
        Console.WriteLine("\tBem-Vindo à calculadora Juliana Vaz");
        while (true)
        {

            Console.WriteLine("1- Soma");
            Console.WriteLine("2- Subtração");
            Console.WriteLine("3- Multiplicação");
            Console.WriteLine("4- Divisão");
            Console.WriteLine("0- Sair");

            if (!int.TryParse(Console.ReadLine(), out int result))
            {
                Console.WriteLine("Insira um número válido");
                continue;
            }
            else if (result == 0)
            {
                break;
            }
            else if (result == 1)
            {
                Console.Clear();
                Console.WriteLine("Escolheu opção soma insira dois números");
                Console.Write("Insira o 1ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num1))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                Console.Write("Insira o 2ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num2))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                int soma = num1 + num2;
                Console.WriteLine($"A soma dos números {num1} e {num2} é = {soma}");
                continue;
            }
            else if (result == 2)
            {
                Console.Clear();
                Console.WriteLine("Escolheu opção subtração insira dois números");
                Console.Write("Insira o 1ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num1))
                {
                    Console.WriteLine("Insira um número válido");
                    continue ;
                }
                Console.Write("Insira o 2ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num2))
                {
                    Console.WriteLine("Insira um número válido");
                    continue ;
                }
                int soma = num1 - num2;
                Console.WriteLine($"A subtração dos números {num1} e {num2} é = {soma}");
                continue;
            }
            else if (result == 3)
            {
                Console.Clear();
                Console.WriteLine("Escolheu opção multiplicação insira dois números");
                Console.Write("Insira o 1ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num1))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                Console.Write("Insira o 2ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num2))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                int soma = num1 * num2;
                Console.WriteLine($"A multiplicação dos números {num1} e {num2} é = {soma}");
                continue;
            }
            else if (result == 4)
            {
                Console.Clear();
                Console.WriteLine("Escolheu opção divisão insira dois números");
                Console.Write("Insira o 1ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num1))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                Console.Write("Insira o 2ºnúmero: ");
                if (!int.TryParse(Console.ReadLine(), out int num2))
                {
                    Console.WriteLine("Insira um número válido");
                    continue;
                }
                int soma = num1 / num2;
                Console.WriteLine($"A divisão dos números {num1} e {num2} é = {soma}");
                continue;
            }
        }
    }
}
