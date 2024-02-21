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
            // Pega os valores do formulário e guarda em variáveis
            string nome = txtNomeProduto.Text;
            string descricao = txtDescricao.Text;
            string ingredientes = txtIngredientes.Text;
            double valor = (double)numValor.Value;

            // Verifica se o nome está em branco
            if (!ValidaTexto("Nome do produto", nome, false, 4))
                return;

            // Valida o campo de descrição
            if (!ValidaTexto("Descrição", descricao, false))
                return;

            // Valida o campo de descrição
            if (!ValidaTexto("Ingredientes", ingredientes, false))
                return;

            // Valida se o valor não é zero
            if (!ValidaNumeros("Valor", valor, false)) 
                return;

            // Cria um novo produto
            Produto novo_produto = new Produto(nome, descricao, ingredientes, valor);

            // Adiciona um produto na lista
            produtos.Add(novo_produto);

            // Armazena a lista no arquivo json
            ProcessaJson.ArmazenaLista("./meuarquivojson.json", produtos);

            MessageBox.Show("Produto cadastrado com sucesso!");

            limparCampos();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Adiciona a coluna no ListView
            // lsvProdutos.View = View.Details;
            // lsvProdutos.Columns.Add("Nome");
            // lsvProdutos.Columns.Add("Valor");

            lsvProdutos.Items.Clear();

            // Executa uma vez para cada produto na lista
            foreach (Produto produto in produtos)
            {
                // Cria um item de list view vazio
                ListViewItem item = new ListViewItem(produto.Nome);

                item.SubItems.Add(produto.Valor.ToString("c"));

                // Adiciona o item ao listView
                lsvProdutos.Items.Add(item);
            }

            lsvProdutos.Visible = true;
        }

        public static bool ValidaTexto(string nomeCampo, string texto, bool permiteVazio, int comprimentoMinimo = 0)
        {
            // Se não permite vazio e o texto estiver vazio, retorna falso
            if (!permiteVazio && texto == "")
            {
                MessageBox.Show($"O campo {nomeCampo} não pode ficar em branco!");
                return false;
            }

            if (comprimentoMinimo > 0 && texto.Length < comprimentoMinimo)
            {
                MessageBox.Show($"O campo {nomeCampo} não pode ter menos que {comprimentoMinimo} caracteres");
                return false;
            }

            return true;
        }

        public static bool ValidaNumeros(string nomeCampo, object numero, bool permiteZeros)
        {
            if (!permiteZeros && numero.ToString() == "0")
            {
                MessageBox.Show($"O campo {nomeCampo} não pode ficar zerado!");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirma se a pessoa quer realmente apagar o produto

            // Pega o index do item selecionado no ListView

            // Remove o item da Lista

            // Salva a lista no arquivo de text

            // Recarrega o ListView
        }
    }
}
