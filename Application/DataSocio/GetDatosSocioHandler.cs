using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataSocio
{
    public class GetDatosSocioHandler : IRequestHandler<ReqGetDatos, ResGetDatos>
    {
		private readonly Appsetings _appsetings;

		public GetDatosSocioHandler(IOptionsMonitor<Appsetings> settings)
        {
			_appsetings = settings.CurrentValue;
		}

		public async Task<ResGetDatos> Handle(ReqGetDatos reqGetDatos, CancellationToken cancellationToken)
		{
			var respuesta = new ResGetDatos();
			var resTran = new RespuestaTransaccion();

			try
			{
                SqlConnectionStringBuilder sql_builder = new SqlConnectionStringBuilder();

                sql_builder.DataSource = _appsetings.url;
                sql_builder.InitialCatalog = _appsetings.nombre;
                sql_builder.IntegratedSecurity = true;

                using (SqlConnection sql_conexion = new SqlConnection(sql_builder.ConnectionString))
                {
                    sql_conexion.Open();
                    string str_sentencia_gen = "select nombres, apellidos from Socios where cedula = @str_cedula";

                    using (SqlCommand comando = new SqlCommand(str_sentencia_gen, sql_conexion))
                    {
                        comando.CommandText = str_sentencia_gen;

                        comando.Parameters.Add("@str_cedula", SqlDbType.VarChar).Value = reqGetDatos.str_cedula;

                        using (SqlDataReader lectura = comando.ExecuteReader())
                        {
                            while (lectura.Read())
                            {
                                respuesta.str_nombres = lectura.GetString(0);
                                respuesta.str_apellidos = lectura.GetString(1);
                            }
                        }
                    }

                    sql_conexion.Close();
                }
                
            }
			catch (Exception ex)
			{
                throw new Exception(ex.Message);
			}
			return respuesta;
		}
	}
}
