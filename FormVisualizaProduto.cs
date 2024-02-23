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
    public partial class FormVisualizaProduto : Form
    {
        Produto produto;

        public FormVisualizaProduto(Produto _produto)
        {
            InitializeComponent();

            this.produto = _produto;
        }

        private void FormVisualizaProduto_Load(object sender, EventArgs e)
        {
            txtNomeProduto.Text = produto.Nome;
            txtDescricao.Text = this.produto.Descricao;
            txtIngredientes.Text = produto.Ingredientes;
            numValor.Value = (decimal)produto.Valor;

            lblDataCriacao.Text += " " + produto.DataCriacao.ToString("dd/MM/yyyy HH:mm");
        }
    }
}
