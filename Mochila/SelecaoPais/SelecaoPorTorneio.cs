using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.SelecaoPais
{

    // Seleciona 3 individuos e coloca em um torneio
    // para ver qual o melhor, vence o com maior Fitness
    public class SelecaoPorTorneio : ISelecaoPais
    {
        private readonly Random _random = new Random();
        public Individuo[] SelecionarPais(Individuo[] populacao)
        {
            List<Individuo> paisSelecionados = new List<Individuo>();

            for (int i = 0; i < populacao.Length; i++)
            {
                List<Individuo> torneio = new List<Individuo>();

                for(int j = 0; j < 3; j++)
                {
                    torneio.Add(populacao[_random.Next(populacao.Length)]);
                }

                Individuo vencedor = torneio.OrderByDescending(i => i.Fit).First();
                paisSelecionados.Add(vencedor);
            }

            return paisSelecionados.ToArray();
        }
    }
}
