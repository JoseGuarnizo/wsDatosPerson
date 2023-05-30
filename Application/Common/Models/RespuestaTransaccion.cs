using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class RespuestaTransaccion
    {
        public object obj_cuerpo { get; set; } = new object();

        public string str_codigo { get; set; } = String.Empty;
        public string str_mensaje { get; set; } = String.Empty;
    }
}
