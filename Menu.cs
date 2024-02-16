using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SorvetesPinguin
{
    public partial class Menu : Form
    {
        // Define a criação de uma lista de produtos vazia
        List<Produto> produtos;

        public Menu()
        {
            InitializeComponent();

            // Carrega os dados do Json para a lista de produtos
            produtos = ProcessaJson.CarregaLista();
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

            // Cria um novo produto
            Produto novo_produto = new Produto(nome, descricao, ingredientes, valor);

            // Adiciona um produto na lista
            produtos.Add(novo_produto);

            // Armazena a lista no arquivo json
            ProcessaJson.ArmazenaLista("./meuarquivojson.json", produtos);

            MessageBox.Show("Produto cadastrado com sucesso!");

            limparCampos();
        }
    }
}
