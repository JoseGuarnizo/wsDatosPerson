using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Appsetings
    {
        public string auth_wsDatosSocio { get; set; } = string.Empty;
        public string typeAuthAcceso { get; set; } = string.Empty;

        public string url { get; set; } = string.Empty;
        public string user { get; set; } = string.Empty;
        public string pass { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
    }
}
