using Application.Common.Interfaces;
using Application.Common.Models;
using Application.DataSocio;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataSql
{
    public class SocioDat : ISocioDat
    {
        private readonly Appsetings _appsetings;

        public SocioDat(IOptionsMonitor<Appsetings> settings)
        {
            _appsetings = settings.CurrentValue;
        }

        public RespuestaTransaccion getDatosSocio(ReqGetDatos reqGetDatos)
        {
            
            var respuesta = new RespuestaTransaccion();

            try
            {
                SqlConnectionStringBuilder sql_builder = new SqlConnectionStringBuilder();

                sql_builder.DataSource = _appsetings.url;
                sql_builder.UserID = _appsetings.user; //USUARIO DE LA BASE
                sql_builder.Password = _appsetings.pass; //PASSWORD DE LA BASE
                sql_builder.InitialCatalog = _appsetings.nombre; //NOMBRE DE LA BASE

                using (SqlConnection sql_conexion = new SqlConnection(sql_builder.ConnectionString))
                {
                    sql_conexion.Open();
                    string str_sentencia_gen = "select nombres, apellidos from DatosSocio where cedula = @str_cedula";

                    using (SqlCommand comando = new SqlCommand(str_sentencia_gen, sql_conexion))
                    {
                        comando.CommandText = str_sentencia_gen;

                        comando.Parameters.Add("@str_cedula", SqlDbType.VarChar).Value = reqGetDatos.str_cedula;

                        using (SqlDataReader lectura = comando.ExecuteReader())
                        {
                            while (lectura.Read())
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            throw new NotImplementedException();
        }
    }
}
