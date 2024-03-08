using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorvetesPinguin
{
    public partial class NovaVendaForm : Form
    {
        List<Produto> produtos;

        // Cria um pedido novo
        Pedido pedido;

        // Cria uma lista vazia para os itens do pedido
        List<Item> itensPedido;

        decimal valorTotal = 0;

        public NovaVendaForm()
        {
            InitializeComponent();
        }

        private void atualizaListViewProdutos(List<Produto> listaProdutos = null)
        {
            lsvProdutos.Items.Clear();

            if (listaProdutos == null)
                listaProdutos = produtos;

            // Executa uma vez para cada produto na lista
            foreach (Produto produto in listaProdutos)
            {
                // Cria um item de list view vazio
                ListViewItem item = new ListViewItem(produto.Nome);

                item.SubItems.Add(produto.Valor.ToString("c"));

                // Adiciona o item ao listView
                lsvProdutos.Items.Add(item);
            }
        }

        private void atualizaListaViewItensPedido()
        {
            // Limpo a lista de itens
            lsvItensPedido.Items.Clear();

            // Itera sobre os itens para adicionar ao listView
            foreach(Item item in itensPedido)
            {
                // Cria o item
                ListViewItem listViewItem = new ListViewItem(item.ProdutoId.ToString());

                // Adiciona as colunas
                listViewItem.SubItems.Add(item.Produto.Nome);
                listViewItem.SubItems.Add(item.Valor.ToString("c"));
                listViewItem.SubItems.Add(item.Quantidade.ToString());
                listViewItem.SubItems.Add(item.ValorTotal.ToString("c"));

                // Adiciona o item ao listview
                lsvItensPedido.Items.Add(listViewItem);
            }
        }

        private void NovaVendaForm_Load(object sender, EventArgs e)
        {
            // Carrega a lista de produtos do arquivo json
            produtos = ProcessaJson.CarregaListaProdutos();

            // Atualiza o ListView
            atualizaListViewProdutos();

            // Inicializa a lista de itens vazia
            itensPedido = new List<Item>();

            // Cria um novo pedido
            pedido = new Pedido("", "Aberto", "");
        }

        private void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            // Verificar se existe algum produto selecionado
            if (lsvProdutos.SelectedItems.Count == 0)
                return;

            // Pega o indice do produto selecionado
            int produtoIndex = lsvProdutos.SelectedIndices[0];

            // Procura o produto na lista de produtos
            Produto produtoSelecionado = produtos[produtoIndex];

            // Cria o item do pedido
            Item item = new Item();
            item.ProdutoId = produtoSelecionado.Id;
            item.Valor = (decimal)produtoSelecionado.Valor;
            item.Quantidade = (int)numQuantidade.Value;
            item.PedidoId = 0;

            // Adiciona o item na lista de itens
            itensPedido.Add(item);

            // Atualiza lista de itens na tela.
            atualizaListaViewItensPedido();

            // Calcula e mostra o valor total na tela.
            calculaValorTotalPedido();

            // Reseta a quantidade para 1
            numQuantidade.Value = 1;

            //desseleciona o item no listview
            lsvProdutos.SelectedIndices.Clear();
        }

        private void calculaValorTotalPedido()
        {
            // Soma todos os valores totais
            valorTotal = itensPedido.Sum(item => item.ValorTotal);

            // Mostra o valor na tela
            lblValorTotal.Text = valorTotal.ToString("c");
        }

        private void btnFecharPedido_Click(object sender, EventArgs e)
        {
            // Validar as informações do pedido
            if( ! SorvetesPinguin.Menu.ValidaTexto("Nome do Cliente", txtNomeCliente.Text, false, 5))
                return;

            if (!SorvetesPinguin.Menu.ValidaTexto("Cpf do Cliente", txtCpfCliente.Text, false, 11))
                return;

            // Preencher o pedido com as informações e status
            pedido.Nome = txtNomeCliente.Text;
            pedido.Cpf = txtCpfCliente.Text;
            pedido.Data = DateTime.Now;
            pedido.ValorTotal = valorTotal;
            pedido.Status = "Fechado";

            // Armazenar pedido no arquivo JSON
            pedido = ProcessaJson.ArmazenaPedido(pedido, itensPedido);

            // Mostrar tela de visualização do pedido
            if (pedido.Id > 0)
            {
                MessageBox.Show("Pedido criado com sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha ao criar o pedido");
            }
        }
    }
}
