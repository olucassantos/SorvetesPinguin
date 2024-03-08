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
    }
}
