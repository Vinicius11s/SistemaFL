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
        }

        private void btnlocalizarImóvel_Click(object sender, EventArgs e)
        {
            var form = Program.serviceProvider.GetRequiredService<FrmConsultaFlat>();
            form.ShowDialog();

            if (form.id > 0)
            {
                btnlocalizarImóvel.Enabled = false;

                var flat = repositorio.Recuperar(e => e.id == form.id);
                txtdescricaoimovel.Text = flat.Descricao.ToString();
                idFlat = flat.id;
            }
            else btnlocalizarImóvel.Enabled = true;
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

            // Criar fluxo de memória para gerar o PDF
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document doc = null; // Declarar o Document fora do bloco try para garantir que ele seja acessível no finally
                try
                {
                    // Criação do documento PDF
                    doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                    doc.Open();

                    string caminhoPDF = Path.Combine(Path.GetTempPath(), "RelatorioFlat.pdf");

                    // Adiciona título ao relatório
                    AdicionarTitulo(doc);

                    // Buscar o Flat com a descrição do imóvel
                    var flat = repositorio.Recuperar(e => e.Descricao == txtdescricaoimovel.Text);

                    // Se o checkbox estiver marcado, adicionar detalhes do imóvel
                    if (ckDadosImovel.Checked)
                    {
                        AdicionarDadosImovel(doc, flat);
                    }

                    // Listar os lançamentos relacionados ao flat
                    var lancamentos = lancamentoRepositorio.Listar(l => l.idFlat == flat.id);
                    AdicionarLancamentos(doc, lancamentos);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Finalizar o documento
                    if (doc != null)
                    {
                        doc.Close(); // Fechar o documento, se ele foi instanciado
                    }

                    // Salvar PDF gerado e carregar na pré-visualização
                    SalvarEVisualizarPDF(memoryStream);
                }
            }
        }

        private void AdicionarTitulo(Document doc)
        {
            iTextSharp.text.Font fonteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 16, iTextSharp.text.Font.BOLD);
            Paragraph titulo = new Paragraph("Relatório Imóvel Individual", fonteTitulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20
            };
            doc.Add(titulo);
        }

        private void AdicionarDadosImovel(Document doc, Flat flat)
        {
            iTextSharp.text.Font fonteNegrito = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fonteNormal = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12);

            doc.Add(new Paragraph("Dados do Imóvel", fonteNegrito));
            doc.Add(new Paragraph($"ID: {flat.id}", fonteNormal));
            doc.Add(new Paragraph($"Descrição: {flat.Descricao}", fonteNormal));
            doc.Add(new Paragraph($"Endereço: {flat.Rua}, {flat.Unidade}, {flat.Bairro}, {flat.Cidade}-{flat.Estado}", fonteNormal));
            doc.Add(new Paragraph($"Empresa: {(flat.Empresa != null ? flat.Empresa.Descricao : "Não associada")}", fonteNormal));
            doc.Add(new Paragraph(" ")); // Espaço extra
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
                    string mes = lanc.DataPagamento.ToString("MMMM").ToUpper();
                    decimal total = (lanc.ValorAluguel ?? 0.00m) +
                                    (lanc.ValorDividendos ?? 0.00m) +
                                    (lanc.ValorFundoReserva ?? 0.00m);

                    string valor = total.ToString("C2"); // Formata como moeda

                    BaseColor corLinha = corAlternada ? corCinza : corBranca;

                    PdfPCell celulaMes = new PdfPCell(new Phrase(mes))
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

        private void SalvarEVisualizarPDF(MemoryStream memoryStream)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"TempRelatorioFlatIndividual.pdf");
            File.WriteAllBytes(tempFilePath, memoryStream.ToArray());

            axAcropdf1.LoadFile(tempFilePath);
            axAcropdf1.setView("FitH");
            axAcropdf1.setShowToolbar(false);

            MessageBox.Show("Pré-visualização do relatório gerada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
