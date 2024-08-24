using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.SelecaoPais
{
    public class SelecaoPorRoleta : ISelecaoPais
    {
        private readonly Random _random = new Random();
        public Individuo[] SelecionarPais(Individuo[] populacao)
        {
            double somaFitness = populacao.Sum(i => i.Fit);
            List<Individuo> paisSelecionados = new List<Individuo>();

            for (int i = 0; i < 30; i++)
            {
                double sorteado = _random.NextDouble() * somaFitness;
                double paiSorteado = 0;

                foreach (Individuo pai in populacao)
                {
                    paiSorteado += pai.Fit;
                    if (paiSorteado >= sorteado)
                    {
                        paisSelecionados.Add(pai);
                        break;
                    }
                }
            }

            return paisSelecionados.ToArray();
        }
    }
}
