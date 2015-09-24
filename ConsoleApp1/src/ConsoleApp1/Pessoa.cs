using System;

namespace ConsoleApp1
{

    public class Pessoa
    {
        private string nome;
        private int idade;

        public Pessoa(string nome, int idade)
        {
            this.nome = nome;
            this.idade = idade;
        }

        public void mostraInfo()
        {
            Console.WriteLine("{0}, tem {1} anos", nome, idade);
        }
    }
}
