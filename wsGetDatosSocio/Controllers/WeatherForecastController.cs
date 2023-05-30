using Application.DataSocio;
using Microsoft.AspNetCore.Mvc;

namespace wsGetDatosSocio.Controllers
{
    [Route("api/wsDatosSocio")]
    [ApiController]

    public class wsDatosSocio : ApiControllerBase
    {
        [HttpGet("GetDatosSocio")]
        public async Task<ResGetDatos> GetDatosSocio(ReqGetDatos reqGetDatos)
        {
            return await Mediator.Send(reqGetDatos);
        }
    }
}