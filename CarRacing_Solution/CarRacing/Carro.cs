using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    internal class Carro : Veiculo
    {
        static string[] _symbols = { ".", "»", "*", "=" };  

        
        public Carro(string marca, ConsoleColor cor) : base(marca, cor)
        {
          
            Random rand = new Random();
            Simbolo = _symbols[rand.Next(_symbols.Length)];
        }

        
        public override void Start(int maxKms = 5)
        {

            Random rand = new Random();
            Kms += rand.Next(1, maxKms + 1);
        }
    }
}
