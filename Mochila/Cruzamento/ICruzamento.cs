using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.Cruzamento
{
    public interface ICruzamento
    {
        (Individuo, Individuo) Cruzar(Individuo pai1, Individuo pai2, double taxaMutacao);
        void Mutacao(Individuo filho, double taxaMutacao);
    }
}
