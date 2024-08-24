using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.CSV_Resultado
{
    public class GerarCSVResultado
    {
        public void ExportarMelhorGeracao(Individuo[] melhorPopulacao)
        {
            string nomeArquivo = "melhor_geracao.csv";
            string caminho = "C:\\Users\\lglaj\\source\\repos\\Mochila\\Mochila\\CSV_Resultados";

            string caminhoArquivo = Path.Combine(caminho, nomeArquivo);

            Directory.CreateDirectory(Path.GetDirectoryName(caminhoArquivo));

            using (StreamWriter sw = new StreamWriter(caminhoArquivo))
            {
                sw.WriteLine("Cromossomo          |            Fitness");

                foreach (Individuo individuo in melhorPopulacao)
                {
                    string cromossomo = string.Join(",", individuo.Cromossomo);
                    sw.WriteLine($"{cromossomo},                    {individuo.Fit}");

                }
            }
        }
    }
}
