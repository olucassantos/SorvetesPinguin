using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorvetesPinguin
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public double Valor {  get; set; }

        public DateTime DataCriacao { get; }

        public Produto(string nome, string descricao, string ingredientes, double valor, DateTime? dataCriacao = null, int? id = null) 
        { 
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ingredientes = ingredientes;
            this.Valor = valor;

            // Armazena a data de criação dentro do objeto
            if (dataCriacao != null )
                this.DataCriacao = (DateTime)dataCriacao;
            else
                this.DataCriacao = DateTime.Now;

            // Decide qual vai ser o ID do produto
            if (id == null)
                this.Id = novoId();
            else
                this.Id = (int)id;
        }

        private int novoId()
        {
            // Pega a lista de produtos
            List<Produto> listaProdutos = ProcessaJson.CarregaLista();

            // Pega o maior ID da lista de produtos
            int maiorIdProduto = 0;

            // Percorre a lista de produtos verificando qual o maior ID
            foreach (Produto produto in listaProdutos)
            {
                // Armazena o maior ID encontrado
                if (produto.Id > maiorIdProduto)
                    maiorIdProduto = produto.Id;
            }

            // Retorna o maior ID + 1, sendo o proximo ID a ser usado
            return maiorIdProduto + 1;
        }
    }
}
