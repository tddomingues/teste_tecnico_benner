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
using System.Windows.Shapes;

namespace teste_tecnico_benner.Views
{
    /// <summary>
    /// Lógica interna para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
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
