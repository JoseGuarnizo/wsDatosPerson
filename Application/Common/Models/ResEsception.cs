using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ResEsception
    {
        public DateTime dt_res_fecha_msj_crea { get; set; } = DateTime.Now;
        public string str_res_estado_transaccion { get; set; } = string.Empty;
        public string str_res_codigo { get; set; } = string.Empty;
        public string str_res_id_servidor { get; set; } = string.Empty;
        public string str_res_info_adicional { get; set; } = string.Empty;
    }
}
