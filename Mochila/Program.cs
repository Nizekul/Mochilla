
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
        bool elitismo = true;

        AlgoritmoGenetico mochila = new AlgoritmoGenetico(items, taxaMutacao1, new SelecaoPorRoleta(), new CruzamentoUniforme());
        var melhorGeracao = mochila.GerarIndividuo(elitismo);

        GerarCSVResultado gerarCSVResultado = new GerarCSVResultado();
        gerarCSVResultado.ExportarMelhorGeracao(melhorGeracao);

    }
}
