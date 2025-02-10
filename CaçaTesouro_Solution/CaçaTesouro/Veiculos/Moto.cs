using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaçaTesouro.Veiculos;

class Moto : Veiculo
{
    public Moto(int startX, int startY) : base(startX, startY, 'M') { }

    public Moto(Floresta floresta, char simbolo) : base(floresta, simbolo)
    {
    }

    public override bool Mover(Floresta floresta)
    {
        
        int dx = random.Next(-2, 3);
        int dy = random.Next(-2, 3); 
        return AtualizarPosicao(floresta, x + dx, y + dy);
    }

    
    protected override bool PodeMoverPara(char destino)
    {
        return destino == '.' || destino == 't';
    }
}



