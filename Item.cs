using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorvetesPinguin
{
    public class Item
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor {  get; set; }

        public Item()
        {

        }

        public virtual decimal ValorTotal
        {
            get
            {
                return this.Valor * this.Quantidade;
            }
        }

        public virtual Produto Produto
        {
            get
            {
                List<Produto> listaProdutos = ProcessaJson.CarregaListaProdutos();

                Produto produto = listaProdutos.Find(prod => prod.Id == this.ProdutoId);

                return produto;
            }
        }
    }
}
