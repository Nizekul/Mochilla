using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mochila
{
    public class Individuo
    {
        public int[] Cromossomo {  get; set; }
        public double Fit { get; set; }

        public Individuo()
        {
            Cromossomo = new int[8];
        }

        public void CalcularFit(Item[] item, int capacidadeDaMochila)
        {
            int pesoTotal = 0;
            int valorTotal = 0;

            for(int i = 0; i < 8; i ++)
            {
                if (Cromossomo[i] == 1)
                {
                    pesoTotal += item[i].Peso;
                    valorTotal += item[i].Valor;
                }
            }
            
            Fit = (pesoTotal <= capacidadeDaMochila) ? valorTotal : 0;
        }

    }
}
