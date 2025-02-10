using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    internal abstract class Veiculo
    {
        public string Marca { get; set; }
        public int Kms { get; set; }
        protected string Simbolo { get; set; }
        public ConsoleColor Color { get; set; }

    
        public Veiculo(string marca, ConsoleColor cor)
        {
            Marca = marca;
            Color = cor;
            Kms = 0; 
        }

       
        public abstract void Start(int maxKms = 5);

     
        public void Print()
        {
            
            Console.ForegroundColor = Color;

            
            for (int i = 0; i < Kms; i++)
            {
                Console.Write(Simbolo);  
            }
            Console.WriteLine($"\n{ Marca}");
            Console.ResetColor(); 
        }
    }
}
