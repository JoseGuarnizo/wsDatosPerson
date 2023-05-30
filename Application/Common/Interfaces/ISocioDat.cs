﻿using Application.Common.Models;
using Application.DataSocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISocioDat
    {
        RespuestaTransaccion getDatosSocio(ReqGetDatos reqGetDatos);
    }
}
