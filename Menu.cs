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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlAdicionarProduto.Visible = true;
        }

        private void btnCancelarCadastro_Click(object sender, EventArgs e)
        {
            limparCampos();
            pnlAdicionarProduto.Visible = false;
        }

        private void limparCampos()
        {
            // Limpa o campo de descricao
            txtDescricao.Clear();
            txtIngredientes.Clear();
            txtNomeProduto.Clear();
            numValor.Value = 0;
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            string nome = txtNomeProduto.Text;
            string descricao = txtDescricao.Text;
            string ingredientes = txtIngredientes.Text;
            double valor = (double)numValor.Value;

            Produto novo_produto = new Produto(nome, descricao, ingredientes, valor);
            MessageBox.Show("Produto cadastrado com sucesso!");

            limparCampos();
        }
    }
}
