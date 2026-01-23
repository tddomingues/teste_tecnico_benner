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

            MessageBox.Show("Pessoa cadastrada com sucesso!");
        }
    }
}
