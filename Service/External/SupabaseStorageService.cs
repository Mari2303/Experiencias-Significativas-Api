using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

public class SupabaseStorageService
{
    public async Task<string> UploadEvaluationPdfToSupabase(byte[] pdfBytes, int evaluationId)
    {
        // ✅ Nombre de archivo estable (para sobrescribir cuando se actualiza)
        string fileName = $"Reporte-{evaluationId}.pdf";

        // ✅ Configuración de Supabase
        string supabaseUrl = "https://clzjdaburaytuimossnf.supabase.co";
        string supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImNsempkYWJ1cmF5dHVpbW9zc25mIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc2MTMyMjQ2MywiZXhwIjoyMDc2ODk4NDYzfQ.V2LsB80vdb3ymThtQBoyLrw6p6Nsx7w7n3DX39V2bPY";
        string bucket = "Experiencia-SignificativaPdf";

            using var client = new HttpClient();
            client.BaseAddress = new Uri(supabaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", supabaseKey);
            client.DefaultRequestHeaders.Add("apikey", supabaseKey);

        // ✅ Endpoint con upsert para reemplazar si ya existe
        string uploadUrl = $"/storage/v1/object/{bucket}/{fileName}?upsert=true";

            var content = new ByteArrayContent(pdfBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            var response = await client.PostAsync(uploadUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error subiendo PDF a Supabase: {error}");
            }

        // ✅ URL pública de acceso al archivo
        return $"{supabaseUrl}/storage/v1/object/public/{bucket}/{fileName}";
    }
}



