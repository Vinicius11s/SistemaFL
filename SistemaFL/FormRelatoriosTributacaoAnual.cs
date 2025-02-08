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
                private void btnVizualizarPDF_Click_1(object sender, EventArgs e)
                {
                    GerarRelatorioAnual();
                }
                public void GerarRelatorioAnual()
                {
                    int? ano = ValidarAno(txtAno.Text);
                    if (!ano.HasValue) return;

                    var dados = ObterDadosRelatorio(ano.Value);
                    if (dados == null) return;

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        try
                        {
                            using (Document doc = new Document(PageSize.A4))
                            {
                                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                                doc.Open();

                                AdicionarTitulo(doc, ano.Value);
                                AdicionarTabela(doc, dados);

                                var dadosIRPJ = new List<decimal>();
                                var dadosContrSocial = new List<decimal>();

                                if (ckIRPJ.Checked)
                                {
                                    for (int trimestre = 1; trimestre <= 4; trimestre++)
                                    {
                                        decimal valor = repositorio.CalcularIRPJTrimestre(ano.Value, trimestre);
                                        dadosIRPJ.Add(valor);
                                    }
                                }

                                if (ckContrSocial.Checked)
                                {
                                    for (int trimestre = 1; trimestre <= 4; trimestre++)
                                    {
                                        decimal valor = repositorio.CalcularContrSocialTrimestre(ano.Value, trimestre);
                                        dadosContrSocial.Add(valor);
                                    }
                                }

                                if (dadosIRPJ.Any() || dadosContrSocial.Any())
                                {
                                    AdicionarTabelaTributos(doc, ano.Value, dadosIRPJ, dadosContrSocial);
                                }
                                AdicionarRendimentos(doc, dadosIRPJ, dadosContrSocial, ano.Value);
                                AdicionarRodape(doc);
                                doc.Close();

                                string tempFilePath = Path.Combine(Path.GetTempPath(), $"TempRelatorio_{ano}.pdf");
                                File.WriteAllBytes(tempFilePath, memoryStream.ToArray());

                                axAcropdf1.LoadFile(tempFilePath);
                                axAcropdf1.setView("FitH");
                                axAcropdf1.setShowToolbar(false);

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
                private void AdicionarTitulo(Document doc, int ano)
                {
                    var fonteTitulo = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 16, iTextSharp.text.Font.BOLD);
                    var titulo = new Paragraph($"Relatório Fiscal - {ano}\n\n", fonteTitulo)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    doc.Add(titulo);
                }
                private void AdicionarTabela(Document doc, dynamic dados)
                {
                    int numColunas = 1;

                    if (ckRendimentos.Checked)
                        numColunas++;
                    if (ckPis.Checked)
                        numColunas++;
                    if (ckCofins.Checked)
                        numColunas++;

                    PdfPTable tabela = new PdfPTable(numColunas) { WidthPercentage = 100 };

                    // Defina larguras das colunas com base nas colunas visíveis
                    float[] larguras = new float[numColunas];
                    larguras[0] = 3; // Mês
                    int coluna = 1;

                    if (ckRendimentos.Checked)
                    {
                        larguras[coluna] = 2; // RENDIMENTOS
                        coluna++;
                    }
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

                    if (ckRendimentos.Checked)
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

                        tabela.AddCell(new PdfPCell(new Phrase(mes)) { HorizontalAlignment = Element.ALIGN_CENTER });

                        if (ckRendimentos.Checked)
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
                private void AdicionarRodape(Document doc)
                {

                    iTextSharp.text.Font rodapeFonte = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 6f, iTextSharp.text.Font.NORMAL);

                    string dataHoraAtual = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    string nomeUsuario = Sessao.nomeUsuarioLogado;
                    string textoRodape = $"Sistema Gerenciador de Investimentos - criado em {dataHoraAtual} - {nomeUsuario}";

                    // Criar o parágrafo com o texto do rodapé
                    Paragraph rodape = new Paragraph(textoRodape, rodapeFonte)
                    {
                        Alignment = Element.ALIGN_LEFT
                    };

                    float margemInferior = 20f;

                    rodape.SetAbsolutePosition(doc.Left, doc.Bottom - margemInferior);
                    doc.Add(rodape);
                }
                private void AdicionarTabelaIRPJ(Document doc, int ano)
                {
                    // Adiciona duas quebras de linha antes da tabela
                    doc.Add(new Paragraph("\n\n"));

                    PdfPTable tabelaIRPJ = new PdfPTable(2) { WidthPercentage = 100 };
                    tabelaIRPJ.SetWidths(new float[] { 3, 2 });

                    AdicionarCelulaCabecalho(tabelaIRPJ, "Trimestre");
                    AdicionarCelulaCabecalho(tabelaIRPJ, "Valor IRPJ");

                    string[] trimestres = { "1° Trimestre", "2° Trimestre", "3° Trimestre", "4° Trimestre" };

                    for (int i = 0; i < 4; i++)
                    {
                        decimal irpj = repositorio.CalcularIRPJTrimestre(ano, i + 1);

                        tabelaIRPJ.AddCell(new PdfPCell(new Phrase(trimestres[i])) { HorizontalAlignment = Element.ALIGN_CENTER });
                        tabelaIRPJ.AddCell(new PdfPCell(new Phrase(irpj.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    }

                    doc.Add(tabelaIRPJ);
                }
                private void AdicionarTabelaTributos(Document doc, int ano, List<decimal> dadosIRPJ, List<decimal> dadosContrSocial)
                {
                    doc.Add(new Paragraph("\n\n")); // Adiciona espaço antes da tabela

                    PdfPTable tabela = new PdfPTable(3) { WidthPercentage = 100 };
                    tabela.SetWidths(new float[] { 1, 1, 1 });

                    AdicionarCelulaCabecalho(tabela, "Trimestre");
                    AdicionarCelulaCabecalho(tabela, "IRPJ");
                    AdicionarCelulaCabecalho(tabela, "Contribuição Social");

                    string[] trimestres = { "1° Trimestre", "2° Trimestre", "3° Trimestre", "4° Trimestre" };

                    for (int i = 0; i < 4; i++)
                    {
                        decimal irpj = dadosIRPJ.Count > i ? dadosIRPJ[i] : 0;
                        decimal contrSocial = dadosContrSocial.Count > i ? dadosContrSocial[i] : 0;

                        tabela.AddCell(new PdfPCell(new Phrase(trimestres[i])) { HorizontalAlignment = Element.ALIGN_CENTER });
                        tabela.AddCell(new PdfPCell(new Phrase(irpj.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        tabela.AddCell(new PdfPCell(new Phrase(contrSocial.ToString("C2"))) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    }

                    doc.Add(tabela);
                }
                private void AdicionarRendimentos(Document doc, List<decimal> dadosIRPJ, List<decimal> dadosContrSocial, int ano)
                {
                    if (ckRendimentos.Checked)
                    {
                        decimal rendimentoBruto = repositorio.SomaLancamentosAnoTodoExcetoDividendos(ano);

                        decimal totalImpostos = dadosIRPJ.Sum() + dadosContrSocial.Sum();

                        doc.Add(new Paragraph("\n\n"));

                        // Adicionar texto "RENDIMENTO BRUTO"
                        doc.Add(new Paragraph($"RENDIMENTO BRUTO: {rendimentoBruto.ToString("C2")}"));

                        // Adicionar texto "RENDIMENTO LÍQUIDO" se os checkboxes de impostos estiverem marcados
                        if (ckIRPJ.Checked || ckContrSocial.Checked)
                        {
                            decimal rendimentoLiquido = rendimentoBruto - totalImpostos;
                            doc.Add(new Paragraph($"RENDIMENTO LÍQUIDO: {rendimentoLiquido.ToString("C2")}"));
                        }
                    }
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
                private void tTamanhotela_Tick(object sender, EventArgs e)
                {
                    Estilos.ReAjustarTamanhoFormulario(this, tTamanhotela);
                }
                private void ckTodos_CheckedChanged(object sender, EventArgs e)
                {
                    if (ckTodos.Checked)
                    {
                        ckCofins.Checked = true;
                        ckPis.Checked = true;
                        ckIRPJ.Checked = true;
                        ckContrSocial.Checked = true;
                        ckIRPJ.Checked = true;
                        ckContrSocial.Checked = true;
                        ckRendimentoBruto.Checked = true;
                        ckRendimentoLiq.Checked = true;
                
                    }
                    else
                    {
                        ckCofins.Checked = false;
                        ckPis.Checked = false;
                        ckIRPJ.Checked = false;
                        ckContrSocial.Checked = false;
                        ckIRPJ.Checked = false;
                        ckContrSocial.Checked = false;
                        ckRendimentoBruto.Checked = false;
                        ckRendimentoLiq.Checked = false;
                    }

                }
                private void pbFecharr_Click(object sender, EventArgs e)
                {
                    this.Close();
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

            }
        }
