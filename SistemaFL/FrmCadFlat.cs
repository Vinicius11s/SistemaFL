﻿using Entidades;
using Infraestrutura.Contexto;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFL
{
    public partial class FrmCadFlat : Form
    {
        private IFlatRepositorio repositorio;
        private IEmpresaRepositorio empresaRepositorio;
        public FrmCadFlat(IFlatRepositorio repositorio, IEmpresaRepositorio empresaRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.empresaRepositorio = empresaRepositorio;
        }

        private void FrmCadFlat_Load(object sender, EventArgs e)
        {
            limpar();
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
        }
        private void btnnovo_Click_1(object sender, EventArgs e)
        {
            pdados.Enabled = true;
            btnnovo.Enabled = false;
            btnlocalizar.Enabled = false;
            btnalterar.Enabled = false;
            btncancelar.Enabled = true;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = true;
            limpar();
            txtdescricao.Focus();
        }
        private void btnalterar_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                pdados.Enabled = true;
                btnnovo.Enabled = false;
                btnlocalizar.Enabled = false;
                btnalterar.Enabled = false;
                btncancelar.Enabled = true;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = true;
                txtdescricao.Focus();
            }
            else MessageBox.Show("Localize o Flat");
        }
        private void btnsalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtdescricao.Text != String.Empty)
                {
                    Flat flat = carregaPropriedades();

                    if (flat.id == 0)
                    {
                        repositorio.Inserir(flat);
                    }
                    else
                    {
                        repositorio.Alterar(flat);
                    }
                    Program.serviceProvider.
                        GetRequiredService<ContextoSistema>().SaveChanges();
                    MessageBox.Show("Salvo com sucesso");

                    limpar();
                    pdados.Enabled = false;
                    btnnovo.Enabled = true;
                    btnlocalizar.Enabled = true;
                    btnalterar.Enabled = false;
                    btncancelar.Enabled = false;
                    btnexcluir.Enabled = false;
                    btnsalvar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar" + ex.Message);

                throw;
            }
        }
        private void btncancelar_Click_1(object sender, EventArgs e)
        {
            limpar();
            pdados.Enabled = false;
            btnnovo.Enabled = true;
            btnlocalizar.Enabled = true;
            btnalterar.Enabled = false;
            btncancelar.Enabled = false;
            btnexcluir.Enabled = false;
            btnsalvar.Enabled = false;
        }
        private void btnexcluir_Click_1(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                var flat = carregaPropriedades();
                repositorio.Excluir(flat);
                Program.serviceProvider.
                    GetRequiredService<ContextoSistema>().SaveChanges();

                MessageBox.Show("Registro excluído com sucesso!");
                limpar();
                pdados.Enabled = false;
                btnnovo.Enabled = true;
                btnlocalizar.Enabled = true;
                btnalterar.Enabled = false;
                btncancelar.Enabled = false;
                btnexcluir.Enabled = false;
                btnsalvar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Localize a Empresa.");
            }
        }
        private void btnlocalizar_Click_1(object sender, EventArgs e)
        {
            var form2 = Program.serviceProvider.GetRequiredService<FrmConsultaFlat>();
            form2.ShowDialog();

            if (form2.id > 0)
            {
                //no clique do botão localizar vamos fazer um select * from empresa where id
                var flat = repositorio.Recuperar(e => e.id == form2.id);
                if (flat != null)
                {
                    txtid.Text = flat.id.ToString();
                    txtdescricao.Text = flat.Descricao;
                    cbbStatus.Text = flat.Status.ToString();
                    txtValorInvestimento.Text = flat.ValorInvestimento.ToString();
                    cbbTipoInvestimento.Text = flat.TipoInvestimento;
                    dtdataaquisicao.Value = flat.DataAquisicao;
                    txtrua.Text = flat.Rua;
                    txtunidade.Text = flat.Unidade.ToString();
                    txtbairro.Text = flat.Bairro;
                    txtcidade.Text = flat.Cidade;
                    txtestado.Text = flat.Estado;
                    if (flat.idEmpresa != null)
                    {
                        var empresa = empresaRepositorio.Recuperar(e => e.id == flat.idEmpresa);
                        if (empresa != null)
                        {
                            txtempresaAss.Text = empresa.Descricao; // Define a descrição da empresa no TextBox
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        txtempresaAss.Text = "Sem empresa associada"; // Caso o flat não tenha empresa associada
                    }
                    pdados.Enabled = false;
                    btnnovo.Enabled = false;
                    btnlocalizar.Enabled = false;
                    btnalterar.Enabled = true;
                    btncancelar.Enabled = true;
                    btnexcluir.Enabled = true;
                    btnsalvar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Empresa não encontrada.");
                }
            }
        }
        public Flat carregaPropriedades()
        {
            Flat flat;
            if (txtid.Text != "")
            {
                //alterar , estou recuperando o registro antigo
                //para manter a referencia do objeto do entity
                flat = repositorio.Recuperar(c => c.id ==
                                int.Parse(txtid.Text));

            }
            else flat = new Flat();//inserir

            flat.id = txtid.Text == "" ? 0 : int.Parse(txtid.Text);
            flat.Descricao = txtdescricao.Text;
            flat.DataAquisicao = dtdataaquisicao.Value;
            //flat.Status
            if (cbbStatus != null && cbbStatus.SelectedItem != null)
            {
                if (cbbStatus.Text == "Ativo")
                {
                    flat.Status = cbbStatus.Text;
                    flat.Ativo = true;
                }
                else
                {
                    if (cbbStatus.Text == "Em Construção")
                    {
                        flat.Status = cbbStatus.Text;
                        flat.Ativo = true;

                        if (!flat.Descricao.EndsWith(" - EM CONSTRUÇÃO"))
                        {
                            flat.Descricao += " - EM CONSTRUÇÃO";
                        }
                    }
                    else
                    {
                        if (cbbStatus.Text == "Em Reforma")
                        {
                            flat.Status = cbbStatus.Text;
                            flat.Ativo = true;
                        }
                        else
                        {
                            if (cbbStatus.Text == "Vendido")
                            {
                                flat.Status = cbbStatus.Text;
                                flat.Ativo = false;

                                if (!flat.Descricao.EndsWith(" - VENDIDO"))
                                {
                                    flat.Descricao += " - VENDIDO";
                                }
                            }
                        }
                    }
                }
                decimal valorInvestimento;
                if (decimal.TryParse(txtValorInvestimento.Text, out valorInvestimento))
                {
                    flat.ValorInvestimento = valorInvestimento;
                    int Unidade;
                    if (int.TryParse(txtunidade.Text, out Unidade))
                    {
                        flat.Unidade = Unidade;
                    }
                    else { }
                }
            }
            flat.TipoInvestimento = cbbTipoInvestimento.SelectedItem?.ToString() ?? "Indefinido";
            flat.Rua = txtrua.Text;
            flat.Bairro = txtbairro.Text;
            flat.Cidade = txtcidade.Text;
            flat.Estado = txtestado.Text;
            flat.idEmpresa = flat.idEmpresa;
            return flat;
        }
        void limpar()
        {
            txtid.Text = "";
            txtdescricao.Text = "";
            dtdataaquisicao.Value = DateTime.Now;
            cbbStatus.Text = "";
            cbbTipoInvestimento.Text = "";
            txtValorInvestimento.Text = "";
            txtrua.Text = "";
            txtunidade.Text = "";
            txtbairro.Text = "";
            txtcidade.Text = "";
            txtestado.Text = "";
            txtempresaAss.Text = "";
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
