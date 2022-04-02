using Acme.Repository;
using Acme.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EncuestaController : ControllerBase
    {

        public EncuestaController(IEncuestaRepositorio encuestaRepositorio)
        {
            EncuestaRepositorio = encuestaRepositorio;
        }

        public IEncuestaRepositorio EncuestaRepositorio { get; }

        [HttpPost("[action]")]
        public async Task<ActionResult<Response>> CrearEncuesta(EncuestaAddRequest request)
        {
            var response = request.IsValid();
            if (!response.Success)
                return Ok(response);

            return Ok(await EncuestaRepositorio.CrearEncuesta(request));
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Response>> ModificarEncuesta(EncuestaModficarRequest request)
        {
            var response = request.IsValid();
            if (!response.Success)
                return Ok(response);

            return Ok(await EncuestaRepositorio.ModificarEncuensta(request));
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Response>> EliminarEncuesta(EliminarEncuestaRequest request)
        {
            var response = request.IsValid();
            if (!response.Success)
                return Ok(response);

            return Ok(await EncuestaRepositorio.EliminarEncuesta(request));
        }
    }
}
