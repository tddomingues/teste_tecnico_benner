using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste_tecnico_benner.Models
{
    public class ItemPedido
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
        public string FormaPagamento { get; set; }
        public string Status { get; set; } 
    }
}
