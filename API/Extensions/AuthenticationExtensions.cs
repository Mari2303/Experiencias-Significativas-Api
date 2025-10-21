using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using Microsoft.OpenApi.Models;

namespace API
{
    /// <summary>
    /// Extensiones de configuraci�n para la autenticaci�n JWT y Swagger.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Configura Swagger para usar autenticaci�n JWT mediante el esquema Bearer.
        /// </summary>
        /// <param name="services">El contenedor de servicios de la aplicaci�n.</param>
        public static void CustomSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                // Define la configuraci�n de seguridad para JWT Bearer
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Ingrese solo su token JWT"
                });

                // Agrega la pol�tica de seguridad a Swagger
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        /// <summary>
        /// Configura la autenticaci�n JWT para la aplicaci�n.
        /// </summary>
        /// <param name="services">El contenedor de servicios de la aplicaci�n.</param>
        /// <param name="configuration">La configuraci�n de la aplicaci�n para leer la clave secreta.</param>
        public static void AddCustomAuthentication(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:Key"]));
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false, // No valida el emisor
                        ValidateAudience = false, // No valida la audiencia
                        ValidateLifetime = true, // Valida la expiraci�n
                        ValidateIssuerSigningKey = true, // Valida la firma
                        IssuerSigningKey = key
                    };

                    // Manejo de eventos al fallar la autenticaci�n
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var response = context.Response;
                            response.ContentType = "application/json";
                            response.StatusCode = StatusCodes.Status401Unauthorized;

                            string message;

                            try
                            {
                                throw context.Exception;
                            }
                            catch (SecurityTokenExpiredException)
                            {
                                message = "Token expirado, genera uno nuevo";
                            }
                            catch (SecurityTokenInvalidSignatureException)
                            {
                                message = "Token inv�lido - fall� la verificaci�n de la firma";
                            }
                            catch (Exception)
                            {
                                message = "Autenticaci�n fallida";
                            }

                            var json = JsonSerializer.Serialize(new
                            {
                                error = message
                            });

                            return response.WriteAsync(json);
                        }
                    };
                });
        }
    }
}

