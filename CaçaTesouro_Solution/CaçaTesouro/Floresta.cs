using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaçaTesouro.Veiculos;

namespace CaçaTesouro;

class Floresta
{
    public int Largura { get; set; }
    public int Altura { get; set; }
    public char[,] Mapa { get; set; }
    private static Random random = new Random();

    public Floresta(int largura, int altura)
    {
        Largura = largura;
        Altura = altura;
        Mapa = new char[altura, largura];
        InicializarFloresta();
    }

    public void InicializarFloresta()
    {
     
        for (int y = 0; y < Altura; y++)
        {
            for (int x = 0; x < Largura; x++)
            {
                Mapa[y, x] = '.';
            }
        }

       
        for (int x = 0; x < Largura; x++)
        {
            Mapa[0, x] = '#';
            Mapa[Altura - 1, x] = '#';
        }

        for (int y = 0; y < Altura; y++)
        {
            Mapa[y, 0] = '#';
            Mapa[y, Largura - 1] = '#';
        }

        
        (int tesouroX, int tesouroY) = GerarPosicaoValida();
        Mapa[tesouroY, tesouroX] = 't'; 
    }

    
    public (int, int) GerarPosicaoValida()
    {
        int x, y;

        
        do
        {
            x = random.Next(1, Largura - 1);
            y = random.Next(1, Altura - 1);
        }
        while (Mapa[y, x] != '.'); 

        return (x, y);
    }

    public void AtualizarPosicao(int x, int y, char simbolo)
    {
        Mapa[y, x] = simbolo;
    }

    public void ExibirFloresta()
    {
        Console.Clear();
        for (int y = 0; y < Altura; y++)
        {
            for (int x = 0; x < Largura; x++)
            {
                Console.Write(Mapa[y, x] + " ");
            }
            Console.WriteLine();
        }
    }
}












