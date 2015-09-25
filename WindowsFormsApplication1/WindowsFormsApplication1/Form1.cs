using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private ListaNomes nomes = new ListaNomes(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            String nome = newName.Text;
            if (nome == "")
            {
                infoLabel.Text = "Nome não pode ser vazio";
            }
            else
            {
                nomes.adicionar(nome);
                infoLabel.Text = "Nome adicionado:" + nome;
                newName.Clear();
            }
        }

        private void list_Click(object sender, EventArgs e)
        {
            personsLabel.Text = nomes.listar();
        }

        private void clean_Click(object sender, EventArgs e)
        {
            nomes.limpar();
            personsLabel.Text = "empty!";
            infoLabel.Text = "Lista de nomes wiped";
        }
    }
}
