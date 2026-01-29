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
using teste_tecnico_benner.Views;

namespace teste_tecnico_benner
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTelaProduto(object sender, RoutedEventArgs e)
        {
            var tela = new CadastrarProduto();
            tela.Show();
        }

        private void BtnTelaPessoa(object sender, RoutedEventArgs e)
        {
            var tela = new CadastrarPessoa();
            tela.Show();
        }

        private void BtnTelaPedido(object sender, RoutedEventArgs e)
        {
            var tela = new CadastrarPedido();
            tela.Show();
        }
    }
}
