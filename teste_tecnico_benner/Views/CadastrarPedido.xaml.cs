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
using teste_tecnico_benner.Data;
using teste_tecnico_benner.Models;

namespace teste_tecnico_benner.Views
{
    /// <summary>
    /// Lógica interna para CadastrarPedido.xaml
    /// </summary>
    public partial class CadastrarPedido : Window
    {
        Armazenamento banco = new Armazenamento();

        public CadastrarPedido()
        {
            InitializeComponent();
            AtualizarTabela(); 
        }

        private void AtualizarTabela()
        {
            var lista = banco.CarregarPedidos();
            dgPedidos.ItemsSource = null; //dgPedidos é o nome da tabela da tela
            dgPedidos.ItemsSource = lista; 
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Pedido p = new Pedido();

            p.PessoaId = int.Parse(txtIdCliente.Text);
            p.DataVenda = DateTime.Now; 
            p.Status = "Pendente"; 
            p.FormaPagamento = txtPagamento.Text;

            p.Itens = new List<ItemPedido>();
            ItemPedido item = new ItemPedido();
            item.Quantidade = int.Parse(txtQtd.Text);
            p.Itens.Add(item);

            var todos = banco.CarregarPedidos();

            Random rd = new Random();
            p.Id = rd.Next(1, 9999);

            todos.Add(p);
            banco.SalvarPedidos(todos); 

            MessageBox.Show("Pedido feito!");

            AtualizarTabela(); 

            txtIdCliente.Clear();
            txtIdProduto.Clear();
            txtPagamento.Clear();
        }
    }
}
