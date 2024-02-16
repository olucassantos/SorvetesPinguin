using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorvetesPinguin
{
    internal class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Ingredientes { get; set; }
        public double Valor { get; set; }

        private DateTime DataCriacao { get; }

        public Produto(string nome, string descricao, string ingredientes, double valor) 
        { 
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ingredientes = ingredientes;
            this.Valor = valor;

            this.DataCriacao = DateTime.Now;
        }
    }
}
