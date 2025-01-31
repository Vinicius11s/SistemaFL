using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Infraestrutura.Repositorio;
using Interfaces;
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
            int? ano = ValidarAno(txtAno.Text);
            if (!ano.HasValue) return;

            var dados = ObterDadosRelatorio(ano.Value);
            if (dados == null) return;

            string caminhoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Relatorio_Tributacao_Anual_{ano}.pdf");

            try
            {
                using (Document doc = new Document(PageSize.A4))
                {
                    PdfWriter.GetInstance(doc, new FileStream(caminhoArquivo, FileMode.Create));
                    doc.Open();

                    AdicionarImagemCabecalho(doc);
                    AdicionarTitulo(doc, ano.Value);
                    AdicionarTabela(doc, dados);

                    MessageBox.Show($"Relatório do ano {ano} gerado com sucesso!\nArquivo salvo em: {caminhoArquivo}",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Erro de acesso ao arquivo: {ioEx.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar o relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarImagemCabecalho(Document doc)
        {
            string caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Icone.Principal.png");
            if (File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(caminhoImagem);
                logo.ScaleToFit(100, 100);
                logo.Alignment = Element.ALIGN_CENTER;
                doc.Add(logo);
            }
        }

        private void AdicionarTitulo(Document doc, int ano)
        {
            var fonteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 16, iTextSharp.text.Font.BOLD);
            var titulo = new Paragraph($"Relatório Anual de PIS e COFINS - {ano}\n\n", fonteTitulo)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(titulo);
        }

        private void AdicionarTabela(Document doc, dynamic dados)
        {
            // Corrigido para 4 colunas, uma para cada categoria (Mês, Total Rendimentos, PIS, COFINS)
            PdfPTable tabela = new PdfPTable(4) { WidthPercentage = 100 };
            tabela.SetWidths(new float[] { 3, 2, 2, 2 }); // Ajuste nas larguras das colunas para 4

            // Cabecalho da Tabela
            AdicionarCelulaCabecalho(tabela, "MÊS");
            AdicionarCelulaCabecalho(tabela, "RENDIMENTOS");
            AdicionarCelulaCabecalho(tabela, "PIS (0.65%)");
            AdicionarCelulaCabecalho(tabela, "COFINS (3%)");

            // Meses do ano
            string[] meses = { "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO" };

            // Adicionando as linhas
            foreach (string mes in meses)
            {
                decimal valorMes = Convert.ToDecimal(dados.GetType().GetProperty(mes)?.GetValue(dados) ?? 0);
                decimal pis = valorMes * 0.0065m;
                decimal cofins = valorMes * 0.03m;

                // Adicionando as células para cada coluna
                tabela.AddCell(new PdfPCell(new Phrase(mes)) { HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase(valorMes.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase(pis.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                tabela.AddCell(new PdfPCell(new Phrase(cofins.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
            }

            doc.Add(tabela);
        }


        private void AdicionarCelulaCabecalho(PdfPTable tabela, string texto)
        {
            var fonteCabecalho = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            PdfPCell celula = new PdfPCell(new Phrase(texto, fonteCabecalho))
            {
                BackgroundColor = new BaseColor(200, 200, 200),
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            tabela.AddCell(celula);
        }

        private int? ValidarAno(string anoTexto)
        {
            if (string.IsNullOrWhiteSpace(anoTexto))
            {
                MessageBox.Show("Por favor, digite um ano.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (!int.TryParse(anoTexto, out int ano) || ano < 1900 || ano > DateTime.Now.Year)
            {
                MessageBox.Show("Por favor, digite um ano válido (exemplo: 2024).", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return ano;
        }

        private dynamic ObterDadosRelatorio(int ano)
        {
            var dados = repositorio.ObterDadosRelatorioAnual(ano).FirstOrDefault();
            if (dados == null)
            {
                MessageBox.Show($"Não há lançamentos para o ano {ano}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return dados;
        }

        private void btnlocalizar_Click(object sender, EventArgs e)
        {
            GerarRelatorioAnual();
        }

        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
