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
    public partial class VisualizaPedidoForm : Form
    {
        Pedido pedido;

        public VisualizaPedidoForm(Pedido pedido)
        {
            InitializeComponent();
            RedimensionaColunasItens();

            this.pedido = pedido;
        }

        public void RedimensionaColunasItens()
        {
            float[] tamanhos = { 0.1f, 0.4f, 0.1f, 0.2f, 0.2f };

            // Largura do List View
            float tamanhoListView = lsvItensPedido.ClientRectangle.Width;

            // Laço de repetição que passa em todas as colunas
            for (int index = 0; index < lsvItensPedido.Columns.Count; index++)
            {
                lsvItensPedido.Columns[index].Width = (int)(tamanhos[index] * tamanhoListView);
            }
        }

        private void VisualizaPedidoForm_Load(object sender, EventArgs e)
        {
            AtualizaInformacoesPedido();
        }

        private void AtualizaInformacoesPedido()
        {
            lblCpfCliente.Text = pedido.Cpf;
            lblNomeCliente.Text = pedido.Nome;
            lblValorTotal.Text = pedido.ValorTotal.ToString("c");
            lblStatus.Text = pedido.Status;
            lblNumeroPedido.Text = pedido.Id.ToString();

            // Itera sobre os itens para adicionar ao listView
            for (int index = 0; index < pedido.Items.Count; index++)
            {
                Item item = (Item)pedido.Items[index];
                // Cria o item
                ListViewItem listViewItem = new ListViewItem((index + 1).ToString());

                // Adiciona as colunas
                listViewItem.SubItems.Add(item.Produto.Nome);
                listViewItem.SubItems.Add(item.Quantidade.ToString());
                listViewItem.SubItems.Add(item.Valor.ToString("c"));
                listViewItem.SubItems.Add(item.ValorTotal.ToString("c"));

                // Adiciona o item ao listview
                lsvItensPedido.Items.Add(listViewItem);
            }
        }
    }
}
