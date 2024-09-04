using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.CSVResultado
{
    public class GerarCSVResultado
    {
        public void ExportarMelhoresIndividuos(List<Individuo> melhoresIndividuos, string configuracao)
        {
            string nomeArquivo = configuracao + ".csv";
            string caminho = "C:\\Users\\lglaj\\source\\repos\\Mochila\\Mochila\\CSVResultados";

            string caminhoArquivo = Path.Combine(caminho, nomeArquivo);

            using (StreamWriter sw = new StreamWriter(caminhoArquivo))
            {
                sw.WriteLine("Cromossomo          |            Fitness");

                foreach (Individuo individuo in melhoresIndividuos.OrderByDescending(ind => ind.Fit))
                {
                    string cromossomo = string.Join(",", individuo.Cromossomo);
                    sw.WriteLine($"{cromossomo},                    {individuo.Fit}");
                }
            }
        }
    }
}
