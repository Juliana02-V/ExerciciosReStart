using CaçaTesouro;
using CaçaTesouro.Veiculos;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Insira largura do mapa da floresta: ");
        int largura = int.Parse(Console.ReadLine());
        Console.WriteLine("Insira a altura do mapa da floresta: ");
        int altura = int.Parse(Console.ReadLine());

        Floresta floresta = new Floresta(largura, altura);

       
        List<Veiculo> veiculos = new List<Veiculo>
        {
            new Moto(floresta, 'M'),
            new Tanque(floresta, 'T'),
            new Escavadora(floresta, 'E')
        };

        string vencedor = null;

        
        floresta.ExibirFloresta();

        while (vencedor == null)
        {
            foreach (var veiculo in veiculos)
            {
                if (veiculo.Mover(floresta))
                {
                    vencedor = veiculo.GetNome(); 
                    break;
                }
            }

           
            floresta.ExibirFloresta();
            Thread.Sleep(500); 
        }

        Console.WriteLine($"O vencedor é: {vencedor}!");
    }
}


