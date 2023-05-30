using Application.Common.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace wsGetDatosSocio.Middleware;

public static class AuthorizationExtensions
{
    public static IApplicationBuilder UseAuthotizationDatosSocio(this IApplicationBuilder app)
    {
        return app.UseMiddleware<Autorizacion>();
    }
}

public class Autorizacion
{
    private readonly RequestDelegate _next;
    private readonly Appsetings _settings;

    public Autorizacion(RequestDelegate next, IOptionsMonitor<Appsetings> settings)
    {
        _next = next;
        _settings = settings.CurrentValue;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        string authHeader = httpContext.Request.Headers["authorization"];
        await _next(httpContext);


        //if (authHeader != null && authHeader.StartsWith("Auth-wsDatosSocio123"))
        //{
        //    string encodeAuthorization = authHeader.Substring("Auth-wsDatosSocio123".Length).Trim();

        //    if (authHeader.Equals(_settings.auth_wsDatosSocio))
        //    {
        //        await _next(httpContext);
        //    }
        //    else
        //    {
        //        await ResException(httpContext, "No autorizado", Convert.ToInt32(System.Net.HttpStatusCode.Unauthorized), System.Net.HttpStatusCode.Unauthorized.ToString());
        //    }
        //}
        //else
        //{
        //    await ResException(httpContext, "No autorizado", Convert.ToInt32(System.Net.HttpStatusCode.Unauthorized), System.Net.HttpStatusCode.Unauthorized.ToString());
        //}
    }

    internal async Task ResException(HttpContext httpContext, String infoAdicional, int statusCode, string str_res_id_servidor)
    {
        ResEsception respuesta = new();

        httpContext.Response.ContentType = "application/json; charset=UTF-8";
        httpContext.Response.StatusCode = statusCode;

        respuesta.str_res_id_servidor = str_res_id_servidor;
        respuesta.str_res_codigo = "001";
        respuesta.dt_res_fecha_msj_crea = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", null);
        respuesta.str_res_estado_transaccion = "ERR";
        respuesta.str_res_info_adicional = infoAdicional;

        string str_respuesta = JsonSerializer.Serialize(respuesta);

        await httpContext.Response.WriteAsync(str_respuesta);
    }
}
    

