using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Infraestrutura;
using Infraestrutura.Repositorio;
using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace SistemaFL
{
    public partial class FormRelatoriosTributacaoAnual : Form
    {
        private ILancamentoRepositorio repositorio;
        public FormRelatoriosTributacaoAnual(ILancamentoRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;
        }

        public void GerarRelatorioAnual()
        {
            string anoDigitado = txtAno.Text.Trim(); // Obter o ano digitado pelo usuário

            if (string.IsNullOrEmpty(anoDigitado))
            {
                MessageBox.Show("Por favor, digite um ano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(anoDigitado, out int ano) || ano < 1900 || ano > DateTime.Now.Year)
            {
                MessageBox.Show("Por favor, digite um ano válido (exemplo: 2024).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dados = repositorio.ObterDadosRelatorioAnual(anoDigitado).FirstOrDefault();
            if (dados == null)
            {
                MessageBox.Show($"Não há lançamentos para o ano {ano}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Caminho onde o PDF será salvo
            string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Relatorio_Tributacao_Anual_{ano}.pdf");

            // Criar documento PDF
            Document doc = new Document(PageSize.A4);
            try
            {
                PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                doc.Open();

                // Criar título com o ano
                string tituloRelatorio = $"Relatório Anual de PIS e COFINS - {ano}\n\n";
                iTextSharp.text.Font fonteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Paragraph titulo = new iTextSharp.text.Paragraph(tituloRelatorio, fonteTitulo)
                {
                    Alignment = Element.ALIGN_CENTER
                };

                doc.Add(titulo);

                // Criar tabela
                PdfPTable tabela = new PdfPTable(3); // 3 colunas (Mês, Base de Cálculo, Impostos)
                tabela.WidthPercentage = 100;
                tabela.SetWidths(new float[] { 3, 2, 2 });

                // Adicionar cabeçalho
                AdicionarCelulaCabecalho(tabela, "Mês");
                AdicionarCelulaCabecalho(tabela, "Total Rendimentos");
                AdicionarCelulaCabecalho(tabela, "Imposto");

                // Adicionar os dados da base de cálculo por mês
                string[] meses = { "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO" };
                foreach (string mes in meses)
                {
                    string valorMes = dados.GetType().GetProperty(mes)?.GetValue(dados)?.ToString() ?? "0.00";
                    AdicionarLinhaTabela(tabela, mes, valorMes);
                }

                // Adicionar PIS e COFINS
                tabela.AddCell(new PdfPCell(new Phrase("PIS")) { Colspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase(dados.GetType().GetProperty("PIS")?.GetValue(dados)?.ToString() ?? "0.00")));

                tabela.AddCell(new PdfPCell(new Phrase("COFINS")) { Colspan = 2, HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase(dados.GetType().GetProperty("COFINS")?.GetValue(dados)?.ToString() ?? "0.00")));

                // Adicionar tabela ao documento
                doc.Add(tabela);

                // Mensagem de sucesso
                MessageBox.Show($"Relatório do ano {ano} gerado com sucesso!\nArquivo salvo em: {caminhoArquivo}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar o relatório: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }



        private void AdicionarCelulaCabecalho(PdfPTable tabela, string texto)
        {
            iTextSharp.text.Font fonteNegrito = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12, iTextSharp.text.Font.BOLD);

            PdfPCell celula = new PdfPCell(new Phrase(texto, fonteNegrito))
            {
                BackgroundColor = new iTextSharp.text.BaseColor(200, 200, 200), // Cinza claro
                HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
            };

            tabela.AddCell(celula);
        }


        private void AdicionarLinhaTabela(PdfPTable tabela, string mes, string valor)
        {
            tabela.AddCell(new PdfPCell(new Phrase(mes)) { HorizontalAlignment = Element.ALIGN_CENTER });
            tabela.AddCell(new PdfPCell(new Phrase(valor)) { HorizontalAlignment = Element.ALIGN_RIGHT });
            tabela.AddCell(new PdfPCell(new Phrase("-")) { HorizontalAlignment = Element.ALIGN_CENTER }); // Coluna de Impostos vazia
        }

        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            GerarRelatorioAnual();
        }
    }
}

