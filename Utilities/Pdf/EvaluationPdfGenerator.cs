using Entity.Requests.EntityDetailRequest;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Utilities.Pdf
{
    public static class EvaluationPdfGenerator
    {
        public static byte[] Generate(EvaluationDetailRequest evaluation, byte[]? logoBytes = null)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var primaryColor = Colors.Blue.Medium;
            var accentColor = Colors.Grey.Lighten3;

            var pdf = Document.Create(container =>
            {
                // =============================
                // PORTADA (según tu ejemplo)
                // =============================
                container.Page(page =>
                {
                    page.Margin(60);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                    page.Content().AlignCenter().PaddingTop(20).Column(col =>
                    {
                        col.Spacing(25);

                        // Logo superior centrado
                        if (logoBytes != null)
                        {
                            col.Item()
                                .Width(90) // 🔸 antes 130 → más pequeño
                                .AlignCenter()
                                .Image(logoBytes)
                                .WithCompressionQuality(ImageCompressionQuality.High);
                        }

                        // Espacio entre logo y título
                        col.Item().PaddingTop(5)
                            .AlignCenter()
                            .Text("REPORTE EVALUATIVO DE LA EXPERIENCIA")
                            .FontSize(26).Bold().FontColor(primaryColor).AlignCenter();

                        // Experiencia
                        col.Item().PaddingTop(65)
                            .AlignCenter()
                            .Text($"Experiencia: {evaluation.ExperienceName}")
                            .FontSize(16).FontColor(Colors.Grey.Darken3);

                        // Institución
                        col.Item().PaddingTop(40)
                            .AlignCenter()
                            .Text($"Institución Educativa: {evaluation.InstitutionName}")
                            .FontSize(15);

                        // Tipo de Evaluación
                        col.Item().PaddingTop(50)
                            .AlignCenter()
                            .Text($"Tipo de Evaluación: {evaluation.TypeEvaluation}")
                            .FontSize(15);

                        // Fecha (abajo)
                        col.Item().PaddingTop(150)
                            .AlignCenter()
                            .Text($"Generado el {DateTime.Now:dd 'de' MMMM 'de' yyyy}")
                            .FontSize(12).Italic().FontColor(Colors.Grey.Darken1);
                    });

                    page.Footer().AlignCenter()
                        .Text("Documento confidencial — Sistema de Evaluación de Experiencias Significativas")
                        .FontSize(9).FontColor(Colors.Grey.Darken1).Italic();
                });


                // ========== CONTENIDO ==========
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    // Fondo con marca de agua (logo)
                    if (logoBytes != null)
                    {
                        var fadedLogo = ApplyImageOpacitySimple(logoBytes, 0.08f);

                        page.Background().Layers(layers =>
                        {
                            layers.PrimaryLayer()
                                .AlignCenter()
                                .AlignMiddle()
                                .Width(280)
                                .Height(280)
                                .Image(fadedLogo)
                                .WithCompressionQuality(ImageCompressionQuality.Medium);
                        });
                    }

                    // Encabezado superior
                    page.Header().Background(primaryColor).Padding(10).Row(row =>
                    {
                        row.RelativeColumn().AlignLeft().Text("Evaluación Detallada")
                            .FontSize(16).Bold().FontColor(Colors.White);
                        row.ConstantColumn(90).AlignRight().Text(DateTime.Now.ToString("dd/MM/yyyy"))
                            .FontColor(Colors.White);
                    });

                    // Contenido principal
                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        col.Spacing(10);

                        // Información general
                        col.Item().Background(accentColor).Padding(8)
                            .Text("Información General")
                            .FontSize(14).Bold().FontColor(primaryColor);

                        col.Item().PaddingLeft(10).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(200);
                                columns.RelativeColumn();
                            });

                            void AddRow(string label, string value)
                            {
                                table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                                    .Background(Colors.White).Padding(5)
                                    .Text(label).Bold().FontColor(primaryColor);

                                table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(value ?? "—");
                            }

                            AddRow("Tipo de Evaluación:", evaluation.TypeEvaluation);
                            AddRow("Rol de Acompañamiento:", evaluation.AccompanimentRole);
                            AddRow("Resultado Final:", evaluation.EvaluationResult);
                            AddRow("Experiencia:", evaluation.ExperienceName);
                            AddRow("Institución:", evaluation.InstitutionName);
                            AddRow("Comentarios:", evaluation.Comments);
                        });

                        // Criterios
                        col.Item().PaddingTop(15).Background(accentColor).Padding(8)
                            .Text("Criterios de Evaluación")
                            .FontSize(14).Bold().FontColor(primaryColor);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(150);
                                columns.ConstantColumn(80);
                                columns.RelativeColumn();
                            });

                            // Encabezados
                            table.Header(header =>
                            {
                                header.Cell().Background(primaryColor).Padding(5).Text("Criterio").FontColor(Colors.White).Bold();
                                header.Cell().Background(primaryColor).Padding(5).Text("Puntaje").FontColor(Colors.White).Bold();
                                header.Cell().Background(primaryColor).Padding(5).Text("Descripción").FontColor(Colors.White).Bold();
                            });

                            foreach (var c in evaluation.CriteriaEvaluations)
                            {
                                table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(c.Criteria).Bold();

                                table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).AlignCenter().Text(c.Score.ToString());

                                table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(5).Text(c.DescriptionContribution ?? "—");
                            }
                        });

                        // Líneas temáticas
                        col.Item().PaddingTop(15).Background(accentColor).Padding(8)
                            .Text("Líneas Temáticas")
                            .FontSize(14).Bold().FontColor(primaryColor);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns => columns.RelativeColumn());
                            foreach (var line in evaluation.ThematicLineNames)
                            {
                                table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2)
                                    .Padding(6).Text($"• {line}");
                            }
                        });
                    });

                    // Pie de página
                    page.Footer().AlignCenter().Text(txt =>
                    {
                        txt.Span("Sistema de Evaluación de Experiencias Significativas ").FontSize(9);
                        txt.Span("© 2025").FontSize(9).Bold();
                    });
                });
            });

            return pdf.GeneratePdf();
        }

        // === Opacidad de imagen simple ===
        public static byte[] ApplyImageOpacitySimple(byte[] imageBytes, float opacity)
        {
            using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageBytes);
            image.Mutate(ctx => ctx.Opacity(opacity));
            using var ms = new MemoryStream();
            image.Save(ms, new PngEncoder());
            return ms.ToArray();
        }

        // === Cargar logo desde URL ===
        public static async Task<byte[]?> LoadImageFromUrlAsync(string imageUrl)
        {
            using var http = new HttpClient();
            return await http.GetByteArrayAsync(imageUrl);
        }
    }
}










