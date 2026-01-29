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
    /// Lógica interna para CadastrarProduto.xaml
    /// </summary>
    public partial class CadastrarProduto : Window
    {

        List<Produto> listaProdutos = new List<Produto>();
        Armazenamento banco = new Armazenamento();
        public CadastrarProduto()
        {
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            listaProdutos = banco.CarregarProdutos();
            dgProdutos.ItemsSource = listaProdutos;
        }

        private void BtnSalvarProduto(object sender, RoutedEventArgs e)
        {
            Produto novo = new Produto();

            // gerar id
            Random rd = new Random();
            novo.Id = rd.Next(1, 9999);

            novo.Nome = txtNomeProduto.Text;
            novo.Codigo = txtCodigo.Text;

            // txtValor.Text pode gerar crach na aplicação, por isso a validação
            if (!string.IsNullOrWhiteSpace(txtValor.Text))
            {
                novo.Valor = int.Parse(txtValor.Text);
            } else
            {
                return;
            }

            // Adiciona na lista e manda o banco salvar o arquivo JSON
            listaProdutos.Add(novo);
            banco.SalvarProdutos(listaProdutos);

            txtNomeProduto.Clear();
            txtCodigo.Clear();
            txtValor.Clear();

            CarregarDados();

            MessageBox.Show("Cadastrado com sucesso!");
        }

        private void BtnExcluir(object sender, RoutedEventArgs e)
        {
            // seleciona o produto que o usuário está clicado
            Produto produtoSelecionado = (Produto)dgProdutos.SelectedItem;

            if (produtoSelecionado != null)
            {
                listaProdutos.Remove(produtoSelecionado);
                banco.SalvarProdutos(listaProdutos);
                CarregarDados();

                MessageBox.Show("Apagado com sucesso!");
            }
            else
            {
                MessageBox.Show("Clique em um registro!");
            }
        }

        private void BtnEditar(object sender, RoutedEventArgs e)
        {
            Produto produtoSelecionado = (Produto)dgProdutos.SelectedItem;
          
            produtoSelecionado.Nome = txtNomeProduto.Text;
            produtoSelecionado.Codigo = txtCodigo.Text;
              
            produtoSelecionado.Valor = int.Parse(txtValor.Text); 

            banco.SalvarProdutos(listaProdutos);
           
            txtNomeProduto.Clear();
            txtCodigo.Clear();
            txtValor.Clear();
            CarregarDados();

            MessageBox.Show("Edição concluida!");
        }
    }
}
