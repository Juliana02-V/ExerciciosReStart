class Program
{
    static void Main()
    {
        //Calcular a soma de dois números se forem ambos diferentes de zero
      
        while (true)
        {
           
            Console.WriteLine("Insira dois Números que não seja Zero(0)");
            Console.Write("Insira o 1ºNúmero: ");
            if (!int.TryParse(Console.ReadLine(), out int num1))
            {
                Console.WriteLine("Insira um número válido");
                Console.WriteLine();
                continue;
            }
           
            Console.Write("Insira o 2ºNúmero: ");
            if (!int.TryParse(Console.ReadLine(), out int num2))
            {
                Console.WriteLine("Insira um número válido");
                Console.WriteLine();
                continue;

            }
        

            int soma = num1 + num2;

            if (num1 == 0 && num2 == 0)
            {
                Console.WriteLine("Insira um número diferente de zero(0)");
                continue;
            }
            else if (num1 != 0 && num2 != 0)
            {
                Console.WriteLine();
                Console.WriteLine($"A soma de {num1} e {num2} é = {soma}");
                Console.WriteLine();
                continue;
            }
            else
            {
                break;
             
            }
        }           
    }
}
