using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        int? ProdutoSelecionado = null;

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

            // Se não for nulo é uma edição
            if (ProdutoSelecionado != null)
            {
                // Pega o produto selecionado da lista
                Produto produtoEdicao = produtos[(int)ProdutoSelecionado];

                // Altera de acordo com os valores dos campos
                produtoEdicao.Nome = nome;
                produtoEdicao.Descricao = descricao;
                produtoEdicao.Valor = valor;
                produtoEdicao.Ingredientes = ingredientes;

                // Salva o produto na mesma posição da lista
                //produtos[(int)ProdutoSelecionado] = produtoEdicao; // Desnecessário!
            }
            else
            {
                // Cria um novo produto
                Produto novo_produto = new Produto(nome, descricao, ingredientes, valor);

                // Adiciona um produto na lista
                produtos.Add(novo_produto);
            }

            // Armazena a lista no arquivo json
            ProcessaJson.ArmazenaLista("./meuarquivojson.json", produtos);

            string mensagem = "";

            if (ProdutoSelecionado != null)
            {
                mensagem = "Produto alterado com sucesso!";
                ProdutoSelecionado = null;
            }
            else
                mensagem = "Produto cadastrado com sucesso!";

            carregaListaProdutos();

            MessageBox.Show(mensagem);

            limparCampos();
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carregaListaProdutos();

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

        private void btnApagar_Click(object sender, EventArgs e)
        {
            // Confirma se a pessoa quer realmente apagar o produto
            DialogResult resposta = MessageBox.Show(
                "Deseja realmente apagar o produto?",
                "Apagar Produto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
            );

            if (resposta == DialogResult.No)
                return;

            // Pegar o index do item selecionado no ListView
            ListView.SelectedIndexCollection itensSelecionados = lsvProdutos.SelectedIndices;
            
            // Passa por cada item que foi selecionado
            foreach (int item in itensSelecionados)
            {
                // Remove o item da Lista   
                produtos.RemoveAt(item);
            }

            //if (itensSelecionados.Count > 0)
            //{
            //    int item = itensSelecionados[0];
            //    produtos.RemoveAt(item);
            //}

            // Recarrega a lista de produtos
            carregaListaProdutos();

            // Salva a lista no arquivo de texto
            ProcessaJson.ArmazenaLista("./meuarquivojson.json", produtos);
        }

        private void carregaListaProdutos(List<Produto> listaProdutos = null)
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

        private void lsvProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Caso tenha produtos selecionados
            if (lsvProdutos.SelectedIndices.Count > 0)
                // Habilita o botão de apagar
                btnApagar.Enabled = true;
            else
                // Desabilita o botão de apagar
                btnApagar.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int itemSelecionado = 0;

            // Pega o item selecionado
            if (lsvProdutos.SelectedItems.Count > 0)
                itemSelecionado = lsvProdutos.SelectedIndices[0];

            // Busca o produto selecionado na lista de produto
            Produto produtoSelecionado = produtos[itemSelecionado];

            // Coloca os dados no formulário do produto
            txtNomeProduto.Text = produtoSelecionado.Nome;
            txtDescricao.Text = produtoSelecionado.Descricao;
            txtIngredientes.Text = produtoSelecionado.Ingredientes;
            numValor.Value = (decimal)produtoSelecionado.Valor;

            ProdutoSelecionado = itemSelecionado;
        }

        private void lsvProdutos_DoubleClick(object sender, EventArgs e)
        {
            int? indexSelecionado = null;
            // Verificar se tem um item selecionado no listView
            if (lsvProdutos.SelectedItems.Count > 0)
                // Pegando o indice do item que foi selecionado
                indexSelecionado = lsvProdutos.SelectedIndices[0];

            // Pega o objeto de produto na List<T> de produtos
            Produto produto = produtos[(int)indexSelecionado];

            // Abre a tela de visualização
            FormVisualizaProduto formVisualiza = new FormVisualizaProduto(produto);
            formVisualiza.ShowDialog();
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            string busca = txtBusca.Text;

            // Caso apague todas as letras, carrega a lista
            if (busca.Length == 0)
            {
                carregaListaProdutos();
                return;
            }

            // Não realiza a busca caso tenha menos que 3 caracteres
            if (busca.Length < 3)
                return;

            List<Produto> resultadosBusca;

            // Metodo 1
            // Busca todos os produtos que contenham a palavra digitada pelo usuário no nome.
            resultadosBusca = produtos.FindAll(prod => prod.Nome.ToUpper().Contains(busca.ToUpper()));

            // Carrega os resultados de produtos no list view
            carregaListaProdutos(resultadosBusca);

            // Metodo 2
            //resultadosBusca = produtos.FindAll(
            //    delegate (Produto prod)
            //    {
            //        return prod.Nome.Contains(busca);
            //    }
            //);
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovaVendaForm formulario = new NovaVendaForm();
            formulario.ShowDialog();
        }
    }
}
