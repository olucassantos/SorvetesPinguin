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

            this.pedido = pedido;
        }
    }
}
