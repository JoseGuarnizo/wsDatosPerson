using Application.Common.Models;
using Microsoft.OpenApi.Models;

namespace wsGetDatosSocio
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration ApiSettingsuration)
        {
            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api rest",
                    Version = "v1",
                    Description = "Servicio Consulta de Datos"
                });
            });

            services.Configure<Appsetings>(ApiSettingsuration.GetSection("ApiSettings:TypeAutorizations"));
            services.Configure<Appsetings>(ApiSettingsuration.GetSection("ApiSettings:Authorization"));
            services.Configure<Appsetings>(ApiSettingsuration.GetSection("ApiSettings:DataBase"));

            return services;
        }
    }
}