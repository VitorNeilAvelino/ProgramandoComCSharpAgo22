using Fintech.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cliente> clientes = new List<Cliente>();
        private Cliente clienteSelecionado;

        public MainWindow()
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outros);

            clienteDataGrid.ItemsSource = clientes;

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);

            var banco1 = new Banco();
            banco1.Nome = "Banco Um";
            banco1.Numero = 208;

            bancoComboBox.Items.Add(banco1);
            bancoComboBox.Items.Add(new Banco { Nome = "Banco Dois", Numero = 210 });
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            var cliente = new Cliente();
            cliente.Cpf = cpfTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);
            cliente.Nome = nomeTextBox.Text;
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            var endereco = new Endereco();
            endereco.Cep = cepTextBox.Text;
            endereco.Cidade = cidadeTextBox.Text;
            endereco.Logradouro = logradouroTextBox.Text;
            endereco.Numero = numeroLogradouroTextBox.Text;

            cliente.EnderecoResidencial = endereco;

            clientes.Add(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso!");
            LimparControlesCliente();
            clienteDataGrid.Items.Refresh();
            pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesCliente()
        {
            cpfTextBox.Clear();
            nomeTextBox.Text = "";
            dataNascimentoTextBox.Text = string.Empty;
            sexoComboBox.SelectedIndex = -1;
            logradouroTextBox.Text = null;
            numeroLogradouroTextBox.Clear();
            cidadeTextBox.Clear();
            cepTextBox.Clear();
        }

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            var botaoClicado = (Button)sender;
            clienteSelecionado = (Cliente)botaoClicado.DataContext;
            //this.clienteSelecionado = (Cliente)clienteSelecionado;

            clienteTextBox.Text = $"{clienteSelecionado.Nome} - {clienteSelecionado.Cpf}";

            contasTabItem.Focus();
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedIndex == -1) return;

            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoConta.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = null;

            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            switch ((TipoConta)tipoContaComboBox.SelectedItem)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }

            clienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso!");
            LimparControlesConta();
            clienteDataGrid.Items.Refresh();
            clienteTabItem.Focus();
        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }
    }
}
