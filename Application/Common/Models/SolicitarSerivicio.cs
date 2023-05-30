using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class SolicitarSerivicio
    {
        public string authBasic { get; set; } = null!;
        public string tipoAuth { get; set; } = "Authorization-Mego";
        public string contentType { get; set; } = "application/json";
        public object objSolicitud { get; set; } = new object();
        public Dictionary<string, object> dcyHeadersAdicionales { get; set; } = new Dictionary<string, object>();
        public string urlServicio { get; set; } = string.Empty;
        public string idTransaccion { get; set; } = string.Empty;
        public string tipoMetodo { get; set; } = "GET";
    }
}
