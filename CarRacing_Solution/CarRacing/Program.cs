
using CarRacing;
internal class Program
{
    private static void Main(string[] args)
    {

        List<Veiculo> veiculos = new List<Veiculo>
            {
                new Carro("Mercedes", ConsoleColor.Magenta),
                new Carro("Seat", ConsoleColor.Red),
                new Carro("BMW", ConsoleColor.Green)
            };

        int totalKms = 50;  
        bool corridaTerminada = false;  

    
        while (!corridaTerminada)
        {
            
            Console.Clear();

           
            foreach (var veiculo in veiculos)
            {
                veiculo.Start(); 
                veiculo.Print();  
                Console.WriteLine();  
            }

           
            corridaTerminada = veiculos.Exists(veiculo => veiculo.Kms >= totalKms);

           
            Thread.Sleep(500); 
        }

       
        Veiculo vencedor = veiculos[0]; 
        foreach (var veiculo in veiculos)
        {
            if (veiculo.Kms > vencedor.Kms)
            {
                vencedor = veiculo;  
            }
        }

      
        Console.WriteLine($"\nO vencedor da corrida é {vencedor.Marca} com {vencedor.Kms} Kms percorridos!");

        Console.ReadKey();
    }
    
}



    
