namespace SorvetesPinguin
{
    partial class NovaVendaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvProdutos = new System.Windows.Forms.ListView();
            this.txtPesquisaProdutos = new System.Windows.Forms.TextBox();
            this.lsvItensPedido = new System.Windows.Forms.ListView();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtCpfCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdicionarItem = new System.Windows.Forms.Button();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFecharPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblValorTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvProdutos
            // 
            this.lsvProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lsvProdutos.HideSelection = false;
            this.lsvProdutos.Location = new System.Drawing.Point(12, 77);
            this.lsvProdutos.MultiSelect = false;
            this.lsvProdutos.Name = "lsvProdutos";
            this.lsvProdutos.Size = new System.Drawing.Size(326, 498);
            this.lsvProdutos.TabIndex = 0;
            this.lsvProdutos.UseCompatibleStateImageBehavior = false;
            this.lsvProdutos.View = System.Windows.Forms.View.SmallIcon;
            // 
            // txtPesquisaProdutos
            // 
            this.txtPesquisaProdutos.Location = new System.Drawing.Point(12, 45);
            this.txtPesquisaProdutos.Name = "txtPesquisaProdutos";
            this.txtPesquisaProdutos.Size = new System.Drawing.Size(326, 26);
            this.txtPesquisaProdutos.TabIndex = 1;
            // 
            // lsvItensPedido
            // 
            this.lsvItensPedido.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvItensPedido.HideSelection = false;
            this.lsvItensPedido.Location = new System.Drawing.Point(491, 140);
            this.lsvItensPedido.Name = "lsvItensPedido";
            this.lsvItensPedido.Size = new System.Drawing.Size(508, 337);
            this.lsvItensPedido.TabIndex = 0;
            this.lsvItensPedido.UseCompatibleStateImageBehavior = false;
            this.lsvItensPedido.View = System.Windows.Forms.View.Details;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(491, 45);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(326, 26);
            this.txtNomeCliente.TabIndex = 2;
            // 
            // txtCpfCliente
            // 
            this.txtCpfCliente.Location = new System.Drawing.Point(491, 97);
            this.txtCpfCliente.Name = "txtCpfCliente";
            this.txtCpfCliente.Size = new System.Drawing.Size(326, 26);
            this.txtCpfCliente.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "CPF";
            // 
            // btnAdicionarItem
            // 
            this.btnAdicionarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarItem.Location = new System.Drawing.Point(373, 330);
            this.btnAdicionarItem.Name = "btnAdicionarItem";
            this.btnAdicionarItem.Size = new System.Drawing.Size(60, 61);
            this.btnAdicionarItem.TabIndex = 4;
            this.btnAdicionarItem.Text = "→";
            this.btnAdicionarItem.UseVisualStyleBackColor = true;
            this.btnAdicionarItem.Click += new System.EventHandler(this.btnAdicionarItem_Click);
            // 
            // numQuantidade
            // 
            this.numQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantidade.Location = new System.Drawing.Point(364, 271);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(78, 53);
            this.numQuantidade.TabIndex = 5;
            this.numQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(842, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pesquisar Produtos";
            // 
            // btnFecharPedido
            // 
            this.btnFecharPedido.Location = new System.Drawing.Point(870, 534);
            this.btnFecharPedido.Name = "btnFecharPedido";
            this.btnFecharPedido.Size = new System.Drawing.Size(129, 41);
            this.btnFecharPedido.TabIndex = 8;
            this.btnFecharPedido.Text = "Fechar Pedido";
            this.btnFecharPedido.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(762, 534);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 41);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 51;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Produto";
            this.columnHeader2.Width = 149;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantidade";
            this.columnHeader4.Width = 98;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Total";
            this.columnHeader5.Width = 106;
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Location = new System.Drawing.Point(934, 480);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(65, 20);
            this.lblValorTotal.TabIndex = 9;
            this.lblValorTotal.Text = "R$ 0,00";
            this.lblValorTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NovaVendaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SorvetesPinguin.Properties.Resources.icebg;
            this.ClientSize = new System.Drawing.Size(1011, 587);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFecharPedido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.btnAdicionarItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCpfCliente);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.txtPesquisaProdutos);
            this.Controls.Add(this.lsvItensPedido);
            this.Controls.Add(this.lsvProdutos);
            this.Name = "NovaVendaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nova Venda";
            this.Load += new System.EventHandler(this.NovaVendaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvProdutos;
        private System.Windows.Forms.TextBox txtPesquisaProdutos;
        private System.Windows.Forms.ListView lsvItensPedido;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.TextBox txtCpfCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnAdicionarItem;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFecharPedido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblValorTotal;
    }
}