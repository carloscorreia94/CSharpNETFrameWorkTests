using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{

    interface IListaNomes
    {
        void adicionar(String nome);

        String listar();

        void limpar();
    }


    class ListaNomes : IListaNomes
    {
        private ArrayList nomes = new ArrayList();

        public void adicionar(String nome)
        {
            nomes.Add(nome);
        }

        public String listar()
        {
            String final = "";
            if (nomes.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (String nome in nomes) sb.Append(nome + ',');
                final = sb.ToString();
                final = final.Remove(final.Length - 1);
            }
            return final;
        }

        public void limpar()
        {
            nomes.Clear();
        }
    }

}
