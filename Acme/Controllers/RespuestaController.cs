using Acme.Repository;
using Acme.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        public RespuestaController(IRepuestaRepositorio respuestaRepositorio)
        {
            RespuestaRepositorio = respuestaRepositorio;
        }

        public IRepuestaRepositorio RespuestaRepositorio { get; }

        [HttpPost("[action]")]
        public async Task<ActionResult<Response>> CrearRespuesta(EncuestaRepuestaRequest request)
        {
            var response = request.IsValid();
            if (!response.Success)
                return Ok(response);

            return Ok(await RespuestaRepositorio.AgregarRespuesta(request));
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<Response<List<RespuestaEncuestaResponse>>>> ObtenerResultado()
        {
            return Ok(await RespuestaRepositorio.ObtenerResultado());
        }
    }
}
