using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibListaNomes.class1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaNomes interfaceNomes = new ListaNomes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            IListaNomes = 
        }
    }
}
