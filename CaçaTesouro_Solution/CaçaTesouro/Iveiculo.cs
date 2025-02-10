using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaçaTesouro;

public interface IVeiculo
{
    bool Mover(Floresta floresta);
    string GetNome();
}
