using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.Cruzamento
{
    public class CruzamentoDoisPontos : ICruzamento
    {
        private readonly Random _random = new Random();

        public (Individuo, Individuo) Cruzar(Individuo pai1, Individuo pai2, double taxaMutacao)
        {
            int[] filho1Vazio = new int[pai1.Cromossomo.Length];
            int[] filho2Vazio = new int[pai1.Cromossomo.Length];

            // Gerando dois pontos de Cortes no cromossomo
            int pontoCorte1 = _random.Next(pai1.Cromossomo.Length);
            int pontoCorte2 = _random.Next(pontoCorte1, pai2.Cromossomo.Length);

            for (int i = 0; i < pai1.Cromossomo.Length; i++)
            {
                if (i >= pontoCorte1 && i <= pontoCorte2)
                {
                    filho1Vazio[i] = pai2.Cromossomo[i];
                    filho2Vazio[i] = pai1.Cromossomo[i];
                }
                else
                {
                    filho1Vazio[i] = pai1.Cromossomo[i];
                    filho2Vazio[i] = pai2.Cromossomo[i];
                }
            }


            Individuo filho1 = new Individuo { Cromossomo = filho1Vazio };
            Individuo filho2 = new Individuo { Cromossomo = filho2Vazio };

            Mutacao(filho1, taxaMutacao);
            Mutacao(filho2, taxaMutacao);

            return (filho1, filho2);
        }

        public void Mutacao(Individuo filho, double taxaMutacao)
        {
            for (int i = 0; i < filho.Cromossomo.Length; ++i)
            {
                double chanceMutacao = _random.NextDouble();

                if (chanceMutacao < taxaMutacao)
                {
                    filho.Cromossomo[i] = (filho.Cromossomo[i] == 0 ) ? 1 : 0;
                }
            }
        }
    }
}
