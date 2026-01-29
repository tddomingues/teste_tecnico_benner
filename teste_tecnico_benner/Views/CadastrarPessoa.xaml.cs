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
    /// Lógica interna para CadastrarPessoa.xaml
    /// </summary>
    public partial class CadastrarPessoa : Window
    {

        List<Pessoa> listaPessoas = new List<Pessoa>();
        Armazenamento banco = new Armazenamento();
        public CadastrarPessoa()
        {
            //var armazenamento = new Armazenamento();
            //armazenamento.ZerarDados();
            InitializeComponent();
            CarregarDados();
        }

        private void CarregarDados()
        {
            listaPessoas = banco.CarregarPessoas();
            dgPessoas.ItemsSource = listaPessoas;
        }

        private void BtnSalvar(object sender, RoutedEventArgs e)
        {
            Pessoa novaPessoa = new Pessoa();

            // Gerar ID
            Random rd = new Random();
            novaPessoa.Id = rd.Next(1, 9999);

            novaPessoa.Nome = txtNome.Text;
            novaPessoa.CPF = txtCPF.Text;
            novaPessoa.Endereco = txtEndereco.Text;

            listaPessoas.Add(novaPessoa);

            // Salvando no banco
            banco.SalvarPessoas(listaPessoas);

            // limpando os campos
            txtNome.Clear();
            txtCPF.Clear();
            txtEndereco.Clear();
            CarregarDados();

            MessageBox.Show("Cadastrado com sucesso!");
        }

        private void BtnExcluir(object sender, RoutedEventArgs e)
        {
            // seleciona o produto que o usuário está clicado
            Pessoa pessoaSelecionada = (Pessoa)dgPessoas.SelectedItem;

            if (pessoaSelecionada != null)
            {
                listaPessoas.Remove(pessoaSelecionada);
                banco.SalvarPessoas(listaPessoas);
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
            Pessoa pessoaSelecionada = (Pessoa)dgPessoas.SelectedItem;

            pessoaSelecionada.Nome = txtNome.Text;
            pessoaSelecionada.CPF = txtCPF.Text;
            pessoaSelecionada.Endereco = txtEndereco.Text;

            banco.SalvarPessoas(listaPessoas);

            txtNome.Clear();
            txtCPF.Clear();
            txtEndereco.Clear();
            CarregarDados();

            MessageBox.Show("Edição concluida!");
        }
    }
}
