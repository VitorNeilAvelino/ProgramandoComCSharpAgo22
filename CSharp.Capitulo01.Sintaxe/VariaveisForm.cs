using System;
using System.Windows.Forms;

namespace CSharp.Capitulo01.Sintaxe
{
    public partial class VariaveisForm : Form
    {
        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Comentário
            int x = 42; 
            int X = 10;

            string nome = "Vítor";
            char letra = 'a';
            
            bool aprovado = true;
            aprovado = false;

            var dataNascimento = new DateTime(2000, 1, 1);

            var a = 2;
            var b = 6;
            var c = 10;
            var d = 13;

            //int e = 15;

            int f;

            object meuObjeto = 35;
            meuObjeto = "Vítor";
            meuObjeto = false;

            var valor = 7.8m;

            var bimestre1 = 5.9m;
            int numero = 11, outroNumero = 12, esseNumero = 14;

            //var nomeCanção = "Release";

            var @class = "4D";

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b/*, c, "asdfasd"*/));
            //resultadoListBox.Items.Add(string.Format("c = {0} - d = {1}", c, d));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");
            
            resultadoListBox.Items.Add($"c * d = {c * d}");
            resultadoListBox.Items.Add($"d / a = {d / a}");
            resultadoListBox.Items.Add($"d % a = {d % a}");
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;
            resultadoListBox.Items.Add("x = " + x);

            //x = x - 3;
            x -= 3;
            resultadoListBox.Items.Add("x = " + x);
        }
    }
}
