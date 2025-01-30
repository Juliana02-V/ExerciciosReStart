using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjSuperClean_Juliana.Vaz;

public class Limpeza
{
    public int DivisaoId { get; set; }
    public DateTime UltimaLimpeza { get; private set; }
    public DateTime DataPrevistaLimpeza { get; private set; }
    public int IntervaloLimpeza { get; set; } // Intervalo de limpeza em dias

    public Limpeza(int divisaoId, int intervaloLimpeza)
    {
        DivisaoId = divisaoId;
        IntervaloLimpeza = intervaloLimpeza;
        UltimaLimpeza = DateTime.MinValue; // Inicialmente, sem registro de limpeza
        DataPrevistaLimpeza = DateTime.MinValue;
    }

    public Limpeza()
    {
    }

 

   
 
}
