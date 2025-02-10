using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaçaTesouro.Veiculos;

class Tanque : Veiculo
{
    public Tanque(int startX, int startY) : base(startX, startY, 'T') { }

    public Tanque(Floresta floresta, char simbolo) : base(floresta, simbolo)
    {
    }

    public override bool Mover(Floresta floresta)
    {
        
        int dx = random.Next(-1, 2);
        int dy = random.Next(-1, 2);
        return AtualizarPosicao(floresta, x + dx, y + dy);
    }

   
    protected override bool PodeMoverPara(char destino)
    {
        
        return destino != '#' && destino != 'T';
    }
}
