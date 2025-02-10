using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaçaTesouro.Veiculos;

class Escavadora : Veiculo
{
    public Escavadora(int startX, int startY) : base(startX, startY, 'E') { }

    public Escavadora(Floresta floresta, char simbolo) : base(floresta, simbolo)
    {
    }

    public override bool Mover(Floresta floresta)
    {
        
        int dx = random.Next(-1, 2);
        int dy = random.Next(-1, 2);
        return AtualizarPosicao(floresta, x + dx, y + dy);
    }

    
    protected override bool AtualizarPosicao(Floresta floresta, int novoX, int novoY)
    {
        novoX = (novoX + floresta.Largura) % floresta.Largura;
        novoY = (novoY + floresta.Altura) % floresta.Altura;

        
        char destino = floresta.Mapa[novoY, novoX];

        if (destino == 't') 
        {
            floresta.AtualizarPosicao(novoX, novoY, simbolo);
            floresta.AtualizarPosicao(x, y, '.');
            x = novoX;
            y = novoY;
            return true;
        }

       
        if (destino != '#') 
        {
            floresta.AtualizarPosicao(novoX, novoY, simbolo);
            floresta.AtualizarPosicao(x, y, '.');
            x = novoX;
            y = novoY;
        }

        return false;
    }
}



