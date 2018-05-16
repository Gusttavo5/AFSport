﻿using AFSport.DAO.Model;
using AFSport.Service.Repository;
using AFSport.WindowsForms.Formularios.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFSport.WindowsForms.Formularios.Produtos
{
    public partial class FrmProdutos : FrmCadastroBase
    {
        Produto produto;
        public FrmProdutos()
        {
            InitializeComponent();
        }

        protected override void FrmCadastroBase_Load(object sender, EventArgs e)
        {
            CarregarGrid();
            base.FrmCadastroBase_Load(sender, e);
        }

        protected override void BtnNovo_Click(object sender, EventArgs e)
        {
            using (FrmFormProdutos frm = new FrmFormProdutos(new Produto()))
            {
                using (FrmModal frmModal = new FrmModal(frm))
                    frmModal.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    CarregarGrid();
            }
            base.BtnNovo_Click(sender, e);
        }

        protected override void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (produto != null)
                using (FrmFormProdutos frm = new FrmFormProdutos(produto))
                {
                    using (FrmModal frmModal = new FrmModal(frm))
                        frmModal.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                        CarregarGrid();
                }
            else
                MessageBox.Show("Seleciona um produto para altera-lo.", "Informações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            base.BtnAlterar_Click(sender, e);
        }

        protected override void BtnDeletar_Click(object sender, EventArgs e)
        {
            if (produto != null && MessageBox.Show($"Confirma a remoção do produto {produto.Nome}?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                
            }
            base.BtnDeletar_Click(sender, e);
        }

        protected override async void CarregarGrid()
        {
            GridPesq.DataSource = await ListarTodosProdutos();
        }

        private async Task<List<Produto>> ListarTodosProdutos()
        {
            using (ProdutoRepository repository = new ProdutoRepository())
            {
                return await repository.SelecionarTodos(true);
            }
        }

        private void GridPesq_SelectionChanged(object sender, EventArgs e)
        {
            if (GridPesq.SelectedRows.Count > 0)
                produto = (Produto)GridPesq.SelectedRows[0].DataBoundItem;
        }
    }
}
