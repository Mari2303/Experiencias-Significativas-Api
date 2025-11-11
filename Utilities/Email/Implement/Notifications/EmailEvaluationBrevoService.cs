using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Utilities.Email.Interfaces;

public class EmailEvaluationBrevoService : IEmailEvaluationBrevoService
{
    private readonly HttpClient _client;
    private readonly string _fromEmail;
    private readonly string _fromName;

    public EmailEvaluationBrevoService(IConfiguration configuration)
    {
        var brevoSection = configuration.GetSection("Brevo");

        string apiKey = brevoSection["ApiKey"];
        _fromEmail = brevoSection["FromEmail"];
        _fromName = brevoSection["FromName"];

        _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.brevo.com/v3/")
        };
        _client.DefaultRequestHeaders.Add("api-key", apiKey);
    }

    public async Task SendEvaluationResultEmailAsync(string toEmail, string userName, string evaluationResult)
    {
        //  Colores dinámicos según el resultado
        string color = evaluationResult switch
        {
            "Naciente" => "#ff9f43",      // naranja
            "Creciente" => "#3498db",     // azul
            "Inspiradora" => "#27ae60",   // verde
            _ => "#7f8c8d"                // gris neutro
        };

        string message = evaluationResult switch
        {
            "Naciente" => "Tu evaluación se encuentra en la etapa <strong>Naciente</strong>. ¡Sigue esforzándote, vas por buen camino!",
            "Creciente" => "Tu resultado es <strong>Creciente</strong>. ¡Estás avanzando de forma consistente, felicidades!",
            "Inspiradora" => "Tu evaluación fue <strong>Inspiradora</strong>. ¡Increíble trabajo, tu desempeño es ejemplar!",
            _ => $"Tu resultado de evaluación es: <strong>{evaluationResult}</strong>."
        };

        // 💌 Plantilla HTML elegante
        string html = $@"
        <div style='background-color:#f4f6f8; padding:40px 0; font-family:Arial, sans-serif;'>
            <div style='max-width:600px; margin:auto; background:#ffffff; border-radius:10px; overflow:hidden; box-shadow:0 4px 10px rgba(0,0,0,0.1);'>
                
                <!-- Encabezado -->
                <div style='background:{color}; color:white; padding:20px; text-align:center;'>
                    <h1 style='margin:0; font-size:24px;'>Sistema de Evaluación</h1>
                    <p style='margin:5px 0 0; font-size:14px;'>Experiencias Significativas</p>
                </div>

                <!-- Cuerpo -->
                <div style='padding:30px; text-align:center;'>
                    <h2 style='color:#333;'>Hola {userName},</h2>
                    <p style='font-size:16px; color:#555; line-height:1.6;'>
                        Nos complace informarte el resultado de tu evaluación:
                    </p>

                    <div style='margin:30px auto; width:70%; background:{color}; color:white; padding:15px; border-radius:8px; font-size:20px; font-weight:bold;'>
                        {evaluationResult}
                    </div>

                    <p style='font-size:15px; color:#555; line-height:1.6;'>
                        {message}
                    </p>

                    <hr style='border:none; height:1px; background-color:#ddd; margin:30px 0;'>

                    <p style='font-size:13px; color:#777;'>
                        Este mensaje ha sido generado automáticamente. No respondas a este correo.<br>
                        Gracias por participar en nuestro proceso de evaluación.
                    </p>
                </div>

                <!-- Pie -->
                <div style='background:#f0f0f0; text-align:center; padding:15px; font-size:12px; color:#888;'>
                    © 2025 Sistema de Evaluación de Experiencias Significativas
                </div>
            </div>
        </div>";

        var body = new
        {
            sender = new { email = _fromEmail, name = _fromName },
            to = new[] { new { email = toEmail, name = userName } },
            subject = $"Resultado de tu Evaluación — {evaluationResult}",
            htmlContent = html
        };

        var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("smtp/email", content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error enviando correo Brevo: {error}");
        }
    }
}
 


