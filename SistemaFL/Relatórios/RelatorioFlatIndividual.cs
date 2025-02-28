using Interfaces;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SkiaSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Entidades;
using Infraestrutura.Seguranca;

namespace SistemaFL
{
    public partial class RelatorioFlatIndividual : Form
    {
        private IFlatRepositorio repositorio;
        private ILancamentoRepositorio lancamentoRepositorio;
        int idFlat;
        public RelatorioFlatIndividual(IFlatRepositorio repositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
            this.lancamentoRepositorio = lancamentoRepositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void RelatorioFlatIndividual_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
            pdescricao.Enabled = false;

            ckTodos.Enabled = false;
            ckDadosImovel.Enabled = false;
            ckRendimentos.Enabled = false;
            btnVizualizarPdf.Enabled = false;
        }
        private void btnlocalizarImóvel_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmConsultaFlat>();
            form.ShowDialog();

            if (form.id > 0)
            {
                btnlocalizarImóvel.Enabled = false;
                pdescricao.Enabled = true;

                ckTodos.Enabled = true;
                ckDadosImovel.Enabled = true;
                ckRendimentos.Enabled = true;
                btnVizualizarPdf.Enabled = true;

                var flat = repositorio.Recuperar(e => e.id == form.id);
                txtdescricaoimovel.Text = flat.Descricao.ToString();
                idFlat = flat.id;
            }
            else
            {
                btnlocalizarImóvel.Enabled = true;
                pdescricao.Enabled = false;

                ckTodos.Enabled = false;
                ckDadosImovel.Enabled = false;
                ckRendimentos.Enabled = false;
                btnVizualizarPdf.Enabled = false;
            }
        }
        private void btnVizualizarPdf_Click(object sender, EventArgs e)
        {
            GerarRelatorioFlat();
        }
        private void GerarRelatorioFlat()
        {
            if (string.IsNullOrWhiteSpace(txtdescricaoimovel.Text))
            {
                MessageBox.Show("Selecione um imóvel primeiro!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    using (Document doc = new Document(PageSize.A4))
                    {
                        PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                        doc.Open();
                        // Criar documento PDF

                        // Criar caminho do PDF temporário
                        string caminhoPDF = Path.Combine(Path.GetTempPath(), "RelatorioFlat.pdf");

                        // Adicionar título
                        AdicionarTitulo(doc);

                        var flat = repositorio.Recuperar(e => e.Descricao == txtdescricaoimovel.Text);

                        if (ckDadosImovel.Checked)
                        {
                            AdicionarDadosImovel(doc, flat);
                        }

                        if (ckRendimentos.Checked)
                        {
                            var lancamentos = lancamentoRepositorio.Listar(l => l.idFlat == flat.id);
                            if (lancamentos.Count > 0)
                            {
                                AdicionarLancamentos(doc, lancamentos);

                            }
                        }
                        AdicionarRodape(doc, writer);
                        doc.Close();

                        string tempFilePath = Path.Combine(Path.GetTempPath(), $"TempRelatorio_{flat.Descricao}.pdf");
                        File.WriteAllBytes(tempFilePath, memoryStream.ToArray());

                        axAcropdf1.LoadFile(tempFilePath);
                        axAcropdf1.setView("FitH");
                        axAcropdf1.setShowToolbar(false);

                        MessageBox.Show($"Pré-visualização do relatório gerada com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }              
            }
        }    
        private void AdicionarTitulo(Document doc)
        {
            var fonteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 16, iTextSharp.text.Font.BOLD);
            var titulo = new Paragraph($"Relatório Imóvel Individual\n\n", fonteTitulo)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(titulo);
        }
        private void AdicionarDadosImovel(Document doc, Flat flat)
        {
            iTextSharp.text.Font fonteNegritoCabecalho = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 14, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fonteNegrito = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fonteNormal = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12);


            doc.Add(new Paragraph("Dados do Imóvel", fonteNegritoCabecalho));

            doc.Add(new Paragraph($"Valor Total do Imóvel: {flat.ValorTotalImovel:C}", fonteNormal));
            doc.Add(new Paragraph($"Descrição: {flat.Descricao}", fonteNormal));
            string tipoUnidade = string.IsNullOrEmpty(flat.TipoUnidade) ? "" : $" | Tipo: {flat.TipoUnidade}";
            doc.Add(new Paragraph($"UN: {flat.Unidade}{tipoUnidade}", fonteNormal));
            doc.Add(new Paragraph($"Endereço: {flat.Rua}, {flat.Numero}, {flat.Bairro}, {flat.Cidade}-{flat.Estado}", fonteNormal));

            if (flat.TipoCadastro == 1)
            {
                doc.Add(new Paragraph($"Operadora: {(flat.Empresa != null ? flat.Empresa.RazaoSocial : "Não associada")}", fonteNormal));
            }
            else if (flat.TipoCadastro == 2)
            {
                doc.Add(new Paragraph($"Plataforma: {(flat.Empresa != null ? flat.Empresa.RazaoSocial : "Não associada")}", fonteNormal));
            }

            doc.Add(new Paragraph($"N° Matrícula: {flat.NumMatriculaImovel}", fonteNormal));
            doc.Add(new Paragraph($"N° UN Consumidora Energia: {flat.NumUCEnergia:C}", fonteNormal));
            doc.Add(new Paragraph($"N° Cadastro Prefeitura: {flat.NumCadastroPrefeitura:C}", fonteNormal));

            doc.Add(new Paragraph($"Tipo Investimento: {flat.TipoInvestimento}", fonteNormal));
            doc.Add(new Paragraph(string.Format("Tamanho do Imóvel: {0} m² | Possui Garagem: {1} | Escriturado: {2} | Registrado: {3}",
                flat.TamanhoUnM2,
                flat.PossuiGaragem ? "Sim" : "Não",
                flat.Escriturado ? "Sim" : "Não",
                flat.Registrado ? "Sim" : "Não"), fonteNormal));

            doc.Add(new Paragraph($"Mês Reajuste Aluguel: {flat.MesReajusteAluguel}", fonteNormal));
            doc.Add(new Paragraph($"IPTU: {flat.IPTU}", fonteNormal));

            doc.Add(new Paragraph($"Valor de Comissão: {flat.valorComissao} | Nota: {(flat.NotaComissao ? "Sim" : "Não")}", fonteNormal));

            doc.Add(new Paragraph($"Valor da Escritura: {flat.ValorEscritura:C}", fonteNormal));
            doc.Add(new Paragraph($"Valor do ITBI: {flat.ValorITBI:C}", fonteNormal));
            doc.Add(new Paragraph($"Laudêmio: {(flat.Laudemio ? $"Sim | Valor: {flat.ValorLaudemio:C}" : "Não")}", fonteNormal));
            doc.Add(new Paragraph($"Valor do Aforamento: {flat.ValorAforamento:C}\n\n", fonteNormal));

            // Título de Rendimentos
            Paragraph titulo = new Paragraph($"Rendimentos\n\n", fonteNegrito);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
        }
        private void AdicionarLancamentos(Document doc, IEnumerable<Lancamento> lancamentos)
        {
            if (lancamentos != null && lancamentos.Any())
            {
                iTextSharp.text.Font fonteCabecalho = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.White);
                PdfPTable tabela = new PdfPTable(2) { WidthPercentage = 100 };
                tabela.SetWidths(new float[] { 2, 1 }); // Ajustar largura das colunas

                // Adiciona cabeçalho da tabela
                AdicionarCabecalhoTabela(tabela, fonteCabecalho);

                // Alternar cores nas linhas
                BaseColor corBranca = BaseColor.White;
                BaseColor corCinza = new BaseColor(230, 230, 230); // Cinza claro
                bool corAlternada = false;

                foreach (var lanc in lancamentos)
                {
                    // Extrair o nome do mês e adicionar o ano com os dois últimos dígitos
                    string mes = lanc.DataPagamento.ToString("MMMM").ToUpper();
                    string ano = lanc.DataPagamento.Year.ToString().Substring(2, 2); // Pega os dois últimos dígitos do ano
                    string mesAno = $"{mes} /{ano}";  // Formata como "FEVEREIRO /25"

                    decimal total = (lanc.ValorAluguel ?? 0.00m) +
                                    (lanc.ValorDividendos ?? 0.00m) +
                                    (lanc.ValorFundoReserva ?? 0.00m);

                    string valor = total.ToString("C2"); // Formata como moeda

                    BaseColor corLinha = corAlternada ? corCinza : corBranca;

                    // Criar células para o mês/ano e valor
                    PdfPCell celulaMes = new PdfPCell(new Phrase(mesAno))
                    {
                        BackgroundColor = corLinha,
                        Border = PdfPCell.NO_BORDER,
                        Padding = 5
                    };

                    PdfPCell celulaValor = new PdfPCell(new Phrase(valor))
                    {
                        BackgroundColor = corLinha,
                        Border = PdfPCell.NO_BORDER,
                        Padding = 5,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };

                    tabela.AddCell(celulaMes);
                    tabela.AddCell(celulaValor);

                    corAlternada = !corAlternada; // Alternar cores
                }

                doc.Add(tabela);
            }
            else
            {
                doc.Add(new Paragraph("Nenhum lançamento encontrado para este flat.",
                    new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12)));
            }
        }
        private void AdicionarCabecalhoTabela(PdfPTable tabela, iTextSharp.text.Font fonteCabecalho)
        {
            PdfPCell cell1 = new PdfPCell(new Phrase("Mês", fonteCabecalho))
            {
                BackgroundColor = BaseColor.DarkGray,
                Border = PdfPCell.NO_BORDER,
                Padding = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            PdfPCell cell2 = new PdfPCell(new Phrase("Valor", fonteCabecalho))
            {
                BackgroundColor = BaseColor.DarkGray,
                Border = PdfPCell.NO_BORDER,
                Padding = 5,
                HorizontalAlignment = Element.ALIGN_CENTER
            };

            tabela.AddCell(cell1);
            tabela.AddCell(cell2);
        }
        private void AdicionarRodape(Document doc, PdfWriter writer)
        {
            iTextSharp.text.Font rodapeFonte = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL);

            string dataHoraAtual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string nomeUsuario = Sessao.NomeUsuarioLogado;
            string textoRodape = $"Sistema Gerenciador de Investimentos - criado em {dataHoraAtual} - {nomeUsuario}";

            PdfContentByte cb = writer.DirectContent;
            ColumnText ct = new ColumnText(cb);

            ct.SetSimpleColumn(new Phrase(textoRodape, rodapeFonte),
                               doc.Left, doc.Bottom - 10,
                               doc.Right, doc.Bottom + 10,
                               10, Element.ALIGN_LEFT);

            ct.Go();
        }      
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
        }
        private void pbFechar_Click(object sender, EventArgs e)
        {
            txtdescricaoimovel.Text = "";
            ckTodos.Checked = false;
            ckDadosImovel.Checked = false;
            ckRendimentos.Checked = false;
            btnlocalizarImóvel.Enabled = true;

            this.Close();
            
        }
        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodos.Checked)
            {
                ckDadosImovel.Checked = true;
                ckRendimentos.Checked = true;
            }
            else
            {
                ckDadosImovel.Checked = false;
                ckRendimentos.Checked = false;
            }
        }
        private void btnSalvarPDF_Click(object sender, EventArgs e)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"TempRelatorioFlatIndividual{txtdescricaoimovel.Text}.pdf");

            if (File.Exists(tempFilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = $"Relatorio_Tributacao_Anual_{txtdescricaoimovel.Text}.pdf",
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    DefaultExt = "pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(tempFilePath, saveFileDialog.FileName, overwrite: true);
                        MessageBox.Show($"Relatório salvo com sucesso em: {saveFileDialog.FileName}",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao salvar o relatório: {ex.Message}",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Não foi possível encontrar o arquivo gerado para salvar.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
