using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorvetesPinguin
{
    internal class ProcessaJson
    {
        public static void ArmazenaLista(string arquivo, object lista)
        {
            //Transforma a lista de produtos em um JSON
            string lista_json = JsonConvert.SerializeObject(lista, Formatting.Indented);

            // Escreve o JSON dentro do Arquivo de texto
            File.WriteAllText(arquivo, lista_json, Encoding.UTF8);
        }

        public static List<Produto> CarregaListaProdutos()
        {
            // Faz a leitura do arquivo json
            if (File.Exists("./produtos_data.json"))
            {
                string arquivo_json = File.ReadAllText("./produtos_data.json");
                return JsonConvert.DeserializeObject<List<Produto>>(arquivo_json);
            }
            else
            {
                return new List<Produto>();
            }
        }

        public static List<Pedido> CarregaListaPedidos()
        {
            // Faz a leitura do arquivo json
            if (File.Exists("./pedidos_data.json"))
            {
                string arquivo_json = File.ReadAllText("./pedidos_data.json");
                return JsonConvert.DeserializeObject<List<Pedido>>(arquivo_json);
            }
            else
            {
                return new List<Pedido>();
            }
        }

        public static List<Item> CarregaListaItensPedido()
        {
            // Faz a leitura do arquivo json
            if (File.Exists("./itensPedidos_data.json"))
            {
                string arquivo_json = File.ReadAllText("./itensPedidos_data.json");
                return JsonConvert.DeserializeObject<List<Item>>(arquivo_json);
            }
            else
            {
                return new List<Item>();
            }
        }

        public static Pedido ArmazenaPedido(Pedido pedido, List<Item> listaItensPedido)
        {
            // Carrega todos os pedidos armazenados
            List<Pedido> listaPedidos = CarregaListaPedidos();

            // Pega o novo Id de pedidos
            int id = 0;

            if (listaPedidos.Count == 0)
                id = 1;
            else
                // Procura dentro da lista o MAIOR valor do campo ID
                id = listaPedidos.Max(item => item.Id) + 1;

            // Adiciona o ID ao pedido a ser salvo
            pedido.Id = id;

            // Adiciona o novo pedido a lista de pedidos
            listaPedidos.Add(pedido);

            // Salva a lista de pedidos no arquivo JSON
            ArmazenaLista("pedidos_data.json", listaPedidos);


            // Carrega a lista de itens
            List<Item> listaGeralItens = CarregaListaItensPedido();

            // Criar o ID de cada item
            int idItem = 0;

            if (listaGeralItens.Count == 0)
                idItem = 1;
            else
                idItem = listaGeralItens.Max(item => item.Id) + 1;

            // Adicionar o Id do pedido aos itens
            // Cria o ID do item
            foreach (Item item in listaItensPedido)
            {
                item.PedidoId = pedido.Id;
                item.Id = idItem;
                idItem++;
            }

            // Adicionar os itens na lista de todos os itens
            listaGeralItens.AddRange(listaItensPedido);

            // Salvar os itens no arquivo JSON
            ArmazenaLista("itensPedidos_data.json", listaGeralItens);

            // Retorna o pedido salvo
            return pedido;
        }
    }
}

