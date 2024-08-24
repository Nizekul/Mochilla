using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.SelecaoPais
{
    public interface ISelecaoPais
    {
        Individuo[] SelecionarPais(Individuo[] populacao);
    }
}
