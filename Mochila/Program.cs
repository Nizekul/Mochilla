
using Mochila;
using Mochila.Cruzamento;
using Mochila.CSV_Resultado;
using Mochila.SelecaoPais;

class Program
{
    static void Main(string[] args)
    {
        // 8 Items com pesos(kg) e valores
        // o limite da mochila é de 104kg
        // Item  -  1 |  2  |  3  |  4  |  5  |  6  |  7  |  8  |
        // Peso  - 25 | 35  | 45  |  5  | 25  |  3  |  2  |  2  |
        // Valor - 350| 400 | 450 |  20 | 70  |  8  |  5  |  5  |
        Item[] items = new Item[]
        {
            new Item(25, 350),
            new Item(35, 400),
            new Item(45, 450),
            new Item(5, 20),
            new Item(25, 70),
            new Item(3, 8),
            new Item(2, 5),
            new Item(2, 5)
        };

        double taxaMutacao1 = 0.01;
        double taxaMutacao5 = 0.05;

        //AlgoritmoGenetico mochila = new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorRoleta(), new CruzamentoUniforme());
        GerarCSVResultado gerarCSVResultado = new GerarCSVResultado();

        // Dicionário para armazenar os melhores indivíduos de cada configuração
        Dictionary<string, List<Individuo>> melhoresIndividuosPorConfiguracao = new Dictionary<string, List<Individuo>>();

        // Lista de configurações a serem testadas
        string[] configuracoes = { "mutacao1", "mutacao5", "roleta", "torneio", "elitismo", "somente_filhos", "uniforme", "dois_pontos" };

        // Itera sobre cada configuração
        foreach (string configuracao in configuracoes)
        {
            melhoresIndividuosPorConfiguracao[configuracao] = new List<Individuo>();

            // Executa 30 vezes para cada configuração
            for (int i = 1; i <= 30; i++)
            {
                bool elitismo = configuracao != "somente_filhos";
                // Cria o algoritmo genético com base na configuração
                AlgoritmoGenetico algoritmoGenetico = CriarAlgoritmoGenetico(configuracao, items, taxaMutacao1, taxaMutacao5, elitismo);

                // Gera a população e obtém o melhor indivíduo
                var melhorGeracao = algoritmoGenetico.GerarIndividuo(elitismo);
                Individuo melhorIndividuo = melhorGeracao.OrderByDescending(ind => ind.Fit).First();

                if (melhorIndividuo != null)
                {
                    melhoresIndividuosPorConfiguracao[configuracao].Add(melhorIndividuo);
                }
            }

            // Exporta os melhores indivíduos para um arquivo CSV
            gerarCSVResultado.ExportarMelhoresIndividuos(melhoresIndividuosPorConfiguracao[configuracao], configuracao);
        }
        
    }
    // Método para criar uma instância de AlgoritmoGenetico com base na configuração
    private static AlgoritmoGenetico CriarAlgoritmoGenetico(string configuracao, Item[] items, double taxaMutacao1, double taxaMutacao5, bool elitismo)
    {
        switch (configuracao)
        {
            case "mutacao1":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorTorneio(), new CruzamentoUniforme());
            case "mutacao5":
                return new AlgoritmoGenetico(items, taxaMutacao5, new SelecaoPorTorneio(), new CruzamentoUniforme());
            case "roleta":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorRoleta(), new CruzamentoUniforme());
            case "torneio":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorTorneio(), new CruzamentoUniforme());
            case "elitismo":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorTorneio(), new CruzamentoUniforme());
            case "somente_filhos":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorTorneio(), new CruzamentoUniforme());
            case "uniforme":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorTorneio(), new CruzamentoUniforme());
            case "dois_pontos":
                return new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorTorneio(), new CruzamentoDoisPontos());
            default:
                throw new ArgumentException("Configuração desconhecida.");
        }
    }
}
