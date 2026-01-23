using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using teste_tecnico_benner.Models;

namespace teste_tecnico_benner.Data
{
    public class Armazenamento
    {
        private string caminhoPessoas = "pessoas.json";
        private string caminhoProdutos = "produtos.json";
        private string caminhoPedidos = "pedidos.json";

        // Pessoas
        public void SalvarPessoas(List<Pessoa> lista)
        {
            string json = JsonConvert.SerializeObject(lista, Formatting.Indented); //transforma a lista (objeto) e transforma em texto (json)
            File.WriteAllText(caminhoPessoas, json); //inseri o json no arquivo criado
        }

        public List<Pessoa> CarregarPessoas()
        {
            string json = File.ReadAllText(caminhoPessoas); //lê o arquivo do caminho exigido e joga na variável
            return JsonConvert.DeserializeObject<List<Pessoa>>(json); //transforma o json em objeto
        }

        // Produtos
        public void SalvarProdutos(List<Produto> lista)
        {
            string json = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(caminhoProdutos, json);
        }

        public List<Produto> CarregarProdutos()
        {
            string json = File.ReadAllText(caminhoProdutos);
            return JsonConvert.DeserializeObject<List<Produto>>(json);
        }

        // Pedidos
        public void SalvarPedidos(List<Pedido> lista)
        {
            string json = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(caminhoPedidos, json);
        }     

        public List<Pedido> CarregarPedidos()
        {
            string json = File.ReadAllText(caminhoPedidos);
            return JsonConvert.DeserializeObject<List<Pedido>>(json);
        }
    }
}
