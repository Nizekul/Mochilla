using Mochila.Cruzamento;
using Mochila.SelecaoPais;

namespace Mochila
{
    public class AlgoritmoGenetico
    {
        private readonly Item[] _itens;
        private readonly double _taxaMutacao;
        private readonly int _capacidadeDaMochila = 104;
        private readonly int _geracoes = 1000;
        private readonly ISelecaoPais _selecaoPais;
        private readonly ICruzamento _cruzamento;

        public AlgoritmoGenetico(Item[] itens, double taxaMutacao, ISelecaoPais selecaoPais, ICruzamento cruzamento)
        {
            _itens = itens;
            _taxaMutacao = taxaMutacao;
            _selecaoPais = selecaoPais;
            _cruzamento = cruzamento;
        }

        public Individuo[] GerarIndividuo(bool elitismo)
        {
            Individuo[] populacao = GerarPopulacaoInicial();

            // Se for utilizar o Elitismo
            int numElitismo = (int)(0.10 * 30);
            Individuo[] elitismoSelecao = populacao.OrderByDescending(i => i.Fit).Take(numElitismo).ToArray(); ;

            for (int geracao = 0; geracao < _geracoes; geracao++)
            {
                Individuo[] pais = _selecaoPais.SelecionarPais(populacao);
                List<Individuo> filhos = new List<Individuo>();

                for (int j = 0; j < pais.Length; j+=2)
                {
                    Individuo pai1 = pais[j];
                    Individuo pai2 = pais[(j + 1) % pais.Length];

                    var (filho1, filho2) = _cruzamento.Cruzar(pai1, pai2, _taxaMutacao);

                    filho1.CalcularFit(_itens, _capacidadeDaMochila);
                    filho2.CalcularFit(_itens, _capacidadeDaMochila);
                    filhos.Add(filho1);
                    filhos.Add(filho2);
                }

               populacao = elitismo ? elitismoSelecao.Concat(filhos).Take(populacao.Length).ToArray() : populacao.ToArray();
            }

            return populacao;
        }

        private Individuo[] GerarPopulacaoInicial()
        {
            Random numRandomico = new Random();
            Individuo[] populacao = new Individuo[30];

            for (int i = 0; i < 30; i++)
            {
                Individuo individuo = new Individuo();

                for (int j = 0; j < 8; j++)
                {
                    individuo.Cromossomo[j] = numRandomico.Next(2);
                }

                individuo.CalcularFit(_itens, _capacidadeDaMochila);
                populacao[i] = individuo;
            }

            return populacao;
        }



    }
}
