using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AxAcroPDFLib;
using Entidades;
using Infraestrutura.Repositorio;
using Infraestrutura.Seguranca;
using Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaFL
{
    public partial class FormRelatoriosTributacaoAnual : Form
    {
        private ILancamentoRepositorio repositorio;
        private string caminhoArquivoPDF;
        public FormRelatoriosTributacaoAnual(ILancamentoRepositorio repositorio)
        {
            InitializeComponent();
            this.repositorio = repositorio;

            tTamanhotela.Tick += tTamanhotela_Tick;
            tTamanhotela.Start();
        }
        private void FormRelatoriosTributacaoAnual_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(205, 41);
        }
        public void GerarRelatorioAnual()
        {
            int? ano = ValidarAno(txtAno.Text);
            if (!ano.HasValue) return;

            var dados = ObterDadosRelatorio(ano.Value);
            if (dados == null) return;

            // Gerar o PDF em memória
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    using (Document doc = new Document(PageSize.A4))
                    {
                        // Criar um escritor para gravar no MemoryStream
                        PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                        doc.Open();

                        AdicionarTitulo(doc, ano.Value);
                        AdicionarTabela(doc, dados);
                        AdicionarRodape(doc);

                        // Fecha o documento, gravando o conteúdo no MemoryStream
                        doc.Close();

                        // Salvar o MemoryStream como um arquivo temporário
                        string tempFilePath = Path.Combine(Path.GetTempPath(), $"TempRelatorio_{ano}.pdf");
                        File.WriteAllBytes(tempFilePath, memoryStream.ToArray());

                        // Carregar o arquivo temporário no controle AxAcroPDF para pré-visualização
                        axAcropdf1.LoadFile(tempFilePath);

                        // Ajusta a visualização do PDF
                        axAcropdf1.setView("FitH");
                        axAcropdf1.setShowToolbar(false);

                        // Exibe mensagem de sucesso
                        MessageBox.Show($"Pré-visualização do relatório do ano {ano} gerada com sucesso!",
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
        }
        private dynamic ObterDadosRelatorio(int ano)
        {
            var dados = repositorio.ObterDadosRelatorioMensal(ano).FirstOrDefault();
            if (dados == null)
            {
                MessageBox.Show($"Não há lançamentos para o ano {ano}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return dados;
        }
        //
        //Adicionar ao doc
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
            int numColunas = 2;

            if (ckPis.Checked)
                numColunas++;
            if (ckCofins.Checked)
                numColunas++;

            PdfPTable tabela = new PdfPTable(numColunas) { WidthPercentage = 100 };

            // Defina larguras das colunas com base nas colunas visíveis
            float[] larguras = new float[numColunas];
            larguras[0] = 3; // Mês
            larguras[1] = 2; // RENDIMENTOS
            int coluna = 2;

            if (ckPis.Checked)
            {
                larguras[coluna] = 2;
                coluna++;
            }
            if (ckCofins.Checked)
            {
                larguras[coluna] = 2;
            }
            tabela.SetWidths(larguras);

            AdicionarCelulaCabecalho(tabela, "MÊS");
            AdicionarCelulaCabecalho(tabela, "RENDIMENTOS");

            if (ckPis.Checked)
                AdicionarCelulaCabecalho(tabela, "PIS (0.65%)");
            if (ckCofins.Checked)
                AdicionarCelulaCabecalho(tabela, "COFINS (3%)");

            string[] meses = { "JANEIRO", "FEVEREIRO", "MARÇO", "ABRIL", "MAIO", "JUNHO", "JULHO", "AGOSTO", "SETEMBRO", "OUTUBRO", "NOVEMBRO", "DEZEMBRO" };

            // Adicionando as linhas
            foreach (string mes in meses)
            {
                decimal valorMes = Convert.ToDecimal(dados.GetType().GetProperty(mes)?.GetValue(dados) ?? 0);
                decimal pis = valorMes * 0.0065m;
                decimal cofins = valorMes * 0.03m;

                // Adicionando as células para cada coluna, de forma condicional
                tabela.AddCell(new PdfPCell(new Phrase(mes)) { HorizontalAlignment = Element.ALIGN_CENTER });
                tabela.AddCell(new PdfPCell(new Phrase(valorMes.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });

                if (ckPis.Checked)
                    tabela.AddCell(new PdfPCell(new Phrase(pis.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                if (ckCofins.Checked)
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
        private void AdicionarRodape(Document doc)
        {

            iTextSharp.text.Font rodapeFonte = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL);

            // Obter a data e hora atual
            string dataHoraAtual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Obter o nome do usuário logado da classe Sessao
            string nomeUsuario = Sessao.nomeUsuarioLogado;

            // Montar o texto do rodapé
            string textoRodape = $"Sistema Gerenciador de Investimentos - criado em {dataHoraAtual} - {nomeUsuario}";

            // Criar o parágrafo com o texto do rodapé
            Paragraph rodape = new Paragraph(textoRodape, rodapeFonte)
            {
                Alignment = Element.ALIGN_LEFT
            };

            // Adicionar o rodapé ao documento
            doc.Add(rodape);
        }

        private void btnVizualizarPDF_Click_1(object sender, EventArgs e)
        {
            GerarRelatorioAnual();
        }
        private void btnSalvarPDF_Click(object sender, EventArgs e)
        {
            // Caminho do arquivo temporário que foi gerado
            string tempFilePath = Path.Combine(Path.GetTempPath(), $"TempRelatorio_{txtAno.Text}.pdf");

            // Verifique se o arquivo temporário foi gerado
            if (File.Exists(tempFilePath))
            {
                // Exibir uma caixa de diálogo para o usuário escolher onde salvar o arquivo
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = $"Relatorio_Tributacao_Anual_{txtAno.Text}.pdf",
                    Filter = "PDF Files (*.pdf)|*.pdf",
                    DefaultExt = "pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Salvar o arquivo no local escolhido pelo usuário
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
        private void pbFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }     
        private void tTamanhotela_Tick(object sender, EventArgs e)
        {
            Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela, 10);
        }
        private void ckTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckTodos.Checked)
            {
                ckCofins.Checked = true;
                ckPis.Checked = true;
                ckIRPJ.Checked = true;
                ckContrAssist.Checked = true;
                ckRendimentoBruto.Checked = true;
                ckRendimentoLiq.Checked = true;
            }
            else
            {
                ckCofins.Checked = false;
                ckPis.Checked = false;
                ckIRPJ.Checked = false;
                ckContrAssist.Checked = false;
                ckRendimentoBruto.Checked = false;
                ckRendimentoLiq.Checked = false;
            }

        }
        private void pbFecharr_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   
    }
}
