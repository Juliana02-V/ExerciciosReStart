using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using CaçaTesouro.Veiculos;

namespace CaçaTesouro;

abstract class Veiculo : IVeiculo
{
    protected int x, y;
    protected char simbolo;
    private int startX;
    private int startY;
    private char v;

    public Veiculo(Floresta floresta, char simbolo)
    {
        
        (x, y) = floresta.GerarPosicaoValida();
        this.simbolo = simbolo;
        floresta.AtualizarPosicao(x, y, simbolo);  
    }

    protected Veiculo(int startX, int startY, char v)
    {
        this.startX = startX;
        this.startY = startY;
        this.v = v;
    }

    public string GetNome()
    {
        return $"{simbolo} ({GetType().Name})";
    }

    public abstract bool Mover(Floresta floresta);

    protected virtual bool AtualizarPosicao(Floresta floresta, int novoX, int novoY)
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

        
        if (destino == '.' || PodeMoverPara(destino))
        {
            floresta.AtualizarPosicao(novoX, novoY, simbolo);
            floresta.AtualizarPosicao(x, y, '.');
            x = novoX;
            y = novoY;
        }

        return false;
    }

    protected virtual bool PodeMoverPara(char destino)
    {
        return destino == '.' || destino == 't'; 
    }
}



