﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorvetesPinguin
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Data {  get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }

        public Pedido(string nome, string status, string cpf = "") {
            this.Nome = nome;
            this.Status = status;
            this.Cpf = cpf;
        }

        public virtual List<Item> Items
        {
            get
            {
                List<Item> listaItens = ProcessaJson.CarregaListaItensPedido();

                return listaItens.FindAll(item => item.PedidoId == Id);
            }
        }
    }
}
