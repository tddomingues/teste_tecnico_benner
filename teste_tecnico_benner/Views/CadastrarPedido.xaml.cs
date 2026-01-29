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

        List<Produto> produtos;
        List<Pessoa> clientes;

        public CadastrarPedido()
        {
            InitializeComponent();
            CarregarCombos();
            AtualizarTabela();
        }

        private void CarregarCombos()
        {
            // Carregando os dados para as referencias
            produtos = banco.CarregarProdutos();
            clientes = banco.CarregarPessoas(); 

            boxProdutos.ItemsSource = produtos;
            boxPessoas.ItemsSource = clientes;
        }

        private void BtnSalvar(object sender, RoutedEventArgs e)
        {

            int qtd = 0;

            // é fundamental que a pessoa e o produto estejam selecionados
            if (boxPessoas.SelectedItem == null || boxProdutos.SelectedItem == null)
            {
                return;
            }


            // esse trecho é importante: ela verifica se é um numero válido e guarda na variável qtd (qtd será utilizada logo abaixo)
            // if (!int.TryParse(txtQtd.Text, out int qtd)) return;
            // outra forma de fazer a mesma verificação:
            if (!string.IsNullOrWhiteSpace(txtQtd.Text))
            {
                qtd = int.Parse(txtQtd.Text);
            }
            else
            {
                return;
            }

            // pega informações dos combos
            Pessoa clienteSelecionado = (Pessoa)boxPessoas.SelectedItem;
            Produto produtoSelecionado = (Produto)boxProdutos.SelectedItem;

            Pedido novoPedido = new Pedido();
            novoPedido.Id = new Random().Next(1, 9999);
            novoPedido.PessoaId = clienteSelecionado.Id; 
            novoPedido.DataVenda = DateTime.Now;
            //valor default
            novoPedido.Status = "Pendente";
            novoPedido.FormaPagamento = ((ComboBoxItem)cbPagamento.SelectedItem).Content.ToString();

            ItemPedido item = new ItemPedido
            {
                Produto = produtoSelecionado, 
                Quantidade = qtd
            };

            novoPedido.Itens.Add(item);

            // esse trecho calcula o valor total do pedido
            novoPedido.ValorTotal = (decimal)(item.Quantidade * item.Produto.Valor);

            var todos = banco.CarregarPedidos();
            todos.Add(novoPedido);
            banco.SalvarPedidos(todos);

            MessageBox.Show("Cadastrado com sucesso!");
            AtualizarTabela();
        }

        // é como se fosse um reset da tabela
        private void AtualizarTabela()
        {
            dgPedidos.ItemsSource = null;
            dgPedidos.ItemsSource = banco.CarregarPedidos();
        }
    }
}
