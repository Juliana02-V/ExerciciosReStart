using Calculadora_Classes;

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
            string opcao = Console.ReadLine();
            if (opcao == "0")
            {
                break;
            }
            else if (opcao == "1")
            {
                Soma.Somar();
            }
            else if (opcao == "2")
            {
                Subtraçao.Subtrair();
            }
            else if (opcao == "3")
            {
                Multiplicaçao.Multiplicar();
            }
            else if (opcao == "4")
            {
                Divisao.Dividir();
            }
            else
            {
                Console.WriteLine("Insira um numero válido");
                continue;
            }
        }
    }
}
