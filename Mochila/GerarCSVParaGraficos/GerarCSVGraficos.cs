using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila.GerarCSVParaGraficos
{
    public class GerarCSVGraficos
    {
        public void ExportarMelhoresIndividuos(Dictionary<string, List<Individuo>> resultados)
        {
            StringBuilder csvContent = new StringBuilder();

            var configuracoes = resultados.Keys;

            csvContent.AppendLine("Geração," + string.Join(",", configuracoes));

            int maxLinhas = 0;
            foreach (var lista in resultados.Values)
            {
                if (lista.Count > maxLinhas)
                {
                    maxLinhas = lista.Count;
                }
            }

            for (int i = 0; i < maxLinhas; i++)
            {
                List<string> linha = new List<string>();

                linha.Add((i + 1).ToString());

                foreach (var configuracao in configuracoes)
                {
                    if (i < resultados[configuracao].Count)
                    {
                        linha.Add(resultados[configuracao][i].Fit.ToString());
                    }
                    else
                    {
                        linha.Add(""); 
                    }
                }

                csvContent.AppendLine(string.Join(",", linha));
            }

            // Salva o conteúdo CSV em um arquivo
            string path = @"C:\Users\lglaj\source\repos\Mochila\Mochila\GerarCSVParaGraficos\MelhoresIndividuosPorGeracao.csv";
            File.WriteAllText(path, csvContent.ToString());
            Console.WriteLine($"Arquivo CSV gerado em: {path}");
        }
    }
}
