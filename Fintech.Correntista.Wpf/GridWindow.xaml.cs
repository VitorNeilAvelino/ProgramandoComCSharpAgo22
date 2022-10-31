using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Lógica interna para GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {
        public GridWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var botaoClicado = sender as Button;

            //var linha = (int)botaoClicado.GetValue(Grid.RowProperty);
            //var coluna = (int)botaoClicado.GetValue(Grid.ColumnProperty);

            //MessageBox.Show(string.Format("Button clicked at column {0}, row {1}", coluna, linha));

            var todosBotoes = testeGrid.Children
                                          .Cast<Button>()
                                          .ToList();

            var botoesSelecionados = testeGrid.Children
                                              .Cast<Button>()
                                              .Where(e => Convert.ToInt32(e.Tag) <= Convert.ToInt32(botaoClicado.Tag)).ToList();

            todosBotoes.ForEach(b => b.Background = Brushes.Transparent);
            botoesSelecionados.ForEach(b => b.Background = Brushes.Red);
        }
    }
}