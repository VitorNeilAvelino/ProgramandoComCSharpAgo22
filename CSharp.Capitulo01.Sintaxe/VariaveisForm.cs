using System;
using System.Windows.Forms;

namespace CSharp.Capitulo01.Sintaxe
{
    public partial class VariaveisForm : Form
    {
        int x = 32;
        int y = 16;
        int w = 45;
        int z = 32;

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

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pré-incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add($"2 + ++a = {2 + ++a}");
            resultadoListBox.Items.Add("a = " + a);

            a = 5;
            resultadoListBox.Items.Add("Exemplo de pós-incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add($"2 + a++ = {2 + a++}");
            resultadoListBox.Items.Add("a = " + a);
        }

        private void boolenasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var d = 32.0;

            //if (true)
            //{
            //    var j = 89;
            //}

            //j = -6;

            ExibirValores();

            resultadoListBox.Items.Add($"w <= x = {w <= x}");
            resultadoListBox.Items.Add($"x == z = {x == z}");
            resultadoListBox.Items.Add($"x != z = {x != z}");
            resultadoListBox.Items.Add($"x == d = {x == d}");
        }

        private void ExibirValores()
        {
            resultadoListBox.Items.Add("x = " + x);
            resultadoListBox.Items.Add("y = " + y);
            resultadoListBox.Items.Add("w = " + w);
            resultadoListBox.Items.Add("z = " + z);

            resultadoListBox.Items.Add("---------------------------------");
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValores();

            resultadoListBox.Items.Add($"w <= x || y == 16 = {w <= x || y == 16}");
            resultadoListBox.Items.Add($"x == z && x != z = {x == z && x != z}");
            resultadoListBox.Items.Add($"!(y > w) = {!(y > w)}");
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;

            ano = 2014;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(ano % 4 == 0 ? "Sim" : "Não" )}.");

            ano = 2016;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não" )}.");

            //var resposta = "";
            //if (DateTime.IsLeapYear(ano))
            //{
            //    resposta = "Sim";
            //}
            //else
            //{
            //    resposta = "Não";
            //}
        }
    }
}
