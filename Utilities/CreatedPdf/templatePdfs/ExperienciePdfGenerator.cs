using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using Entity.Models.ModuleOperation;

public static class ExperiencePdfGenerator
{
    public static byte[] Generate(Experience data, byte[]? watermarkBytes = null)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var primaryColor = Colors.Blue.Medium;
        var accentColor = Colors.Grey.Lighten3;

        var pdf = QuestPDF.Fluent.Document.Create(container =>

        {
            // PORTADA  
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0);

              
                // --- Marca de agua en todas las páginas ---
                if (watermarkBytes != null)
                {
                    var fadedLogo = ApplyImageOpacitySimple(watermarkBytes, 0.08f);

                    page.Background().Element(e =>
                    {
                        e.AlignCenter()
                         .AlignMiddle()
                         .Width(300)
                         .Height(300)
                         .Image(fadedLogo)
                         .WithCompressionQuality(ImageCompressionQuality.Medium);
                    });
                }


                // --- CONTENIDO CENTRADO ---
                page.Content()
                    .Padding(20)
                    .AlignCenter()
                    .AlignMiddle()
                    .Column(col =>
                    {
                        col.Spacing(25);

                        col.Item().Text(data.NameExperiences ?? "")
                            .FontSize(34)
                            .Bold()
                            .FontColor(primaryColor)
                            .AlignCenter();

                        col.Item().Text(data.Institution?.Name ?? "")
                            .FontSize(22)
                            .AlignCenter();

                        col.Item().Text(data.User?.Person?.FirstName ?? data.User?.Username ?? "")
                            .FontSize(18)
                            .AlignCenter();

                        col.Item().Text(data.CreatedAt.ToString("yyyy-MM-dd"))
                            .FontSize(18)
                            .AlignCenter();
                    });
            });



            // CONTENIDO 
            container.Page(page =>
            {
                page.Margin(40);
                page.Header().Element(e =>
                {
                    e.Row(row =>
                    {
                        row.ConstantColumn(1).Background(Colors.Grey.Lighten2);
                        row.RelativeColumn().Padding(4).AlignCenter()
                            .Text("Registro").FontSize(10);

                        row.ConstantColumn(1).Background(Colors.Grey.Lighten2);

                        row.RelativeColumn().PaddingLeft(10).PaddingRight(10)
                            .Text(" Experiencia Significativa")
                            .Bold().FontSize(12);

                        row.ConstantColumn(1).Background(Colors.Grey.Lighten2);

                        row.RelativeColumn().AlignRight()
                            .Text("Versión 2\n11/Agosto/2025")
                            .FontSize(10);
                    });
                });


                page.Content().PaddingTop(20).Column(col =>
                {
                    col.Spacing(18);

                    // INTRODUCCIÓN -------------------------
                    // SectionTitle equivalent
                    col.Item().Text("1. Introducción")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    col.Item().Text("La presente guía tiene como propósito orientar el proceso de sistematización de la experiencia significativa, permitiendo registrar, organizar y analizar la información relevante para fortalecer las prácticas pedagógicas y promover la reflexión crítica en la comunidad educativa.")
                        .FontSize(11)
                        .LineHeight(1.4f);

                    // 1. DATOS GENERALES (Experiencia Significativa)
                    col.Item().Text("2. Experiencia Significativa")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    // Field("Nombre", data.NameExperiences);
                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Nombre de la Experiencia Significativa:").Bold();
                        r.RelativeColumn().Text(data.NameExperiences ?? "—");
                    });

                    // Field("Estado de desarrollo", data.StateExperience != null ? data.StateExperience.Name : "No disponible");
                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Estado de desarrollo en el que se encuentra la Experiencia Significativa:").Bold();
                        r.RelativeColumn().Text(data.StateExperience != null ? data.StateExperience.Name : "No disponible");
                    });

                    // Field("Área principal que se desarrolla", data.ThematicLocation);
                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Área principal que se desarrolla:").Bold();
                        r.RelativeColumn().Text(data.ThematicLocation ?? "—");
                    });

                    // Field("Fecha desarrollo", data.Developmenttime.ToString("yyyy-MM-dd"));
                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Tiempo de desarrollo:").Bold();
                        r.RelativeColumn().Text(data.Developmenttime != null ? data.Developmenttime.ToString("yyyy-MM-dd") : "—");
                    });

                    // ENFOQUE TEMÁTICO (líneas temáticas)
                    var enfoques = data.ExperienceLineThematics?
                        .Select(x => x.LineThematic?.Name)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList();

                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Enfoque temático de la Experiencia Significativa:").Bold();
                        r.RelativeColumn().Text(
                            enfoques != null && enfoques.Count > 0
                                ? string.Join(", ", enfoques)
                                : "No disponible"
                        );
                    });

                    // GRADOS (Description (pivot) + Grade.Name)
                    var grados = data.ExperienceGrades?
                        .Select(x =>
                            $"{(x.Description ?? "").Trim()}" +
                            (x.Grade != null && !string.IsNullOrWhiteSpace(x.Grade.Name) ? $" ({x.Grade.Name})" : "")
                        )
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList();

                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Grados:").Bold();
                        r.RelativeColumn().Text(
                            grados != null && grados.Count > 0
                                ? string.Join(", ", grados)
                                : "No registrados"
                        );
                    });

                    // GRUPO POBLACIONAL
                    var poblaciones = data.ExperiencePopulations?
                        .Select(x => x.PopulationGrade?.Name)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList();

                    col.Item().Row(r =>
                    {
                        r.RelativeColumn().Text("Grupo poblacional:").Bold();
                        r.RelativeColumn().Text(
                            poblaciones != null && poblaciones.Count > 0
                                ? string.Join(", ", poblaciones)
                                : "No registrado"
                        );
                    });

                    // 3. DESARROLLO
                    var dev = data.Developments?.FirstOrDefault();
                    col.Item().Text("3. Desarrollo de la experiencia")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    if (dev != null)
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Técnicas en articulación con el SENA vinculadas:").Bold();
                            r.RelativeColumn().Text(string.IsNullOrWhiteSpace(dev.CrossCuttingProject) ? "No registrado" : dev.CrossCuttingProject);
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("El modelo educativo en el que se enmarca  el desarrollo:").Bold();
                            r.RelativeColumn().Text(string.IsNullOrWhiteSpace(dev.Population) ? "No registrado" : dev.Population);
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text(" Recibió apoyo para la formulación, fundamentación y/o desarrollo:").Bold();
                            r.RelativeColumn().Text(string.IsNullOrWhiteSpace(dev.PedagogicalStrategies) ? "No registrado" : dev.PedagogicalStrategies);
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text(" Vinculada en el Proyecto Educativo Institucional:").Bold();
                            r.RelativeColumn().Text(string.IsNullOrWhiteSpace(dev.Coverage) ? "No registrado" : dev.Coverage);
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Reconocimiento de la Experiencia Significativo:").Bold();
                            r.RelativeColumn().Text(data.Recognition ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("La Experiencia Significativa cuenta con:").Bold();
                            r.RelativeColumn().Text(data.Socialization ?? "—");
                        });
                    }


                    // 4. Identificación Institucional
                    var inst = data.Institution;
                    col.Item().Text("4. Identificación Institucional")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    if (inst != null)
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Nombre:").Bold();
                            r.RelativeColumn().Text(inst.Name ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Dirección:").Bold();
                            r.RelativeColumn().Text(inst.Address ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Teléfono:").Bold();
                            r.RelativeColumn().Text(inst.Phone != null ? inst.Phone.ToString() : "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Email:").Bold();
                            r.RelativeColumn().Text(inst.EmailInstitucional ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Código DANE:").Bold();
                            r.RelativeColumn().Text(inst.CodeDane ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Rector(a):").Bold();
                            r.RelativeColumn().Text(inst.NameRector ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Características del EE:").Bold();
                            r.RelativeColumn().Text(inst.TerritorialEntity ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Entidad Territorial Certificada (ETC):").Bold();
                            r.RelativeColumn().Text(inst.TestsKnow ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Departamento:").Bold();
                            r.RelativeColumn().Text(inst.Departaments?.FirstOrDefault()?.Name ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Municipio:").Bold();
                            r.RelativeColumn().Text(inst.Municipalitis?.FirstOrDefault()?.Name ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Comuna:").Bold();
                            r.RelativeColumn().Text(inst.Communes?.FirstOrDefault()?.Name ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Zona:").Bold();
                            r.RelativeColumn().Text(inst.EEZones?.FirstOrDefault()?.Name ?? "—");
                        });
                    }

                    // 5. Datos líder
                    var leader = data.Leaders?.FirstOrDefault();
                    col.Item().Text("5. Datos Líder de la Experiencia Significativa")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    if (leader != null)
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Líder de la Experiencia Significativa:").Bold();
                            r.RelativeColumn().Text(leader.NameLeaders ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Número de identificación del Docente líder:").Bold();
                            r.RelativeColumn().Text(leader.IdentityDocument ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Correo electrónico en minúscula:").Bold();
                            r.RelativeColumn().Text(leader.Email ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Número de Contacto:").Bold();
                            r.RelativeColumn().Text(leader.Phone != null ? leader.Phone.ToString() : "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Tipo de vinculación:").Bold();
                            r.RelativeColumn().Text(leader.Position ?? "—");
                        });
                    }

                    // 6. Identificación de la experiencia (Objetivos)
                    var obj = data.Objectives?.FirstOrDefault();
                    col.Item().Text("6.Fundamentación Teórica y Metodológica.")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    if (obj != null)
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Descripción del problema:").Bold();
                            r.RelativeColumn().Text(obj.DescriptionProblem ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Objetivo propuesto:").Bold();
                            r.RelativeColumn().Text(obj.ObjectiveExperience ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Logros obtenidos de acuerdo con el (o los) objetivo (s) planteado (s) :").Bold();
                            r.RelativeColumn().Text(obj.EnfoqueExperience ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Productos que ha generado la Experiencia Significativa:").Bold();
                            r.RelativeColumn().Text(obj.Methodologias ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Existe una articulación de los referentes pedagógicos , conceptuales y metodológicos que guían la Experiencia Significativa con los componentes del PEI y su proyección en el PMI?:").Bold();
                            r.RelativeColumn().Text(obj.Pmi ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Existe coherencia de la Experiencia Significativa con el contexto donde se desarrolla y se evidencia acciones que ofrecen respuesta a las necesidades y al desarrollo integral de los NNAJ?:").Bold();
                            r.RelativeColumn().Text(obj.Nnaj ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Cuenta con resultados a nivel de logros obtenidos  de acuerdo con los objetivos propuestos, al impacto y alternativas de solución a las problemáticas identificadas?:").Bold();
                            r.RelativeColumn().Text(obj.InnovationExperience ?? "—");
                        });
                    }

                    // Testimonios / Soportes
                    var support = obj?.SupportInformations?.FirstOrDefault();
                    if (support != null)
                    {
                        // I left section title empty in your original, so we keep simple rows
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Durante el desarrollo de la Experiencia Significativa se evidencio reorganización y actualización permanente desde el análisis de la implementación, nuevos conocimientos, comprensiones, enfoques y métodos que contribuyen al mejoramiento de la práctica pedagógica?:").Bold();
                            r.RelativeColumn().Text(support.MonitoringEvaluation ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Existe un nivel alto de empoderamiento, participación y apropiación por parte de toda la comunidad educativa?:").Bold();
                            r.RelativeColumn().Text(support.MetaphoricalPhrase ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Cuenta con acciones, recursos tecnológicos o no tecnológicos, materiales, métodos, contenidos entre otros novedosos para su desarrollo?:").Bold();
                            r.RelativeColumn().Text(support.Testimony ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿La Experiencia Significativa cuenta con estrategias y procesos que garantizan la permanencia y mejora continua?:").Bold();
                            r.RelativeColumn().Text(support.FollowEvaluation ?? "—");
                        });
                    }

                    // Monitoreos
                    var moni = obj?.Monitorings?.FirstOrDefault();
                    if (moni != null)
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Existen metodologías o mecanismos que sirven de referencia para replicar la Experiencia Significativa en otros escenarios?:").Bold();
                            r.RelativeColumn().Text(moni.MonitoringEvaluation ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("¿Cuenta con mecanismos para el seguimiento y evaluación de la implementación de la Experiencia Significativa?:").Bold();
                            r.RelativeColumn().Text(moni.Sustainability ?? "—");
                        });
                    }

                    // Documentos
                    col.Item().Text("7. Documentos solicitados")
                        .FontSize(16).Bold().FontColor(primaryColor);

                    foreach (var d in data.Documents ?? Enumerable.Empty<Entity.Models.ModuleOperation.Document>())
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Documento:").Bold();
                            r.RelativeColumn().Text(d.Name ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Enlaces:").Bold();
                            r.RelativeColumn().Text(d.UrlLink ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Proyecto Experiencia Significativa:").Bold();
                            r.RelativeColumn().Text(d.UrlPdfExperience ?? "—");
                        });

                        col.Item().Row(r =>
                        {
                            r.RelativeColumn().Text("Membrete de la IE y firma del Rector(a):").Bold();
                            r.RelativeColumn().Text(d.UrlPdf ?? "—");
                        });
                    }
                });

                page.Footer().AlignCenter()
                    .Text("Sistema de Experiencias Significativas © 2025")
                    .FontSize(10)
                    .FontColor(Colors.Grey.Darken1);
            });
        });

        return pdf.GeneratePdf();
    }

    // Opacidad de imagen simple 
        public static byte[] ApplyImageOpacitySimple(byte[] imageBytes, float opacity)
        {
            using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageBytes);
            image.Mutate(ctx => ctx.Opacity(opacity));
            using var ms = new MemoryStream();
            image.Save(ms, new PngEncoder());
            return ms.ToArray();
        }


    //  Cargar logo desde URL 
    public static async Task<byte[]?> LoadImageFromUrlAsync(string imageUrl)
    {
        using var http = new HttpClient();
        return await http.GetByteArrayAsync(imageUrl);

    }
}







