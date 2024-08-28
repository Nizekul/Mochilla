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

            // Obter todas as chaves (configurações) para a primeira linha do CSV
            var configuracoes = resultados.Keys;

            // Adiciona o cabeçalho ao CSV
            csvContent.AppendLine(string.Join(",", configuracoes));

            // Determinar o número máximo de linhas necessárias
            int maxLinhas = 0;
            foreach (var lista in resultados.Values)
            {
                if (lista.Count > maxLinhas)
                {
                    maxLinhas = lista.Count;
                }
            }

            // Preencher os dados de cada configuração
            for (int i = 0; i < maxLinhas; i++)
            {
                List<string> linha = new List<string>();
                foreach (var configuracao in configuracoes)
                {
                    if (i < resultados[configuracao].Count)
                    {
                        linha.Add(resultados[configuracao][i].Fit.ToString());
                    }
                    else
                    {
                        linha.Add(""); // Adiciona uma célula vazia se não houver mais indivíduos para essa configuração
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
