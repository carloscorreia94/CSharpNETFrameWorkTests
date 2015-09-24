using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public void Main(string[] args)
        {
            Pessoa cliente = new Pessoa("Carlos", 25);
            Console.WriteLine("Hello World!");
            cliente.mostraInfo();
        }
    }
}
